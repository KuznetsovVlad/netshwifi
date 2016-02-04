using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SettingHomeWifi
{
    public struct Settings
    {
        public String Ssid { get; set; }
        public String Key { get; set; }
        public String Data { get; set; }
    }

    public class Network
    {
        private Process proc = new Process();
        private ProcessStartInfo procInfo = new ProcessStartInfo();

        public Network()
        {
            procInfo.FileName = "netsh.exe";
            procInfo.CreateNoWindow = true;
            procInfo.UseShellExecute = false;
            procInfo.RedirectStandardInput = true;
            procInfo.RedirectStandardOutput = true;
            procInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            proc.StartInfo = procInfo;
        }
        // Запустить сеть
        public bool StartHostednetwork()
        {
            String commandStart = String.Format("wlan start hostednetwork");
            proc.StartInfo.Arguments = commandStart;
            proc.Start();
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            String set = String.Format("wlan set hostednetwork mode=allow"); // На всякий случай
            proc.StartInfo.Arguments = set;                                   
            proc.Start();
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            if (StateNetwork())
                return true;            // сеть запущена
            else 
                return false;           // не удалось запустить сеть
        }
        // Остановиь сеть
        public bool StopHostednetwork()
        {
            String commandStop = String.Format("wlan stop hostednetwork");
            proc.StartInfo.Arguments = commandStop;
            proc.Start();
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            String set = String.Format("wlan set hostednetwork mode=allow"); // На всякий случай
            proc.StartInfo.Arguments = set;                                   
            proc.Start();
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            if (!StateNetwork())
                return true;           // сеть остановлена
            else
                return false;          // сеть не остановлена
        }
        // Установить параметры сети, методу могут быть переданы оба параметра(ssid, key), либо только key 
        public void SetHostednetwork(String ssid, String key) 
        {
            if (key.Length < 8)
                throw new System.ArgumentException("Марзь, ты охуел? Пароль должен содержать не мене восьми символов");                          //  Пароль должен содержать не менее 8 символов 

            if (ssid == null)                          // Если производим замену пароля
                ssid = GetSsidFromCmd();          

            String reset = String.Format("wlan set hostednetwork mode=disallow");
            String set = String.Format("wlan set hostednetwork mode=allow");
            String setting = String.Format("wlan set hostednetwork ssid=\"{0}\" key={1}", ssid, key);

            proc.StartInfo.Arguments = reset;          // Сброс параметров
            proc.Start();
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            proc.StartInfo.Arguments = setting;          // Установка
            proc.Start();
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();
             
            proc.StartInfo.Arguments = set;            // Позволить
            proc.Start();
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            WriteToXml(ssid, key);                     // Записать параметры в xml файл

            return;
        }
        // Записать параметры  в xml
        private void WriteToXml(String ssid, String key)
        {
            if (!File.Exists("Settings.xml"))          // Проверка отсутствия файла
                CreateXml();                           // Создать файл

            XmlDocument document = new XmlDocument();  
            document.Load("Settings.xml");  

            XmlElement settingInfo = document.DocumentElement;

            //Перзаписывание текущих данных в раздел предыдущие
            String prevSsid = settingInfo.SelectSingleNode("current").SelectSingleNode("ssid").InnerText;
            String prevKey = settingInfo.SelectSingleNode("current").SelectSingleNode("key").InnerText;
            String data = settingInfo.SelectSingleNode("current").Attributes.GetNamedItem("data").InnerText;
            settingInfo.SelectSingleNode("previous").SelectSingleNode("ssid").InnerText = prevSsid;
            settingInfo.SelectSingleNode("previous").SelectSingleNode("key").InnerText = prevKey;
            settingInfo.SelectSingleNode("previous").Attributes.GetNamedItem("data").InnerText = data;

            //Обновление данных
            if (ssid != null)
                settingInfo.SelectSingleNode("current").SelectSingleNode("ssid").InnerText = ssid;
            if (key != null)
                settingInfo.SelectSingleNode("current").SelectSingleNode("key").InnerText = key;
            settingInfo.SelectSingleNode("current").Attributes.GetNamedItem("data").Value = DateTime.Now.ToString();

            document.Save("Settings.xml");
            return;
        }
        // Создание фалйла .xml
        private void CreateXml()
        { 
            // Создание шаблона xml файла
            XElement doc = new XElement(    
                "securityinfo",                                              
                    new XElement("current", new XAttribute("data", ""),
                        new XElement("ssid"),
                        new XElement("key")),
                    new XElement("previous", new XAttribute("data", ""),
                        new XElement("ssid"),
                        new XElement("key")));
            doc.Save("Settings.xml"); 
        }
        // Извлечение параметро сети из xml файла
        private Settings GetSettings()
        {
            XmlDocument document = new XmlDocument();
            document.Load("xui.xml");
            XmlElement settingInfo = document.DocumentElement;

            Settings settings = new Settings();
            settings.Ssid = settingInfo.SelectSingleNode("current").SelectSingleNode("ssid").InnerText;
            settings.Key = settingInfo.SelectSingleNode("current").SelectSingleNode("key").InnerText;
            settings.Data = settingInfo.SelectSingleNode("current").Attributes.GetNamedItem("data").InnerText;

            return settings;
        }
        // Получить название текущей сети
        public String GetSsidFromCmd()
        {
            char[] buffer = new char[170];
            String command = String.Format("wlan show hostednetwork");
            proc.StartInfo.Arguments = command;
            proc.Start();
            proc.StandardOutput.ReadBlock(buffer,0,buffer.Length);
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            Regex reg = new Regex("\"(.*)\"");         // Регулярка для поиска ssid
            String input = new String(buffer);
            Match match = reg.Match(input);

            reg = new Regex("[^\"](.*)[^\"]");         // Регулярка для вытаскивания ssid без кавычек
            match = reg.Match(match.Value.ToString());

            if (match.Success)
                return match.Value.ToString();
            else
                throw new NotFoundSubFromCmdExceprion("Товарисчи, нихуя же не найдено, это я про ssid");
        }
        // Получить пароль текущей сети
        public String GetKeyFromCmd()
        {
            char[] buffer = new char[330];
            String command = String.Format("wlan show hostednetwork setting=security");
            proc.StartInfo.Arguments = command;
            proc.Start();
            proc.StandardOutput.ReadBlock(buffer, 0, buffer.Length);
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            Regex reg = new Regex(@"пользователя(\W*):\W(\w*)\W");   // Регулярка для поиска key
            String input = new String(buffer);
            Match match = reg.Match(input);

            reg = new Regex(@"[^пользователя : ](.*)[^\W]");        // Втаскивание key без кавычек
            match = reg.Match(match.Value.ToString());

            if (match.Success)                                      // Здесь вроде как исключение
                return match.Value.ToString();
            else
                throw new NotFoundSubFromCmdExceprion("Товарисчи нихуя не найдено же, это я про пароль");
        }
        // Проверка состония сети
        public bool StateNetwork()
        {
            char[] buffer = new char[370];
            String command = String.Format("wlan show hostednetwork");
            proc.StartInfo.Arguments = command;
            proc.Start();
            proc.StandardOutput.ReadBlock(buffer, 0, buffer.Length);
            proc.StandardOutput.Close();
            proc.Refresh();
            proc.Close();

            Regex reg = new Regex(@"Состояние(\W*): Запущено");     // Регулярка для определения состояния сети
            String input = new String(buffer);                      

            if (reg.IsMatch(input))
                return true;                                        // Сеть запущена
            else 
                return false;                                       // Сеть не запущена
        }
    }

    [Serializable]
    public class NotFoundSubFromCmdExceprion : System.ApplicationException      
    {
        public NotFoundSubFromCmdExceprion() { }
        public NotFoundSubFromCmdExceprion(string message) :base(message) { }
        public NotFoundSubFromCmdExceprion(string message,Exception ex) : base(message) { }
        protected NotFoundSubFromCmdExceprion(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
    }
}
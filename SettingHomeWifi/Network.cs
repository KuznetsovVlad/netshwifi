using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace SettingHomeWifi
{
    public class Network
    {
        private Process _proc = new Process();
        private ProcessStartInfo _procInfo = new ProcessStartInfo();
        private bool _on = false;

        public Network()
        {
            _procInfo.Verb = "runas";
            _procInfo.FileName = "netsh.exe";
            _procInfo.CreateNoWindow = true;
            _procInfo.UseShellExecute = false;
            _procInfo.RedirectStandardInput = true;
            _procInfo.RedirectStandardOutput = true;
            _proc.StartInfo = _procInfo;
        }

        public int StartHostednetwork()
        {
            if (_on)
                return -1;                         // -1 сеть уже запущена
            String _commandStart = String.Format("wlan start hostednetwork");
            _proc.StartInfo.Arguments = _commandStart;
            _proc.Start();
            _proc.Close();
            _on = true;
            return 0;
        }

        public int StopHostednetwork()
        {
            if (!_on)
                return -1;                          // -1 сеть не запущена
            String _commandStop = String.Format("wlan stop hostednetwork");
            _proc.StartInfo.Arguments = _commandStop;
            _proc.Start();
            _proc.Close();
            _on = false;
            return 0;
        }

        public int SetHostednetwork(String ssid, String key)
        {
            if (key.Length < 8)
                return -1;                           // -1 пароль должен содержать не менее 8 символов 

            this.WriteToXml(ssid,key,null);

            String _reset = String.Format("wlan set hostednetwork mode = disallow");
            String _set = String.Format("wlan set hostednetwork mode = allow ssid={0} key={1}", ssid, key);

            StreamWriter _writer = new StreamWriter();
            _writer = _proc.StandardInput;

            _proc.StartInfo.Arguments = _reset;
            _proc.Start();
            _writer.WriteLine(_set);
            _proc.Close();

            return 0;
        }

        private int WriteToXml(String _ssid, String _key, String _pathToFile)
        {
            if (!File.Exists(_pathToFile))
                return -1;                            // Файл не найден

            XmlDocument _document = new XmlDocument();
            _document.Load(_pathToFile);
            XmlElement _settingInfo = _document.DocumentElement;

            //Перзаписывание текущих данных в раздел предыдущие
            String _prevSsid = _settingInfo.SelectSingleNode("current").SelectSingleNode("ssid").InnerText;
            String _prevKey = _settingInfo.SelectSingleNode("current").SelectSingleNode("key").InnerText;
            String _data = _settingInfo.SelectSingleNode("current").Attributes.GetNamedItem("data").InnerText;
            _settingInfo.SelectSingleNode("previous").SelectSingleNode("ssid").InnerText = _prevSsid;
            _settingInfo.SelectSingleNode("previous").SelectSingleNode("key").InnerText = _prevKey;
            _settingInfo.SelectSingleNode("previous").Attributes.GetNamedItem("data").InnerText = _data;

            //Обновление данных
            if (_ssid != null)
                _settingInfo.SelectSingleNode("current").SelectSingleNode("ssid").InnerText = _ssid;
            if (_key != null)
                _settingInfo.SelectSingleNode("current").SelectSingleNode("key").InnerText = _key;
            _settingInfo.SelectSingleNode("current").Attributes.GetNamedItem("data").Value = DateTime.Now.ToString();

            _document.Save(_pathToFile);

            return 0;
        }
    }
}

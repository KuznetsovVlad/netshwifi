using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingHomeWifi;

namespace NetshWiFI
{
    public partial class Form2 : Form
    {
        Network net;
        ToolTip tp_key, tp_ssid;                   // Подсказка для текст бокса
        Bitmap flag_check;            // Изображение, когда верный ssid и key
        Bitmap flag_uncheck;          // Изображение, когда неверный ssid и key
       
        public Form2()
        {
            InitializeComponent();
            net = new Network();
            tp_key = new ToolTip();
            tp_ssid = new ToolTip();
            flag_check = new Bitmap(Image.FromFile("check.png"), 28, 20);
            flag_uncheck = new Bitmap(Image.FromFile("uncheck.png"), 20, 20); 
            tp_key.SetToolTip(textBox_Key, "Пароль должен содержать только латинске символы и цифры");
        }
        // Установить новые настройки
        private void button_Apply_Click(object sender, EventArgs e)
        {
            CheckInput();
        }
        // Сменить только пароль, или пароль и название сети
        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (textBox_Ssid.Enabled)
            {
                textBox_Ssid.Enabled = false;
                label_ChangeSet.Text = "Сменить пароль и название сети";
            }
            else
            {
                textBox_Ssid.Enabled = true;
                label_ChangeSet.Text = "Сменить только пароль";
            }
        }
        // Фильтр для ввода пароля(только латиница и цифры, без пробелов)
        private void textBox_Key_KeyPress(object sender, KeyPressEventArgs e)
        {
            pictureBox.Image = null;
            if (textBox_Key.Text.Length >= 8)
                pictureBox.Image = flag_check;

            if (e.KeyChar != 8 && e.KeyChar < 48 || e.KeyChar > 'z')
                e.Handled = true;                                   // Обработать событие
        }
        // Ввыод изображения в соотвествии с правильным либо непрвильным вводом названия сети
        private void textBox_Ssid_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Ssid.Text.Length < 3)
            {
                pictureBox1.Image = null;
                return;
            }
            pictureBox1.Image = flag_check;
        }
        // Принять настройки по нажатие клавиши Enter
        private void textBox_Key_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_Apply_Click(sender, e);
        }
        // Принять новые настройки сети, там текстбоксы немного обратать
        private void CheckInput()
        {
            String ssid = textBox_Ssid.Text;
            String key = textBox_Key.Text;

            if (textBox_Ssid.Text.Length < 3 && textBox_Ssid.Enabled)
            {
                tp_ssid.Show("Не мене трёх символов", textBox_Ssid, 1200);
                pictureBox1.Image = flag_uncheck;
                return;
            }

            if (key.Length < 8)
            {
                tp_key.Show("Не менее восьми символов", textBox_Key, 1200);
                pictureBox.Image = flag_uncheck;
                return;
            }

            if (textBox_Ssid.Enabled)                 // Сменить настройки
                net.SetHostednetwork(ssid, key);
            else
                net.SetHostednetwork(null, key);

            textBox_Ssid.Clear();
            textBox_Key.Clear();

            pictureBox1.Image = null;
            pictureBox.Image = null;
            Thread.Sleep(500);
            String str = String.Format("Параметры сети успешно изменены\n\n" +
                             "Текущие параметры:\n" +
                             "ssid: {0}\n" + "key: {1}", net.GetSsidFromCmd(), net.GetKeyFromCmd());
            MessageBox.Show(str);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 main = this.Owner as Form1;
            main.State();
        }
    }
}

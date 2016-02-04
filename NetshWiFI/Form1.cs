using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml;
using SettingHomeWifi;

namespace NetshWiFI
{   // Начальная форма
    public partial class Form1 : Form
    {
        Network net;
        Icon icon;               // Значок приложения

        public Form1()
        {
            InitializeComponent();
            net = new Network();
            try
            {
                icon = new Icon("wifi.ico");   
            }
            catch (Exception)
            {
                icon = SystemIcons.Application;
            }
        }
        // Открытие формы настрокйи сети
        private void button_Settings_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Owner = this;
            form.ShowDialog();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            State();  
        }
        // Запустить сеть
        private void button_StartNet_Click(object sender, EventArgs e)
        {
            net.StartHostednetwork();
            State();
        }
        // Остановить сеть
        private void button_StopNet_Click(object sender, EventArgs e)
        {
            net.StopHostednetwork();
            State();
        }
        // Обновление значения состояния сети, в форме
        public void State()
        {
            label_NameNet.Text = net.GetSsidFromCmd();   
            if (net.StateNetwork())
                label_StateNet.Text = "Запущено";
            else
                label_StateNet.Text = "Не запущено";
        }
        // Показать либо скрыть пароль
        private void button_ShowKey_Click(object sender, EventArgs e)
        {
            if (label_ShowKey.Text == "********")            // Если пароль скрыт, то показать   
            {
                label_ShowKey.Font = new System.Drawing.Font
                    (label_ShowKey.Font.FontFamily,8);            
                label_ShowKey.Text = net.GetKeyFromCmd();
                button_ShowKey.Text = "Скрыть";
            }
            else                                             // Елси пароль отрыть, то скрыть
            { 
                label_ShowKey.Font = new System.Drawing.Font
                    (label_ShowKey.Font.FontFamily,14);
                label_ShowKey.Text = "********";
                button_ShowKey.Text = "Показать";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                State();
        }
        // Сворчивание приложения в трей
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)     // Свернуть
            {
                Hide();
                notifyIcon1.Icon = icon;
                notifyIcon1.BalloonTipText = "Эй, неко!";
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if(this.WindowState == FormWindowState.Normal)     // Развернуть
            {
                State();
                notifyIcon1.BalloonTipText = "Грибабас";
                notifyIcon1.ShowBalloonTip(1000);
            }
        }
        // Развенуть приложение из трея, двойной щелчок
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        // Развенуть приложение из контекстного меню
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        // Кто ты есть на самом деле
        private void YouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loser loser = new Loser();      // Фора с маюши
            loser.Show();
        }
        // Закрыть приложение
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // При закрытии свернуть приложение в трей
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)      // Если пользователь закрывает нажатием на крестик
            {
                WindowState = FormWindowState.Minimized;
                Hide();                                       
                e.Cancel = true;                               // Отменить событие закрытия
            }
        }
    }
}

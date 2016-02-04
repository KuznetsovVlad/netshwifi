namespace NetshWiFI
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Settings = new System.Windows.Forms.Button();
            this.button_StartNet = new System.Windows.Forms.Button();
            this.button_StopNet = new System.Windows.Forms.Button();
            this.label_Net = new System.Windows.Forms.Label();
            this.label_NameState = new System.Windows.Forms.Label();
            this.label_NameNet = new System.Windows.Forms.Label();
            this.label_StateNet = new System.Windows.Forms.Label();
            this.label_key = new System.Windows.Forms.Label();
            this.label_ShowKey = new System.Windows.Forms.Label();
            this.button_ShowKey = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Settings
            // 
            resources.ApplyResources(this.button_Settings, "button_Settings");
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // button_StartNet
            // 
            resources.ApplyResources(this.button_StartNet, "button_StartNet");
            this.button_StartNet.Name = "button_StartNet";
            this.button_StartNet.UseVisualStyleBackColor = true;
            this.button_StartNet.Click += new System.EventHandler(this.button_StartNet_Click);
            // 
            // button_StopNet
            // 
            resources.ApplyResources(this.button_StopNet, "button_StopNet");
            this.button_StopNet.Name = "button_StopNet";
            this.button_StopNet.UseVisualStyleBackColor = true;
            this.button_StopNet.Click += new System.EventHandler(this.button_StopNet_Click);
            // 
            // label_Net
            // 
            resources.ApplyResources(this.label_Net, "label_Net");
            this.label_Net.Name = "label_Net";
            // 
            // label_NameState
            // 
            resources.ApplyResources(this.label_NameState, "label_NameState");
            this.label_NameState.Name = "label_NameState";
            // 
            // label_NameNet
            // 
            resources.ApplyResources(this.label_NameNet, "label_NameNet");
            this.label_NameNet.Name = "label_NameNet";
            // 
            // label_StateNet
            // 
            resources.ApplyResources(this.label_StateNet, "label_StateNet");
            this.label_StateNet.Name = "label_StateNet";
            // 
            // label_key
            // 
            resources.ApplyResources(this.label_key, "label_key");
            this.label_key.Name = "label_key";
            // 
            // label_ShowKey
            // 
            resources.ApplyResources(this.label_ShowKey, "label_ShowKey");
            this.label_ShowKey.Name = "label_ShowKey";
            // 
            // button_ShowKey
            // 
            resources.ApplyResources(this.button_ShowKey, "button_ShowKey");
            this.button_ShowKey.Name = "button_ShowKey";
            this.button_ShowKey.UseVisualStyleBackColor = true;
            this.button_ShowKey.Click += new System.EventHandler(this.button_ShowKey_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowToolStripMenuItem,
            this.YouToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            resources.ApplyResources(this.ShowToolStripMenuItem, "ShowToolStripMenuItem");
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // YouToolStripMenuItem
            // 
            this.YouToolStripMenuItem.Name = "YouToolStripMenuItem";
            resources.ApplyResources(this.YouToolStripMenuItem, "YouToolStripMenuItem");
            this.YouToolStripMenuItem.Click += new System.EventHandler(this.YouToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label_key);
            this.groupBox1.Controls.Add(this.label_Net);
            this.groupBox1.Controls.Add(this.label_NameState);
            this.groupBox1.Controls.Add(this.label_NameNet);
            this.groupBox1.Controls.Add(this.button_ShowKey);
            this.groupBox1.Controls.Add(this.label_StateNet);
            this.groupBox1.Controls.Add(this.label_ShowKey);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_StopNet);
            this.Controls.Add(this.button_StartNet);
            this.Controls.Add(this.button_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Settings;
        private System.Windows.Forms.Button button_StartNet;
        private System.Windows.Forms.Button button_StopNet;
        private System.Windows.Forms.Label label_Net;
        private System.Windows.Forms.Label label_NameState;
        private System.Windows.Forms.Label label_NameNet;
        private System.Windows.Forms.Label label_StateNet;
        private System.Windows.Forms.Label label_key;
        private System.Windows.Forms.Label label_ShowKey;
        private System.Windows.Forms.Button button_ShowKey;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem YouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;

    }
}


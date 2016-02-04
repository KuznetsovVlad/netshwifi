namespace NetshWiFI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBox_Ssid = new System.Windows.Forms.TextBox();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.label_Ssid2 = new System.Windows.Forms.Label();
            this.label_Key2 = new System.Windows.Forms.Label();
            this.button_Apply = new System.Windows.Forms.Button();
            this.label_ChangeSet = new System.Windows.Forms.Label();
            this.button_Ok = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Ssid
            // 
            this.textBox_Ssid.Location = new System.Drawing.Point(77, 31);
            this.textBox_Ssid.Name = "textBox_Ssid";
            this.textBox_Ssid.Size = new System.Drawing.Size(121, 20);
            this.textBox_Ssid.TabIndex = 0;
            this.textBox_Ssid.TextChanged += new System.EventHandler(this.textBox_Ssid_TextChanged);
            // 
            // textBox_Key
            // 
            this.textBox_Key.Location = new System.Drawing.Point(77, 66);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(121, 20);
            this.textBox_Key.TabIndex = 1;
            this.textBox_Key.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Key_KeyDown);
            this.textBox_Key.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Key_KeyPress);
            // 
            // label_Ssid2
            // 
            this.label_Ssid2.AutoSize = true;
            this.label_Ssid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Ssid2.Location = new System.Drawing.Point(14, 34);
            this.label_Ssid2.Name = "label_Ssid2";
            this.label_Ssid2.Size = new System.Drawing.Size(57, 13);
            this.label_Ssid2.TabIndex = 2;
            this.label_Ssid2.Text = "Название";
            // 
            // label_Key2
            // 
            this.label_Key2.AutoSize = true;
            this.label_Key2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Key2.Location = new System.Drawing.Point(14, 69);
            this.label_Key2.Name = "label_Key2";
            this.label_Key2.Size = new System.Drawing.Size(45, 13);
            this.label_Key2.TabIndex = 3;
            this.label_Key2.Text = "Пароль";
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(94, 108);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 4;
            this.button_Apply.Text = "Применить";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // label_ChangeSet
            // 
            this.label_ChangeSet.AutoSize = true;
            this.label_ChangeSet.Location = new System.Drawing.Point(66, 166);
            this.label_ChangeSet.Name = "label_ChangeSet";
            this.label_ChangeSet.Size = new System.Drawing.Size(128, 13);
            this.label_ChangeSet.TabIndex = 5;
            this.label_ChangeSet.Text = "Сменить только пароль";
            // 
            // button_Ok
            // 
            this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Ok.Location = new System.Drawing.Point(253, 161);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(26, 23);
            this.button_Ok.TabIndex = 6;
            this.button_Ok.Text = "OK";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(204, 66);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(38, 31);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(204, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Ssid);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.textBox_Key);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.label_Ssid2);
            this.groupBox1.Controls.Add(this.label_Key2);
            this.groupBox1.Controls.Add(this.button_Apply);
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 143);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Сеть";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 203);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.label_ChangeSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Параметры сети";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Ssid;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Label label_Ssid2;
        private System.Windows.Forms.Label label_Key2;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Label label_ChangeSet;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}
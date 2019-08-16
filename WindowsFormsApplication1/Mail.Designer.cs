namespace WindowsFormsApplication1
{
    partial class Mail
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
            this.Tb_Path = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Bt_Path = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Tb_Content = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Rtb_Message = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Txt_CC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Txt_BCC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tb_Print = new System.Windows.Forms.TextBox();
            this.Tb_Email_from = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.发件人 = new System.Windows.Forms.GroupBox();
            this.Tb_Email_to = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.收件人 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.B_Send = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Tb_PassWord = new System.Windows.Forms.TextBox();
            this.Tb_Port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tb_UeserName = new System.Windows.Forms.TextBox();
            this.Tb_SmtpServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.发件人.SuspendLayout();
            this.收件人.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tb_Path
            // 
            this.Tb_Path.Location = new System.Drawing.Point(99, 20);
            this.Tb_Path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_Path.Name = "Tb_Path";
            this.Tb_Path.Size = new System.Drawing.Size(197, 21);
            this.Tb_Path.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "本地路径：";
            // 
            // Bt_Path
            // 
            this.Bt_Path.Location = new System.Drawing.Point(308, 18);
            this.Bt_Path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bt_Path.Name = "Bt_Path";
            this.Bt_Path.Size = new System.Drawing.Size(75, 23);
            this.Bt_Path.TabIndex = 2;
            this.Bt_Path.Text = "选择";
            this.Bt_Path.UseVisualStyleBackColor = true;
            this.Bt_Path.Click += new System.EventHandler(this.Bt_Path_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Bt_Path);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.Tb_Path);
            this.groupBox4.Location = new System.Drawing.Point(12, 297);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(416, 48);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "附件";
            // 
            // Tb_Content
            // 
            this.Tb_Content.Location = new System.Drawing.Point(99, 14);
            this.Tb_Content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_Content.Name = "Tb_Content";
            this.Tb_Content.Size = new System.Drawing.Size(197, 21);
            this.Tb_Content.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "标题：";
            // 
            // Rtb_Message
            // 
            this.Rtb_Message.Location = new System.Drawing.Point(7, 46);
            this.Rtb_Message.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rtb_Message.Name = "Rtb_Message";
            this.Rtb_Message.Size = new System.Drawing.Size(403, 68);
            this.Rtb_Message.TabIndex = 0;
            this.Rtb_Message.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Rtb_Message);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.Tb_Content);
            this.groupBox5.Location = new System.Drawing.Point(12, 349);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(416, 119);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "信息";
            // 
            // Txt_CC
            // 
            this.Txt_CC.Location = new System.Drawing.Point(77, 19);
            this.Txt_CC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_CC.Name = "Txt_CC";
            this.Txt_CC.Size = new System.Drawing.Size(334, 21);
            this.Txt_CC.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "邮箱地址";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.Txt_CC);
            this.groupBox6.Location = new System.Drawing.Point(10, 191);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(417, 46);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "抄送";
            // 
            // Txt_BCC
            // 
            this.Txt_BCC.Location = new System.Drawing.Point(77, 19);
            this.Txt_BCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_BCC.Name = "Txt_BCC";
            this.Txt_BCC.Size = new System.Drawing.Size(334, 21);
            this.Txt_BCC.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "邮箱地址";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.Txt_BCC);
            this.groupBox7.Location = new System.Drawing.Point(10, 247);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(417, 46);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "密送";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "显示：";
            // 
            // Tb_Print
            // 
            this.Tb_Print.Location = new System.Drawing.Point(263, 17);
            this.Tb_Print.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_Print.Name = "Tb_Print";
            this.Tb_Print.Size = new System.Drawing.Size(141, 21);
            this.Tb_Print.TabIndex = 4;
            this.Tb_Print.Text = "系统测试";
            // 
            // Tb_Email_from
            // 
            this.Tb_Email_from.Location = new System.Drawing.Point(75, 17);
            this.Tb_Email_from.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_Email_from.Name = "Tb_Email_from";
            this.Tb_Email_from.Size = new System.Drawing.Size(135, 21);
            this.Tb_Email_from.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "邮箱地址";
            // 
            // 发件人
            // 
            this.发件人.Controls.Add(this.label8);
            this.发件人.Controls.Add(this.Tb_Email_from);
            this.发件人.Controls.Add(this.Tb_Print);
            this.发件人.Controls.Add(this.label6);
            this.发件人.Location = new System.Drawing.Point(12, 87);
            this.发件人.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.发件人.Name = "发件人";
            this.发件人.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.发件人.Size = new System.Drawing.Size(417, 46);
            this.发件人.TabIndex = 19;
            this.发件人.TabStop = false;
            this.发件人.Text = "发件人";
            // 
            // Tb_Email_to
            // 
            this.Tb_Email_to.Location = new System.Drawing.Point(65, 19);
            this.Tb_Email_to.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_Email_to.Name = "Tb_Email_to";
            this.Tb_Email_to.Size = new System.Drawing.Size(346, 21);
            this.Tb_Email_to.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "邮箱地址";
            // 
            // 收件人
            // 
            this.收件人.Controls.Add(this.label5);
            this.收件人.Controls.Add(this.Tb_Email_to);
            this.收件人.Location = new System.Drawing.Point(11, 139);
            this.收件人.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.收件人.Name = "收件人";
            this.收件人.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.收件人.Size = new System.Drawing.Size(417, 46);
            this.收件人.TabIndex = 18;
            this.收件人.TabStop = false;
            this.收件人.Text = "收件人";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(11, 139);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(417, 46);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // B_Send
            // 
            this.B_Send.Location = new System.Drawing.Point(341, 472);
            this.B_Send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_Send.Name = "B_Send";
            this.B_Send.Size = new System.Drawing.Size(75, 23);
            this.B_Send.TabIndex = 23;
            this.B_Send.Text = "发送";
            this.B_Send.UseVisualStyleBackColor = true;
            this.B_Send.Click += new System.EventHandler(this.B_Send_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.Tb_PassWord);
            this.groupBox1.Controls.Add(this.Tb_Port);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tb_UeserName);
            this.groupBox1.Controls.Add(this.Tb_SmtpServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(417, 70);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置Smtp服务器";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 37);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Is Anonymous";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Tb_PassWord
            // 
            this.Tb_PassWord.Location = new System.Drawing.Point(284, 46);
            this.Tb_PassWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_PassWord.Name = "Tb_PassWord";
            this.Tb_PassWord.PasswordChar = '*';
            this.Tb_PassWord.Size = new System.Drawing.Size(100, 21);
            this.Tb_PassWord.TabIndex = 4;
            // 
            // Tb_Port
            // 
            this.Tb_Port.Location = new System.Drawing.Point(284, 17);
            this.Tb_Port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_Port.Name = "Tb_Port";
            this.Tb_Port.Size = new System.Drawing.Size(100, 21);
            this.Tb_Port.TabIndex = 4;
            this.Tb_Port.Text = "25";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口:";
            // 
            // Tb_UeserName
            // 
            this.Tb_UeserName.Location = new System.Drawing.Point(107, 43);
            this.Tb_UeserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_UeserName.Name = "Tb_UeserName";
            this.Tb_UeserName.Size = new System.Drawing.Size(115, 21);
            this.Tb_UeserName.TabIndex = 2;
            // 
            // Tb_SmtpServer
            // 
            this.Tb_SmtpServer.Location = new System.Drawing.Point(107, 17);
            this.Tb_SmtpServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tb_SmtpServer.Name = "Tb_SmtpServer";
            this.Tb_SmtpServer.Size = new System.Drawing.Size(115, 21);
            this.Tb_SmtpServer.TabIndex = 2;
            this.Tb_SmtpServer.Text = "smtp.qq.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smtp服务器名称:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(1, 76);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(417, 46);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(426, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 519);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.收件人);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.B_Send);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.发件人);
            this.Name = "Mail";
            this.Text = "Mail";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.发件人.ResumeLayout(false);
            this.发件人.PerformLayout();
            this.收件人.ResumeLayout(false);
            this.收件人.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tb_Path;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Bt_Path;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox Tb_Content;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox Rtb_Message;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox Txt_CC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox Txt_BCC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tb_Print;
        private System.Windows.Forms.TextBox Tb_Email_from;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox 发件人;
        private System.Windows.Forms.TextBox Tb_Email_to;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox 收件人;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button B_Send;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox Tb_PassWord;
        private System.Windows.Forms.TextBox Tb_Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tb_UeserName;
        private System.Windows.Forms.TextBox Tb_SmtpServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
namespace WindowsFormsApplication1
{
    partial class Author
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Author));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_PipeInfo = new System.Windows.Forms.Label();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pic_Code = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Code)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_PipeInfo);
            this.panel1.Controls.Add(this.pic_logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 93);
            this.panel1.TabIndex = 1;
            // 
            // lbl_PipeInfo
            // 
            this.lbl_PipeInfo.AutoSize = true;
            this.lbl_PipeInfo.Font = new System.Drawing.Font("楷体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PipeInfo.Location = new System.Drawing.Point(105, 31);
            this.lbl_PipeInfo.Name = "lbl_PipeInfo";
            this.lbl_PipeInfo.Size = new System.Drawing.Size(65, 18);
            this.lbl_PipeInfo.TabIndex = 2;
            this.lbl_PipeInfo.Text = "王亚洲";
            // 
            // pic_logo
            // 
            this.pic_logo.Image = ((System.Drawing.Image)(resources.GetObject("pic_logo.Image")));
            this.pic_logo.Location = new System.Drawing.Point(30, 21);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(82, 66);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_logo.TabIndex = 0;
            this.pic_logo.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbl_Email);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 144);
            this.panel2.TabIndex = 2;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(137, 64);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(137, 12);
            this.lbl_Email.TabIndex = 5;
            this.lbl_Email.Text = "邮箱：869553752@qq.com";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pic_Code);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(131, 142);
            this.panel3.TabIndex = 0;
            // 
            // pic_Code
            // 
            this.pic_Code.Image = ((System.Drawing.Image)(resources.GetObject("pic_Code.Image")));
            this.pic_Code.Location = new System.Drawing.Point(8, 20);
            this.pic_Code.Name = "pic_Code";
            this.pic_Code.Size = new System.Drawing.Size(120, 122);
            this.pic_Code.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Code.TabIndex = 0;
            this.pic_Code.TabStop = false;
            // 
            // Author
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 237);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Author";
            this.Text = "关于作者";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Code)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_PipeInfo;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pic_Code;

    }
}
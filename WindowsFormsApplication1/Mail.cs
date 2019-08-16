using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }
        private void Bt_Path_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.Title = "请选择附件";
            this.openFileDialog1.Filter = "所有文件类型（＊．＊）|*.*";
            this.openFileDialog1.Multiselect = false;
            DialogResult Result = this.openFileDialog1.ShowDialog();
            if (Result == DialogResult.OK)
            {

                Tb_Path.Text = this.openFileDialog1.FileName.Trim();

            }
        }

        private void B_Send_Click(object sender, EventArgs e)
        {
            SendMail mail = null;
            mail = new SendMail();
            mail.m_Port = Tb_Port.Text.Trim();
            mail.m_SMTPServer = Tb_SmtpServer.Text.Trim();
            mail.m_UserName = Tb_UeserName.Text.Trim();
            mail.m_UserPwd = Tb_PassWord.Text.Trim();
            if (checkBox1.Checked)
            {
                mail.IsAnonymous = 1;
            }
            mail.Func_SendMail(Tb_Email_from.Text, Tb_Email_to.Text, Txt_CC.Text, Txt_BCC.Text, Tb_Content.Text, Tb_Path.Text, Rtb_Message.Text);
            if (mail.pblnSuccess == false)
            {
                MessageBox.Show(mail.pFailInfo);
            }
            else
            {
                MessageBox.Show("发送成功，请查看收件箱");
            }
            mail = null;


        }
    }
}

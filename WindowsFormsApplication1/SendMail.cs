using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    class SendMail
    {
         private SmtpClient SmtpClient_my = null;//SMTP 邮件发送主体
        private MailMessage MailMessage_my = null;
        private Attachment Attachment_my = null;

        public string m_SMTPServer="";
        public string m_Port="25";
        public string m_UserName="";
        public string m_UserPwd="";
        public int IsAnonymous=0;


        public bool pblnSuccess = true;//判断邮件是否发送成功True==成功， False: 失败
        public string pFailInfo = "";//邮件发送失败后，对应的失败原因

        //设置邮件格式 html,plaintext, richtext
        public enum MailTypes
        {
            Html=0, Text=1
        }

        public MailTypes pMailType;//邮件类型变量

        //设置邮件编码格式 GB2312, UTF-8

        public enum MailEncodings
        {
            GB2312=0, ASCII=1, Unicode=2, UTF8=3
            //The Default mailtype=Html, CodingType=3
        }
        public MailEncodings pMailEncoding;//邮件编码类型

        public enum EmailPriory
        { 
            High=0,Normal=1,Low=2
        }
        public EmailPriory pPriority;
        //构造函数，New SMTP变量实例
        public SendMail()
        {
            //初始化邮件信息
            MailMessage_my = new MailMessage();
            pFailInfo = "";
            IsAnonymous = 0;
            pblnSuccess = true;
            pMailType = MailTypes.Html;
            pMailEncoding = MailEncodings.UTF8;
            pPriority = EmailPriory.Normal;
        }

        #region //初始设置SMTP 服务器
        private int Func_InitSMTP()
        {
            try
            {

                string StrIP = "";
                //此Resolve函数已经过时
                //IPAddress hostIPAddress = (Dns.Resolve(m_SMTPServer)).AddressList[0];
                IPAddress[] IpAddress = Dns.GetHostEntry(m_SMTPServer).AddressList;
                if (IpAddress.Length > 0)
                {
                    IPAddress hostIPAddress = Dns.GetHostEntry(m_SMTPServer).AddressList[0];
                    StrIP = hostIPAddress.ToString();
                }
                else
                {
                    pFailInfo = "Could not find the matched IP address for SMTP Server by the method Dns.GetHostEntry";
                    pblnSuccess = false;
                }
                //此部分过程，存在，如果网站禁止Ping命令，则得不到Ping通得IP地址。


                //IPAddress[] IpAddress = Dns.GetHostEntry(m_SMTPServer).AddressList;
                //Ping ping = new Ping();
                //PingReply pingReply = null;
                ////取得smt服务器可用的ＩＰ
                //foreach (IPAddress IP in IpAddress)
                //{
                //    pingReply = ping.Send(IP);
                //    if (pingReply.Status == IPStatus.Success)
                //    {
                //        StrIP = IP.ToString();
                //        break;
                //    }
                //}

                SmtpClient_my = new SmtpClient(StrIP, Int32.Parse(m_Port));
                SmtpClient_my.Timeout = 20000;
                //创建服务器认证
                NetworkCredential NetworkCredential_my=null;
                if (IsAnonymous==0)
                {
                    //如果非匿名访问,写上邮箱的账号，密码
                    NetworkCredential_my = new NetworkCredential(m_UserName,m_UserPwd);
                }
                else
                {
                    //匿名访问
                    NetworkCredential_my = new NetworkCredential();
                    SmtpClient_my.UseDefaultCredentials = true;
                }
                SmtpClient_my.Credentials = NetworkCredential_my;

                SmtpClient_my.SendCompleted += new SendCompletedEventHandler(SmtpClient_my_SendCompleted);
                pblnSuccess = true;
                return 1;
            }
            catch (SocketException E)
            {

                pFailInfo=E.ToString();
                pblnSuccess = false;
                return 0;
            }
        }
        #endregion



        #region//设置m_From发送人，m_To收件人，m_CC抄送，m_BCC密送人

        private int Func_PersonInit(string m_From, string m_To, string m_CC, string m_BCC)
        {
            MailAddress mailTemp = null;
            string[] aryTemp = null;
            //数据库需要设置系统邮件地址
            if (m_From.Trim().Equals(""))
            {
                pFailInfo = "the email sender could not be null";
                pblnSuccess = false;
                return 0;
            }
            else
            {
                mailTemp = new MailAddress(m_From.Trim(),"System");
                MailMessage_my.From = mailTemp;
            }
            if (m_To.Trim().Equals(""))
            {
                pFailInfo = "the email receiver could not be null";
                pblnSuccess = false;
                return 0;
            }
            else
            {
                aryTemp = m_To.Split(';');
                for (int i = 0; i < aryTemp.Length; i++)
                {
                    if (!aryTemp[i].Trim().Equals(""))
                    {
                        mailTemp = new MailAddress(aryTemp[i].Trim());
                        MailMessage_my.To.Add(mailTemp);
                    }
                }
            }
            //抄送
            if (!m_CC.Trim().Equals(""))
            {
                aryTemp = m_CC.Split(';');
                for (int i = 0; i < aryTemp.Length; i++)
                {
                    if (!aryTemp[i].Trim().Equals(""))
                    {
                        mailTemp = new MailAddress(aryTemp[i].Trim());
                        MailMessage_my.CC.Add(mailTemp);
                    }
                }
            }
            //密送
            if (!m_BCC.Trim().Equals(""))
            {
                aryTemp = m_BCC.Split(';');
                for (int i = 0; i < aryTemp.Length; i++)
                {
                    if (!aryTemp[i].Trim().Equals(""))
                    {
                        mailTemp = new MailAddress(aryTemp[i].Trim());
                        MailMessage_my.Bcc.Add(mailTemp);
                    }
                }
            }
            pblnSuccess = true;
            return 1;
        }
        #endregion

        //smtp.163.com   25

        #region//读取附件信息，将附件组添加到邮件附件组中。
        private int Func_AttachInit(string m_Attachment)
        {
            string[] aryTemp = null;
            if (!m_Attachment.Equals(""))
            {
                //分割附件数组
                aryTemp = m_Attachment.Split(';');
                for (int i = 0; i < aryTemp.Length; i++)
                {
                    //如果文件不存在
                    if (!File.Exists(aryTemp[i].Trim()))
                    {
                        if (!aryTemp[i].Trim().Equals(""))
                        {
                            pFailInfo = "The file " + aryTemp[i] + " doese not exist.";
                            pblnSuccess = false;
                            return 0;
                            //MessageBox.Show("{0}文件不存在！", aryTemp[i].Trim());
                        }
                    }
                    //如果文件存在
                    //获取文件
                    try
                    {
                        FileStream FileStream_my = new FileStream(aryTemp[i], FileMode.Open);
                        string name = FileStream_my.Name;
                        int size = (int)(FileStream_my.Length / 1024);
                        //控制文件大小不大于10Ｍ
                        if (size > 10240)
                        {
                            // MessageBox.Show("文件长度不能大于１０Ｍ！你选择的文件大小为{0}", size.ToString());
                            pFailInfo = "The file size could not be over 10M, The current file size [" + aryTemp[i]+"] is " + size.ToString();
                            FileStream_my.Close();
                            pblnSuccess = false;
                            return 0;
                        }
                        else
                        {
                            FileStream_my.Close();
                            FileStream_my.Dispose();
                            //Attachment_my = new Attachment(aryTemp[i], MediaTypeNames.Application.Octet);
                            //ContentDisposition ContentDisposition_my = Attachment_my.ContentDisposition;
                            //ContentDisposition_my.Size = size;
                            //ContentDisposition_my.FileName = name;
                            //ContentDisposition_my.CreationDate = File.GetCreationTime(aryTemp[i]);
                            //ContentDisposition_my.ModificationDate = File.GetLastWriteTime(aryTemp[i]);
                            //ContentDisposition_my.ReadDate = File.GetCreationTimeUtc(aryTemp[i]);
                            Attachment_my = new Attachment(aryTemp[i]);
                            MailMessage_my.Attachments.Add(Attachment_my);
                            
                        }
                    }
                    catch (IOException E)
                    {
                       pFailInfo=E.Message;
                       pblnSuccess = false;
                       return 0;
                    }
                }//end for each
            }
            pblnSuccess = true;
            return 1;
            //程序正常结束，返回1

        }

        #endregion

        #region 发送邮件后所处理的函数
        private void SmtpClient_my_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            { 
                
                pFailInfo="the email sending is canceld";
                pblnSuccess = false;
                
            
            }
            if (e.Error != null)
            {
                //MessageBox.Show(e.UserState.ToString() + "发送错误：" + e.Error.Message, "发送错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pFailInfo = "the email sending error "+e.Error.Message;
                pblnSuccess = false;
            }
            else
            {
                //MessageBox.Show("邮件成功发出!", "恭喜!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pblnSuccess = true;
            }

        }
        #endregion

        #region "设置邮件类型与编码格式"
        private void Void_SetMailCoding()
        {
            int intType = (int)pMailType;
            int intCoding = (int)pMailEncoding;
            int intPriority = (int)pPriority;
            //设定邮件类型Html=0, PlainText=1,RichText=2
            switch (intType)
            { 
                case 0://Html
                    MailMessage_my.IsBodyHtml = true;
                    break;
                case 1://Text
                    MailMessage_my.IsBodyHtml = false;
                    break;
                default://Hteml
                    MailMessage_my.IsBodyHtml = true;
                    break;
            
            }
            //Set Mail Coding Tyep


        //设置邮件编码格式 GB2312, UTF-8

            switch (intCoding)
            {
                case 0://GB2312
                    MailMessage_my.BodyEncoding=Encoding.GetEncoding(936);
                    MailMessage_my.SubjectEncoding=Encoding.GetEncoding(936);
                    
                    break;
                case 1://ASCII
                    MailMessage_my.BodyEncoding=Encoding.ASCII;
                    MailMessage_my.SubjectEncoding=Encoding.ASCII;
                    break;
                case 2://Unicode
                    MailMessage_my.BodyEncoding=Encoding.Unicode;
                    MailMessage_my.SubjectEncoding=Encoding.Unicode;
                    break;
                case 3://UTF8
                    MailMessage_my.BodyEncoding=Encoding.UTF8;
                    MailMessage_my.SubjectEncoding=Encoding.UTF8;
                    break;
                default:
                    MailMessage_my.BodyEncoding=Encoding.UTF8;
                    MailMessage_my.SubjectEncoding=Encoding.UTF8;
                    break;

            }
            //设置优先级
            switch (intPriority)
            { 
                case 0://High
                    MailMessage_my.Priority = MailPriority.High;
                    break;
                case 1://normal
                    MailMessage_my.Priority = MailPriority.Normal;
                    break;
                case 2://low
                    MailMessage_my.Priority = MailPriority.Low;
                    break;
                default:
                    MailMessage_my.Priority = MailPriority.Normal;
                    break;
            }
            
            

        }
        #endregion


        #region//发送邮件主函数
        //返回值=0 发送失败，pFailInfo 查看失败原因
        //返回值=1 发送成功
        public int  Func_SendMail(string m_From, string m_To, string m_CC, string m_BCC, string m_SubJect, string m_Attachment, string m_Boday)
        {

            try
            {
                //设置smtp 服务器及后期处理函数
                Func_InitSMTP();
                if (pblnSuccess == false)
                {
                    return 0;
                }
                //设置收，发邮件人的列表
                Func_PersonInit(m_From, m_To, m_CC, m_BCC);
                if (pblnSuccess==false)
                {
                    return 0;
                }

                //设置附件
                Func_AttachInit(m_Attachment);
                if (pblnSuccess == false)
                {
                    return 0;
                }
                MailMessage_my.Subject = m_SubJect;
                MailMessage_my.Body = m_Boday;
                Void_SetMailCoding();
                string userToken = "Well!";
                if (SmtpClient_my != null)
                {
                    //SmtpClient_my.SendAsync(MailMessage_my, userToken);
                    SmtpClient_my.Send(MailMessage_my);
                    MailMessage_my.Dispose();
                    pblnSuccess = true;
                    return 1;
                }
                else
                {

                    //MessageBox.Show("邮件没有发送！Ｓmtp服务器没有初始化!");
                    pblnSuccess = false;
                    pFailInfo = "the smtp server didn't be initialized";
                    return 0;
                }
            }
            catch (Exception ex)
            {
                pblnSuccess = false;
                pFailInfo = ex.Message;
                MailMessage_my.Dispose();
                return 0;
            }
            

        }
        #endregion
    }
}

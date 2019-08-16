using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using System.Collections;
using System.Net;
using System.Xml;
using System.IO.Compression;
using HtmlAgilityPack;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Scan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Scan()
        {
            InitializeComponent();

        }
        delegate void chang();
        delegate void changRichtextbox();
        private void Scan_Load(object sender, EventArgs e)
        {
            progressPanel2.Visible = true;
            Task task = new Task(n => Getallurl(), 0);
            task.Start();
            Task tsk = task.ContinueWith(t => addtreelist());
            Task ts = tsk.ContinueWith(t => Xssscan(), 0);
            Task tt = ts.ContinueWith(t => Creatpoc(),0);
        }
        private static Scan uniqueInstance;
        private static readonly object syncObject = new object();
        public static Scan Getinstance()
        {
            if (uniqueInstance == null || uniqueInstance.IsDisposed)
            {
                lock (syncObject)
                {
                    if (uniqueInstance == null || uniqueInstance.IsDisposed)
                    {
                        uniqueInstance = new Scan();
                    }

                }
            }
            return uniqueInstance;
        }
        delegate void AsynUpdateUI();
        List<string> list = new List<string>();
        List<string> listallurl = new List<string>();
        List<string> wplayload = new List<string>();
        string Playpath = null;
        int value = 0;
        string filepath = "F:\\毕设\\资料\\WindowsFormsApplication1\\WindowsFormsApplication1\\bin\\Debug\\www.xml";
        public static int parentId;
        public static int Id;
        private List<string> Geturl()
        {
            string url = GetHttpWebRequest(Common.url);
            return list = GetHyperLinks(url, Common.url);


        }
        #region 添加到treelist
        private void addtreelist()
        {
            DataTable dt = new DataTable();
            DataColumn did = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn dParentID = new DataColumn("ParentID", Type.GetType("System.Int32"));
            DataColumn dNodeName = new DataColumn("节点名称", Type.GetType("System.String"));
            dt.Columns.Add(did);
            dt.Columns.Add(dParentID);
            dt.Columns.Add(dNodeName);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            int Id = 1;
            int ParentId = 0;
            //获取根节点
            XmlElement xmlRootElement = xmlDoc.DocumentElement;
            DataRow dr = dt.NewRow();
            dr["ID"] = Id++;
            dr["ParentID"] = 0;
            dr["节点名称"] = xmlRootElement.Attributes["root"].Value;

            dt.Rows.Add(dr);
            XmlNodeList xmlNodeList = xmlRootElement.ChildNodes;
            foreach (XmlElement xmlElement in xmlNodeList)
            {
                dr = dt.NewRow();
                dr["ID"] = Id++;
                dr["ParentID"] = ParentId;
                dr["节点名称"] = xmlElement.Attributes["url"].Value;
                dt.Rows.Add(dr);
                int parentId = Id - 1;
                //遍历该节点下面的子节点
                XmlNodeList ChildNodeList = xmlElement.ChildNodes;
                foreach (XmlNode xmlNode in ChildNodeList)
                {
                    dr = dt.NewRow();
                    dr["ID"] = Id++;
                    dr["ParentID"] = parentId;
                    dr["节点名称"] = xmlNode.InnerText;
                    dt.Rows.Add(dr);
                }
            }
            //this.treeList1.Dispatcher.Invoke(() =>
            //    {
            //        treeList1.DataSource = dt;
            //    }
            // );
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate()
                {
                    treeList1.DataSource = dt;
                }));
            }
            else
            {
                treeList1.DataSource = dt;
            }
            //this.treeList1.DataSource = dt;
            //this.treeList1.DataSource = SelectXml(filepath);
        }
        #endregion
        #region 爬取html
        /// <summary>
        /// 爬虫
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetHttpWebRequest(string url)
        {
            HttpWebResponse result;
            string strHTML = string.Empty;
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
                if (Common.cookie != null)
                {
                    request.Headers.Set("Cookie", Common.cookie);
                    request.Referer = "http://localhost:8888/DVWA-master/index.php";
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader mystreamreader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retstring = mystreamreader.ReadToEnd();
                strHTML = retstring;
                mystreamreader.Close();
                myResponseStream.Close();

                //Uri uri = new Uri(url);
                //WebRequest webReq = WebRequest.Create(uri);
                //WebResponse webRes = webReq.GetResponse();

                //HttpWebRequest myReq = (HttpWebRequest)webReq;
                //myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
                //myReq.Accept = "*/*";
                //myReq.KeepAlive = true;
                //myReq.Referer = "http://localhost:8888/DVWA-master/index.php";
                //if (Common.cookie != null)
                //{
                //    myReq.Headers.Set("Cookie", Common.cookie);
                //}
                //myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                //result = (HttpWebResponse)myReq.GetResponse();
                //Stream receviceStream = result.GetResponseStream();
                //StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
                //strHTML = readerOfStream.ReadToEnd();
                //readerOfStream.Close();
                //receviceStream.Close();
                //result.Close();
            }
            catch
            {
                Uri uri = new Uri(url);
                WebRequest webReq = WebRequest.Create(uri);
                HttpWebRequest myReq = (HttpWebRequest)webReq;
                myReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
                myReq.Accept = "*/*";
                myReq.KeepAlive = true;
                myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                if (Common.cookie != null)
                {
                    myReq.Headers.Set("Cookie", Common.cookie);
                    myReq.Referer = "http://localhost:8888/DVWA-master/index.php";
                }
                else
                {

                }

                //myReq.CookieContainer = Common.cookie;
                //result = (HttpWebResponse)myReq.GetResponse();
                try
                {
                    result = (HttpWebResponse)myReq.GetResponse();
                }
                catch (WebException ex)
                {
                    result = (HttpWebResponse)ex.Response;
                }
                if (result != null)
                {
                    try
                    {
                        Stream receviceStream = result.GetResponseStream();
                        StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("gb2312"));
                        strHTML = readerOfStream.ReadToEnd();
                        readerOfStream.Close();
                        receviceStream.Close();
                        result.Close();
                    }
                    catch (WebException ex)
                    {

                    }
                }
            }
            return strHTML;
        }
        #endregion
        #region 提取HTML代码中的网址
        /// <summary>
        /// 提取HTML代码中的网址
        /// </summary>
        /// <param name="htmlCode"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private static List<string> GetHyperLinks(string htmlCode, string url)
        {
            ArrayList al = new ArrayList();
            bool IsGenxin = false;
            StringBuilder weburlSB = new StringBuilder();//SQL
            StringBuilder linkSb = new StringBuilder();//展示数据
            List<string> Weburllistzx = new List<string>();//新增
            List<string> Weburllist = new List<string>();//旧的
            string ProductionContent = htmlCode;
            Regex reg = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+/?");
            string wangzhanyuming = reg.Match(url, 0).Value;
            MatchCollection mc = Regex.Matches(ProductionContent.Replace("href=\"/", "href=\"" + wangzhanyuming).Replace("href='/", "href='" + wangzhanyuming).Replace("href=/", "href=" + wangzhanyuming).Replace("href=\"./", "href=\"" + wangzhanyuming), @"<[aA][^>]* href=[^>]*>", RegexOptions.Singleline);
            int Index = 1;
            foreach (Match m in mc)
            {
                MatchCollection mc1 = Regex.Matches(m.Value, @"[a-zA-z]+://[^\s]*", RegexOptions.Singleline);
                if (mc1.Count > 0)
                {
                    foreach (Match m1 in mc1)
                    {
                        string linkurlstr = string.Empty;
                        linkurlstr = m1.Value.Replace("\"", "").Replace("'", "").Replace(">", "").Replace(";", "");
                        weburlSB.Append("$-$");
                        weburlSB.Append(linkurlstr);
                        weburlSB.Append("$_$");
                        if (!Weburllist.Contains(linkurlstr) && !Weburllistzx.Contains(linkurlstr))
                        {
                            IsGenxin = true;
                            if (Common.GetTopDomainName(linkurlstr) != Common.Dominant)
                            {
                                continue;
                            }
                            Weburllistzx.Add(linkurlstr);

                            Common.Weburllistzx.Add(linkurlstr);

                            linkSb.AppendFormat("{0}<br/>", linkurlstr);
                        }
                    }
                }
                else
                {
                    if (m.Value.IndexOf("javascript") == -1)
                    {
                        string amstr = string.Empty;
                        string wangzhanxiangduilujin = string.Empty;
                        wangzhanxiangduilujin = url.Substring(0, url.LastIndexOf("/") + 1);
                        amstr = m.Value.Replace("href=\"", "href=\"" + wangzhanxiangduilujin).Replace("href='", "href='" + wangzhanxiangduilujin);
                        MatchCollection mc11 = Regex.Matches(amstr, @"[a-zA-z]+://[^\s]*", RegexOptions.Singleline);
                        foreach (Match m1 in mc11)
                        {
                            string linkurlstr = string.Empty;
                            linkurlstr = m1.Value.Replace("\"", "").Replace("'", "").Replace(">", "").Replace(";", "");
                            weburlSB.Append("$-$");
                            weburlSB.Append(linkurlstr);
                            weburlSB.Append("$_$");
                            if (!Weburllist.Contains(linkurlstr) && !Weburllistzx.Contains(linkurlstr))
                            {
                                //if (Common.GetTopDomainName(linkurlstr) != Common.Dominant)
                                //{
                                //    continue;
                                //}
                                IsGenxin = true;
                                Weburllistzx.Add(linkurlstr);
                                //Common.Weburllistzx.Add(Common.url);
                                Common.Weburllistzx.Add(linkurlstr);
                                linkSb.AppendFormat("{0}<br/>", linkurlstr);
                            }
                        }
                    }
                }
                Index++;
            }

            return Weburllistzx;
        }
        #endregion
        #region 把网址写入xml文件
        /// <summary>
        /// // 把网址写入xml文件
        /// </summary>
        /// <param name="strURL"></param>
        /// <param name="alHyperLinks"></param>
        private static void WriteToXml(string strURL, List<string> alHyperLinks)
        {
            string dd = System.Environment.CurrentDirectory;
            dd += "\\www.xml";

            FileInfo fi = new FileInfo(dd);//判断文件是否为空

            XmlTextWriter writer = new XmlTextWriter(dd, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument(false);
            writer.WriteComment("提取自" + strURL + "的超链接");
            writer.WriteStartElement("root", null);
            writer.WriteAttributeString("root", "URL描述");
            writer.WriteStartElement("url", null);
            writer.WriteAttributeString("url", strURL + DateTime.Now.ToString());

            foreach (string str in alHyperLinks)
            {
                string title = GetDomain(str);
                string body = str;
                writer.WriteElementString(title, null, body);
            }
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }
        #endregion
        #region 获取网址的域名后缀
        /// <summary>
        /// 获取网址的域名后缀
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns></returns>
        private static string GetDomain(string strURL)
        {
            string retVal;
            string strRegex = @"(\.com/|\.net/|\.cn/|\.org/|\.gov/)";
            Regex r = new Regex(strRegex, RegexOptions.IgnoreCase);
            Match m = r.Match(strURL);
            retVal = m.ToString();
            strRegex = @"\.|/$";
            retVal = Regex.Replace(retVal, strRegex, "").ToString();
            if (retVal == "")
                retVal = "other";
            return retVal;
        }
        #endregion
        #region 遍历所有url

        private void Getallurl()
        {
            List<string> listurl = new List<string>();
            listurl = Geturl();
            foreach (var li in listurl)
            {
                string url1 = GetHttpWebRequest(li);

                foreach (var lis in GetHyperLinks(url1, li))
                {
                    listallurl.Add(lis);
                }
            }
            WriteToXml(Common.url, listallurl);
            //MessageBox.Show("完成！");
        }

        #endregion

        #region 开始扫描
        private void Xssscan()
        {



            if (InvokeRequired)
            {
                this.Invoke(new chang(delegate()
                {
                    progressPanel2.Caption = "测试漏洞中...";
                }));
            }
            else
            {
                progressPanel2.Caption = "测试漏洞中...";
            }


            Analysis analysis = new Analysis();
            analysis.analysis();


            //List<string> copyList = new List<copyList>();


            Hashtable hash = new Hashtable();
            foreach (string str in Common.poc)//源LIST去重
            {

                if (!hash.ContainsKey(str))
                {
                    hash.Add(str, str);
                    Common.zuihou.Add(str);//把不重复的列加入
                }
            }
            foreach (var item in Common.zuihou)
            {
                try
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new chang(delegate()
                        {
                            progressPanel2.Description = item.ToString();
                        }));
                    }
                    else
                    {
                        progressPanel2.Description = item.ToString();
                    }
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(item);
                    request.Method = "GET";
                    request.ContentType = "text/html;charset=UTF-8";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
                    if (Common.cookie != null)
                    {
                        request.Headers.Set("Cookie", Common.cookie);
                        request.Referer = "http://localhost:8888/DVWA-master/vulnerabilities/xss_r/?name=";
                    }

                    //request.Referer = "http://localhost:8888/DVWA-master/vulnerabilities/xss_r/?name=";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader mystreamreader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    string retstring = mystreamreader.ReadToEnd();
                    mystreamreader.Close();
                    myResponseStream.Close();
                    MatchCollection mc = Regex.Matches(retstring, @"((\<script.*script\>))", RegexOptions.Multiline);
                    for (int i = 0; i < mc.Count; i++)
                    {

                        //Task task = new Task(n => Changtext(url), 0);
                        //task.Start();
                        //验证问题。。。。
                        foreach (var item1 in Common.replayload)
                        {
                            if (mc[i].Value == item1)
                                WritePlayLoad(item);

                        }

                    }
                }

                catch (Exception)
                {


                }
                //string script="<script>alert(document.cookie)</script>";
                //string url = "http://localhost:8888/DVWA-master/vulnerabilities/xss_r/?name=" + slinr + "#";
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            }
            if (InvokeRequired)
            {
                this.Invoke(new chang(delegate()
                {
                    progressPanel2.Visible = false;
                }));
            }
            else
            {
                progressPanel2.Visible = false;
            }
            MessageBox.Show("扫描完成");
        }
        #endregion
        #region 记录playload
        private void WritePlayLoad(string slinr)
        {
            Common.result.Add(slinr);
           // Common.playload.Add(slinr);
            wplayload.Add(slinr);

        }
        #endregion
        /// <summary>
        /// 报表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report report = Report.Getinstance();
            report.Show();
            report.Focus();
        }
        #region
        private void Creatpoc()
        {
            //RichTextBox rtb = new RichTextBox();
            //ListBox lb = new ListBox();
            //rtb.Size = new System.Drawing.Size(600, 600);
            //rtb.Location = new Point(0, 700);
            //richTextBox1.AppendText("playload为：\n");

            if (InvokeRequired)
            {
                this.Invoke(new changRichtextbox(delegate()
                {
                    foreach (var item in wplayload)
                    {
                        richTextBox1.AppendText(item + "\n");
                    }
                }));
            }
            else
            {
                foreach (var item in wplayload)
                {
                    richTextBox1.AppendText(item + "\n");
                }
            }
            //foreach (var item in wplayload)
            //{
            //    richTextBox1.AppendText(item + "\n");
            //}
            //groupControl1.Controls.Add(rtb);
            
        }
        #endregion

    }
}
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
using DevExpress.XtraCharts;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Replacing;
using System.Net.Mail;
using System.Net;
namespace WindowsFormsApplication1
{
    public partial class Report : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Report()
        {
            InitializeComponent();
        }
        string desktop = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string dd = System.Environment.CurrentDirectory;
        string strlab2 = "";
        int i = 0; int j = 0;
        string path = "";
        private static Report uniqueInstance;
        private static readonly object syncObject = new object();
        public static Report Getinstance()
        {
            if (uniqueInstance == null || uniqueInstance.IsDisposed)
            {
                lock (syncObject)
                {
                    if (uniqueInstance == null || uniqueInstance.IsDisposed)
                    {
                        uniqueInstance = new Report();
                    }

                }
            }
            return uniqueInstance;
        }
        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            // Label label1 = new Label();
            label1.Text = Common.Dominant + "漏洞扫描报告";
            int w = label1.Width;
            label1.Location = new Point(300 - w / 2, 13);
            label1.Visible = true;
            xtraScrollableControl1.Controls.Add(label1);
            ChartControl pieChart = new ChartControl();
            Series series1 = new Series("漏洞分布", ViewType.Pie);
           
            foreach (var item in Common.playload)
            {
                i++;
            }
            if (i <= 5)
            {
                strlab2 = "得分为：" + (100 - i * 10);
            }
            else if (i > 5 & i <= 10)
            {
               strlab2 = "得分为：" + (50 - i * 3);
            }
            else
            {
                strlab2 = "得分为：20";
            }
            label2.Text = strlab2;
            foreach (var item in Common.poc)
            {
                j++;
            }
            series1.Points.Add(new SeriesPoint("不存在XSS占比", j * 1.0 / (i + j)));
            series1.Points.Add(new SeriesPoint("存在XSS占比", 1.0 - (j / (i + j))));
            series1.Label.TextPattern = "{A}: {VP:p0}";
            pieChart.Series.Add(series1);
            pieChart.Location = new Point(0, 67);
            pieChart.Size = new System.Drawing.Size(600, 600);
            xtraScrollableControl1.Controls.Add(pieChart);
            if (pieChart.IsPrintingAvailable) //是否能被打印或输出
            {
                 path = dd+"\\" + Common.Dominant.Replace(".", "1") + ".png";
                pieChart.ExportToImage(path, ImageFormat.Png);
            }
            RichTextBox rtb = new RichTextBox();
            //ListBox lb = new ListBox();
            rtb.Size = new System.Drawing.Size(600, 100);
            rtb.Location = new Point(0, 690);
            rtb.AppendText("playload为：\n");

            foreach (var item in Common.result)
            {
                rtb.AppendText(item + "\n");
            }
            xtraScrollableControl1.Controls.Add(rtb);
            richTextBox1.Location = new Point(0, 800);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            string filep = "";
            if (filep == null)
            {
                filep = desktop + "\\" + Common.Dominant.Replace(".", "1") + ".doc";
            }
            string savefile = "";
            saveFileDialog1.FileName = Common.Dominant.Replace(".", "1") + ".doc";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savefile = saveFileDialog1.FileName.ToString();//改保存的文件夹加要保存的文件名
                //doc.SaveToFile(savefile);
                creatdoc(savefile);
                //doc.Close();
                //MessageBox.Show("另存成功");
                DialogResult dialogResult = MessageBox.Show("是否要打开保存报告", "提示", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    PDFDocumentViewer(savefile);
                }
            }
            else
            {
                return;
            }

        }



        public void creatdoc(string savepath) {
            Document doc = new Document(dd+"\\report.docx");
            var name = string.Format("&{0}&", "你的姓名");
            doc.Range.Replace(name, System.Environment.UserName.ToString(), false, false);

            var time = string.Format("&{0}&", "日期");
            doc.Range.Replace(time, DateTime.Now.ToLocalTime().ToString(), false, false);

            var score = string.Format("&{0}&", "得分");
            doc.Range.Replace(score, strlab2, false, false);

            var domin = string.Format("&{0}&", "域名");
            doc.Range.Replace(domin, Common.Dominant, false, false);

           
            Regex reg = new Regex("&图片&");
            //doc.Range.Replace(score, doc.Range.Replace(reg, new ReplaceAndInsertImage(".//1.jpg"), false);, false, true);
            doc.Range.Replace(reg, new ReplaceAndInsertImage(path), false);
            string zuihou = "";
            foreach (var item in Common.result)
            {
                zuihou = zuihou + item.ToString() + "\n\n\n\n\n\n";
                
            }
            var py = string.Format("&{0}&", "playload");
            doc.Range.Replace(py, zuihou, false, false);
            //doc.Save("字符串替换操作.doc");
            doc.Save(savepath);
        }
        public class ReplaceAndInsertImage : IReplacingCallback
        {
            /// <summary>
            /// 需要插入的图片路径
            /// </summary>
            public string url { get; set; }

            public ReplaceAndInsertImage(string url)
            {
                this.url = url;
            }

            public ReplaceAction Replacing(ReplacingArgs e)
            {
                //获取当前节点
                var node = e.MatchNode;
                //获取当前文档
                Document doc = node.Document as Document;
                DocumentBuilder builder = new DocumentBuilder(doc);
                //将光标移动到指定节点
                builder.MoveTo(node);
                //插入图片
                builder.InsertImage(url);
                return ReplaceAction.Replace;
            }
        }
        

        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch
            {
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Mail mail = new Mail();
            mail.Show();
        }
    }
}
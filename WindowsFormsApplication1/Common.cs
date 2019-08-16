using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Common
    {

        public static int number;
        public static string cookie;
        public static List<string> Weburllistzx = new List<string>();//url
        public static List<string> playload = new List<string>();//最后的
        public static List<string> replayload = new List<string>();//对比字典
        public static List<string> poc = new List<string>();//同域名
        public static List<string> zuihou = new List<string>();//同域名
        public static List<string> result = new List<string>();//
        public static string url;
        public static string dd="";
        public static string Mail = "";
        public static string dd1="";
        public static string rePlaypath = "";
        public static string Playpath = "";
        public static string Dominant;//域名
        public static string GetTopDomainName(string domain)
        {
            //https://www.safsd.asdfasdf.baidu.com.cn/ssssd/s/b/d/hhh.html?domain=sfsdf.com.cn&id=1
            domain = domain.Trim().ToLower();
            string rootDomain = ".com.cn|.gov.cn|.cn|.com|.net|.org|.so|.co|.mobi|.tel|.biz|.info|.name|.me|.cc|.tv|.asiz|.hk";
            if (domain.StartsWith("http://")) domain = domain.Replace("http://", "");
            if (domain.StartsWith("https://")) domain = domain.Replace("https://", "");
            if (domain.StartsWith("www.")) domain = domain.Replace("www.", "");
            //safsd.asdfasdf.baidu.com.cn/ssssd/s/b/d/hhh.html?domain=sfsdf.com.cn&id=1
            if (domain.IndexOf("/") > 0)
                domain = domain.Substring(0, domain.IndexOf("/"));
            //safsd.asdfasdf.baidu.com.cn
            foreach (string item in rootDomain.Split('|'))
            {
                if (domain.EndsWith(item))
                {
                    domain = domain.Replace(item, "");
                    if (domain.LastIndexOf(".") > 0)//adfasd.asdfas.cn
                    {
                        domain = domain.Replace(domain.Substring(0, domain.LastIndexOf(".") + 1), "");
                    }
                    return domain + item;
                }
                continue;
            }
            return "";
        }
        #region 加载poc
        public static void loadpoc()
        {


            if (string.IsNullOrEmpty(Playpath))
            {
                dd = System.Environment.CurrentDirectory;
                dd += "\\wordlist.txt";
            }
            else
            {
                dd = Playpath;
            }
            StreamReader sr = new StreamReader(dd, Encoding.Default);
            string slinr = "";
            Common.playload.Clear();
            while (!sr.EndOfStream)
            {
                slinr = sr.ReadLine();
                Common.playload.Add(slinr);
            }
            sr.Close();
            if (string.IsNullOrEmpty(rePlaypath))
            {
                dd1 = System.Environment.CurrentDirectory;
                dd1 += "\\wordlist1.txt";
            }
            else
            {
                dd1 = rePlaypath;
            }
            StreamReader resr = new StreamReader(dd1, Encoding.Default);
            string reslinr = "";
            Common.replayload.Clear();
            while (!resr.EndOfStream)
            {
                reslinr = resr.ReadLine();
                Common.replayload.Add(reslinr);
            }
            resr.Close();
        }
        #endregion

    }
}

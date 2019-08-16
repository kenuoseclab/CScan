using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Analysis
    {
        string[] sArray;
        string[] sArray1;
        string[] sArray2;
        string aaa = "";
        public void analysis()
        {
            foreach (var item in Common.Weburllistzx)
            {
                MatchCollection mc = Regex.Matches(item, @"\=(\w+)");
                if (mc.Count != 0)
                {
                    foreach (var item2 in mc)
                    {
                        aaa = item2.ToString();
                    }
                    //遍历playload
                    foreach (var item1 in Common.playload)
                    {
                        Common.poc.Add(item.Replace(aaa, "=" + item1.ToString()));
                    }
                }

            }
        }

    }
}

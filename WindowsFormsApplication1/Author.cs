using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsFormsApplication1
{
    public partial class Author : Form
    {
       
        private Author()
        {
            InitializeComponent();
        }
        private static Author uniqueInstance;
        private static readonly object syncObject = new object();
        public static Author Getinstance() {
            if ( uniqueInstance==null|| uniqueInstance .IsDisposed)
            {
                lock (syncObject)
                {
                    if (uniqueInstance==null|| uniqueInstance .IsDisposed)
                    {
                         uniqueInstance = new Author();
                    }
                   
                }
            }
            return uniqueInstance;
        }
    }
}
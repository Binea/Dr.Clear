using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dentalWebForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            testArgs ta = new testArgs();
            if (args != null&&args.Length>0)
            {
                ta.label1.Text = args[0].ToString();
            }
          
            Application.Run(ta);
        }
    }
}

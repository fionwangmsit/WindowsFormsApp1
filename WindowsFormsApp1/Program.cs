using Demo;
using Starter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1._1._Overview;
using WindowsFormsApp1._4._Disconnected_離線_DataSet;

namespace WindowsFormsApp1
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //解決傳統的Windows Forms在高解析度（High DPI）設定下，所引發的文字模糊問題
            if (System.Environment.OSVersion.Version.Major >= 6) { SetProcessDPIAware(); }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Application.Run(new FrmOverview()); //呼叫 class 建構子方法
            // Application.Run(new  FrmSqlConnection());
            //Application.Run(new  FrmConnected());
            // Application.Run(new FrmTransactionIsolation());

            Application.Run(new FrmProductsCRUD());
            Application.Run(new  FrmDisConnected_離線DataSet());

        }
    }
}

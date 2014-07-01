using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using open;

namespace Plock
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Open zady = new Open();//オープニング画面
            zady.ShowDialog();
            if (zady.eFlag == true)Application.Run(new Form1());
        }
    }
}

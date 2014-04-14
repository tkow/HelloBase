using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using HelloMaze;
//using Plock;
//using PlockForm = Plock.Form1;

namespace open
{
    public partial class Open : Form
    {
        Bitmap bmp;
        Timer timer = new Timer();
        int count = 0;
        int cursolx = 273;
        int cursoly = 360;
        int dy = 54;
        int[,] r;
        int[,] g;
        int[,] b;

        public Open()
        {
            InitializeComponent();
            timer.Interval = 1;  // 更新間隔 (ミリ秒)
            // タイマ用のイベントハンドラを登録
            timer.Tick += new EventHandler(timer_Tick);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            // タイマ用のイベントハンドラをフォームにも登録
            //this.Load += new EventHandler(timer_Tick);
            bmp = Properties.Resources.intro;
            r =new int[bmp.Width, bmp.Height];
            g =new int[bmp.Width, bmp.Height];
            b =new int[bmp.Width, bmp.Height];
            pictureBox1.Controls.Add(label1);//labelの透過処理
            timer.Start();  // タイマ ON
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {

                bmp = Properties.Resources.intro;
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        r[i, j] = (bmp.GetPixel(i, j).R);
                        g[i, j] = (bmp.GetPixel(i, j).G);
                        b[i, j] = (bmp.GetPixel(i, j).B);
                    }
                }
            }

            if (count <= 8)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(r[i, j] / 8 * count, g[i, j] / 8 * count, b[i, j] / 8 * count));
                    }
                }
            }

            else if (count > 8 && count <= 16)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(r[i, j] / 8 * (count - ((count - 8) * 2 - 1)), g[i, j] / 8 * (count - ((count - 8) * 2 - 1)), b[i, j] / 8 * (count - ((count - 8) * 2 - 1))));
                    }
                }
            }

            else if (count > 16 && count <= 22)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(0,0,0));
                    }
                }
                string[] load;
                load = new string[6] { "","ロ", "ー", "ド", "中", "…" }; 
                label1.Text += load[count-17];
            }

            else if (count == 23)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            else if (count > 23)
            {
                bmp = Properties.Resources.title;
                Graphics gra = Graphics.FromImage(bmp);
                gra.FillEllipse(Brushes.White, 273, 360, 10, 10);
                label1.Text = "";
                if (count == 24) timer.Stop();
            }

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
            count++;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            Graphics g = Graphics.FromImage(bmp);
            if (e.KeyCode == Keys.Down && cursoly==360 && count > 23)
            {
                // 実行したい処理
                cursoly += dy;
                g.FillEllipse(Brushes.Black, 273, cursoly-dy, 10, 10);
                g.FillEllipse(Brushes.White, 273, cursoly, 10, 10);
                g.Dispose();
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
            }
            else if (e.KeyCode == Keys.Up && cursoly==414 && count > 23)
            {
                cursoly -= dy;
                g.FillEllipse(Brushes.White, 273, cursoly, 10, 10);
                g.FillEllipse(Brushes.Black, 273, cursoly+dy, 10, 10);
                g.Dispose();
                pictureBox1.Image = bmp;
                pictureBox1.Refresh();
            }
            else if (e.KeyCode == Keys.Enter && count > 23)
            {
                if (cursoly == 360)
                {                  
                    //PlockForm gameForm = new PlockForm();
                    //gameForm.Show();
                    //cFlag = true;
                    
                    this.Close();                    
                }
            }
        }

    }
}

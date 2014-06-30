using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BitmapPaint
{
    public class BitmapPaintClass
    {
        int sqlength;
        int sepalatenum=5;//アニメーションの区切り数
        
        public BitmapPaintClass(int squarelength)
        {
             sqlength= squarelength;
        }

        //int ObjectSelect;(この行は消さないように) //0:Wall,1:player,2:enemy,3:Item,4:Goal
        //int directionselect //1:Up2:Right3:Left4:Down

        public void ResetBoard(bool[,] CanPutObjectOnBoard,Bitmap bmp) {

            for (int i = 0; i < CanPutObjectOnBoard.GetLength(0);i++ )
                for (int j = 0; j < CanPutObjectOnBoard.GetLength(1); j++)
                {
                    if(CanPutObjectOnBoard[i,j]==true){
                    using (Graphics g = Graphics.FromImage(bmp))
                    using(Brush b=new SolidBrush(Color.Empty))
                    {
                        g.FillRectangle(b, i * sqlength, j * sqlength, sqlength, sqlength);
                        g.Dispose();
                    }
                    }
         
                }
        }

        public void ResetObject(ref bool[,] CanPutObjectOnBoard,Bitmap bmp,int x,int y){
            CanPutObjectOnBoard[x, y] = true;
            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush b = new SolidBrush(Color.White))
            {
                g.FillRectangle(b, x * sqlength, y * sqlength, sqlength, sqlength);
                
                g.Dispose();
            }
    }
        public void ResetObject( Bitmap bmp, int x, int y,int i,int j)  //アニメーション用
        {
            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush b = new SolidBrush(Color.White))
            {
                g.FillRectangle(b, x * sqlength + i*sqlength / sepalatenum, y * sqlength + j*sqlength / sepalatenum, sqlength, sqlength);
                g.Dispose();
            }
        }


        /// <summary>
        /// オブジェクトを配置するメソッド
        /// </summary>
        /// <param name="PositionX">配置する横座標</param>
        /// <param name="PositionY">配置する縦座標</param>
        /// <param name="bmp">更新するbitimap</param>
        /// <param name="CanPutObjectOnBoard">ボード上のブールをfalseに変える</param>
        /// <param name="ObjectSelect">オブジェクトの種類を指定</param>
        public void ObjectSetPaint(int PositionX,int PositionY,Bitmap bmp,ref bool[,] CanPutObjectOnBoard,int ObjectSelect) {

            ResetObject(ref CanPutObjectOnBoard, bmp,PositionX,PositionY);

            switch(ObjectSelect){
                
                case 0: using (Graphics g = Graphics.FromImage(bmp))
                    {
						//g.FillRectangle(Brushes.Black, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);
						Bitmap img = Properties.Resources.wall;

						img.MakeTransparent();



						g.DrawImage(img, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);
						img.Dispose();
                        g.Dispose();
                                    CanPutObjectOnBoard[PositionX, PositionY] = false;
                    }
                    break;

                case 1: using(Graphics g=Graphics.FromImage(bmp))
            {
                Bitmap img = Properties.Resources.player1 ;

                img.MakeTransparent();

                    
                  
                g.DrawImage(img, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);
                img.Dispose();
                g.Dispose();
                                    CanPutObjectOnBoard[PositionX, PositionY] = false;
            }
                    break;
                case 2: using (Graphics g = Graphics.FromImage(bmp))
                    {
                        Bitmap img = Properties.Resources.Monster1;
                        img.MakeTransparent();
                        g.DrawImage(img, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);
                        img.Dispose();
                        g.Dispose();
                                    CanPutObjectOnBoard[PositionX, PositionY] = false;
                    }
                    break;
                case 3: using (Graphics g = Graphics.FromImage(bmp))
                    {
						//g.FillEllipse(Brushes.Blue, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);

						Bitmap img = Properties.Resources.items;

						img.MakeTransparent();



						g.DrawImage(img, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);
						img.Dispose();
                        g.Dispose();
                    }
                    break;
                case 4: using (Graphics g = Graphics.FromImage(bmp))
                    {
						//g.FillEllipse(Brushes.Blue, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);
						Bitmap img = Properties.Resources.goal;

						img.MakeTransparent();



						g.DrawImage(img, PositionX * sqlength, PositionY * sqlength, sqlength, sqlength);
						img.Dispose();
                        g.Dispose();
                    }
                    break;
             }
            }





        public void ObjectMovePaint(int PosX, int PosY, Bitmap bmp,int objselect,ref bool[,] CanPutObjectOnBoard,int directionselect,int paintorder)//(アニメーション担当の人が実装)
        {
            if(paintorder==0)  CanPutObjectOnBoard[PosX,PosY]=true;


            
            

            switch (directionselect) {
                case 1:
                    ResetObject(bmp, PosX, PosY, 0, -paintorder);
                    
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        //g.Clear(Color.Empty);
                        Bitmap img;                    
                       switch(objselect){

                           case 0:
                               {
                                   g.FillRectangle(Brushes.Black, PosX * sqlength, PosY * sqlength - (paintorder + 1) * sqlength / sepalatenum, sqlength, sqlength);
                                   g.Dispose();
                                 
                               }break;

                           case 1: 
             
                                 img = Properties.Resources.player1 ;

                                 img.MakeTransparent();

                    

                                       g.DrawImage(img, PosX * sqlength, PosY * sqlength-(paintorder+1)*sqlength/sepalatenum, sqlength, sqlength);
                                       img.Dispose();
                                       g.Dispose();               
                                       break;

                           case 2: img = Properties.Resources.Monster1;
                                       img.MakeTransparent();
                           g.DrawImage(img, PosX * sqlength, PosY * sqlength - (paintorder + 1) * sqlength / sepalatenum, sqlength, sqlength);
                           img.Dispose();
                           g.Dispose();
                           break;

                       }
                      }              

            
            break;


                case 2:
            ResetObject(bmp, PosX, PosY, paintorder, 0);
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //g.Clear(Color.Empty);
                Bitmap img;
                switch (objselect)
                {
                    case 0:
                        {
                            g.FillRectangle(Brushes.Black, PosX * sqlength + (paintorder + 1) * sqlength / sepalatenum, PosY * sqlength, sqlength, sqlength);
                            g.Dispose();

                        } break;


                    case 1: img = Properties.Resources.player1;
                        img.MakeTransparent();
                        g.DrawImage(img, PosX * sqlength + (paintorder + 1) * sqlength / sepalatenum, PosY * sqlength, sqlength, sqlength);
                        img.Dispose();
                        g.Dispose();
                        break;

                    case 2: img = Properties.Resources.Monster1;
                        g.DrawImage(img, PosX * sqlength + (paintorder + 1) * sqlength / sepalatenum, PosY * sqlength, sqlength, sqlength);
                        img.Dispose();
                        g.Dispose();
                        break;

                }
            } break;
                case 3:
                    ResetObject(bmp, PosX, PosY, -paintorder, 0);
               
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        //g.Clear(Color.Empty);
                        Bitmap img;
                        switch (objselect)
                        {
                            case 0:
                                {
                                    g.FillRectangle(Brushes.Black, PosX * sqlength - (paintorder + 1) * sqlength / sepalatenum, PosY * sqlength, sqlength, sqlength);
                                    g.Dispose();

                                } break;

                            case 1:  img = Properties.Resources.player1;
                                img.MakeTransparent();
                                g.DrawImage(img, PosX * sqlength - (paintorder + 1) * sqlength / sepalatenum, PosY * sqlength, sqlength, sqlength);
                                img.Dispose();
                                g.Dispose();
                                break;

                            case 2: img = Properties.Resources.Monster1;
                                img.MakeTransparent();
                                g.DrawImage(img, PosX * sqlength - (paintorder + 1) * sqlength / sepalatenum, PosY * sqlength, sqlength, sqlength);
                                img.Dispose();
                                g.Dispose();
                                break;

                        }
                    } break;

                case 4:
                    ResetObject(bmp, PosX, PosY, 0, +paintorder);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        //g.Clear(Color.Empty);
                        Bitmap img;
                        switch (objselect)
                        {
                            case 0:
                                {
                                    g.FillRectangle(Brushes.Black, PosX * sqlength, PosY * sqlength + (paintorder + 1) * sqlength / sepalatenum, sqlength, sqlength);
                                    g.Dispose();

                                } break;
                            case 1:  img = Properties.Resources.player1;
                                img.MakeTransparent();
                                g.DrawImage(img, PosX * sqlength, PosY * sqlength + (paintorder + 1) * sqlength / sepalatenum, sqlength, sqlength);
                                img.Dispose();
                                g.Dispose();
                                break;

                            case 2: img = Properties.Resources.Monster1;
                                img.MakeTransparent();
                                g.DrawImage(img, PosX * sqlength, PosY * sqlength + (paintorder + 1) * sqlength / sepalatenum, sqlength, sqlength);
                                img.Dispose();
                                g.Dispose();
                                break;

                        }
                    }

                    break;
            }

            //ObjectSetPaint(PositionX,PositionY,bmp,ref CanPutObjectOnBoard,player.ObjectSelectNum); 
        }

        public void RepaintEvent(int posX,int posY,int ObjectSelectNum)//clearされたオブジェクトを再描画するメソッド
        {
        
    }

        public void PointSquare(int x ,int y,Bitmap bmp)//操作キャラを枠で囲む(未実装)
        {

            using (Graphics g = Graphics.FromImage(bmp)) {
                g.DrawRectangle(Pens.Red, x*sqlength, y*sqlength, sqlength, sqlength);
                g.Dispose();
            }

        }



    }
}

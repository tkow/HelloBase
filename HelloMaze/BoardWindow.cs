using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitmapPaint;


namespace HelloMaze
{
    

    /// <summary>
    /// BoardDataを管理するクラス
    /// </summary>
    public partial class  BoardData : Form,BoardPosition
    {

        #region //fieldおよびプロパティ
     private static int squarelength = 40;
     private int BoardSizeWidth ;
     private int BoardSizeHeight;
     private int gridsizewidth ;
     private int gridsizeheight ;
     private bool[,] CanPutObjectOnBoard;
     BoardObject controlobj;
     private List<BoardObject> _ListObjectBoard=new List<BoardObject>(); 
     BitmapPaintClass bmppaint = new BitmapPaintClass(squarelength);
     Bitmap back;
     Bitmap fore;
     Point sp;    //イベント発生時に保持されるマウスの画面座標

     public int BoardPositionXmax {
         get { return gridsizewidth; }
     }

     public int BoardPositionYmax {
         get { return gridsizeheight; }
     }

     public bool[,] BoardObjectCanMove
     {
         get { return CanPutObjectOnBoard; }
         set { CanPutObjectOnBoard = value; }
     }
        public List<BoardObject> ListObjectBoard{
            get { return _ListObjectBoard; }
            set { _ListObjectBoard = value; }
        }

        #endregion
             
        public BoardData() //コンストラクタ
     {
        
         InitializeComponent();

            back = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            fore = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        

            this.pictureBox1.BackgroundImage = back;
            this.pictureBox1.Image = fore;

            Graphics g=Graphics.FromImage(back);
            
             BoardSizeWidth  = pictureBox1.Width;
             BoardSizeHeight = pictureBox1.Height;
             gridsizewidth=BoardSizeWidth/squarelength;
             gridsizeheight = BoardSizeHeight / squarelength;

             CanPutObjectOnBoard=new bool[gridsizewidth, gridsizeheight];


             for (int i = 0; i < gridsizewidth; i++) {
                 for (int j = 0; j < gridsizeheight; j++)
                 {

                     CanPutObjectOnBoard[i, j] = true;

                     
                         g.FillRectangle(Brushes.White, i * squarelength, j * squarelength, squarelength, squarelength);
                    //---------------------------デバック領域
                     //if (i == gridsizewidth / 2 || j == gridsizeheight / 2)
                     //{
                     //    CanPutObjectOnBoard[i, j] = true;
                
                     //{
                     //    g.FillRectangle(Brushes.White, i * squarelength, j * squarelength, squarelength, squarelength);
                     //}
                     //    }
                     //else { CanPutObjectOnBoard[i, j] = false;
                     //{
                     //    g.FillRectangle(Brushes.Black, i * squarelength, j * squarelength, squarelength, squarelength);
                     //}
                     //}
                     //デバック領域エンド
                 }
             }

              controlobj = new PlayerObject(gridsizeheight / 2, gridsizeheight / 2);
              //player = (PlayerObject)controlobj;
              ListObjectBoard.Add(controlobj);
              bmppaint.ObjectSetPaint(controlobj.ObjectPositionX,controlobj.ObjectPositionY,fore,ref CanPutObjectOnBoard,controlobj.ObjectSelectNum);

             pictureBox1.Refresh();
             g.Dispose();
           }
    

        public void GetCursolPosition(int X,int Y,ref int x,ref int y)//クライアントを盤面座標に直すメソッド
       {
           for (int i = 0; i < gridsizewidth; i++)
            {
                for (int j = 0; j < gridsizeheight; j++)
                {
                    if ((i * squarelength < X && X < (i + 1) * squarelength) && (j * squarelength < Y && Y < (j + 1) * squarelength))
                    {
                        x = i;
                        y = j;
                    }
                }
            }
   }


        private void pictureBox1_Click(object sender, EventArgs e)//マウスクリックによるオブジェクトの操作権限の移行
     {
            int x = -1;
            int y = -1;

            Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = pictureBox1.PointToClient(sp);

            GetCursolPosition(cp.X, cp.Y,ref x,ref y);

           squareX.Text = "squareX:" + x;
           squareY.Text = "squareY:" + y;
           
           WallObject wall = new WallObject(x, y);

            if (-1 < x)
            {
                //bmppaint.PointSquare(x,y,fore);
                //pictureBox1.Refresh();

                switch (CanPutObjectOnBoard[x, y])
                {
                    case (false):
                        {
                            if(ListObjectBoard!=null){
                             
                             controlobj =  ListObjectBoard.Find(p => p.ObjectPositionX == x && p.ObjectPositionY == y);
                            }
                            
                            break;
                        }

                    case (true):
                        {
                            //bmppaint.ObjectSetPaint(x, y, fore, ref CanPutObjectOnBoard,wall.ObjectSelectNum);
                            //pictureBox1.Refresh();
                            break;
                        }
                }
                            }
        }
     

        private void BoardData_KeyDown(object sender, KeyEventArgs e) //十字キー入力後オブジェクトを移動するメソッド
     {
         if (e.KeyCode == Keys.Right && (controlobj.ObjectPositionX<BoardPositionXmax-1&&BoardObjectCanMove[controlobj.ObjectPositionX+1,controlobj.ObjectPositionY]==true))
            {
                for (int i = 0; i < 5; i++)
                {
                    bmppaint.ObjectMovePaint(controlobj.ObjectPositionX, controlobj.ObjectPositionY, fore, controlobj.ObjectSelectNum, ref CanPutObjectOnBoard, 2, i);
                    fore.MakeTransparent(Color.White);
                    pictureBox1.Refresh();
                    System.Threading.Thread.Sleep(1);

                }

                controlobj.moveRight();
                CanPutObjectOnBoard[controlobj.ObjectPositionX, controlobj.ObjectPositionY] = false;
            }
            if (e.KeyCode == Keys.Left && (0<controlobj.ObjectPositionX&&BoardObjectCanMove[controlobj.ObjectPositionX-1,controlobj.ObjectPositionY]==true))
            {
                
                for (int i = 0; i < 5; i++)
                {
                    bmppaint.ObjectMovePaint(controlobj.ObjectPositionX, controlobj.ObjectPositionY, fore, controlobj.ObjectSelectNum, ref CanPutObjectOnBoard, 3, i);
                    fore.MakeTransparent(Color.White);    
                    pictureBox1.Refresh();
                    System.Threading.Thread.Sleep(1);

                }
                controlobj.moveLeft();
                CanPutObjectOnBoard[controlobj.ObjectPositionX, controlobj.ObjectPositionY] = false;
            } 
            if (e.KeyCode == Keys.Up && (0 < controlobj.ObjectPositionY && BoardObjectCanMove[controlobj.ObjectPositionX, controlobj.ObjectPositionY - 1] == true))
            {
                for (int i = 0; i < 5; i++)
                {
                    bmppaint.ObjectMovePaint(controlobj.ObjectPositionX,controlobj.ObjectPositionY,fore,controlobj.ObjectSelectNum,ref CanPutObjectOnBoard,1,i);
                    fore.MakeTransparent(Color.White);
                    pictureBox1.Refresh();
                    System.Threading.Thread.Sleep(1);

                }
                controlobj.moveUp();
                CanPutObjectOnBoard[controlobj.ObjectPositionX, controlobj.ObjectPositionY] = false;
            }
            if (e.KeyCode == Keys.Down && (controlobj.ObjectPositionY < BoardPositionYmax - 1 && BoardObjectCanMove[controlobj.ObjectPositionX, controlobj.ObjectPositionY + 1] == true))
            {      for (int i = 0; i < 5; i++)
                {
                    bmppaint.ObjectMovePaint(controlobj.ObjectPositionX, controlobj.ObjectPositionY, fore, controlobj.ObjectSelectNum, ref CanPutObjectOnBoard, 4, i);
                    fore.MakeTransparent(Color.White);    
                    pictureBox1.Refresh();
                    System.Threading.Thread.Sleep(1);
                }
                controlobj.moveDown();
                CanPutObjectOnBoard[controlobj.ObjectPositionX, controlobj.ObjectPositionY] = false;
            }
              

  
        }


        private void MoveOperation(BoardObject obj,int directionselect,int repititionnum)  //ブロックスクリプト用移動命令
     {

            CanPutObjectOnBoard[controlobj.ObjectPositionX, controlobj.ObjectPositionY] = true;
            switch(directionselect){
                case 1: obj.moveUp(); break;

                case 2: obj.moveRight(); break;

                case 3: obj.moveLeft(); break;

                case 4: obj.moveDown(); break;
        }
            bmppaint = new BitmapPaintClass(squarelength);
            bmppaint.ObjectSetPaint(obj.ObjectPositionX, obj.ObjectPositionY, fore, ref CanPutObjectOnBoard, obj.ObjectSelectNum);
        }


        public void ObjectSet(int x,int y,int ObjectSelectNum)       //ブロックスクリプト用配置命令
        {
            if (controlobj.ObjectPositionX == x && controlobj.ObjectPositionY == y) { return; }
            CanPutObjectOnBoard[x, y] = true;
            BoardObject NewObject = new BoardObject();
            switch (ObjectSelectNum)
            {
                case 0: NewObject = new WallObject(x, y); ListObjectBoard.Add(NewObject);
                    break;
                case 1: if (controlobj is PlayerObject == false) CanPutObjectOnBoard[controlobj.ObjectPositionX, controlobj.ObjectPositionY] = false;

                    controlobj = new PlayerObject(x, y);
                    NewObject = controlobj; ListObjectBoard[0] = controlobj;
                    break;
                case 2: NewObject = new EnemyObject(x, y); ListObjectBoard.Add(NewObject);
                    break;
                case 3: NewObject = new ItemObject(x, y); ListObjectBoard.Add(NewObject);
                    break;
                case 4: NewObject = new GoalObject(x, y); ListObjectBoard.Add(NewObject);
                    break;
            }
            if (NewObject is GoalObject || NewObject is ItemObject)
            {
                bmppaint.ObjectSetPaint(NewObject.ObjectPositionX, NewObject.ObjectPositionY, back, ref CanPutObjectOnBoard, NewObject.ObjectSelectNum);
            }
            else
            {
                bmppaint.ObjectSetPaint(NewObject.ObjectPositionX, NewObject.ObjectPositionY, fore, ref CanPutObjectOnBoard, NewObject.ObjectSelectNum);
            }
            pictureBox1.Refresh();

        }

　　　　#region  //コンテキストメニュー関連のメソッド
        private void PutPlayerToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)  //コンテキストメニューで主人公を置く
        {
            int x = -1;
            int y = -1;
            int objectselectnum = 1;

            bmppaint.ResetObject(ref CanPutObjectOnBoard, fore, ListObjectBoard.Find(p => p is PlayerObject).ObjectPositionX, ListObjectBoard.Find(p => p is PlayerObject).ObjectPositionY);

            Point cp = Object_Control_Menu.SourceControl.PointToClient(sp);
            GetCursolPosition(cp.X, cp.Y, ref x, ref y);
            if (x > -1)
            {
                ObjectSet(x, y, objectselectnum);
            }
        }

        private void PutEnemyToolStripMenuItem_Click(object sender, EventArgs e)  //コンテキストメニューで敵を置く
        {
            int x = -1;
            int y = -1;
            int objectselectnum = 2;


            Point cp = Object_Control_Menu.SourceControl.PointToClient(sp);
            GetCursolPosition(cp.X, cp.Y, ref x, ref y);
            if (x > -1)
            {
                ObjectSet(x, y, objectselectnum);
            }
        }
      
        private void Object_Control_Menu_Opened(object sender, EventArgs e)//コンテキストメニューを開いた時のマウス座標を記録
        {
            sp = Control.MousePosition;
        }

        private void PutWalltoolStripMenuItem2_Click(object sender, EventArgs e)//コンテキストメニューで壁を置く
        {
            int x = -1;
            int y = -1;
            int objectselectnum = 0;


            Point cp = Object_Control_Menu.SourceControl.PointToClient(sp);
            GetCursolPosition(cp.X, cp.Y, ref x, ref y);
            if (x > -1)
            {
                ObjectSet(x, y, objectselectnum);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)//コンテキストメニューでオブジェクトを削除
        {

            int x = -1;
            int y = -1;

            Point cp = Object_Control_Menu.SourceControl.PointToClient(sp);
            GetCursolPosition(cp.X, cp.Y, ref x, ref y);
            
            if (x > -1)
            {
                if ((controlobj.ObjectPositionX == x && controlobj.ObjectPositionY == y) ||(ListObjectBoard.Find(p=> p is PlayerObject).ObjectPositionX==x&&ListObjectBoard.Find(p=> p is PlayerObject ).ObjectPositionY==y)) { return; }

                if (ListObjectBoard.Find(p => p.ObjectPositionX == x && p.ObjectPositionY == y) is PlayerObject 
                    ||ListObjectBoard.Find(p => p.ObjectPositionX == x && p.ObjectPositionY == y) is EnemyObject)
                {
                ListObjectBoard.RemoveAll(p => p.ObjectPositionX == x && p.ObjectPositionY == y);
                bmppaint.ResetObject(ref CanPutObjectOnBoard, fore, x, y);
                }
                else {
                ListObjectBoard.RemoveAll(p => p.ObjectPositionX == x && p.ObjectPositionY == y);    
                bmppaint.ResetObject(ref CanPutObjectOnBoard, back, x, y); }
                pictureBox1.Refresh();
            }
            }

        private void PutItemToolStripMenuItem_Click(object sender, EventArgs e)//コンテキストメニューでアイテムを置く
        {
            int x = -1;
            int y = -1;
            int objectselectnum = 3;


            Point cp = Object_Control_Menu.SourceControl.PointToClient(sp);
            GetCursolPosition(cp.X, cp.Y, ref x, ref y);
            if (x > -1)
            {
                ObjectSet(x, y, objectselectnum);
            }

        }
     

        private void GoaltoolStripMenuItem2_Click(object sender, EventArgs e) //Goalを置く
        {
            int x = -1;
            int y = -1;
            int objectselectnum = 4;


            Point cp = Object_Control_Menu.SourceControl.PointToClient(sp);
            GetCursolPosition(cp.X, cp.Y, ref x, ref y);
            if (x > -1)
            {
                ObjectSet(x, y, objectselectnum);
            }

        }
    #endregion
    }


    interface BoardPosition //ボードの仕様はBoardDataクラス以外で変更不可，外部からのアクセスを制限
    {
        int BoardPositionXmax { get; }
        int BoardPositionYmax { get; }
        bool[,] BoardObjectCanMove { get; set; }
        List<BoardObject> ListObjectBoard { get; set; }
    }

}

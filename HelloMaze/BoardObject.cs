using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmapPaint;

namespace HelloMaze
{
    /// <summary>
    /// Boardに配置されるオブジェクト操作を行うクラス
    /// </summary>
    [Serializable]
    public class BoardObject 
    {
        /// <summary>
        /// オブジェクトの横マス座標
        /// </summary>
        internal int ObjectPositionX;
        /// <summary>
        /// オブジェクトの縦マス座標
        /// </summary>
        internal int ObjectPositionY;
         /// <summary>
         /// オブジェクトの種類を識別する番号
         /// <remarks>
         /// 0:壁,1:プレイヤー,2:敵,3:アイテム.4:ゴール
         /// </remarks>
         /// </summary>
        internal int ObjectSelectNum;  //0:Wall,1:Player,2:Enemy,3:Item,4:Goal

        internal bool OperateMove=false; //ターンの間にAIまたはプレイヤーが動いたかどうかの判定

        public BoardObject()
        {

            ObjectPositionX = 0;
            ObjectPositionY = 0;
            ObjectSelectNum = -1;
        }

       public BoardObject(int X,int Y)
        {
            ObjectPositionX = X;
            ObjectPositionY = Y;
        }

        /// <summary>
        /// オブジェクトを上に移動させる
        /// </summary>
       internal void moveUp() { ObjectPositionY--; }
       internal void moveDown() { ObjectPositionY++; }
       internal void moveRight() {ObjectPositionX++; }
       internal void moveLeft() { ObjectPositionX--; }
    

    }
    [Serializable]
    class PlayerObject : BoardObject
    {
       

        public PlayerObject() {
            //ObjectPositionX=1;
            //ObjectPositionY=1;
        
            //if (BoardData.BoardPosition.BoardPositionCanMove[ObjectPositionX, ObjectPositionY])
            //{ }
            //else {}
        }

        public PlayerObject(int X,int Y)
        {
            ObjectPositionX = X;
            ObjectPositionY = Y;
            ObjectSelectNum=1;
        }


    }
    [Serializable]
    class WallObject :BoardObject
    { 
     public WallObject(int X,int Y)
        {
            ObjectPositionX = X;
            ObjectPositionY = Y;
            ObjectSelectNum = 0;
         }
    }
    [Serializable]
    class EnemyObject : BoardObject
    { 
     public EnemyObject(int X,int Y)
        {
            ObjectPositionX = X;
            ObjectPositionY = Y;
            ObjectSelectNum = 2;
         }
    }
    [Serializable]
    class ItemObject : BoardObject
    {
        public ItemObject(int X,int Y)
        {
            ObjectPositionX = X;
            ObjectPositionY = Y;
            ObjectSelectNum = 3;
        }
        }
    [Serializable]
    class GoalObject : BoardObject
    { 
    public GoalObject(int X,int Y)
        {
            ObjectPositionX = X;
            ObjectPositionY = Y;
            ObjectSelectNum = 4;
        }
    }


}

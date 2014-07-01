using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plock
{
    using GameData = HelloMaze.BoardData;


    public class MethodWrapper
    {
        Method method;//execute(ゲームの更新用)
        public MethodWrapper()
        {
            method = null;
        }

        /// <summary>
        /// methodをStringで設定する
        /// </summary>
        /// <param name="code"></param>
        public void set(String code)
        {
            method = GameMethodProperty.getDoMethodDictionary().Single(_method => code.Contains(_method.Key)).Value;//methodをセットする
            method.set(code);//制御文のisMethodをセットする
        }

        /// <summary>
        /// ReturnMethodを直接指定して設定する
        /// </summary>
        /// <param name="code"></param>
        public void setReturnMethod()
        {
            method = new baseGameMethodProperty.ReturnMethod();
        }

        public GameData execute(GameData game)
        {
            return method.execute(game);
        }

        /// <summary>
        /// 次のcurrentCodeの場所を返す
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public MoveTo getMoveTo(GameData game)
        {
            return method.getMoveTo(game);
        }

        public bool isControlMethod()
        {
            return method is ControlMethod;
        }

        public bool isWhileMethod()
        {
            return method is baseGameMethodProperty.WhileMethod;
        }
    }

    abstract internal class Method
    {
        public virtual GameData execute(GameData game)//受け取ったゲームのデータを更新して返すメソッドを実装する必要がある
        {
            throw new NotImplementedException();
        }

        public virtual MoveTo getMoveTo(GameData game)
        {
            return MoveTo.NEXT;//通常はNEXT
        }

        internal virtual void set(string code)
        {

        }
    }

    abstract internal class ControlMethod : Method//制御文のメソッド
    {
        internal IsMethod isMethod;
        public override GameData execute(GameData game)
        {
            return game;
        }

        /// <summary>
        /// フィールドを設定する
        /// </summary>
        /// <param name="code"></param>
        internal override void set(string code)
        {
            isMethod = GameMethodProperty.getIsMethodDictionary().Single(_method => code.Contains(_method.Key)).Value;
        }
    }

    abstract internal class IsMethod
    {
        public virtual bool execute(GameData game)//ゲームのデータを受け取ってboolを返すメソッド
        {
            throw new NotImplementedException();
        }
    }


    class baseGameMethodProperty
    {
        public static Dictionary<string, Method> getDoMethodDictionary()
        {
            Dictionary<string, Method> methodDictionary = new Dictionary<string, Method>();
            methodDictionary.Add("もし", new IfMethod());
            methodDictionary.Add("繰り返す", new WhileMethod());
            methodDictionary.Add("}", new EmptyMethod());
            return methodDictionary;
        }


        public class IfMethod : ControlMethod
        {
            public override MoveTo getMoveTo(GameData game)
            {
                if (isMethod.execute(game)) return MoveTo.COLLEE;
                return MoveTo.NEXT;
            }
        }

        public class WhileMethod : ControlMethod
        {
            public override MoveTo getMoveTo(GameData game)
            {
                if (isMethod.execute(game)) return MoveTo.COLLEE;
                return MoveTo.NEXT;
            }
        }

        //何もしないメソッド。　例えば、While分の中かっこの終わり｝とか。次のcurrentCodeの場所が呼び出し元コードになることに注意。
        public class ReturnMethod : Method
        {
            public override GameData execute(GameData game)
            {
                return game;
            }
            public override MoveTo getMoveTo(GameData game)
            {
                return MoveTo.COLLER;
            }
        }
        //何もしないメソッド。　例えば、if文の中かっこの終わり｝とか。表示上は残しておいた方が見やすいが、何もしない行用。
        public class EmptyMethod : Method
        {
            public override GameData execute(GameData game)
            {
                return game;
            }
            public override MoveTo getMoveTo(GameData game)
            {
                return MoveTo.COLLERNEXT;
            }
        }
    }
    public enum MoveTo
    {
        NEXT, COLLERNEXT, COLLEE ,COLLER
    }
}

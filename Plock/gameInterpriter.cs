using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plock
{
    using GameData = HelloMaze.BoardData;//TODO:利用したいゲームのデータクラスを登録

    class GameInterpriter
    {
        CodeList currentCode;

        public GameData run(String code, GameData game)
        {
            build(code);

            while (true)
            {
                game = currentCode.execute(game);
                currentCode = currentCode.getMoveTo(game);
                if (currentCode.isEnd()) break;
            }
            return game;
        }

        internal GameData runOneLine(string code, GameData game)
        {
            if (currentCode.isEnd()) return game;

            game = currentCode.execute(game);
            currentCode = currentCode.getMoveTo(game);
            return game;
        }

        internal void build(string code)
        {
            currentCode = new CodeList();
            currentCode.setValue(code);
        }
    }

    /// <summary>
    /// コードの双方向リンク
    /// </summary>
    class CodeList
    {
        String _value;
        MethodWrapper value;
        CodeList nextCode;//後に実行されるコード
        CodeList previousCode;//前に実行されたコード
        CodeList collerCode;//このコードの呼び出し元
        CodeList colleeCode;//このコードの呼び出し先

        public CodeList()
        {
            value = new MethodWrapper();
            nextCode = null;
            previousCode = null;
            collerCode = null;
            colleeCode = null;
        }
        /// <summary>
        /// メソッドを実行する
        /// </summary>
        /// <param name="game">gameにvalue（のメソッド）を実行させる</param>
        /// <returns>実行後のgameを返す</returns>
        internal GameData execute(GameData game)
        {
            return value.execute(game);
        }

        /// <summary>
        /// 次に実行するべき位置のコードリストを返す
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        internal CodeList getMoveTo(GameData game)
        {
            if (value.isControlMethod()) return getCodeList(value.getMoveTo(game));//制御文の時は要検討（制御文による）
            if(nextCode!=null)return nextCode;//次のコードがあるときは次のコード
            return getCodeList(value.getMoveTo(game));//次のコードがない時は要検討（コードによる）
        }

        /// <summary>
        /// Enum型の位置に対応するコードリストを返す
        /// </summary>
        /// <param name="moveTo">移動先を示すEnum型</param>
        /// <returns>移動先のコードリスト</returns>
        internal CodeList getCodeList(MoveTo moveTo)
        {
            switch (moveTo)
            {
                case MoveTo.NEXT:
                    return nextCode;
                case MoveTo.COLLERNEXT:
                    return collerCode.nextCode;
                case MoveTo.COLLEE:
                    return colleeCode;
                case MoveTo.COLLER:
                    return collerCode;
            }
            return null;
        }

        /// <summary>
        /// 文字列を受け取って、実行できるようにメソッドを設定する
        /// </summary>
        /// <param name="code"></param>
        public void setValue(String code)
        {
            var codeQueue = splitToQueue(code);//前処理
            setValue(codeQueue);//移譲
        }

        /// <summary>
        /// キューに格納された文字列を受け取って、実行できるようにメソッドを設定する
        /// </summary>
        /// <param name="codeQueue"></param>
        void setValue(Queue<String> codeQueue)
        {

            if (codeQueue.Count == 0) return;

            _value = codeQueue.Dequeue();

            if ( _value.Contains("}") && collerCode.value.isWhileMethod()) 
                value.setReturnMethod();//While文の終わりの}は特殊（呼び出し元のisMethodで次に実行するコードが変わる）なので場合分け
            else value.set(_value);

            if (_value.Contains("{"))
            {
                //次は、呼び出し先に値をセットする
                colleeCode = new CodeList();
                colleeCode.collerCode = this;

                colleeCode.setValue(codeQueue);
            }
            else if (_value.Contains("}"))
            {
                //次は、呼び出し元の後のコードに値をセットする
                collerCode.nextCode = new CodeList();
                collerCode.nextCode.previousCode = collerCode;
                collerCode.nextCode.collerCode = collerCode.collerCode;

                collerCode.nextCode.setValue(codeQueue);
            }
            else
            {
                //次は、後のコードに値をセットする
                nextCode = new CodeList();
                nextCode.previousCode = this;
                nextCode.collerCode = this.collerCode;

                nextCode.setValue(codeQueue);
            }
        }

        /// <summary>
        /// コードを/r/nごとに区切って、順次キューに格納して返す
        /// /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Queue<string> splitToQueue(String str)
        {
            string[] separator = { "\r\n" };
            string[] texts = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Queue<String> codeQueue = new Queue<string>();
            foreach (String text in texts)
            {
                codeQueue.Enqueue(text);
            }
            return codeQueue;
        }

        /// <summary>
        /// 一番最後のコード（の次）ならtrueを返す
        /// </summary>
        /// <returns></returns>
        public bool isEnd()
        {
            return _value == null;
        }
    }

}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plock
{
    using GameForm = HelloMaze.BoardData;//TODO:利用したいゲームのFormを登録
    using System.Threading;

    public partial class Form1 : Form
    {
        GameForm gameForm;

        GameInterpriter gameInterpriter;

        Thread forRunAll;

        public Form1()
        {
            InitializeComponent();

            //ゲームのFormのインスタンスを生成
            gameForm = new GameForm();
            gameForm.Show();

            //インタプリタの実体を生成
            gameInterpriter = new GameInterpriter();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ゲームのデータクラスの更新
            if (forRunAll != null && forRunAll.IsAlive)
            {
                //無視する
            }
            else
            {
                forRunAll = new Thread(new ThreadStart(() => { gameInterpriter.run(textBox1.Text, gameForm); }));
                forRunAll.Start();//開始する
            }

            //ゲームのデータクラスの更新
            //gameForm=gameInterpriter.run(textBox1.Text, gameForm);

            //表示の更新(refreshObjectは未完成のメソッド)
            //gameForm.refreshObject(gameForm.controlobj);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ゲームのデータクラスの更新
            gameForm = gameInterpriter.runOneLine(textBox1.Text, gameForm);
            ////表示の更新(refreshObjectは未完成のメソッド)
            //gameForm.refreshObject(gameForm.controlobj);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gameInterpriter.build(textBox1.Text);
        }
    }
}

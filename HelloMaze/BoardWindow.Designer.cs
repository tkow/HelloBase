namespace HelloMaze
{
    partial class BoardData
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Object_Control_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.主人公を置くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.敵を置くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アイテムを置くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.壁を置くtoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareX = new System.Windows.Forms.Label();
            this.squareY = new System.Windows.Forms.Label();
            this.save_button = new System.Windows.Forms.Button();
            this.load_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Object_Control_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.Object_Control_Menu;
            this.pictureBox1.Location = new System.Drawing.Point(689, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(750, 720);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Object_Control_Menu
            // 
            this.Object_Control_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主人公を置くToolStripMenuItem,
            this.敵を置くToolStripMenuItem,
            this.アイテムを置くToolStripMenuItem,
            this.壁を置くtoolStripMenuItem2,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.削除ToolStripMenuItem});
            this.Object_Control_Menu.Name = "Object_Control_Menu";
            this.Object_Control_Menu.Size = new System.Drawing.Size(178, 178);
            this.Object_Control_Menu.Opened += new System.EventHandler(this.Object_Control_Menu_Opened);
            // 
            // 主人公を置くToolStripMenuItem
            // 
            this.主人公を置くToolStripMenuItem.Name = "主人公を置くToolStripMenuItem";
            this.主人公を置くToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
            this.主人公を置くToolStripMenuItem.Text = "主人公を置く";
            this.主人公を置くToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PutPlayerToolStripMenuItem_MouseDown);
            // 
            // 敵を置くToolStripMenuItem
            // 
            this.敵を置くToolStripMenuItem.Name = "敵を置くToolStripMenuItem";
            this.敵を置くToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
            this.敵を置くToolStripMenuItem.Text = "敵を置く";
            this.敵を置くToolStripMenuItem.Click += new System.EventHandler(this.PutEnemyToolStripMenuItem_Click);
            // 
            // アイテムを置くToolStripMenuItem
            // 
            this.アイテムを置くToolStripMenuItem.Name = "アイテムを置くToolStripMenuItem";
            this.アイテムを置くToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
            this.アイテムを置くToolStripMenuItem.Text = "アイテムを置く";
            this.アイテムを置くToolStripMenuItem.Click += new System.EventHandler(this.PutItemToolStripMenuItem_Click);
            // 
            // 壁を置くtoolStripMenuItem2
            // 
            this.壁を置くtoolStripMenuItem2.Name = "壁を置くtoolStripMenuItem2";
            this.壁を置くtoolStripMenuItem2.Size = new System.Drawing.Size(177, 28);
            this.壁を置くtoolStripMenuItem2.Text = "壁を置く";
            this.壁を置くtoolStripMenuItem2.Click += new System.EventHandler(this.PutWalltoolStripMenuItem2_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 28);
            this.toolStripMenuItem2.Text = "ゴールを作る";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.GoaltoolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            this.削除ToolStripMenuItem.Size = new System.Drawing.Size(177, 28);
            this.削除ToolStripMenuItem.Text = "削除";
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // squareX
            // 
            this.squareX.AutoSize = true;
            this.squareX.Location = new System.Drawing.Point(549, 49);
            this.squareX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.squareX.Name = "squareX";
            this.squareX.Size = new System.Drawing.Size(73, 18);
            this.squareX.TabIndex = 1;
            this.squareX.Text = "squareX:";
            // 
            // squareY
            // 
            this.squareY.AutoSize = true;
            this.squareY.Location = new System.Drawing.Point(549, 80);
            this.squareY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.squareY.Name = "squareY";
            this.squareY.Size = new System.Drawing.Size(73, 18);
            this.squareY.TabIndex = 2;
            this.squareY.Text = "squareY:";
            // 
            // save_button
            // 
            this.save_button.CausesValidation = false;
            this.save_button.Location = new System.Drawing.Point(385, 457);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(156, 45);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "save";
            this.save_button.UseCompatibleTextRendering = true;
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // load_button
            // 
            this.load_button.CausesValidation = false;
            this.load_button.Location = new System.Drawing.Point(385, 530);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(156, 45);
            this.load_button.TabIndex = 4;
            this.load_button.Text = "load";
            this.load_button.UseVisualStyleBackColor = true;
            this.load_button.Click += new System.EventHandler(this.load_button_Click);
            // 
            // BoardData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 847);
            this.Controls.Add(this.load_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.squareY);
            this.Controls.Add(this.squareX);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BoardData";
            this.Text = "迷路を解こう";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BoardData_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Object_Control_Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label squareX;
        private System.Windows.Forms.Label squareY;
        private System.Windows.Forms.ContextMenuStrip Object_Control_Menu;
        private System.Windows.Forms.ToolStripMenuItem 主人公を置くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 敵を置くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アイテムを置くToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 壁を置くtoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button load_button;
    }
}


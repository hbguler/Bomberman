namespace DynamicBomberman {
    partial class mapForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mapForm));
            this.topWall = new System.Windows.Forms.PictureBox();
            this.rightWall = new System.Windows.Forms.PictureBox();
            this.bottomWall = new System.Windows.Forms.PictureBox();
            this.leftWall = new System.Windows.Forms.PictureBox();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.mapPanel = new System.Windows.Forms.Panel();
            this.playerPB = new System.Windows.Forms.PictureBox();
            this.generatePattern = new System.Windows.Forms.Button();
            this.collisionTextBox = new System.Windows.Forms.TextBox();
            this.playerXY = new System.Windows.Forms.TextBox();
            this.wallCollison = new System.Windows.Forms.TextBox();
            this.generateBricks = new System.Windows.Forms.Button();
            this.monsterGenerator = new System.Windows.Forms.Button();
            this.monsterTimer = new System.Windows.Forms.Timer(this.components);
            this.exploTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.topWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftWall)).BeginInit();
            this.mapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerPB)).BeginInit();
            this.SuspendLayout();
            // 
            // topWall
            // 
            this.topWall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topWall.BackgroundImage")));
            this.topWall.Dock = System.Windows.Forms.DockStyle.Top;
            this.topWall.Location = new System.Drawing.Point(0, 0);
            this.topWall.Name = "topWall";
            this.topWall.Size = new System.Drawing.Size(576, 30);
            this.topWall.TabIndex = 1;
            this.topWall.TabStop = false;
            // 
            // rightWall
            // 
            this.rightWall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightWall.BackgroundImage")));
            this.rightWall.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightWall.Location = new System.Drawing.Point(546, 30);
            this.rightWall.Name = "rightWall";
            this.rightWall.Size = new System.Drawing.Size(30, 428);
            this.rightWall.TabIndex = 2;
            this.rightWall.TabStop = false;
            // 
            // bottomWall
            // 
            this.bottomWall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bottomWall.BackgroundImage")));
            this.bottomWall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomWall.Location = new System.Drawing.Point(0, 428);
            this.bottomWall.Name = "bottomWall";
            this.bottomWall.Size = new System.Drawing.Size(546, 30);
            this.bottomWall.TabIndex = 3;
            this.bottomWall.TabStop = false;
            // 
            // leftWall
            // 
            this.leftWall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftWall.BackgroundImage")));
            this.leftWall.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftWall.Location = new System.Drawing.Point(0, 30);
            this.leftWall.Name = "leftWall";
            this.leftWall.Size = new System.Drawing.Size(30, 398);
            this.leftWall.TabIndex = 4;
            this.leftWall.TabStop = false;
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Interval = 10;
            this.animationTimer.Tick += new System.EventHandler(this.animationTick);
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mapPanel.BackgroundImage = global::DynamicBomberman.Properties.Resources.background1;
            this.mapPanel.Controls.Add(this.playerPB);
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(30, 30);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(516, 398);
            this.mapPanel.TabIndex = 9;
            // 
            // playerPB
            // 
            this.playerPB.Location = new System.Drawing.Point(0, 0);
            this.playerPB.Name = "playerPB";
            this.playerPB.Size = new System.Drawing.Size(30, 30);
            this.playerPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPB.TabIndex = 0;
            this.playerPB.TabStop = false;
            // 
            // generatePattern
            // 
            this.generatePattern.Location = new System.Drawing.Point(10, 1);
            this.generatePattern.Name = "generatePattern";
            this.generatePattern.Size = new System.Drawing.Size(50, 23);
            this.generatePattern.TabIndex = 10;
            this.generatePattern.Text = "Pattern";
            this.generatePattern.UseVisualStyleBackColor = true;
            this.generatePattern.Click += new System.EventHandler(this.generatePattern_Click);
            // 
            // collisionTextBox
            // 
            this.collisionTextBox.Location = new System.Drawing.Point(256, 3);
            this.collisionTextBox.Name = "collisionTextBox";
            this.collisionTextBox.ReadOnly = true;
            this.collisionTextBox.Size = new System.Drawing.Size(100, 20);
            this.collisionTextBox.TabIndex = 11;
            // 
            // playerXY
            // 
            this.playerXY.Location = new System.Drawing.Point(176, 3);
            this.playerXY.Name = "playerXY";
            this.playerXY.Size = new System.Drawing.Size(74, 20);
            this.playerXY.TabIndex = 12;
            // 
            // wallCollison
            // 
            this.wallCollison.Location = new System.Drawing.Point(362, 4);
            this.wallCollison.Name = "wallCollison";
            this.wallCollison.Size = new System.Drawing.Size(81, 20);
            this.wallCollison.TabIndex = 13;
            // 
            // generateBricks
            // 
            this.generateBricks.Location = new System.Drawing.Point(66, 1);
            this.generateBricks.Name = "generateBricks";
            this.generateBricks.Size = new System.Drawing.Size(45, 23);
            this.generateBricks.TabIndex = 14;
            this.generateBricks.Text = "Brick";
            this.generateBricks.UseVisualStyleBackColor = true;
            this.generateBricks.Click += new System.EventHandler(this.generateBricks_Click);
            // 
            // monsterGenerator
            // 
            this.monsterGenerator.Location = new System.Drawing.Point(117, 1);
            this.monsterGenerator.Name = "monsterGenerator";
            this.monsterGenerator.Size = new System.Drawing.Size(53, 23);
            this.monsterGenerator.TabIndex = 15;
            this.monsterGenerator.Text = "Monster";
            this.monsterGenerator.UseVisualStyleBackColor = true;
            this.monsterGenerator.Click += new System.EventHandler(this.monsterGenerator_Click);
            // 
            // monsterTimer
            // 
            this.monsterTimer.Interval = 25;
            this.monsterTimer.Tick += new System.EventHandler(this.monsterTimer_Tick);
            // 
            // exploTimer
            // 
            this.exploTimer.Interval = 2000;
            this.exploTimer.Tick += new System.EventHandler(this.exploTimer_Tick);
            // 
            // mapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 458);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.wallCollison);
            this.Controls.Add(this.collisionTextBox);
            this.Controls.Add(this.monsterGenerator);
            this.Controls.Add(this.generateBricks);
            this.Controls.Add(this.playerXY);
            this.Controls.Add(this.generatePattern);
            this.Controls.Add(this.leftWall);
            this.Controls.Add(this.bottomWall);
            this.Controls.Add(this.rightWall);
            this.Controls.Add(this.topWall);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(166, 188);
            this.Name = "mapForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapForm_KeyDown);
            this.Resize += new System.EventHandler(this.mapForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.topWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftWall)).EndInit();
            this.mapPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playerPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox topWall;
        private System.Windows.Forms.PictureBox rightWall;
        private System.Windows.Forms.PictureBox bottomWall;
        private System.Windows.Forms.PictureBox leftWall;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Button generatePattern;
        private System.Windows.Forms.TextBox collisionTextBox;
        private System.Windows.Forms.TextBox playerXY;
        private System.Windows.Forms.TextBox wallCollison;
        private System.Windows.Forms.Button generateBricks;
        private System.Windows.Forms.Button monsterGenerator;
        private System.Windows.Forms.PictureBox playerPB;
        private System.Windows.Forms.Timer monsterTimer;
        private System.Windows.Forms.Timer exploTimer;
    }
}


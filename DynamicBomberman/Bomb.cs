using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicBomberman {
    class Bomb {

        private int x, y;
        private int width, height;
        private PictureBox bombPB;      

        public Bomb(int x, int y, int width, int height, Panel panel) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            bombPB = new PictureBox();
            bombPB.Image = DynamicBomberman.Properties.Resources.pixBomb;
            bombPB.SizeMode = PictureBoxSizeMode.StretchImage;
            bombPB.Size = new System.Drawing.Size(width, height);
            bombPB.Location = new System.Drawing.Point(x, y);
            panel.Controls.Add(bombPB);
        }

        public int X {
            get { return x; }
            set { x = value; }
        }
        public int Y {
            get { return y; }
            set { y = value; }
        }
        public int Width {
            get { return width; }
            set { width = value; }
        }
        public int Height {
            get { return height; }
            set { height = value; }
        }
        public PictureBox BombPB {
            get { return bombPB; }
            set { bombPB = value; }
        }
    }
}

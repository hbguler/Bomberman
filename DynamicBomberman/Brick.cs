using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicBomberman {
    class Brick {
        private int x, y;
        private int width, height;
        private PictureBox brickPB;

        public Brick(int x, int y, int width, int height, Panel panel) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            brickPB = new PictureBox();
            brickPB.Size = new System.Drawing.Size(width, height);
            brickPB.Image = DynamicBomberman.Properties.Resources.brick;
            brickPB.Location = new System.Drawing.Point(x, y);

            panel.Controls.Add(brickPB);
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
        public PictureBox BrickPB {
            get { return brickPB; }
            set { brickPB = value; }
        }
    }
}

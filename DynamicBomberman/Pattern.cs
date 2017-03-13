using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicBomberman {
    class Pattern {
        private int x, y;
        private int width, height;      
        private PictureBox patternPB;
        

        public Pattern(int X, int Y, int patternWidth, int patternHeight, int spaceWidth, int spaceHeight, Panel panel) {
            x = X;
            y = X;
            width = patternWidth;
            height = patternHeight;
            
            patternPB = new PictureBox();
            patternPB.Size = new System.Drawing.Size(patternWidth, patternHeight);
            patternPB.Image = DynamicBomberman.Properties.Resources.wall;
            patternPB.Location = new System.Drawing.Point(X, Y);

            panel.Controls.Add(patternPB);

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
        public PictureBox PatternPB {
            get { return patternPB; }
            set { patternPB = value; }
        }
    }
}

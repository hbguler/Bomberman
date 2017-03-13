using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicBomberman {
    class Explosion {

        private int x, y;

        private PictureBox explosionPB;
        private Explosion explosionLeft;
        private Explosion explosionRight;
        private Explosion explosionTop;
        private Explosion explosionBottom;
        private Explosion explosionCenter;





        public Explosion(Bomb bomb, int bombRadius, List<Explosion> explosionList, List<Brick> brickList, Panel panel) {

            explosionCenter = new Explosion(bomb.X, bomb.Y, bomb.Width, bomb.Height);
            explosionList.Add(explosionCenter);

            for (int i = 1; i <= bombRadius; i++) {

                //Creating explosions
                explosionLeft = new Explosion(bomb.X - (bomb.Width * i), bomb.Y, bomb.Width, bomb.Height);
                explosionList.Add(explosionLeft);
                explosionRight = new Explosion(bomb.X + (bomb.Width * i), bomb.Y, bomb.Width, bomb.Height);
                explosionList.Add(explosionRight);
                explosionTop = new Explosion(bomb.X, bomb.Y - (bomb.Height * i), bomb.Width, bomb.Height);
                explosionList.Add(explosionTop);
                explosionBottom = new Explosion(bomb.X, bomb.Y + (bomb.Height * i), bomb.Width, bomb.Height);
                explosionList.Add(explosionBottom);    
            }
            //Drawing explosions
            drawExplosion(panel, explosionList);
            //Controlling bricks that going to break
            checkBrickIntersect(brickList, explosionList);
        }

        private Explosion(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            explosionPB = new PictureBox();
            explosionPB.Location = new System.Drawing.Point(x, y);
            explosionPB.Size = new System.Drawing.Size(width, height);
            explosionPB.Image = DynamicBomberman.Properties.Resources.boom;
        }

        
        private void drawExplosion(Panel panel, List<Explosion> explosionList) {
            foreach (Explosion explosion in explosionList) {
                panel.Controls.Add(explosion.explosionPB);
            }
        }

        public void checkBrickIntersect(List<Brick> brickList, List<Explosion> explosionList) {
            foreach (Explosion explosion in explosionList) {
                foreach (Brick brick in brickList.ToList()) {
                    if (explosion.ExplosionPB.Bounds.IntersectsWith(brick.BrickPB.Bounds)) {
                        brickList.Remove(brick);
                        brick.BrickPB.Dispose();
                    } 
                }
            }
        }


        public int X {
            get { return x; }
            set { x = value; }
        }

        public int Y {
            get { return y; }
            set { y = value; }
        }
        public PictureBox ExplosionPB {
            get { return explosionPB; }
            set { explosionPB = value; }
        }



        
    }
}

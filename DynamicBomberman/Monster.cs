using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicBomberman {
    class Monster {
        private PictureBox monsterPB;
        private int width, height;
        private string movementDirection;
        private bool collisionCheck;
        private int elapsedDistance;
        private bool movementDone;
        private static int monsterImageNumber = 0;


        public Monster(int x, int y, int height, int width, Panel panel) {
            this.width = width;
            this.height = height;

            monsterPB = new PictureBox();
            monsterPB.Location = new System.Drawing.Point(x, y);
            monsterPB.Size = new System.Drawing.Size(height, width);
            monsterPB.SizeMode = PictureBoxSizeMode.StretchImage;

            switch (monsterImageNumber % 4) {
                case 0:
                    monsterPB.Image = DynamicBomberman.Properties.Resources.monster1;
                    break;
                case 1:
                    monsterPB.Image = DynamicBomberman.Properties.Resources.monster2;
                    break;
                case 2:
                    monsterPB.Image = DynamicBomberman.Properties.Resources.monster3;
                    break;
                case 3:
                    monsterPB.Image = DynamicBomberman.Properties.Resources.monster4;                   
                    break;
            }
            monsterImageNumber++;
            panel.Controls.Add(monsterPB);

        }



        public void setMonsterMovementDirection(PictureBox player) {
            if (this.monsterPB.Top > player.Top) {
                // player is above monster. monster have to go up
                movementDirection = "UP";
            } else if (this.monsterPB.Top < player.Top) {
                // player is below monster. monster have to go down
                movementDirection = "DOWN";
            } else {
                if (this.monsterPB.Left > player.Left) {
                    // player is at left of monster. monster have to go left
                    movementDirection = "LEFT";
                } else if (this.monsterPB.Left < player.Left) {
                    // player is at right of monster. monster have to go right
                    movementDirection = "RIGHT";
                } else {
                    // Monster has centered player :)
                    movementDirection = "UP"; // Trivia
                }
            }
            this.movementDone = false;
        }

        public bool MovementDone {
            get { return movementDone; }
            set { movementDone = value; }
        }

        public int ElapsedDistance {
            get { return elapsedDistance; }
            set { elapsedDistance = value; }
        }

        public string MovementDirection {
            get { return movementDirection; }
            set { movementDirection = value; }
        }

        public bool CollisionCheck {
            get { return collisionCheck; }
            set { collisionCheck = value; }
        }
        public PictureBox MonsterPB {
            get { return monsterPB; }
            set { monsterPB = value; }
        }

        public void changeDirection() {
            Random randomMovementDirection = new Random();
             int direction = randomMovementDirection.Next(1, 5);
             switch (direction) {
                 case 1:
                     movementDirection = "DOWN";
                     break;
                 case 2:
                     movementDirection = "UP";
                     break;
                 case 3:
                     movementDirection = "LEFT";
                     break;
                 case 4:
                     movementDirection = "RIGHT";
                     break;
             }
        }
    }
}

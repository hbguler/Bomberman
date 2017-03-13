using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicBomberman {
    public partial class mapForm : Form {
        public mapForm() {
            InitializeComponent();
            initializePlayer();
            resizeMap();
        }

        // Final Values
        //Map
        private readonly int widthOffset = 76;
        private readonly int heightOffset = 98;
        private readonly int patternWidth = 30;
        private readonly int patternHeight = 30;
        private readonly int spaceWidth = 30;
        private readonly int spaceHeight = 30;
        private readonly int brickWidth = 30;
        private readonly int brickHeight = 30;
        //Player
        private readonly int horizontalSpeed = 2;
        private readonly int verticalSpeed = 2;
        private readonly int playerWidth = 30;
        private readonly int playerHeight = 30;
        private readonly int playerStartLocationX = 0;
        private readonly int playerStartLocationY = 0;
        //Monster
        private readonly int monsterNumber = 1;
        private readonly int monsterHorizontalSpeed = 2;
        private readonly int monsterVerticalSpeed =  2;
        //Bomb and Boom
        private readonly int bombWidth = 30;
        private readonly int bombHeight = 30;
        private readonly int bombExplodeTime = 2000; // First interval
        private readonly int boomStayTime = 500; // Second interval

        // Dynamic Values
        //Map
        private int mapWidth;
        private int mapHeight;
        private int actualWidth;
        private int actualHeight;
        private int brickNumber;
        private bool monsterSequence = false;

        //Player
        private bool upDirection = false;
        private bool downDirection = false;
        private bool leftDirection = false;
        private bool rightDirection = false;
        private bool movementDone = true;
        private bool atPattern = false;
        private bool collisionCheckValue = false;
        int elapsedDistance = 0;
        //Bomb
        private int maxBombNumber = 1; // unavailable
        private int bombRadius = 1;     // bugged
        private bool clearBoom = false;
        private Bomb lastBomb;
        private bool canBombPlaced = true; 


        // Lists
        List<Pattern> patternList = new List<Pattern>();
        List<EmptySpace> emptySpaceList = new List<EmptySpace>();
        List<Brick> brickList = new List<Brick>();
        List<Bomb> bombList = new List<Bomb>();
        List<Explosion> explosionList = new List<Explosion>();
        List<Monster> monsterList = new List<Monster>();


        // Player animation and movement Timer
        private void animationTick(object sender, EventArgs e) {

            // At every tick, player moves to its direction.
            // If player has no direction (i.e. all booleans are false) 
            // then player doesnt move.


            if (rightDirection == true && movementDone == false && collisionCheck(verticalSpeed, 0) == true) {


                if (elapsedDistance < (patternWidth + spaceWidth) / 2) {
                    playerPB.Left += verticalSpeed;
                    elapsedDistance += verticalSpeed;
                } else {
                    elapsedDistance = 0;
                    movementDone = true;
                    rightDirection = false;
                    collisionCheckValue = false;
                    atPattern = !atPattern;
                }
            }

            if (leftDirection == true && movementDone == false && collisionCheck(-verticalSpeed, 0) == true) {
                if (elapsedDistance < (patternWidth + spaceWidth) / 2) {
                    playerPB.Left -= verticalSpeed;
                    elapsedDistance += verticalSpeed;
                } else {
                    elapsedDistance = 0;
                    movementDone = true;
                    leftDirection = false;
                    collisionCheckValue = false;
                    atPattern = !atPattern;
                }
            }
            if (upDirection == true && movementDone == false && collisionCheck(0, -horizontalSpeed) == true) {
                if (elapsedDistance < (patternHeight + spaceHeight) / 2) {
                    playerPB.Top -= horizontalSpeed;
                    elapsedDistance += horizontalSpeed;
                } else {
                    elapsedDistance = 0;
                    movementDone = true;
                    upDirection = false;
                    collisionCheckValue = false;
                    atPattern = !atPattern;
                }
            }
            if (downDirection == true && movementDone == false && collisionCheck(0, horizontalSpeed) == true) {
                if (elapsedDistance < (patternHeight + spaceHeight) / 2) {
                    playerPB.Top += horizontalSpeed;
                    elapsedDistance += horizontalSpeed;
                } else {
                    elapsedDistance = 0;
                    movementDone = true;
                    downDirection = false;
                    collisionCheckValue = false;
                    atPattern = !atPattern;
                }
            }




            playerXY.Text = playerPB.Left.ToString() + "-" + playerPB.Top.ToString();


        }

        private void initializePlayer() {
            mapPanel.BackgroundImage = Image.FromFile("background.png");
            playerPB.Location = new System.Drawing.Point(playerStartLocationX, playerStartLocationY);
            playerPB.Image = DynamicBomberman.Properties.Resources.stand;

        }

        private void mapForm_KeyDown(object sender, KeyEventArgs e) {
            // According to the pressed buttons -which are, up down left right-
            // corresponding boolean becomes true.
            // Also pressing direction buttons changes the player's image.

            if (movementDone == true) {
                if (e.KeyCode == Keys.Left) {
                    leftDirection = true;
                    movementDone = false;
                    playerPB.Image = DynamicBomberman.Properties.Resources.walkLeft;
                } else if (e.KeyCode == Keys.Right) {
                    rightDirection = true;
                    movementDone = false;
                    playerPB.Image = DynamicBomberman.Properties.Resources.walkRight;
                } else if (e.KeyCode == Keys.Up) {
                    upDirection = true;
                    movementDone = false;
                    playerPB.Image = DynamicBomberman.Properties.Resources.walkUp;
                } else if (e.KeyCode == Keys.Down) {
                    downDirection = true;
                    movementDone = false;
                    playerPB.Image = DynamicBomberman.Properties.Resources.walkDown;
                } else if (e.KeyCode == Keys.Space) {
                    if (canBombPlaced == true) {
                        createBomb();
                    } 
                }

            }

        }

        // Drawing things into form / panel.


        #region Collision
        // --Collision checks--
        private bool collisionCheck(int nextX, int nextY) {
            // Next position location, also a rectangle that will not be draw
            PictureBox nextLocation = new PictureBox();
            nextLocation.Location = new System.Drawing.Point(playerPB.Left + nextX, playerPB.Top + nextY);
            nextLocation.Size = new System.Drawing.Size(playerWidth, playerHeight);

            PictureBox nextLocationForWall = new PictureBox();
            nextLocationForWall.Location = new System.Drawing.Point(playerPB.Left + (nextX * 15),
                playerPB.Top + (nextY * 15));
            nextLocationForWall.Size = new System.Drawing.Size(playerWidth, playerHeight);

            if (collisionCheckValue == true)
                return true;
            if (patternCollisionCheck(nextLocation) == true
                && wallCollisionCheck(nextLocationForWall) == true
                && brickCollisionCheck(nextLocation) == true
                && bombCollisionCheck(nextLocation) == true
                && playerToMonsterCollisionCheck(nextLocation) == true) {

                collisionCheckValue = true;
                collisionTextBox.Text = string.Empty;
                return true;
            } else {
                upDirection = false; downDirection = false;
                leftDirection = false; rightDirection = false;
                movementDone = true;
                return false;
            }

        }

        private bool patternCollisionCheck(PictureBox nextLocation) {
            foreach (Pattern patternBlock in patternList) {
                if (patternBlock.PatternPB.Bounds.IntersectsWith(nextLocation.Bounds)) {
                    collisionTextBox.Text = "Pattern";
                    return false;
                }
            }
            return true;
        }

        private bool wallCollisionCheck(PictureBox nextLocation) {
            // Player starts at 0;0 location. (Because player is on panel.)
            // But walls are bound to form, minus operation required because of this
            // 60 is total offset, if you change the walls' size, change this offset too.

            // Every collision check is managing by controlling
            // the very next location of the picturebox(Picturebox nextLocation)
            // But wall is different, for wall, i have to check next 60pixels


            if (nextLocation.Left < 0) {
                collisionTextBox.Text = "Left Wall";
                wallCollison.Text = leftWall.Right.ToString() + "-0";
                return false;
            } else if (nextLocation.Left > rightWall.Left - 60) {
                collisionTextBox.Text = "Right Wall";
                wallCollison.Text = rightWall.Left.ToString() + "-0";
                return false;
            } else if (nextLocation.Top < 0) {
                collisionTextBox.Text = "Top Wall";
                wallCollison.Text = "0-" + topWall.Bottom.ToString();
                return false;
            } else if (nextLocation.Top > bottomWall.Top - 60) {
                collisionTextBox.Text = "Bottom Wall";
                wallCollison.Text = "0-" + bottomWall.Top.ToString();
                return false;
            } else
                return true;
        }

        private bool brickCollisionCheck(PictureBox nextLocation) {

            foreach (Brick brick in brickList) {
                if (brick.BrickPB.Bounds.IntersectsWith(nextLocation.Bounds)) {
                    collisionTextBox.Text = "Brick";
                    return false;
                }
            }
            return true;
        }

        private bool bombCollisionCheck(PictureBox nextLocation) {
            foreach (Bomb bomb in bombList) {
                if (bomb.BombPB.Bounds.IntersectsWith(nextLocation.Bounds)) {
                    if (bomb.X == playerPB.Left && bomb.Y == playerPB.Top)
                        continue;
                    collisionTextBox.Text = "Bomb!";
                    return false;
                }
            }
            return true;
        }

        private bool playerToMonsterCollisionCheck(PictureBox nextLocation) {
            foreach (Monster monster in monsterList) {
                if (monster.MonsterPB.Bounds.IntersectsWith(nextLocation.Bounds)) {
                    collisionTextBox.Text = "Monster!!";
                    gameEnds("You Died");
                    return false;
                }
            }
            return true;
        }

        private bool monsterToPlayerCollisionCheck(PictureBox nextLocation) {
            if (nextLocation.Bounds.IntersectsWith(playerPB.Bounds)) {
                collisionTextBox.Text = "Monster got you.";
                gameEnds("You died.");
                return false;
            }
            return true;
        }

        private bool boomToPlayerCollisionCheck() {
            foreach (Explosion boom in explosionList) {
                if (playerPB.Bounds.IntersectsWith(boom.ExplosionPB.Bounds)) {
                    collisionTextBox.Text = "You've burned to death.";
                    gameEnds("You died");
                    return false;
                }
            }
            return true;
        }

        private bool boomToMonsterCollisionCheck() {
            if (monsterSequence) {
                foreach (Monster monster in monsterList) {
                    foreach (Explosion boom in explosionList) {
                        if (monster.MonsterPB.Bounds.IntersectsWith(boom.ExplosionPB.Bounds)) {
                            monsterDied(monster);
                            return false;
                        }
                    }
                }
                return true;
            }
            return true;
        }

        
        #endregion

        #region Monsters


        // Monster button
        private void monsterGenerator_Click(object sender, EventArgs e) {
            monsterList.Clear();
            createMonster();
            monsterTimer.Enabled = true;
        }

        // Creating the monsters into monsterList.
        private void createMonster() {
           
            Random randomLocation = new Random();
            for (int i = 0; i < monsterNumber; i++) {
                int monsterLocation = randomLocation.Next(0, emptySpaceList.Count);
                EmptySpace emptySpace = emptySpaceList.ElementAt(monsterLocation);
                emptySpaceList.RemoveAt(monsterLocation);

                Monster monster = new Monster(emptySpace.X, emptySpace.Y, playerHeight, playerWidth, mapPanel);
                monster.setMonsterMovementDirection(playerPB);
                monsterList.Add(monster);
            }
            monsterSequence = true;
            
        }
        // Monster Timer
        private void monsterTimer_Tick(object sender, EventArgs e) {

            Monster currentMonster;

            for (int currentMonsterIndex = 0; currentMonsterIndex < monsterList.Count; currentMonsterIndex++) {

                currentMonster = monsterList.ElementAt(currentMonsterIndex);

                if (currentMonster.MovementDirection == "UP" && currentMonster.MovementDone == false && 
                    monsterCollisionCheck(currentMonster, 0, -monsterVerticalSpeed) == true) {
                    if (currentMonster.ElapsedDistance < (patternHeight + spaceHeight) / 2) {
                        currentMonster.MonsterPB.Top -= monsterVerticalSpeed;
                        currentMonster.ElapsedDistance += monsterVerticalSpeed;
                    } 
                    else {
                        //moved for 30 pixel, start again.
                        currentMonster.CollisionCheck = false;
                        currentMonster.ElapsedDistance = 0;
                        currentMonster.MovementDone = true;
                        currentMonster.setMonsterMovementDirection(playerPB);

                    }
                }

                if (currentMonster.MovementDirection == "DOWN" && currentMonster.MovementDone == false &&
                    monsterCollisionCheck(currentMonster, 0, +monsterVerticalSpeed) == true ) {
                    if (currentMonster.ElapsedDistance < (patternHeight + spaceHeight) / 2) {
                        currentMonster.MonsterPB.Top += monsterVerticalSpeed;
                        currentMonster.ElapsedDistance += monsterVerticalSpeed;
                    } 
                    else {
                        //moved for 30 pixel, start again.
                        currentMonster.CollisionCheck = false;
                        currentMonster.ElapsedDistance = 0;
                        currentMonster.MovementDone = true;
                        currentMonster.setMonsterMovementDirection(playerPB);

                    }
                }

                if (currentMonster.MovementDirection == "LEFT" && currentMonster.MovementDone == false &&
                    monsterCollisionCheck(currentMonster, -monsterHorizontalSpeed, 0) == true) {
                    if (currentMonster.ElapsedDistance < (patternWidth + spaceWidth) / 2) {
                        currentMonster.MonsterPB.Left -= monsterHorizontalSpeed;
                        currentMonster.ElapsedDistance += monsterHorizontalSpeed;
                    } 
                    else {
                        //moved for 30 pixel, start again.
                        currentMonster.CollisionCheck = false;
                        currentMonster.ElapsedDistance = 0;
                        currentMonster.MovementDone = true;
                        currentMonster.setMonsterMovementDirection(playerPB);

                    }
                }

                if (currentMonster.MovementDirection == "RIGHT" && currentMonster.MovementDone == false &&
                    monsterCollisionCheck(currentMonster, +monsterHorizontalSpeed, 0) == true) {
                    if (currentMonster.ElapsedDistance < (patternWidth + spaceWidth) / 2) {
                        currentMonster.MonsterPB.Left += monsterHorizontalSpeed;
                        currentMonster.ElapsedDistance += monsterHorizontalSpeed;
                    } 
                    else {
                        //moved for 30 pixel, start again.
                        currentMonster.CollisionCheck = false;
                        currentMonster.ElapsedDistance = 0;
                        currentMonster.MovementDone = true;
                        currentMonster.setMonsterMovementDirection(playerPB);
                    }
                }




            }
        }
       
        private bool monsterCollisionCheck(Monster monster, int nextX, int nextY){
            // This part checks collision for monster. Creates a nextLocation
                // and with this nextLocation, searches for collisions.
                // If collisionCheck is false, it means monster is on the move
                // and there is no need to check for collision again.

                // This part can be improved by checking every movement, not 30 pixel.
            
            PictureBox monsterNextLocation = new PictureBox();
            monsterNextLocation.Size = new System.Drawing.Size(playerWidth, playerHeight);
            monsterNextLocation.Location = new System.Drawing.Point(monster.MonsterPB.Left + nextX,
                monster.MonsterPB.Top + nextY);

            if (wallCollisionCheck(monsterNextLocation) == true
                    && patternCollisionCheck(monsterNextLocation) == true
                    && brickCollisionCheck(monsterNextLocation) == true
                    && bombCollisionCheck(monsterNextLocation) == true
                    && monsterToPlayerCollisionCheck(monsterNextLocation) == true) {
                //Passed collision check, dont have to check for next 30 pixel.
                monster.CollisionCheck = true;
                return true;
            } else {
                //Failed collision check, changing direction.
                monster.changeDirection();
                return false;
            }
        }


        #endregion

        #region BOMB and BOOM

        // Creating bomb and drawing it
        private void createBomb() {
            canBombPlaced = false;
            Bomb bomb = new Bomb(playerPB.Left, playerPB.Top, bombWidth, bombHeight, mapPanel);
            bombList.Add(bomb);
            lastBomb = bomb;
            // After creaing and drawing bomb, it is time to explode it.
            exploTimer.Enabled = true;
        }

        // Creating the boom effect and drawing into map    
        private void createExplosion(Bomb bomb) {

            Explosion explosion = new Explosion(lastBomb, bombRadius, explosionList, brickList, mapPanel);


            boomToMonsterCollisionCheck();
            boomToPlayerCollisionCheck();

            bombList.Clear();
            bomb.BombPB.Dispose();


        }

        private void removeBoom() {
            foreach (Explosion explosion in explosionList) {
                explosion.ExplosionPB.Dispose();
            }

            explosionList.Clear();
            canBombPlaced = true;
        }

        private void exploTimer_Tick(object sender, EventArgs e) {


            if (clearBoom == false) {
                clearBoom = true;

                createExplosion(lastBomb);
                exploTimer.Interval = boomStayTime;

            } else if (clearBoom == true) {
                removeBoom();
                clearBoom = false;
                exploTimer.Interval = bombExplodeTime;
                exploTimer.Enabled = false;
            }
        }

        #endregion

        #region Pattern
        // Pattern Button
        private void generatePattern_Click(object sender, EventArgs e) {
            patternList.Clear();
            createPattern();
            mapPanel.Refresh();

        }

        private void createPattern() {
            for (int i = 0; i < calculateHorizontalBoxNumber(); i++) {
                for (int j = 0; j < calculateVerticalBoxNumber(); j++) {

                    Pattern pattern = new Pattern(
                        (j * (spaceWidth + patternWidth) + spaceWidth),      //X
                        ((i * (spaceHeight + patternHeight)) + spaceHeight), //Y
                    patternWidth, patternHeight, spaceWidth, spaceHeight, mapPanel);

                    patternList.Add(pattern);
                }
            }
        }

        #endregion

        #region Brick
        // Brick Button
        private void generateBricks_Click(object sender, EventArgs e) {
            brickList.Clear();
            createEmptySpaces();
            createBricks();
            mapPanel.Refresh();
        }
        // Creating the bricks into brickList.
        private void createEmptySpaces() {

            int verticalBlockNumber = calculateVerticalBoxNumber();
            int horizontalBlockNumber = calculateHorizontalBoxNumber();
            brickNumber = verticalBlockNumber * horizontalBlockNumber;

            //Creating empty space locations.
            // 1, 3, 5, 7.. for every row, column is filled. (whole column).
            for (int verticalOdd = 0; verticalOdd < verticalBlockNumber + 1; verticalOdd++) {
                for (int horizontalEvery = 0; horizontalEvery < horizontalBlockNumber * 2 + 1; horizontalEvery++) {
                    //(0,0) and (1,0) is safe.
                    if ((verticalOdd == 0 && horizontalEvery == 0) || (verticalOdd == 0 && horizontalEvery == 1)) continue;
                    EmptySpace emptySpace = new EmptySpace(verticalOdd * (patternHeight * 2), horizontalEvery * patternWidth);
                    emptySpaceList.Add(emptySpace);
                }
            }
            // 2, 4, 6, 8.. every once column
            for (int verticalEven = 0; verticalEven < verticalBlockNumber; verticalEven++) {
                for (int horizontalOdd = 0; horizontalOdd < horizontalBlockNumber + 1; horizontalOdd++) {
                    // (0,1) is safe.
                    if (verticalEven == 0 && horizontalOdd == 0) continue;
                    EmptySpace emptySpace = new EmptySpace(patternHeight + (verticalEven * patternHeight * 2), horizontalOdd * (patternHeight * 2));
                    emptySpaceList.Add(emptySpace);
                }
            }

        }
        //Drawing all bricks into panel
        private void createBricks() {
            // Creating bricks
            Random randomLocation = new Random();

            for (int i = 0; i < brickNumber; i++) {
                int brickLocation = randomLocation.Next(0, emptySpaceList.Count);
                EmptySpace emptySpace = emptySpaceList.ElementAt(brickLocation);
                emptySpaceList.RemoveAt(brickLocation);
                Brick brick = new Brick(emptySpace.X, emptySpace.Y, brickWidth, brickHeight, mapPanel);
                brickList.Add(brick);
            }
        }
        #endregion

        #region Map
        // Calculates the square that map can take.
        private int calculateVerticalBoxNumber() {
            return (actualWidth - spaceWidth) / (spaceWidth + patternWidth);
        }
        private int calculateHorizontalBoxNumber() {
            return (actualHeight - spaceHeight) / (patternHeight + patternHeight);
        }

        // Resizing map event
        private void mapForm_Resize(object sender, EventArgs e) {
            resizeMap();
        }
        // Resizing map when resolution change occurs
        private void resizeMap() {
            mapWidth = this.Width;
            mapHeight = this.Height;

            actualWidth = mapWidth - widthOffset;
            actualHeight = mapHeight - heightOffset;
        }

        #endregion

        private void gameEnds(String text) {
            animationTimer.Enabled = false;
            monsterTimer.Enabled = false;
            exploTimer.Enabled = false;

            MessageBox.Show(text);

        }

        private void monsterDied(Monster monster) {
            monster.MonsterPB.Dispose();
            monsterList.Remove(monster);

            if (monsterList.Count == 0) { 
                gameEnds("All Monsters Died.");
            }
        }

    }
}

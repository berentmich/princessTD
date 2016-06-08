using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace PrincessTowerDefence.Model
{
    public class GameModel
    {
        DispatcherTimer enemyTimer;
        DispatcherTimer enemySpawnTimer;
        DispatcherTimer shootTimer;
        DispatcherTimer bulletTimer;
        DispatcherTimer countdownTimer;
        public Brush enemyBrush;
        public Brush backgroundBrush;
        bool preparePhase = true;
        public int countdown;

        public LevelModel level;

        public GameModel()
        {
            level = new LevelModel(1);
            countdown = 20;
            enemyTimer = new DispatcherTimer();
            enemyTimer.Tick += monsterTimerTick;
            enemyTimer.Interval = new TimeSpan(0, 0 ,0, 0, 1000);

            shootTimer = new DispatcherTimer();
            shootTimer.Tick += shootTimerTick;
            shootTimer.Interval = new TimeSpan(0, 0, 3);

            bulletTimer = new DispatcherTimer();
            bulletTimer.Tick += bulletTimerTick;
            bulletTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);

            countdownTimer = new DispatcherTimer();
            countdownTimer.Tick += countdownTimerTick;
            countdownTimer.Interval = new TimeSpan(0, 0, 1);

            enemySpawnTimer = new DispatcherTimer();
            enemySpawnTimer.Tick += enemySpawnTimerTick;
            enemySpawnTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void enemySpawnTimerTick(object sender, EventArgs e)
        {
            if (level.board.BoardGrid[0, level.enemyStart] != 3)
            {
                level.board.BoardGrid[0, level.enemyStart] = 3;

                EnemyModel newSpawn = new EnemyModel(level.enemyType);
                newSpawn.posX = 0;
                newSpawn.posY = level.enemyStart;
                level.enemies.Add(newSpawn);
            }
        }

        private void countdownTimerTick(object sender, EventArgs e)
        {
            countdown--;
            if (preparePhase && countdown == 0)
            {
                preparePhase = false;
                countdown = 40;
                enemyTimer.Start();
                shootTimer.Start();
                bulletTimer.Start();
                enemySpawnTimer.Start();

            }
            if(!preparePhase && countdown == 0 && level.number !=3)
            {
                MessageBox.Show("Congratulations, moving to next level");
                InitiateNextLevel();
            }
        }

        private void InitiateNextLevel()
        {
            if (level.number == 3)
            {
                MessageBox.Show("Wygrales");
                return;
            }
            
            enemyTimer.Stop();
            shootTimer.Stop();
            bulletTimer.Stop();
            enemySpawnTimer.Stop();
            preparePhase = true;
            countdown = 20;
            level = new LevelModel(level.number + 1);
        }

        private void bulletTimerTick(object sender, EventArgs e)
        {
            foreach (var bullet in level.bullets)
            {
                bullet.Move();
            }
        }

        private void shootTimerTick(object sender, EventArgs e)
        {
            foreach(var princess in level.placedPrincesses)
            {
                princess.Shoot(level);
            }
        }

        private void monsterTimerTick(object sender, EventArgs e)
        {
            foreach (var enemy in level.enemies)
            {
                enemy.moveForward(level.board);
            }
            if (level.board.BoardGrid[13, level.crownPos] == 3)
            {
                enemyTimer.Stop();
                MessageBox.Show("You lost");
            }


        }

        public void Start()
        {
            countdownTimer.Start();        
        }
    }
}

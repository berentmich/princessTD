using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PrincessTowerDefence.Model
{
    public class GameModel
    {
        DispatcherTimer enemyTimer;

        public LevelModel level;

        public GameModel()
        {
            level = new LevelModel();
            enemyTimer = new DispatcherTimer();
            enemyTimer.Tick += monsterTimerTick;
            enemyTimer.Interval = new TimeSpan(0,0,1);
        }

        private void monsterTimerTick(object sender, EventArgs e)
        {
            if (level.board.BoardGrid[level.crownPos, 13 ] == 3)
            {
                enemyTimer.Stop();
                MessageBox.Show("You lost");
            }
            if(level.board.BoardGrid[level.enemyStart, 0] != 3 && level.hiddenEnemies.Count > 0)
            {
                level.board.BoardGrid[level.enemyStart, 0] = 3;
                EnemyModel newSpawn = level.hiddenEnemies[0];
                level.hiddenEnemies.RemoveAt(0);
                level.enemies.Add(newSpawn);
                newSpawn.posX = level.enemyStart;
                newSpawn.posY = 0;
            }
            foreach(var enemy in level.enemies)
            {
                enemy.moveForward(level.board);
            }

        }

        public void Start()
        {
            enemyTimer.Start();
        }
    }
}

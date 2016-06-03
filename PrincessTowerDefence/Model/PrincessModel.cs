using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PrincessTowerDefence.Model
{
    public class PrincessModel : CreatureModel
    {
        public int shootDelay;
        public int range;
        public PrincessType type;


        public PrincessModel(PrincessType type)
        {
            this.type = type;

            switch(type)
            {
                case PrincessType.Blue:
                    shootDelay = 1000;
                    range = 1;
                    break;
                case PrincessType.Pink:
                    shootDelay = 1000;
                    range = 2;
                    break;
                case PrincessType.Yellow:
                    shootDelay = 2000;
                    range = 2;
                    break;
            }
        }

        public void  Shoot(LevelModel level)
        {
            for(int i = Math.Max(0, posX - range); i<=Math.Min(13, posX + range); i++)
            {
                for (int j = Math.Max(0, posY - range); j <= Math.Min(13, posY + range); j++)
                {
                    if (level.board.BoardGrid[i, j] == 3)
                    {
                        foreach (var enemy in level.enemies)
                        {
                            if (enemy.posX == i && enemy.posY == j)
                            {
                                SpawnBullet(posX, posY, enemy.posX, enemy.posY, level);
                                enemy.HealthPoints--;
                                if (enemy.HealthPoints == 0)
                                {
                                    level.board.BoardGrid[i, j] = 2;
                                    level.enemies.Remove(enemy);
                                    return;
                                }
                                return;
                            }
                        }
                        return;
                    }
                }
            }

                
        }

        private void SpawnBullet(int posX1, int posY1, int posX2, int posY2, LevelModel level)
        {
            BulletModel bullet = new BulletModel(40 * posX1 + 20, 40 * posY1 + 20, 40 * posX2 + 20, 40 * posY2 + 20);
            level.bullets.Add(bullet);
        }
    }
    public enum PrincessType
    {
        Blue,
        Pink,
        Yellow
    }
}

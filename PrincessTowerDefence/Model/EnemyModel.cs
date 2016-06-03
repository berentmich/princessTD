using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessTowerDefence.Model
{
    public class EnemyModel : CreatureModel
    {
        public int HealthPoints { get; set; }
        public EnemyType Type { get; set; }

        public EnemyModel(EnemyType type)
        {
            Type = type;
            switch (Type)
            {
                case EnemyType.Spider:
                    HealthPoints = 1;
                    break;
                case EnemyType.Minion:
                    HealthPoints = 2;
                    break;
                case EnemyType.FrogKing:
                    HealthPoints = 3;
                    break;
            }
        }

        public void moveForward(BoardModel board)
        {
            if (posX < 13)
            {
                if (board.BoardGrid[posX + 1, posY] == 2 || board.BoardGrid[posX + 1, posY] == 4)
                {
                    board.BoardGrid[posX, posY] = 2;
                    posX++;
                    board.BoardGrid[posX, posY] = 3;
                    return;
                }
                if (board.BoardGrid[posX, posY + 1] == 2 || board.BoardGrid[posX + 1, posY] == 4)
                {
                    board.BoardGrid[posX, posY] = 2;
                    posY++;
                    board.BoardGrid[posX, posY] = 3;
                }
            }
        }
    }


    public enum EnemyType
    {
        Spider,
        Minion,
        FrogKing
    }
}

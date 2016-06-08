using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PrincessTowerDefence.Model
{
    public class LevelModel
    {
        public int number;
        public EnemyType enemyType;
        public int enemyStart;
        public int crownPos;
        public int yellowCount, pinkCount, blueCount;
        public ArsenalModel arsenal;
        public BoardModel board;
        public List<EnemyModel> enemies;
        public List<EnemyModel> hiddenEnemies;
        public List<PrincessModel> placedPrincesses;
        public List<BulletModel> bullets;

        public Brush enemyBrush;
        public Brush backgroundBrush;

        public LevelModel(int num)
        {
           number = num;
            board = new BoardModel();
            for (int i = 0; i < 14; i++)
                for (int j = 0; j < 14; j++)
                {
                    board.BoardGrid[i, j] = 1;
                }
            switch(number)
            {
                case 1:
                    enemyType = EnemyType.Spider;
                    enemyBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/spider.png", UriKind.Absolute)));
                    backgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00CC00"));
                    enemyStart = 5;
                    crownPos = 9;
                    board.BoardGrid[0, enemyStart] = 2;
                    board.BoardGrid[1, 5] = 2;
                    board.BoardGrid[2, 5] = 2;
                    board.BoardGrid[3, 5] = 2;
                    board.BoardGrid[3, 6] = 2;
                    board.BoardGrid[3, 7] = 2;
                    board.BoardGrid[4, 7] = 2;
                    board.BoardGrid[5, 7] = 2;
                    board.BoardGrid[6, 7] = 2;
                    board.BoardGrid[7, 7] = 2;
                    board.BoardGrid[8, 7] = 2;
                    board.BoardGrid[9, 7] = 2;
                    board.BoardGrid[9, 8] = 2;
                    board.BoardGrid[9, 9] = 2;
                    board.BoardGrid[10, 9] = 2;
                    board.BoardGrid[11, 9] = 2;
                    board.BoardGrid[12, 9] = 2;
                    board.BoardGrid[13, crownPos] = 4;

                    yellowCount = 1;
                    blueCount = 2;
                    pinkCount = 1;

                    arsenal = new ArsenalModel(blueCount, yellowCount, pinkCount);
                    break;

                case 2:
                    enemyType = EnemyType.Minion;
                    enemyBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/minionek.png", UriKind.Absolute)));
                    backgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b30000"));
                    enemyStart = 5;
                    crownPos = 10;
                    board.BoardGrid[0, enemyStart] = 2;
                    board.BoardGrid[1, 5] = 2;
                    board.BoardGrid[2, 5] = 2;
                    board.BoardGrid[3, 5] = 2;
                    board.BoardGrid[3, 6] = 2;
                    board.BoardGrid[3, 6] = 2;
                    board.BoardGrid[4, 6] = 2;
                    board.BoardGrid[5, 6] = 2;
                    board.BoardGrid[5, 7] = 2;
                    board.BoardGrid[6, 7] = 2;
                    board.BoardGrid[7, 7] = 2;
                    board.BoardGrid[8, 7] = 2;
                    board.BoardGrid[9, 7] = 2;
                    board.BoardGrid[9, 8] = 2;
                    board.BoardGrid[9, 9] = 2;
                    board.BoardGrid[10, 9] = 2;
                    board.BoardGrid[11, 9] = 2;
                    board.BoardGrid[12, 9] = 2;
                    board.BoardGrid[12, 10] = 2;
                    board.BoardGrid[13, crownPos] = 4;

                    yellowCount = 1;
                    blueCount = 2;
                    pinkCount = 1;

                    arsenal = new ArsenalModel(blueCount, yellowCount, pinkCount);
                    break;

                case 3:
                    enemyType = EnemyType.FrogKing;
                    enemyBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/frogking.png", UriKind.Absolute)));
                    backgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000059"));
                    enemyStart = 4;
                    crownPos = 12;
                    board.BoardGrid[0, enemyStart] = 2;
                    board.BoardGrid[1, 4] = 2;
                    board.BoardGrid[2, 4] = 2;
                    board.BoardGrid[2, 5] = 2;
                    board.BoardGrid[3, 5] = 2;
                    board.BoardGrid[3, 6] = 2;
                    board.BoardGrid[3, 6] = 2;
                    board.BoardGrid[4, 6] = 2;
                    board.BoardGrid[5, 6] = 2;
                    board.BoardGrid[5, 7] = 2;
                    board.BoardGrid[6, 7] = 2;
                    board.BoardGrid[7, 7] = 2;
                    board.BoardGrid[7, 8] = 2;
                    board.BoardGrid[8, 8] = 2;
                    board.BoardGrid[9, 8] = 2;
                    board.BoardGrid[9, 9] = 2;
                    board.BoardGrid[9, 10] = 2;
                    board.BoardGrid[10, 10] = 2;
                    board.BoardGrid[11, 10] = 2;
                    board.BoardGrid[11, 11] = 2;
                    board.BoardGrid[12, 11] = 2;
                    board.BoardGrid[12, 12] = 2;
                    board.BoardGrid[13, crownPos] = 4;

                    yellowCount = 3;
                    blueCount = 2;
                    pinkCount = 1;

                    arsenal = new ArsenalModel(blueCount, yellowCount, pinkCount);
                    break;
            }


            enemies = new List<EnemyModel>();

            placedPrincesses = new List<PrincessModel>();
            bullets = new List<BulletModel>();

        }
    }
}

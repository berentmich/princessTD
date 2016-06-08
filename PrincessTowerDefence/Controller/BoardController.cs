using PrincessTowerDefence.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PrincessTowerDefence.Controller
{
    public class BoardController : ControllerBase
    {
        public ObservableCollection<TileModel> Tiles { get; set; }
        public GameModel GameInstance { get; set; }
        public ControlPanelController controlPanel { get; set; }
        public Brush Background { get; set; }
        public BrushesPicker brushes;
        private DispatcherTimer timer;

        public BoardController()
        {
            Tiles = new ObservableCollection<TileModel>();
            GameInstance = new GameModel();
            timer = new DispatcherTimer();
            brushes = new BrushesPicker();

            Background = GameInstance.level.backgroundBrush;

            GameInstance.Start();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += timerTick;
            timer.Start();
        }

        public void PlacePrincess(int x, int y)
        {
            if (controlPanel.ChosenPrincess != null)
            {
                int px = x / 40;
                int py = y / 40;
                switch(controlPanel.ChosenPrincess.type)
                {
                    case PrincessType.Blue:
                        GameInstance.level.board.BoardGrid[px, py] = 5;
                        break;
                    case PrincessType.Yellow:
                        GameInstance.level.board.BoardGrid[px, py] = 6;
                        break;
                    case PrincessType.Pink:
                        GameInstance.level.board.BoardGrid[px, py] = 7;
                        break;

                }

                controlPanel.ChosenPrincess.posX = px;
                controlPanel.ChosenPrincess.posY = py;
                GameInstance.level.placedPrincesses.Add(controlPanel.ChosenPrincess);
                controlPanel.ChosenPrincess = null;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            Background = GameInstance.level.backgroundBrush;
            OnPropertyChanged("Background");
            BoardToTiles();
            controlPanel.TimeLeft = GameInstance.countdown;
            controlPanel.Arsenal = GameInstance.level.arsenal;
            controlPanel.Update();
        }


        private void BoardToTiles()
        {
            Tiles = new ObservableCollection<TileModel>();

            for(int i=0; i <14; i++)
                for(int j = 0; j<14; j++)
                {
                    TileModel tile = new TileModel(){ Top = 40 * j, Left = 40 * i, Width =40, Height = 40 };
                    switch (GameInstance.level.board.BoardGrid[i, j])
                    {
                        case 1:
                            tile.Brush = GameInstance.level.backgroundBrush;
                            break;
                        case 2:
                            tile.Brush = brushes.PathBrush;
                            break;
                        case 3:
                            tile.Brush = GameInstance.level.enemyBrush;
                            break;
                        case 4:
                            tile.Brush = brushes.CrownBrush;
                            break;
                        case 5:
                            tile.Brush = brushes.BluePrincessBrush;
                            break;
                        case 6:
                            tile.Brush = brushes.YellowPrincessBrush;
                            break;
                        case 7:
                            tile.Brush = brushes.PinkPrincessBrush;
                            break;

                    }
                    Tiles.Add(tile);
                }
            List<BulletModel> toRemove = new List<BulletModel>();
            foreach (var bullet in GameInstance.level.bullets)
            {              
                if (bullet.ticks == 5)
                    toRemove.Add(bullet);
                Tiles.Add(new TileModel() { Top = bullet.posY, Left = bullet.posX, Brush = brushes.BulletBrush, Width = 10, Height = 10 });
                bullet.ticks++;
            }
            foreach (var bullet in toRemove)
                    GameInstance.level.bullets.Remove(bullet);
            OnPropertyChanged("Tiles");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PrincessTowerDefence.Model
{
    public class BrushesPicker
    {
        public Brush BackgroundBrush { get; set; }
        public Brush PathBrush { get; set; }
        public Brush CrownBrush { get; set; }

        public Brush EnemyBrush { get; set; }

        public Brush BluePrincessBrush { get; set; }
        public Brush PinkPrincessBrush { get; set; }
        public Brush YellowPrincessBrush { get; set; }

        public Brush BulletBrush { get; set; }

        public BrushesPicker()
        {
            PathBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f00ff"));

            EnemyBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/spider.png", UriKind.Absolute)));

            CrownBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/crown.png", UriKind.Absolute)));
            BluePrincessBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/blue_princ.png", UriKind.Absolute)));
            YellowPrincessBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/yellow_princ.png", UriKind.Absolute)));
            PinkPrincessBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/pink_princ.png", UriKind.Absolute)));
            BackgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00CC00"));
            BulletBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

    }
}

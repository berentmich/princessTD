using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PrincessTowerDefence.Model
{
    public class TileModel
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public Brush Brush { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}

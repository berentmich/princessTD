using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessTowerDefence.Model
{
    public class PrincessModel : CreatureModel
    {
        public int shootDelay;
        public int range;
        public PrincessType type;

    }
    public enum PrincessType
    {
        Blue,
        Pink,
        Yellow
    }
}

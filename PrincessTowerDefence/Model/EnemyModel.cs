using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessTowerDefence.Model
{
    public class EnemyModel
    {
        public int HealthPoints { get; set; }
        public EnemyType Type { get; set; }
    }

    public enum EnemyType
    {
        Spider,
        Minion,
        FrogKing
    }
}

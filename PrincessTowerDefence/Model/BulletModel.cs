using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessTowerDefence.Model
{
    public class BulletModel
    {
        public int posX, posY;
        public int destX, destY;
        public int dX, dY;
        public int ticks=0;

        public BulletModel(int posX, int posY, int destX, int destY)
        {
            this.posX = posX;
            this.posY = posY;
            this.destX = destX;
            this.destY = destY;

            dX = (destX - posX) / 5;
            dY = (destY - posY) / 5;
        }

        public void Move()
        {
            posX += dX;
            posY += +dY;
            
        }
    }
}

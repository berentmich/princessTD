﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessTowerDefence.Model
{
    public class BoardModel
    {
        public int[,] BoardGrid;
        public BoardModel()
        {
            BoardGrid = new int[14, 14];
        }
    }
}

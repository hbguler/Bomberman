﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBomberman {
    class EmptySpace {
        private int x, y;


        public EmptySpace(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int X {
            get { return x; }
        }
        public int Y {
            get { return y; }
        }
    }
}

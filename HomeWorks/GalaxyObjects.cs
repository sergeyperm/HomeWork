﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    abstract class GalaxyObjects
    {
        public Point pos;
        public Point dir;
        public Size size;
        public GalaxyObjects(Point _pos, Point _dir, Size _size)
        {
            pos = _pos;
            dir = _dir;
            size = _size;
        }
        public abstract void Draw();
        public abstract void Update();
       
        
    }
}

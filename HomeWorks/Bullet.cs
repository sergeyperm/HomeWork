﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
  class Bullet : GalaxyObjects
    {
        public Bullet(Point pos, Point dir, Size size) : base (pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Blue, pos.X, pos.Y,size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X - dir.X*2;
            
        }
        public void Move()
        {
            Update();
            Draw();
        }
    }
}

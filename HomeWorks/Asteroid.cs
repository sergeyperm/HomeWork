﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWorks
{
    class Asteroid:GalaxyObjects
    {
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Orange, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.Orange, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X + dir.X/2;
            pos.Y = pos.Y + dir.Y/2;
            if (pos.X > 1000) pos.X = -10;
            if (pos.Y > 600) pos.Y = -10;
        }
        public void Move()
        {
            Update();
            Draw();
        }
    }
}

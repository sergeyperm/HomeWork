using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    class GalaxyObjects
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
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y,size.Width, size.Height);
        }


        public virtual void Update(Galaxy galaxy)
        {
            
            pos.X = pos.X + pos.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > galaxy.galaxyWidth) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y > galaxy.galaxyHeight) dir.Y = -dir.Y;
        }

        
    }
}

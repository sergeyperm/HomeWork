using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWorks
{
    class Asteroid:Star
    {
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Orange, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.Orange, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update(Galaxy galaxy)
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            //if (pos.X < 0) pos.X = galaxy.galaxyWidth + size.Width;
        }
        public new void Move(Galaxy galaxy)
        {
            Update(galaxy);
            Draw();
        }
    }
}

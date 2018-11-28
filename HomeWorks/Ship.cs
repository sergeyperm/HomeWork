using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace HomeWorks
{
    class Ship:GalaxyObjects
    {
        private int _energy = 100;
        public static event Message MessageDie;
        public int Energy => _energy;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y,size.Width, size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }
        public void Down(Galaxy galaxy)
        {
            if (pos.Y < galaxy.galaxyHeight) pos.Y = pos.Y + dir.Y;
        }

        public void Right()
        {
            pos.X = pos.X + dir.X;
        }
        public void Left()
        {
            pos.X = pos.X - dir.X;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace HomeWorks
{
    class Ship:GalaxyObjects
    {
        private int _energy = 100;
        public static event Message MessageDie;
        public int Energy => _energy;
        string shipPath;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, Size size, string _shipPath) : base(pos, dir, size)
        {
            shipPath = _shipPath;
        }
        public override void Draw()
        {
            // Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y,size.Width, size.Height);
            Bitmap _image = new Bitmap(Application.StartupPath + shipPath);
            Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawImage(_image, rect);
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
            if (pos.Y < galaxy.galaxyHeight-12) pos.Y = pos.Y + dir.Y;
        }

        public void Right(Galaxy galaxy)
        {
            if (pos.X<galaxy.galaxyWidth-12) pos.X= pos.X + dir.X;
        }
        public void Left()
        {
            if (pos.X>0) pos.X = pos.X - dir.X;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}

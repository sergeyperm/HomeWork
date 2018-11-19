using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWorks
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    abstract class GalaxyObjects:ICollision
    {
        public Point pos;
        public Point dir;
        public Size size
        {
            get { return size; }
            set
            {
                //if (value.Height < 10||value.Width<10)
                //{
                //    throw new GameObjectException("Размер объекта не может быть меньше 10");
                //}
            }
        }
        public GalaxyObjects(Point _pos, Point _dir, Size _size)
        {
            pos = _pos;
            dir = _dir;
            size = _size;
        }
        public abstract void Draw();
        public abstract void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(pos, size);

    }
}

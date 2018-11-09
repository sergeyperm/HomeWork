using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWorks
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для
            //текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            //буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static BaseObject[] _objs;
        public static BaseObject[] _stars;
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200,
            //200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200,
            //200));
            //Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            //foreach (BaseObject obj in _objs) obj.Draw();
            foreach (BaseObject obj in _stars) obj.DrawStars();
            Buffer.Render();
        }
        
        public static void Load()
        {
            //_objs = new BaseObject[30];
            //for (int i = 0; i < _objs.Length; i++)
            //    _objs[i] = new BaseObject(new Point(600, i * 30), new Point(15-i, 15-i), new Size(10, 10));
            //foreach (BaseObject obj in _objs)
            //    obj.Update();

            _stars = new BaseObject[300];
            Random rand = new Random();
            int x, y;
            int k, z;
            for (int i = 0; i < _stars.Length; i++)
            {
                x = rand.Next(100,700);
                y = rand.Next(50,550);
                k = rand.Next(100);
                z = rand.Next(100);
                _stars[i] = new BaseObject(new Point(x, y), new Point(k,z), new Size(2, 2));
            }
        }
        public static void Update()
        {
            //foreach (BaseObject obj in _objs)
            //    obj.Update();
        }
    }
}

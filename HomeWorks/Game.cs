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
        static Game()
        {
        }
        
        public static void Init(Form form)
        {
            Graphics g;
            galaxy=new Galaxy(form.ClientSize.Width,form.ClientSize.Height);
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Buffer = _context.Allocate(g, new Rectangle(0, 0, galaxy.galaxyWidth, galaxy.galaxyHeight));
            Timer timer = new Timer { Interval =100};
            timer.Start();
            timer.Tick += Timer_Tick;
            Timer timer1 = new Timer { Interval = 50 };
            timer1.Start();
            timer1.Tick += Timer1_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private static void Timer1_Tick(object sender, EventArgs e)
        {
            if (asteroid.pos.X>galaxy.galaxyWidth||asteroid.pos.X > galaxy.galaxyHeight)
            {
                asteroid = new Asteroid(new Point(rand.Next(galaxy.galaxyWidth), rand.Next(galaxy.galaxyHeight)), new Point(5, 5), new Size(6, 6));
            }
        }

        public static Galaxy galaxy;
        public static Asteroid asteroid=new Asteroid(new Point(10, 200), new Point(5, 5), new Size(6, 6));
        public static Bullet bullet = new Bullet(new Point(500, 200), new Point(5, 5), new Size(6, 6));
        public static Random rand=new Random();
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            galaxy.GalaxyShow();
            asteroid.Draw();
            bullet.Draw();
            Buffer.Render();
        }
        
        public static void Load()
        {
            galaxy.GalaxyCreate();
            galaxy.GalaxyShow();
        }
        public static void Update()
        {
            asteroid.Update();
            bullet.Update();
        }
    }
}

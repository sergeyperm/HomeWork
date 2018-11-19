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
            galaxy = new Galaxy(form.ClientSize.Width, form.ClientSize.Height);
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Buffer = _context.Allocate(g, new Rectangle(0, 0, galaxy.galaxyWidth, galaxy.galaxyHeight));
            Timer timer = new Timer { Interval = 100 };
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
            //if (asteroid1.pos.X>galaxy.galaxyWidth||asteroid1.pos.X > galaxy.galaxyHeight)
            //{
            //    asteroid1 = new Asteroid(new Point(rand.Next(galaxy.galaxyWidth), rand.Next(galaxy.galaxyHeight)), new Point(5, 5), new Size(6, 6));
            //}
        }

        public static Galaxy galaxy;
        //public static Asteroid asteroid = new Asteroid(new Point(10, 200), new Point(5, 5), new Size(6, 6));
        //public static Bullet bullet = new Bullet(new Point(500, 200), new Point(5, 5), new Size(6, 6));
      
        public static Asteroid asteroid1 = new Asteroid(new Point(100, 300), new Point(5, 5), new Size(11,11));
        public static Bullet bullet1 = new Bullet(new Point(500, 300), new Point(5, 5), new Size(11, 11));
        public static Random rand=new Random();
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            galaxy.GalaxyShow();
            asteroid1.Draw();
            bullet1.Draw();
            Buffer.Render();
        }
        
        public static void Load()
        {
            galaxy.GalaxyCreate();
            galaxy.GalaxyShow();
        }
        public static void Update()
        {
            asteroid1.Update();
            bullet1.Update();
            if (asteroid1.Collision(bullet1))
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }
    }
}

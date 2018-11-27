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
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        private static Timer timer = new Timer();
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
            //Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Timer timer1 = new Timer { Interval = 50 };
            timer1.Start();
            timer1.Tick += Timer1_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down(galaxy);
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right();
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif,60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private static void Timer1_Tick(object sender, EventArgs e)
        {
            //if (asteroid.pos.X > galaxy.galaxyWidth || asteroid.pos.X > galaxy.galaxyHeight)
            //{
            //    asteroid = new Asteroid(new Point(rand.Next(galaxy.galaxyWidth), rand.Next(galaxy.galaxyHeight)), new Point(5, 5), new Size(6, 6));
            //}
        }

        public static Galaxy galaxy;
        public static Asteroid asteroid = new Asteroid(new Point(10, 200), new Point(5, 5), new Size(6, 6));
        public static Bullet bullet = new Bullet(new Point(500, 200), new Point(5, 5), new Size(6, 6));
        public static Random rand=new Random();
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            galaxy?.GalaxyShow();
            asteroid?.Draw();
            _ship?.Draw();
            bullet?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy,SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }
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
            if (asteroid.Collision(bullet))
            {
                System.Media.SystemSounds.Beep.Play();
            }
            if (!_ship.Collision(asteroid)) System.Media.SystemSounds.Beep.Play();
            var rnd = new Random();
            //_ship?.EnergyLow(rnd.Next(1, 10));
             System.Media.SystemSounds.Asterisk.Play();
            if (_ship.Energy <= 0) _ship?.Die();
        }
    }
}

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
        private static Ship _ship = new Ship(new Point(500, 200), new Point(5, 5), new Size(10, 10));
        public static Galaxy galaxy;
        public static Asteroid asteroid = new Asteroid(new Point(10, 200), new Point(5, 5), new Size(6, 6));
        public static Bullet bullet;
        public static Sputnik sputnik = new Sputnik(new Point(100, 200), new Point(5, 5), new Size(20, 20), "\\PlanetImages\\sputnik.jpg");
        public static Random rand = new Random();
        private static Timer timer = new Timer();
        public static int countAsteroids = 0;
        static Game()
        {
        }

        public static void Init(Form form)
        {
            Graphics g;
            galaxy = new Galaxy(form.ClientSize.Width, form.ClientSize.Height);
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Buffer = _context  .Allocate(g, new Rectangle(0, 0, galaxy.galaxyWidth, galaxy.galaxyHeight));
            timer.Start();
            timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(8, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down(galaxy);
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right(galaxy);
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif,60, FontStyle.Underline), Brushes.White, 500, 500);
            Buffer.Render();
        }
        
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
            
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            galaxy?.GalaxyShow();
            asteroid?.Draw();
            _ship?.Draw();
            sputnik.Draw();
            bullet?.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy,SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Count asteroids:" + countAsteroids, SystemFonts.DefaultFont, Brushes.White, 100, 0);
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
            sputnik.Update();
            if (bullet != null)
            {
                bullet.Update();

                if (asteroid.Collision(bullet))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    asteroid = null;
                    bullet = null;
                    asteroid = new Asteroid(new Point(rand.Next(10, 100),rand.Next(10,100)), new Point(5, 5), new Size(10, 10));
                    countAsteroids++;
                }
            }
            if (_ship.Collision(asteroid))
            {
                System.Media.SystemSounds.Asterisk.Play();
                _ship?.EnergyLow(5);
            }
            if (_ship.Energy <= 0) _ship?.Die();
        }
    }
}
  
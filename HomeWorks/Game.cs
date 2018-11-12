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
            Graphics g;// Графическое устройство для вывода графики
            galaxy=new Galaxy(form.ClientSize.Width,form.ClientSize.Height);
            _context = BufferedGraphicsManager.Current;// Предоставляет доступ к главному буферу графического контекста для текущего приложения
            g = form.CreateGraphics();
            Buffer = _context.Allocate(g, new Rectangle(0, 0, galaxy.galaxyWidth, galaxy.galaxyHeight));
            Timer timer = new Timer { Interval = 200 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static Galaxy galaxy;
        public static void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);

            Buffer.Render();
        }
        
        public static void Load()
        {
            galaxy.GalaxyCreate();
            galaxy.GalaxyShow();
        }
        public static void Update()
        {
            //foreach (GalaxyObjects obj in _objs)
            //{
            //    obj.Update();
            //}
        }
    }
}

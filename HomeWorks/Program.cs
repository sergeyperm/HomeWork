using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace HomeWorks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            form.Width = 1000;
            form.Height = 600;
            Game.Init(form);
            Game.Load();
            form.Show();
            Game.Draw();
            //try
            //{
            //    Asteroid asteroid2 = new Asteroid(new Point(100, 200), new Point(10, 10), new Size(10, 10));
            //}
            //catch(GameObjectException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            Application.Run(form);
        }
    }
}

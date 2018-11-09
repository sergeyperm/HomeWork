﻿using System;
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
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            Game.Load();
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}

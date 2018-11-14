﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    class Galaxy
    {
        public int galaxyWidth { get; set; }
        public int galaxyHeight { get; set; }
        public List<Star> stars;
        public List<Planet> planets;
        public Galaxy(int _galaxyWidth, int _galaxyHeight)
        {
            galaxyWidth = _galaxyWidth;
            galaxyHeight = _galaxyHeight;
            
        }
        public void GalaxyCreate()
        {
            Random rand = new Random();
            int starPositionX;
            int starPositionY;
            stars = new List<Star>();
            planets = new List<Planet>();
            for (int i = 0; i < 800; i++)
            {
                starPositionX = rand.Next(galaxyWidth);
                starPositionY = rand.Next(galaxyHeight);
                stars.Add(new Star(new Point(starPositionX, starPositionY), new Point(10, 10), new Size(2, 2)));
            }
            planets.Add(new Planet(new Point(500, 200), new Point(10, 10), new Size(150, 150), "\\PlanetImages\\Earth.jpg"));
            planets.Add(new Planet(new Point(800, 100), new Point(10, 10), new Size(50, 50), "\\PlanetImages\\Luna.jpg"));
            planets.Add(new Planet(new Point(25, 25), new Point(10, 10), new Size(200, 200), "\\PlanetImages\\Sun.jpg"));
        }

        public void GalaxyShow()
        {
           
            foreach (Star star in stars)
            {
                star.Draw();
            }
            foreach (Planet planet in planets)
            {
                planet.Draw();
            }
        }
    }
}

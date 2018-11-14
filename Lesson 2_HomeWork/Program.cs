using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Emploers emploers = new Emploers();
            emploers.workers[0] = new WorkerFixSalary("Vadim", 50000.00);
            emploers.workers[1] = new WorkerFixSalary("Sergey", 70000.00);
            emploers.workers[2] = new WorkerFixSalary("Dmtriy", 80000.00);
            emploers.workers[3] = new WorkerFixSalary("Oleg", 90000.00);
            emploers.workers[4] = new WorkerFixSalary("Gleb", 100000.00);
            emploers.workers[5] = new WorkerHourSalary("Andrey", 200.00);
            emploers.workers[6] = new WorkerHourSalary("Alexey", 250.00);
            emploers.workers[7] = new WorkerHourSalary("Stas", 300.00);
            emploers.workers[8] = new WorkerHourSalary("Slava", 280.00);
            emploers.workers[9] = new WorkerHourSalary("Ivan", 270.00);
            emploers.emploersPrint();
            Console.WriteLine("=================");
            Console.ReadKey();
            Array.Sort(emploers.workers,new Emploers());
            emploers.emploersPrint();
            
            Console.ReadKey();
        }
    }
}

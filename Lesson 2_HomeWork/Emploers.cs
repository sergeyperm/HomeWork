using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{
    class Emploers:IComparer
    {
        public Worker[] workers = new Worker[10];
        public Emploers() { }
        public void emploersPrint()
        {
            foreach (Worker w in workers)
            {
                if (w is WorkerFixSalary)
                {
                    Console.WriteLine("Name-{0}   Salary in mounth-{1}", w.name, (w as WorkerFixSalary).fixRate);
                }

                if (w is WorkerHourSalary)
                {
                    Console.WriteLine("Name-{0}   Salary in hour-{1}", w.name, (w as WorkerHourSalary).hourlyRate);
                }


            }
        }
        int IComparer.Compare(object x, object y)
        {
            if ((x is WorkerFixSalary) && (y is WorkerFixSalary))
            {
                if ((x as WorkerFixSalary).fixRate < (y as WorkerFixSalary).fixRate)
                {
                    return 1;
                }
                else if ((x as WorkerFixSalary).fixRate > (y as WorkerFixSalary).fixRate)
                {
                    return -1;
                }
                else return 0;

            }
            if ((x is WorkerHourSalary) && (y is WorkerHourSalary))
            {
                if ((x as WorkerHourSalary).hourlyRate < (y as WorkerHourSalary).hourlyRate)
                {
                    return 1;
                }
                else if ((x as WorkerHourSalary).hourlyRate > (y as WorkerHourSalary).hourlyRate)
                {
                    return -1;
                }
                else return 0;

            }
            return 2;
        }

    }
}

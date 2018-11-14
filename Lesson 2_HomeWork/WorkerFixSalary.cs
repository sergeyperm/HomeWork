using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_HomeWork
{
    class WorkerFixSalary:Worker
    {
        public double fixRate { get; set;}
        public WorkerFixSalary(string _name, double _fixRate) : base(_name)
        {
            fixRate = _fixRate;
        }

        public override void SalaryCalc()
        {
            averageSalary = fixRate;
        }
    }
}

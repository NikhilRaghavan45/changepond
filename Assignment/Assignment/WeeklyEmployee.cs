using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class WeeklyEmployee : Employee
    {
        double WeeklyRate { get; set; }
        int NumberOfWeeks { get; set; }

        public WeeklyEmployee(int Id, string Name, string Job, double WeeklyRate, int NumberOfWeeks) : base(Id, Name, Job)
        {
            this.WeeklyRate = WeeklyRate;
            this.NumberOfWeeks = NumberOfWeeks;
        }

        public override void GetDetails()
        {
            base.GetDetails();
            Console.WriteLine($"Weekly Rate: {WeeklyRate}, Number of Weeks: {NumberOfWeeks}");
        }

        public override double CalcPay()
        {
            return WeeklyRate * NumberOfWeeks;
        }
    }
}

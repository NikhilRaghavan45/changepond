using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class HourlyEmployee : Employee
    {
        double HourlyRate { get; set; }
        int HoursWorked { get; set; }

        public HourlyEmployee(int Id, string Name, string Job, double HourlyRate, int HoursWorked) : base(Id, Name, Job)
        {
            this.HourlyRate = HourlyRate;
            this.HoursWorked = HoursWorked;
        }

        public override void GetDetails()
        {
            base.GetDetails();
            Console.WriteLine($"Hourly Rate: {HourlyRate}, Hours Worked: {HoursWorked}");
        }

        public override double CalcPay()
        {
            return HourlyRate * HoursWorked;
        }
    }
}

using System;

namespace Assignment
{
    internal class Employee
    {
        int Id { get; set; }
        string Name { get; set; }
        string Job { get; set; }

        public Employee(int Id,string Name,string Job)
        {
            this.Id = Id;
            this.Name = Name;
            this.Job = Job;
        }

    
        public virtual void GetDetails()
        {
            Console.WriteLine("Id: " + this.Id);
            Console.WriteLine("Name: " + this.Name);
            Console.WriteLine("Job: " + this.Job);
        }

        public virtual double CalcPay()
        {
            return 0; 
        }
    }
}

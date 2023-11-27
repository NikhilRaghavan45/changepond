using Assignment;
using System;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Choose employee type: (1) Hourly or (2) Weekly");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Job: ");
            string job = Console.ReadLine();

            Console.Write("Enter Hourly Rate: ");
            double hourlyRate = double.Parse(Console.ReadLine());

            Console.Write("Enter Hours Worked: ");
            int hoursWorked = int.Parse(Console.ReadLine());

            HourlyEmployee emp1 = new HourlyEmployee(id, name, job, hourlyRate, hoursWorked);

            Console.WriteLine("Hourly Employee Details:");
            emp1.GetDetails();
            Console.WriteLine($"Pay: {emp1.CalcPay()}");
        }
        else if (choice == 2)
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Job: ");
            string job = Console.ReadLine();

            Console.Write("Enter Weekly Rate: ");
            double weeklyRate = double.Parse(Console.ReadLine());

            Console.Write("Enter Number of Weeks: ");
            int numberOfWeeks = int.Parse(Console.ReadLine());

            WeeklyEmployee weeklyEmployee = new WeeklyEmployee(id, name, job, weeklyRate, numberOfWeeks);

            Console.WriteLine("\nWeekly Employee Details:");
            weeklyEmployee.GetDetails();
            Console.WriteLine($"Pay: {weeklyEmployee.CalcPay()}");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please choose 1 or 2.");
        }
    }
}

using ExampleOnetoOne;

class Program
{
    private static void Main(string[] args)
    {
        Company company = new Company
        {
            
            CompanyName = "Hematite Company"
        };
        Company company1 = new Company
        {

            CompanyName = "Godrej Company"
        };

        Employee employee = new Employee
        {
            EmployeeId = 1,
            EmployeeName = "Nikhil",
            Email = "nikhil@gmail.com",
            Company = company 
        };

        Employee employee1 = new Employee
        {
            EmployeeId = 2,
            EmployeeName = "Mukhil",
            Email = "Mukhil@gmail.com",
            Company = company1
        };

        Console.WriteLine("Employee: " + employee.EmployeeName);
        Console.WriteLine("Company: " + employee.Company.CompanyName);
        Console.WriteLine("Employee: " + employee1.EmployeeName);
        Console.WriteLine("Company: " + employee1.Company.CompanyName);
    }

}
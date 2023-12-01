using ObjectRelations;

internal class Program
{
    private static void Main(string[] args)
    {
        Department department = new Department()
        { DepartmentId = 100, DepartmentName = "Software" };

        Employee employee = new Employee()
        {EmployeeId = 1, EmployeeName = "Nikhil", Email = "nikhil@gmail.com" };
        Employee employee1 = new Employee()
        { EmployeeId = 2, EmployeeName = "Ajay", Email = "ajay@gmail.com" };
        Employee employee2 = new Employee()
        { EmployeeId = 3, EmployeeName = "Surya", Email = "surya@gmail.com" };


        employee.dept = department;

        employee.AddressList = new List<Address>();
        employee.AddressList.Add(new Address() { city = "Chennai", state = "TN", code = 600087 });
        employee.AddressList.Add(new Address() { city = "Ottapalam", state = "KL", code = 688968 });
        employee1.dept=department;
        employee2.dept=department;
       


        Console.WriteLine("Department: " + employee.dept.DepartmentName);
        Console.WriteLine("Employee1 Name:" + employee.EmployeeName);

        foreach(Address address in employee.AddressList)
        {
            Console.WriteLine("Address: "+address.city + ", " + address.state + ", " + address.code);
        }
        Console.WriteLine("Employee1 Email:" + employee.Email);
        Console.WriteLine("Employee2 Name:" + employee1.EmployeeName);
        Console.WriteLine("Employee2 Email:" + employee1.Email);
        Console.WriteLine("Employee3 Name:" + employee2.EmployeeName);
        Console.WriteLine("Employee3 Email:" + employee2.Email);
    }
}
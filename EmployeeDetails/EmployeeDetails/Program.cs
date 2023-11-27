internal class Program
{
    private static void Main(string[] args)
    {

        Employee emp1 = new Employee(1, "Prachi", "pune");
        emp1.getdetails();
        emp1.empId = 1;
        emp1.name = "prachi";
        emp1.location = "pune";
        Console.WriteLine("ID : {0},Name: {1},Location: {2}", emp1.empId, emp1.name, emp1.location);
        Console.WriteLine("***********************************************************");
        emp1 = new Manager(4, "Anand", "Trivendrum", "Cybersecurity");
        emp1.getDetails();


        Console.WriteLine("***********************************************************");
        emp1 = new SalesMan(5, "Manas", "Nagpur", "Pavan Bhoomi");
        emp1.getDetails();

        Console.WriteLine("***********************************************************");
        Manager manager = new Manager(2, "Yashwant", "chennai", "Engineering");
        manager.getDetails();
        manager.empId = 2;
        manager.name = "Shativel";
        manager.location = "chennai";
        manager.departmentName = "Engineering";
        Console.WriteLine("ID : {0},Name: {1},Location: {2}",manager.empId,manager.name,manager.location);
        Console.WriteLine("Department: " + manager.departmentName);
        manager.getManagerDetails();


        SalesMan salesMan = new SalesMan(3, "parag", "chennai", "OMR");
        salesMan.getDetails();
        salesMan.empId = 3;
        salesMan.name = "Parag";
        salesMan.location = "Chennai";
        salesMan.region = "OMR";
        Console.WriteLine("ID : {0},Name: {1},Location: {2}",salesMan.empId,salesMan.name,salesMan.location);
        Console.WriteLine("Region: " + salesMan.region);



        Emp emp = new Emo();
        emp.Tax = 50;
        Console.WriteLine("Native Place: " + emp.nativePlace);
        emp.nativePlace = "pune";
        Console.WriteLine("native Place Changed: " + emp.nativePlace);
        Console.WriteLine("Basic salary: " + emp.salary);
        Console.WriteLine("NetSalary :" + emp.CalculateNetSalary());


        Emp emp = new Emp(101, "Parag Joshi", "Trainer");
        Emp e2 = new Emp();
        Emp e3 = new Emp(103, "Chandrakanth Moghe");
        Emp e4 = new Emp() { empName = "Pankaj", Job = "Developer" };
        Emp e4 = new Emp();
        e4.empName = "Pankaj";
        e4.EmpID = 110;



        Console.WriteLine(Emp.companyName);
        Console.WriteLine(e4.empId);
        Console.WriteLine(e4.empName);
        Console.WriteLine(e4.Job);

        Console.WriteLine("Employee 1 Details");
        Console.WriteLine(Emp.companyName);
        Console.WriteLine(e1.empId);
        Console.WriteLine(e1.empName);
        Console.WriteLine(e1.Job);

        Console.WriteLine("Employee 4 Details");
        Console.WriteLine(Emp.companyName);
        Console.WriteLine(e4.empId);
        Console.WriteLine(e4.empName);
        Console.WriteLine(e4.Job);

        Console.WriteLine("Employee 2 Details");
        Console.WriteLine(Emp.companyName);
        Console.WriteLine(e2.empId);
        Console.WriteLine(e2.empName);
        Console.WriteLine(e2.Job);


        Console.WriteLine("Employee 3 Details");
        Console.WriteLine(Emp.companyName);
        Console.WriteLine(e3.empId);
        Console.WriteLine(e3.empName);
        Console.WriteLine(e3.Job);


    }
}

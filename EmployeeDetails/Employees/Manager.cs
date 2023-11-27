using System;
public class manager : Employee
{
    public string departmentName { get; set; }

    public manager(int empId,string name,string location,string departmentName) : base(empId, name, location)
    {
        this.departmentName = departmentName;
    }
    public override void getDetails()
    {
        base.getDetails();
        getManagerDetails();
        Console.WriteLine("Total Sales of the year" + this.totalSalesOfTheYear());
    }
    public void getManagerDetails()
    {
        Console.WriteLine("Manager : {0} from department {1} workd in the location {2}", base.name, this.departmentName, base.location);

    }

    private long totalSalesOfTheYear()
    {
        return 10000;
    }
}

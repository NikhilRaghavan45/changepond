using System;

public class SalesMan: Employee
{
    public string region { get; set; }
    public SalesMan(int empId,string name,string location,string region):base(empId,name,location)
    {
        this.region = region;
    }
    public override void getDetails()
    {
       
            base.getDetails();
        Console.WriteLine("Region: " + region);
        Console.WriteLine("sales of the current month: "+getSalesOfTheCurrentMonth());
        
    }

    private long getSalesOfTheCurrentMonth()
    {
        return 1000;
    }
}


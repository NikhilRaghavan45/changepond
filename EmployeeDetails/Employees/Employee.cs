using System;
public class Employee
{
    public int empId { get; set; }
    public string name { get; set; }
    public string location { get; set; }

    public Employee(int empId, string name, string location)
    {
        this.empId = empId;
        this.name = name;
        this.location = location;
    }


    public virtual void getDetails()
    {
        Console.WriteLine("Id: " + this.empId);
        Console.WriteLine("Name: " + this.name);
        Console.WriteLine("Location: " + this.location);
    }

 }
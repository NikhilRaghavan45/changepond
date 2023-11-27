using System;

public class Emp
{
    public int EmpID;
    public string Name;
    public string Job;
    private int _salary;
    private double _tax;

    public int Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }

    public double Tax
    {
        set
        {
            if (value > 0 && value < 100)
            {
                _tax = value;
            }
            
        }
    }

    public double CalculateNetSalary()
    {
        return Salary - (Salary * _tax);
    }

    public Emp(int empID, string name, string job)
    {
        EmpID = empID;
        Name = name;
        Job = job;
    }

    public string NativePlace { get; set; } = "Chennai";
}
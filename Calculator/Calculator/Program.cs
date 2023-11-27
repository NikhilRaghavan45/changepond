public static class Calculator
{
    private static int _resultStorage = 0;
    public static string Type = "Arithmetic";
    public static int sum(int n1, int n2)
    {
        return n1 + n2;
    }
    public static void store(int result)
    {
        _resultStorage=result;
        Console.WriteLine("Result: {0}", _resultStorage);
    }
}

public class StopWatch
{
    public static int noofinstances = 0;
    public string watchbrand = "Timex";
    static StopWatch()
    {
        Console.WriteLine("static Constructed called");

    }
    public StopWatch() { 
        Console.WriteLine("Regular Constructed called");
        StopWatch.noofinstances++;
    }
   
}

internal class Program
{
    private static void Main(string[] args)
    {
        var result = Calculator.sum(10, 20);
        Calculator.store(result);
        result=Calculator.sum(30, 40);
        Calculator.store(result);
        Calculator.Type = "Scientific";
        StopWatch watch=new StopWatch();
        StopWatch watch2=new StopWatch();
        Console.WriteLine(StopWatch.noofinstances);
        StopWatch watch3 = new StopWatch();
        Console.WriteLine(StopWatch.noofinstances);
    }
}
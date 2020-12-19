using System;
using System.Diagnostics;

Machine machine = new Machine();

var machine1Metrics = machine.Run(machine.ToDo1);
Console.WriteLine($"Machine 1 was running for { machine1Metrics.Item2.ElapsedMilliseconds } ms");

var machine2Metrics = machine.Run(machine.ToDo2);
Console.WriteLine($"Machine 2 was running for { machine2Metrics.Item2.ElapsedMilliseconds } ms");

public class Machine
{
    public delegate void ToDo();

    public Tuple<ToDo, Stopwatch> Run(ToDo toDoMethod)
    {
        var stopWatch = new Stopwatch();

        stopWatch.Start();
        toDoMethod();
        stopWatch.Stop();

        return new ( toDoMethod, stopWatch );
    }

    public void ToDo1()
    {
        Console.WriteLine("Odpalam maszynę 1");
        Console.WriteLine("Wrum wrum 1");
        Console.WriteLine("Zamykam maszynę 1");
    }

    public void ToDo2()
    {
        Console.WriteLine("Odpalam maszynę 2");
        Console.WriteLine("Wrum wrum 2");
        Console.WriteLine("Zamykam maszynę 2");
    }
}
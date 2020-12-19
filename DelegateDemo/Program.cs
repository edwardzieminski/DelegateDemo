using System;
using System.Diagnostics;

Machine machine = new Machine();

machine.Run(machine.ToDo1);
machine.Run(machine.ToDo2);

public class Machine
{
    public delegate void ToDo();

    public Stopwatch Run(ToDo toDoMethod)
    {
        var stopWatch = new Stopwatch();

        stopWatch.Start();
        toDoMethod();
        stopWatch.Stop();

        return stopWatch;
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
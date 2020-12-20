using System;
using System.Diagnostics;

Action toDo1 = () =>
{
    Console.WriteLine("Machine 1 is starting.");
    Console.WriteLine("Machine 1 is working now...");
    Console.WriteLine("Machine 1 is closing.");
};

Action toDo2 = () =>
{
    Console.WriteLine("Machine 2 is starting.");
    Console.WriteLine("Machine 2 is working now...");
    Console.WriteLine("Machine 2 is closing.");
};

var machine1Metrics = Machine.Run(toDo1);
Console.WriteLine($"Machine 1 was running for { machine1Metrics.StopWatch.ElapsedMilliseconds } ms");

var machine2Metrics = Machine.Run(toDo2);
Console.WriteLine($"Machine 2 was running for { machine2Metrics.StopWatch.ElapsedMilliseconds } ms");

public static class Machine
{
    public static MachineResults Run(Action toDoAction)
    {
        var stopWatch = new Stopwatch();

        stopWatch.Start();
        toDoAction();
        stopWatch.Stop();

        return new ( toDoAction, stopWatch );
    }
}

public record MachineResults(Action ToDoAction, Stopwatch StopWatch);
using System.Diagnostics;
int positionGoal = 100000;


var stopwatch = new Stopwatch();
stopwatch.Start();

var res = RecursiveFibonacci(5);

stopwatch.Stop();

Console.WriteLine(res);
Console.WriteLine(stopwatch.ToString());

stopwatch.Reset();
stopwatch.Start();

res = Fibonacci(positionGoal);

Console.WriteLine(res);
Console.WriteLine(stopwatch.ToString());

Console.ReadKey();




ulong RecursiveFibonacci(int position) {
    if (position == 2 || position == 1) return 1;
    return RecursiveFibonacci(position - 2) + RecursiveFibonacci(position - 1);
}

ulong Fibonacci(int position)
{
    if (position == 2 || position == 1) return 1;

    ulong previous = 1;
    ulong current = 1;
    for (int i = 0; i < position-2; i++)
    {
        var next = previous + current;
        previous = current;
        current = next;
    }


    return current;
}
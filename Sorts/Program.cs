using System.Diagnostics;

Console.OutputEncoding = System.Text.Encoding.UTF8;

const int maxSize = 100000;
const int step = 1;

long totalBinaryTicks = 0;
long totalIterativeTicks = 0;

int binaryWins = 0;
int iterativeWins = 0;

Console.WriteLine("╔════════════════════════════════════════════╗");
Console.WriteLine("║        SEARCH WIN TRACKING BENCHMARK       ║");
Console.WriteLine("╚════════════════════════════════════════════╝");
Console.WriteLine();

for (int size = step; size <= maxSize; size += step)
{
    var input = Enumerable.Range(1, size).ToArray();
    int target = size / 2;

    // ---------------- Binary Search ----------------
    var sw = Stopwatch.StartNew();
    BinarySearch(input, target);
    sw.Stop();
    long binaryTicks = sw.ElapsedTicks;

    // ---------------- Iterative Search ----------------
    sw.Restart();
    IterativeSearch(input, target);
    sw.Stop();
    long iterativeTicks = sw.ElapsedTicks;

    totalBinaryTicks += binaryTicks;
    totalIterativeTicks += iterativeTicks;

    // ---------------- WIN LOGIC ----------------
    if (binaryTicks < iterativeTicks)
        binaryWins++;
    else if (iterativeTicks < binaryTicks)
        iterativeWins++;

    // Optional live log (comment out if noisy)
    Console.WriteLine(
        $"Size {size,6:N0} | " +
        $"Binary {binaryTicks,6:N0} | " +
        $"Linear {iterativeTicks,6:N0} | " +
        $"{(binaryTicks < iterativeTicks ? "Binary wins" : "Linear wins")}"
    );
}

// ---------------- FINAL REPORT ----------------

Console.WriteLine();
Console.WriteLine("╔════════════════════════════════════════════╗");
Console.WriteLine("║                FINAL REPORT                ║");
Console.WriteLine("╚════════════════════════════════════════════╝");

Console.WriteLine();

Console.WriteLine("📊 TOTAL PERFORMANCE");
Console.WriteLine($"Binary Search   : {totalBinaryTicks:N0} ticks");
Console.WriteLine($"Linear Search   : {totalIterativeTicks:N0} ticks");

Console.WriteLine();

Console.WriteLine("🏁 WIN COUNTS (per array size)");
Console.WriteLine($"Binary wins     : {binaryWins}");
Console.WriteLine($"Linear wins     : {iterativeWins}");

Console.WriteLine();

if (binaryWins > iterativeWins)
{
    Console.WriteLine("⚡ Overall winner: Binary Search (more wins)");
}
else if (iterativeWins > binaryWins)
{
    Console.WriteLine("⚡ Overall winner: Linear Search (more wins)");
}
else
{
    Console.WriteLine("⚖️ It's a tie (by win count)");
}

void InsertionSort(int[] arr)
{
    int n = arr.Length;
    for (int i = 1; i < n; ++i)
    {
        int key = arr[i];
        int j = i - 1;

        /* Move elements of arr[0..i-1], that are
           greater than key, to one position ahead
           of their current position */
        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j = j - 1;
        }
        arr[j + 1] = key;
    }
}


int BinarySearch(int[] arr, int target)
{
    var low = 0;
    var high = arr.Length - 1;


    while(low <= high)
    {
        var mid = (low + high) / 2;

        if (arr[mid] == target)
        {
            return mid;
        }

        if (target > arr[mid])
        {
            low = mid + 1;
        }
        if(target < arr[mid])
        {
            high = mid - 1;
        }
    }

    return -1;
}

int IterativeSearch(int[] arr, int target)
{
    for(int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == target)
        {
            return i;
        }
    }

    return -1;
}

void PrintArray(int[] arr)
{
    // Print indexes
    Console.Write("Index : ");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"{i,4}");
    }

    Console.WriteLine();

    // Print separator
    Console.Write("        ");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write("----");
    }

    Console.WriteLine();

    // Print values
    Console.Write("Value : ");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"{arr[i],4}");
    }

    Console.WriteLine();
}
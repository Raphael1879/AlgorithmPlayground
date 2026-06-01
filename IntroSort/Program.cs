using IntroSort;
using System.Diagnostics;

//var originalData = new[] { 8, 3, 5, 1, 9, 2, 33, 78, 232, 2312, 1231, 213, 4, 64, 7657456, 45848, 465456, 4646, 34522, 7876989, 7866, 6444, 3322, 1, 1, 32, 54, 7 };
var originalData = Enumerable.Range(1, 10000).ToArray();

var introData = (int[])originalData.Clone();

var sw1 = Stopwatch.StartNew();
IntroSort.IntroSort.Sort(introData);
sw1.Stop();

Console.WriteLine("Intro Sort result:");
Console.WriteLine(SortHelper.GetArrayString(introData, 0, 100));
Console.WriteLine($"Intro Sort time: {sw1.ElapsedTicks} ticks");

Console.WriteLine();

var quickData = (int[])originalData.Clone();

var sw2 = Stopwatch.StartNew();
QuickSort.Sort(quickData);
sw2.Stop();

Console.WriteLine("QuickSort result:");
Console.WriteLine(SortHelper.GetArrayString(quickData, 0, 100));
Console.WriteLine($"QuickSort time: {sw2.ElapsedTicks} ticks");

Console.WriteLine("Done.");
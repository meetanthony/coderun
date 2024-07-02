using System;
using System.Collections.Generic;

namespace P02ListGrowing;

internal class Program
{
    static void Main(string[] args)
    {
        var sarr = GetIntsWhileLineIsNotEmpty();

        Console.WriteLine(IsArrayAscending(sarr) ? "YES" : "NO");
    }

    static bool IsArrayAscending(List<int> sarr)
    {
        if (sarr.Count == 0) 
            return false;

        int prev = sarr[0];
        for (int i = 1; i < sarr.Count; i++)
        {
            var curr = sarr[i];
            if (prev >= curr)
                return false;
            prev = curr;
        }

        return true;
    }

    #region ConsoleCommons

    private static int ReadInt32()
    {
        var line = Console.ReadLine();
        if (line == null)
            return 0;

        return int.Parse(line);
    }

    private static List<int> GetIntsWhileLineIsNotEmpty()
    {
        var sarr = new List<int>();
        string? line;
        while (string.IsNullOrEmpty(line = Console.ReadLine()) == false)
        {
            var words = line.Split(' ');
            foreach (var word in words)
            {
                sarr.Add(Int32.Parse(word));
            }
        }

        return sarr;
    }

    #endregion
}
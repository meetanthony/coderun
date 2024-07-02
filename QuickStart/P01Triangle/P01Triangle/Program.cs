using System;

namespace P01Triangle;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] lineLengths =
        {
            GetOneInt32FromLine(),
            GetOneInt32FromLine(),
            GetOneInt32FromLine(),
        };

        Console.WriteLine(IsTrianglePossible(lineLengths) ? "YES" : "NO");
    }

    private static bool IsTrianglePossible(int[] lineLengths)
    {
        Array.Sort(lineLengths);
        return lineLengths[0] + lineLengths[1] > lineLengths[2];
    }

    #region ConsoleCommons

    private static int GetOneInt32FromLine()
    {
        var line = Console.ReadLine();
        if (line == null)
            return 0;

        return int.Parse(line);
    }

    #endregion ConsoleCommons
}
using System;

namespace P01Triangle;

internal class Program
{
    static void Main(string[] args)
    {
        int[] lineLengths =
        {
            ReadInt32(),
            ReadInt32(),
            ReadInt32(),
        };

        Console.WriteLine(IsTrianglePossible(lineLengths) ? "YES" : "NO");
    }

    static bool IsTrianglePossible(int[] lineLengths)
    {
        Array.Sort(lineLengths);
        return lineLengths[0] + lineLengths[1] > lineLengths[2];
    }

    #region ConsoleCommons

    private static int ReadInt32()
    {
        var line = Console.ReadLine();
        if (line == null)
            return 0;

        return int.Parse(line);
    }

    #endregion
}
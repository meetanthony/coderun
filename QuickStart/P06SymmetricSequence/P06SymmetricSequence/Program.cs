using System;
using System.Collections.Generic;
using System.Text;

namespace P06SymmetricSequence;

public static class Program
{
    static void Main(string[] args)
    {
        var numbersCount = ReadInt32();

        var numbers = GetInts32FromOneLine();
        
        var addition = GetAdditionToSymmetric(numbers);

        Console.WriteLine(addition.Length);

        if (addition.Length == 0)
        {
            return;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < addition.Length; i++)
        {
            sb.Append(addition[i]);
            if (i != addition.Length - 1)
                sb.Append(" ");
        }
        Console.WriteLine(sb.ToString());
    }

    public static int[] GetAdditionToSymmetric(List<int> sourceNumbers)
    {
        var beginPtr = 0;
        var endPtr = sourceNumbers.Count-1;

        int lastNonSymmetricPrt = -1;
        while (beginPtr < endPtr)
        {
            if (sourceNumbers[beginPtr] == sourceNumbers[endPtr])
            {
                endPtr--;
            }
            else
            {
                endPtr = sourceNumbers.Count - 1;
                lastNonSymmetricPrt = beginPtr;
            }

            beginPtr++;
        }

        if (lastNonSymmetricPrt == -1)
            return Array.Empty<int>();

        var numbers = new int[lastNonSymmetricPrt+1];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = sourceNumbers[lastNonSymmetricPrt - i];
        }

        return numbers;
    }

    #region ConsoleCommons

    private static int ReadInt32()
    {
        var line = Console.ReadLine();
        if (line == null)
            return 0;

        return int.Parse(line);
    }

    private static List<int> GetInts32FromOneLine(int expectedNumbersCount = -1)
    {
        var ints = new List<int>();
        string? line = Console.ReadLine();
        if (line == null)
            return ints;

        var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (expectedNumbersCount == -1)
            expectedNumbersCount = words.Length;

        for (var i = 0; i < expectedNumbersCount; i++)
        {
            var word = words[i];
            ints.Add(int.Parse(word));
        }

        return ints;
    }

    private static List<int> GetInts32WhileLineIsNotEmpty()
    {
        var ints = new List<int>();
        var intsFromLine = GetInts32FromOneLine();
        while (intsFromLine.Count > 0)
        {
            ints.AddRange(intsFromLine);
            intsFromLine = GetInts32FromOneLine();
        }

        return ints;
    }

    private static List<string> GetWordsWhileLineIsNotEmpty()
    {
        var allWords = new List<string>();

        string? line;
        while (string.IsNullOrEmpty(line = Console.ReadLine()) == false)
        {
            var words = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            allWords.AddRange(words);
        }

        return allWords;
    }

    #endregion ConsoleCommons
}
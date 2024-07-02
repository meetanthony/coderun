using System;
using System.Collections.Generic;

namespace P05NearestNumber;

internal class Program
{
    static void Main(string[] args)
    {
        var numbersCount = ReadInt32();
        
        var numbers = GetInts32FromOneLine(numbersCount);
        
        var targetValue = ReadInt32();

        var result = GetNearestNumber(numbers, targetValue);

        Console.WriteLine(result);
    }

    private static int GetNearestNumber(IEnumerable<int> numbers, int targetValue)
    {
        int? result= null;
        foreach (var number in numbers)
        {
            result ??= number;

            if (Math.Abs(number - targetValue) >= Math.Abs(result.Value - targetValue))
                continue;

            result = number;
        }
        
        if (result == null) return 0;

        return result.Value;
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
using System;
using System.Collections.Generic;

namespace P04NumberWordsText;

internal class Program
{
    private static void Main(string[] args)
    {
        var allWords = GetWordsWhileLineIsNotEmpty();

        var wordsCount = UniqueWordsCount(allWords);

        Console.WriteLine(wordsCount);
    }

    private static int UniqueWordsCount(IEnumerable<string> words)
    {
        HashSet<string> hashSet = new HashSet<string>();
        foreach (var word in words)
        {
            hashSet.Add(word);
        }

        return hashSet.Count;
    }

    #region ConsoleCommons

    private static int ReadInt32()
    {
        var line = Console.ReadLine();
        if (line == null)
            return 0;

        return int.Parse(line);
    }

    private static List<int> GetInts32FromOneLine()
    {
        var ints = new List<int>();
        string? line = Console.ReadLine();
        if (line == null)
            return ints;

        var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        for (var i = 0; i < words.Length; i++)
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
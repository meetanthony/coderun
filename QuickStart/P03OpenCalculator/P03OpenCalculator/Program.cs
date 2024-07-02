using System;
using System.Collections.Generic;

namespace P03OpenCalculator;

internal class Program
{
    private static void Main(string[] args)
    {
        var buttons = GetInts32FromOneLine();

        var number = ReadInt32();

        Console.WriteLine(AdditionalButtonsCount(buttons, number));
    }

    private static int AdditionalButtonsCount(List<int> buttons, int number)
    {
        bool[] existingButtons = new bool[10];
        for (int i = 0; i < buttons.Count; i++)
        {
            existingButtons[buttons[i]] = true;
        }

        var addButtonsCounter = 0;
        do
        {
            var button = number % 10;
            if (existingButtons[button] == false)
            {
                existingButtons[button] = true;
                addButtonsCounter++;
            }
            number /= 10;
        } while (number != 0);

        return addButtonsCounter;
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

    #endregion ConsoleCommons
}
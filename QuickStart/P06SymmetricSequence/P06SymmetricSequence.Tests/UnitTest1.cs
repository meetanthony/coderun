using System;
using System.Collections.Generic;
using Common.TestData;

namespace P06SymmetricSequence.Tests;

public class UnitTest1
{
    private const int MaxArrayLength = 8;
        
    [Fact]
    public void CheckAlgorithm()
    {
        for (int i = 0; i <= MaxArrayLength; i++)
        {
            BruteForceArrays<int> brutforcer = new BruteForceArrays<int>(i, 0, 9);

            var zeroSymmetric = new List<int>(Program.GetAdditionToSymmetric(new List<int>()));
            Assert.True(IsItSymmetric(zeroSymmetric));

            foreach (int[] numbers in brutforcer)
            {
                var listOfNumbers = new List<int>(numbers);
                var additionToSymmetric = Program.GetAdditionToSymmetric(listOfNumbers);
                listOfNumbers.AddRange(additionToSymmetric);

                Assert.True(IsItSymmetric(listOfNumbers));
            }
        }
    }
        
    private bool IsItSymmetric(List<int> numbers)
    {
        int beginPtr = 0;
        int endPtr = numbers.Count - 1;
        while (beginPtr < endPtr)
        {
            if (numbers[beginPtr] != numbers[endPtr])
                return false;
            beginPtr++;
            endPtr--;
        }

        return true;
    }
}
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();

        int maxValue = 0;
        int maxEven = -1;

        for (int i = 0; i < input.Length; i++)
        {
            bool isNumeric = int.TryParse(input[i], out maxValue);
            if (input[i].Contains('.'))
            {
                Console.WriteLine(maxEven);
                return;
            }
            if (isNumeric)
            {
                if (maxValue % 2 == 0)
                {
                    if (maxValue > maxEven)
                    {
                        maxEven = maxValue;
                    }
                }
            }
        }
        Console.WriteLine(maxEven);
    }

    
}
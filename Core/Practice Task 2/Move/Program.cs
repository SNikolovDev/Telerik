using System;
using System.Collections;
using System.Linq;

namespace Spiral_Matrix
{
    class Test
    {
        static void Main(string[] args)
        {
            int position = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            int forwardSum = 0;
            int backwardsSum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "exit")
                {
                    break;
                }

                string[] command = input
                    .Split(' ');

                int times = int.Parse(command[0]);
                string direction = command[1];
                int stepSize = int.Parse(command[2]);

                if (stepSize > arr.Length - 1)
                {
                    stepSize = stepSize % arr.Length;
                }

                switch (direction)
                {
                    case "forward":
                        for (int i = 0; i < times; i ++)
                        {

                            int nextPosition = position + stepSize;
                            if (nextPosition > arr.Length - 1)
                            {
                                position = nextPosition % arr.Length;
                            }
                            else
                            {
                                position = nextPosition;
                            }

                            forwardSum += arr[position];
                        }

                        break;

                    case "backwards":

                        for (int i = times - 1; i >= 0; i --)
                        {
                            int nextPosition = position - stepSize;
                            if (nextPosition < 0)
                            {
                                position = arr.Length - Math.Abs(nextPosition);
                            }
                            else
                            {
                                position = nextPosition;
                            }

                            backwardsSum += arr[position];
                        }

                        break;
                }
            }

            Console.WriteLine($"Forward: {forwardSum}");
            Console.WriteLine($"Backwards: {backwardsSum}");
        }
    }
}
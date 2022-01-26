using System;
using System.Linq;

namespace Matrix_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }

            int[] coordinates = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

            int sum = 0;

            for (int i = 0; i < coordinates.Length / 2; i += 2)
            {
                int rowCoordinates = coordinates[i] - 1;
                int colCoordinates = coordinates[i + 1] - 1;
                //if row is positive, moove right
                if (rowCoordinates >= 0)
                {
                    rowCoordinates = Math.Abs(rowCoordinates);
                    colCoordinates = Math.Abs(colCoordinates);
                    for (int j = 0; j <= colCoordinates; j++)
                    {
                        sum += matrix[rowCoordinates][j];
                    }

                    if (colCoordinates >= 0)
                    {
                        for (int j = rowCoordinates - 1; j > 0; j--)
                        {
                            sum += matrix[rowCoordinates][j];
                        }
                    }

                    if (colCoordinates >= 0)
                    {
                        for (int j = rowCoordinates - 1; j >= 0; j--)
                        {
                            sum += matrix[rowCoordinates][j];
                        }
                    }
                    else
                    {
                        for (int j = colCoordinates + 1; j < matrix.GetLength(1); j++)
                        {
                            sum += matrix[rowCoordinates][j];
                        }
                    }

                    Console.WriteLine(sum);
                    sum = 0;
                }

                if (rowCoordinates < 0)
                {
                    rowCoordinates = Math.Abs(rowCoordinates);
                    colCoordinates = Math.Abs(colCoordinates);
                    for (int j = matrix.GetLength(0) - 1; j >= colCoordinates; j--)
                    {
                        sum += matrix[rowCoordinates][colCoordinates];
                    }

                    if (colCoordinates >= 0)
                    {
                        for (int j = rowCoordinates - 1; j >= 0; j--)
                        {
                            sum += matrix[rowCoordinates][j];
                        }
                    }

                    if (colCoordinates >= 0)
                    {
                        for (int j = rowCoordinates - 1; j >= 0; j--)
                        {
                            sum += matrix[rowCoordinates][j];
                        }
                    }
                    else
                    {
                        for (int j = colCoordinates + 1; j < matrix.GetLength(1); j++)
                        {
                            sum += matrix[rowCoordinates][j];
                        }
                    }
                }
                Console.WriteLine(sum);
                sum = 0;
            }

        }
    }
}

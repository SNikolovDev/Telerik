using System;

namespace Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int size = n * n;
            int[,] matrix = new int[n, n];
            int top = 0;
            int bottom = n - 1;
            int left = 0;
            int right = n - 1;
            int cellValue = 1;

            while (cellValue <= size)
            {
                for (int i = left; i <= right && cellValue <= size; i++)
                {
                    matrix[top, i] = cellValue;
                    cellValue++;
                }

                top++;
                for (int i = top; i <= bottom && cellValue <= size; i++)
                {
                    matrix[i, right] = cellValue;
                    cellValue++;
                }

                right--;
                for (int i = right; i >= left && cellValue <= size; i--)
                {
                    matrix[bottom, i] = cellValue;
                    cellValue++;
                }

                bottom--;

                for (int i = bottom; i >= top && cellValue <= size; i--)
                {
                    matrix[i, left] = cellValue;
                    cellValue++;
                }

                left++;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine(); ;
            }
        }
    }
}

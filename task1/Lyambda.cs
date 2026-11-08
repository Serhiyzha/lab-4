using System;

namespace DiagonalExtractor
{
    public delegate string[] GetMainDiagonalDelegate(string[,] matrix);

    internal class Lyambda
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Робота з делегатом та лямбда-виразом");

            GetMainDiagonalDelegate extractDiagonal = (string[,] matrix) =>
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                int size = Math.Min(rows, cols);

                string[] result = new string[size];
                for (int i = 0; i < size; i++)
                {
                    result[i] = matrix[i, i];
                }
                return result;
            };

            string[,] matrix = {
                { "Рядок_0_0", "Рядок_0_1", "Рядок_0_2" },
                { "Рядок_1_0", "Рядок_1_1", "Рядок_1_2" },
                { "Рядок_2_0", "Рядок_2_1", "Рядок_2_2" }
            };

            string[] diagonal = extractDiagonal(matrix);

            Console.WriteLine("\nЕлементи головної діагоналі:");
            foreach (var item in diagonal)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
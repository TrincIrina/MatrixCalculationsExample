using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixCalculationsExample
{
    // MatrixCalculations - класс для процедур, связанных с матричными вычислениями
    internal static class MatrixCalculations
    {
        // ОСНОВНЫЕ ПРОЦЕДУРЫ

        // процедура вычисления суммы двух матриц
        public static void Sum(int[][] m1, int[][] m2, int[][] result)
        {
            for(int i = 0; i < m1.Length; i++)
            {
                for(int j = 0; j < m1[i].Length; j++)
                {
                    result[i][j] = m1[i][j] + m2[i][j];
                }
            }
        }

        // процедура вычисления произведения матриц
        public static void Mult(int[][] m1, int[][] m2, int[][] result)
        {
            for(int i = 0; i < m1.Length; i++)
            {
                for (int j = 0; j < m1[i].Length; j++)
                {
                    result[i][j] = 0;
                    for(int k = 0; k < m1[i].Length; k++)
                    {
                        result[i][j] += m1[i][k] * m2[k][j];
                    }
                }
            }
        }
        // SumParallel - аналогично Sum, но выполнение происходит с распараллеливанием на 
        // threadNumber потоков
        public static void SumParallel(int[][] m1, int[][] m2, int[][] result, int threadNumber)
        {
            Thread[] threads = new Thread[threadNumber];
            int rowsNumber = m1.Length / threadNumber;
            // Подготовка и запуск потоков
            for(int k = 0; k < threads.Length; k++)
            {
                int start = rowsNumber * k;
                int end = start + rowsNumber;
                if(k == threadNumber - 1)
                {
                    end = m1.Length;
                }
                threads[k] = new Thread(() =>
                {
                    for (int i = start; i < end; i++)
                    {
                        for (int j = 0; j < m1[i].Length; j++)
                        {
                            result[i][j] = m1[i][j] + m2[i][j];
                        }
                    }
                });
                threads[k].Start();
            }
            // Ожидание потоков
            foreach(var thread in threads)
            {
                thread.Join();
            }
        }

        // MultParallel - аналогично Mult, но выполнение происходит с распараллеливанием на 
        // threadNumber потоков
        public static void MultParallel(int[][] m1, int[][] m2, int[][] result, int threadNumber)
        {
            Thread[] threads = new Thread[threadNumber];
            int rowsNumber = m1.Length / threadNumber;
            // Подготовка и запуск потоков
            for (int k = 0; k < threads.Length; k++)
            {
                int start = rowsNumber * k;
                int end = start + rowsNumber;
                if (k == threadNumber - 1)
                {
                    end = m1.Length;
                }
                threads[k] = new Thread(() =>
                {
                    for (int i = start; i < end; i++)
                    {
                        for (int j = 0; j < m1[i].Length; j++)
                        {
                            result[i][j] = 0;
                            for (int l = 0; l < m1[i].Length; l++)
                            {
                                result[i][j] += m1[i][l] * m2[l][j];
                            }
                        }
                    }
                });
                threads[k].Start();
            }
            // Ожидание потоков
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        // ВСПОМОГАТЕЛЬНЫЕ ПРОЦЕДУРЫ

        // GenerateRandom - процедура генерации матрицы, заполненной случайными элементами
        // m - кол-во строк, n - кол-во столбцов, min - минимальное значение элементов, max - максимальное
        public static int[][] GenerateRandom(int m, int n, int min, int max, Random random)
        {
            int[][] matrix = new int[m][];
            for(int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
            }
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrix[i][j] = random.Next(min, max + 1);
                }
            }
            return matrix;
        }

        // Print - процедура вывода матрицы в консоль
        public static void Print(int[][] matrix)
        {
            foreach(int[] row in matrix)
            {
                foreach(int item in row)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // AreEqual - процедура сравнения двух матриц (поэлементно)
        public static bool AreEqual(int[][] m1, int[][] m2)
        {
            
            for(int i = 0; i < m1.Length; i++)
            {
                for(int j = 0; j < m1[i].Length; j++)
                {
                    if (m1[i][j] != m2[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

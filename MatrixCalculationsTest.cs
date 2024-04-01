using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculationsExample
{
    // MatrixCalculationsTest - класс с процедурами тестирования матричных вычислений
    internal static class MatrixCalculationsTest
    {
        // TestSum - тестирование суммы
        public static void TestSum()
        {
            Random r = new Random();
            Console.Write("Enter row: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter min: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enetr max: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[][] m1 = MatrixCalculations.GenerateRandom(m, n, min, max, r);            
            int[][] m2 = MatrixCalculations.GenerateRandom(m, n, min, max, r);            
            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }
            Console.WriteLine("Sum started");
            Stopwatch sw = Stopwatch.StartNew();
            MatrixCalculations.Sum(m1, m2, res);
            sw.Stop();
            Console.WriteLine($"Sum finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            Console.Write("Enter print y/n: ");
            string p = Console.ReadLine();
            if (p == "y")
            {
                MatrixCalculations.Print(m1);
                MatrixCalculations.Print(m2);
                MatrixCalculations.Print(res);
            }            
        }

        // TestSumParallel - тестирование параллельной суммы
        public static void TestSumParallel()
        {
            Random r = new Random();
            Console.Write("Enter row: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter min: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enetr max: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[][] m1 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] m2 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }
            Console.Write("Enter number threads: ");
            int threadNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum started");
            Stopwatch sw = Stopwatch.StartNew();
            MatrixCalculations.SumParallel(m1, m2, res, threadNumber);
            sw.Stop();
            Console.WriteLine($"Sum finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            Console.Write("Enter print y/n: ");
            string p = Console.ReadLine();
            if (p == "y")
            {
                MatrixCalculations.Print(m1);
                MatrixCalculations.Print(m2);
                MatrixCalculations.Print(res);
            }
        }

        // TestSums - тестирование двух вариантов суммирования со сравнением результатов
        public static void TestSums()
        {
            Random r = new Random();
            Console.Write("Enter row: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter min: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enetr max: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[][] m1 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] m2 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }
            Console.WriteLine("Sum started");
            Stopwatch sw = Stopwatch.StartNew();
            MatrixCalculations.Sum(m1, m2, res);
            sw.Stop();
            Console.WriteLine($"Sum finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            Console.Write("Enter number threads: ");
            int threadNumber = Convert.ToInt32(Console.ReadLine());
            int[][] res1 = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res1[i] = new int[n];
            }
            Console.WriteLine("Sum parallel started");
            sw.Start();
            MatrixCalculations.SumParallel(m1, m2, res1, threadNumber);
            sw.Stop();
            Console.WriteLine($"Sum parallel finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            if(MatrixCalculations.AreEqual(res, res1))
            {
                Console.WriteLine("Matrix equal");
            }
            else
            {
                Console.WriteLine("Matrix not equal");
            }
        }

        // Тестирование умножения
        public static void TestMult()
        {
            Console.WriteLine("Matrix multiplication:");
            Random r = new Random();
            Console.Write("Enter row: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter min: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enetr max: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[][] m1 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] m2 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }
            Console.WriteLine("Multiplication started");
            Stopwatch sw = Stopwatch.StartNew();
            MatrixCalculations.Mult(m1, m2, res);
            sw.Stop();
            Console.WriteLine($"Multiplication finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            Console.Write("Enter print y/n: ");
            string p = Console.ReadLine();
            if (p == "y")
            {
                Console.WriteLine("The first matrix:");
                MatrixCalculations.Print(m1);
                Console.WriteLine("The second matrix:");
                MatrixCalculations.Print(m2);
                Console.WriteLine("The product of matrices:");
                MatrixCalculations.Print(res);
            }
        }

        // TestSumParallel - тестирование параллельной суммы
        public static void TestMultParallel()
        {
            Console.WriteLine("Matrix multiplication:");
            Random r = new Random();
            Console.Write("Enter row: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter min: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enetr max: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[][] m1 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] m2 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }
            Console.Write("Enter number threads: ");
            int threadNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Multiplication started");
            Stopwatch sw = Stopwatch.StartNew();
            MatrixCalculations.MultParallel(m1, m2, res, threadNumber);
            sw.Stop();
            Console.WriteLine($"Multiplication finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            Console.Write("Enter print y/n: ");
            string p = Console.ReadLine();
            if (p == "y")
            {
                Console.WriteLine("The first matrix:");
                MatrixCalculations.Print(m1);
                Console.WriteLine("The second matrix:");
                MatrixCalculations.Print(m2);
                Console.WriteLine("The product of matrices:");
                MatrixCalculations.Print(res);
            }
        }

        // тестирование двух вариантов умножения со сравнением результатов
        public static void TestMultEqual()
        {
            Random r = new Random();
            Console.Write("Enter row: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter min: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enetr max: ");
            int max = Convert.ToInt32(Console.ReadLine());
            int[][] m1 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] m2 = MatrixCalculations.GenerateRandom(m, n, min, max, r);
            int[][] res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }
            Console.WriteLine("Multiplication started");
            Stopwatch sw = Stopwatch.StartNew();
            MatrixCalculations.Mult(m1, m2, res);
            sw.Stop();
            Console.WriteLine($"Multiplication finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            Console.Write("Enter number threads: ");
            int threadNumber = Convert.ToInt32(Console.ReadLine());
            int[][] res1 = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res1[i] = new int[n];
            }
            Console.WriteLine("Multiplication parallel started");
            sw.Start();
            MatrixCalculations.MultParallel(m1, m2, res1, threadNumber);
            sw.Stop();
            Console.WriteLine($"Multiplication parallel finishid, elapsed: {sw.ElapsedMilliseconds}ms");
            if (MatrixCalculations.AreEqual(res, res1))
            {
                Console.WriteLine("Matrix equal");
            }
            else
            {
                Console.WriteLine("Matrix not equal");
            }
        }
    }
}

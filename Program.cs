using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculationsExample
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // задача: распараллелить матричные вычисления    

            // 1. реализовать все вспомогательные процедуры (можно протестировать в Main)
            // 2. реализовать синхронный алгоритм суммирования, написать тест
            // 3. реализовать параллельный алгоритм суммирования, написать тест

            // - во всех тестах необходимо замерять время работы алгоритма, а именно время выполнения
            // самого алгоритма (т.е. время не выделение памяти, вывод не замеряется)
            // - исходные данные вводятся с консоли (размеры матриц, диапазоны элемнетов, кол-во потоков)
            // так же предумостреть возможность запуска теста с выводм в консоль и без вывода

            //MatrixCalculationsTest.TestSum();
            //MatrixCalculationsTest.TestSumParallel();
            //MatrixCalculationsTest.TestSums();

            //MatrixCalculationsTest.TestMult();
            //MatrixCalculationsTest.TestMultParallel();
            //MatrixCalculationsTest.TestMultParallel();
            //MatrixCalculationsTest.TestMultParallel();
            //MatrixCalculationsTest.TestMultParallel();
            //MatrixCalculationsTest.TestMultParallel();
            //MatrixCalculationsTest.TestMultParallel();
            //MatrixCalculationsTest.TestMultParallel();
            MatrixCalculationsTest.TestMultEqual();
            MatrixCalculationsTest.TestMultEqual();
        }
    }
}

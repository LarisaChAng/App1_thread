using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App1_thread
{
    class Program
    {
        static int[,] area;
        static int m;
        static int n;

        static void Main(string[] args)

        {
            Console.WriteLine("Введите размерность двумерного массива (участка).Укажите число строк");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите размерность двумерного массива(участка).Укажите число столбцов");
            m = Convert.ToInt32(Console.ReadLine());

            area = new int[n, m];

            Thread gardener1 = new Thread(Gardener1);
            Thread gardener2 = new Thread(Gardener2);

            gardener1.Start();
            gardener2.Start();

            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(area[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (area[i, j] == 0)
                        area[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        private static void Gardener2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (area[j, i] == 0)
                        area[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}

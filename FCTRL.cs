using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCTRL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            int T = Int32.Parse(Console.ReadLine());
            int[] digit = new int[T];
            int step = 0;
            const int maxDigit = 1000000000;
            while (step < T)
            {
                int num = Int32.Parse(Console.ReadLine());
                if (num <= maxDigit)
                {
                    digit[step] = num;
                    step++;
                }
            }
            DateTime start = DateTime.Now;
            digit = NumOfZerosInFactorial(digit);
            OutputArray(digit);
            DateTime end = DateTime.Now;
            TimeSpan time = end - start;
            //  Console.WriteLine("time: {0}", time);
            //  Console.ReadKey();
        }

        private static void OutputArray(int[] digit)
        {
            Console.WriteLine("");
            for (int i = 0; i < digit.Length; i++)
            {
                Console.WriteLine("{0}", digit[i]);
            }
        }

        private static int[] NumOfZerosInFactorial(int[] digit)
        {
            int[] numOfZeros = new int[digit.Length];

            for (int i = 0; i < digit.Length; i++)
            {
                bool check = true;
                int zerosSum = 0;
                int iteration = 1;
                int divider = 0;


                while (check)
                {
                    divider = calculateDivider(iteration);
                    if (divider <= digit[i])
                    {
                        zerosSum += (int)(digit[i] / divider);
                        iteration += 1;
                    }
                    else
                    {
                        numOfZeros[i] = zerosSum;
                        check = false;
                    }
                }

            }
            return numOfZeros;
        }

        private static int calculateDivider(int iteration)
        {
            int divider = 5;
            int TotalDivider = 1;
            for (int i = 1; i <= iteration; i++)
            {
                TotalDivider *= divider;
            }
            return TotalDivider;
        }
    }
}

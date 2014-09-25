using System;

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = Int32.Parse(Console.ReadLine());
                if (n == 42) break;
                Console.WriteLine(n);
            }
        }
    }


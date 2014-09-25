using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> expression = new List<string>();
            int allStep = Int32.Parse(Console.ReadLine());
            while (allStep > 101)
            {
                allStep = Int32.Parse(Console.ReadLine());
            }
            
            for (int step = 0; step < allStep; step++)
            {
                string input = Console.ReadLine();
                if (checkFunc(input))
                {
                    expression.Add(input);
                }
            }

            if (expression.Count > 0)
            {
               expression = analysFunc(expression);
            }
            else
            {
                Console.WriteLine("list empty");
            }

            Output(expression);
            Console.ReadKey();
        }

        public static bool checkFunc(string inputText)
        {
            bool check = false;
            char[] inputSymbol = inputText.ToCharArray();
            if (inputSymbol.Length < 400)
            {
                for (int i = 0; i < inputSymbol.Length; i++)
                {
                    if (((inputSymbol[i] >= 'a') && (inputSymbol[i] <= 'z')) || ((inputSymbol[i] >= '(') && (inputSymbol[i] <= '/') && (inputSymbol[i] != ',') && (inputSymbol[i] != '.')) || (inputSymbol[i] == '^'))
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }

        public static List<string> analysFunc(List<string> expressions)
        {            
            List<string> outputExpressions = new List<string>();
            foreach (string expression in expressions)
            {
            outputExpressions.Add(transposition(expression));
            }


            return outputExpressions;
        }

        public static string transposition(string expression)
        {
            StringBuilder sb = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            char s;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(expression[i]);
                }
                else if (expression[i] == ')')
                {
                    while (0 < stack.Count)
                    {
                        s = stack.Pop();
                        if (s != '(')
                        {
                            sb.Append(s);
                        }
                        else break;
                    }
                }
                else if (expression[i] == '^')
                {
                    stack.Push(expression[i]);
                }
                else if ((expression[i] == '*') || (expression[i] == '/'))
                {
                    stack.Push(expression[i]);
                }
                else if ((expression[i] == '+') || (expression[i] == '-'))
                {
                    stack.Push(expression[i]);
                }
                else
                {
                    sb.Append(expression[i]);
                }
            }

            return sb.ToString();
        }

        public static void Output(List<string> expression)
        {
            for (int i = 0; i < expression.Count; i++)
            {
                Console.WriteLine(expression[i]);
            }
        }

    }



}

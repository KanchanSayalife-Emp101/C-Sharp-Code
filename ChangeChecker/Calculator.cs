using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeChecker
{
    public class Calculator
    {
        public static void Main()
        {
            double num1, num2;
            int choice;

            Console.Write("Enter First Number: ");
            if (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid First Number!");
                return;
            }

            Console.Write("Enter Second Number: ");
            if (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid Second Number!");
                return;
            }

            Console.WriteLine("\nSelect Operation");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            Console.Write("Enter Choice (1-4): ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid Choice!");
                return;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Result = " + (num1 + num2));
                    break;

                case 2:
                    Console.WriteLine("Result = " + (num1 - num2));
                    break;

                case 3:
                    Console.WriteLine("Result = " + (num1 * num2));
                    break;

                case 4:
                    if (num2 != 0)
                        Console.WriteLine("Result = " + (num1 / num2));
                    else
                        Console.WriteLine("Cannot divide by zero!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }
}

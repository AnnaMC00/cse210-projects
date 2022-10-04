using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 4");

            List<int> numbers = new List<int>();

            Console.WriteLine("Enter a list of numbers, type 0 when finished");
            int userNumber = 0;
            int total = 0;
            int large = 0;

            do
            {
                Console.Write("Enter number: ");
                userNumber = int.Parse(Console.ReadLine());
                if (userNumber != 0)
                {
                    numbers.Add(userNumber);
                    total += userNumber;

                    if (userNumber > large)
                    {
                        large = userNumber;
                    }
                }
            } while (userNumber != 0);

            double average = (double)total / (double)numbers.Count;

            Console.WriteLine($"The sum is: {total}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {large}");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSDRadixSort
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            // Accept user input
            Console.Write("Type some numbers (separated by spaces):");
            string input = Console.ReadLine();

            // Convert to array
            string[] inputSplit = input.Split(' ');
            int[] array = new int[inputSplit.Length];
            for (int i=0; i < inputSplit.Length; i++)
            {
                try
                {
                    array[i] = Int32.Parse(inputSplit[i]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid number in array.");
                    Console.ReadKey();
                    return;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Input is empty.");
                    Console.ReadKey();
                    return;
                }
            }

            // Perform Sort
            int radix = 10;
            RadixSort numberSet = new RadixSort(array, radix);
            numberSet.Sort();

            // Present results
            Console.Write("Array sorted!\n" +
                "{ ");
            foreach (var number in numberSet.Array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("}");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
            Console.WriteLine("That tickles!");
            Console.ReadKey();
        }
    }
}

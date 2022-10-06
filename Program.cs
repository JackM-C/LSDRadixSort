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
            Sort(array, radix);
        }

        static void Sort(int[] array, int radix)
        {
            //Determine min and max values
            int minValue = array[0];
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
                else if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            // Perform counting sort on each exponent/digit, starting at the least significant digit
            int exponent = 1;
            while ((maxValue - minValue) / exponent >= 1) // determines the highest exponent for which the array needs to be sorted
            {
                CountingSortByDigit(array, radix, exponent, minValue);
                exponent *= radix;
            }

            Console.Write("Array sorted!\n" +
                "{ ");
            foreach (var number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("}");
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
            Console.WriteLine("That tickles!");
            Console.ReadKey();
        }

        static void CountingSortByDigit(int[] array, int radix, int exponent, int minValue)
        {
            int bucketIndex;
            int[] buckets = new int[radix];
            int[] output = new int[array.Length];

            // Initialize the buckets for counting frequencies
            for (int i=0; i < radix; i++)
            {
                buckets[i] = 0;
            }

            // Count frequencies
            for (int i=0; i < array.Length; i++)
            {
                bucketIndex = (int)(((array[i] - minValue) / exponent) % radix); // Modulo radix gets the digit at the exponent place in the number
                buckets[bucketIndex]++;
            }

            // The sum of all buckets is equal to the size of our array.
            // Computing the cumulates this way lets the bucketIndex determine the index of each item in our output array
            for (int i=1; i < radix; i++)
            {
                buckets[i] += buckets[i - 1];
            }

            // Move records
            for (int i=array.Length - 1; i >= 0; i--)
            {
                bucketIndex = (int)(((array[i] - minValue) / exponent) % radix);
                output[--buckets[bucketIndex]] = array[i];
            }

            // Printing sorting stage
            Console.Write("{ ");
            for (int i=0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }
            Console.WriteLine("}: Array state at exponent " + exponent);

            // Copy back
            for (int i=0; i < array.Length; i++)
            {
                array[i] = output[i];
            }
        }
    }
}

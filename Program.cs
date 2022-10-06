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

            Console.Write("Enter array size: ");
            bool arraySizeIsParsable = Int32.TryParse(Console.ReadLine(), out int arraySize);
            if (!arraySizeIsParsable)
            {
                Console.WriteLine("Invalid array size.");
                Console.ReadKey();
                return;
            }

            int radixSize = 10; // for now
            //Console.Write("Enter radix size (2, 10, or 16): ");
            //bool radixSizeIsParsable = Int32.TryParse(Console.ReadLine(), out int radixSize);
            //bool validRadixSize = radixSize == 2 || radixSize == 10 || radixSize == 16;
            //if (!(radixSizeIsParsable && validRadixSize))
            //{
            //    Console.WriteLine("Invalid radix size.");
            //    Console.ReadKey();
            //    return;
            //}

            Console.Write("Enter number length: ");
            bool numberLengthIsParsable = Int32.TryParse(Console.ReadLine(), out int numberLength);
            if (!numberLengthIsParsable || numberLength <= 0)
            {
                Console.WriteLine("Invalid number length.");
                Console.ReadKey();
                return;
            }

            string[] unsortedArray = GenerateArray(arraySize, radixSize, numberLength);
            Console.Write("Your randomly generated array is: {");
            foreach (var item in unsortedArray)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine(" }");
            Console.WriteLine("Press any key to begin LSD Radix Sort...");
            Console.ReadKey();

            for (int i = 0; i < numberLength; i++)
            {
                unsortedArray = Sort(unsortedArray, i, radixSize);
            }

        }

        static string[] GenerateArray(int arraySize, int radixSize, int numberLength)
        {
            string[] unsortedArray = new string[arraySize];
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                unsortedArray[i] = RandomNumberString(numberLength, radixSize);
            }
            return unsortedArray;
        }

        static string RandomNumberString(int numberLength, int radixSize)
        {
            string number = "";
            for (int i = 0; i < numberLength; i++)
            {
                    number += rnd.Next(0, 9).ToString();
            }
            return number;
        }

        static string[] Sort(string[] unsortedArray, int position, int radixSize)
        {
            int[,] buckets = new int[, radixSize];
            return unsortedArray;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSDRadixSort
{
    public class RadixSort
    {
        private int[] array;
        private int radix;

        public RadixSort(int[] array, int radix) {
            this.array = array;
            this.radix = radix; 
        } 

        public int[] Array { get { return array; } }

        public void Sort()
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
        }

        private void CountingSortByDigit(int[] array, int radix, int exponent, int minValue)
        {
            int bucketIndex;
            int[] buckets = new int[radix];
            int[] output = new int[array.Length];

            // Initialize the buckets for counting frequencies
            for (int i = 0; i < radix; i++)
            {
                buckets[i] = 0;
            }

            // Count frequencies
            for (int i = 0; i < array.Length; i++)
            {
                bucketIndex = (int)(((array[i] - minValue) / exponent) % radix); // Modulo radix gets the digit at the exponent place in the number
                buckets[bucketIndex]++;
            }

            // The sum of all buckets is equal to the size of our array.
            // Computing the cumulates this way lets the bucketIndex determine the index of each item in our output array
            for (int i = 1; i < radix; i++)
            {
                buckets[i] += buckets[i - 1];
            }

            // Move records
            for (int i = array.Length - 1; i >= 0; i--)
            {
                bucketIndex = (int)(((array[i] - minValue) / exponent) % radix);
                output[--buckets[bucketIndex]] = array[i];
            }

            // Printing sorting stage
            Console.Write("{ ");
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }
            Console.WriteLine("}: Array state at exponent " + exponent);

            // Copy back
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = output[i];
            }
        }
    }
}

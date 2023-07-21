using System.Xml.Linq;
using System;

namespace ResDiaryCodingChallenge
{
    internal class Program
    {
        // Method to group array elements into N array groups
        static int[][] GroupArrayElements(int[] arr, int N)
        {
            // Handle edge case where arr is empty
            if (arr.Length == 0)
                return new int[0][];

            // Handle edge case where N is less than 1
            if (N < 1)
                N = 1; 

            // Handle edge case where N is greater than the array length
            if (N > arr.Length)
                N = arr.Length;

            int arrayGroupSize = arr.Length / N; // Determine the size of each array group excluding any remainder elements
            int remainder = arr.Length % N; // Determine the number of remaining elements that need to be distributed among the array groups
            int[][] result = new int[N][];

            int startIndex = 0;
            // Loop for each array group
            for (int i = 0; i < N; i++)
            {
                int currentArraySize = arrayGroupSize + (i < remainder ? 1 : 0); // Get current array size
                result[i] = new int[currentArraySize]; // Create a new array with the determined size

                // Inner loop to set values in the current array group
                for (int j = 0; j < currentArraySize; j++)
                {
                    result[i][j] = arr[startIndex++];
                }
            }

            return result;
        }    

        // Method to print array groups
        static void PrintArrayGroups(int[][] arr)
        {
            string[] arrayGroups = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                string arrayGroupString = string.Join(", ", arr[i]);
                arrayGroups[i] = $"[ {arrayGroupString} ]";
            }

            Console.WriteLine($"[ {string.Join(", ", arrayGroups)} ]");
        }

        static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int N = 3;
            int[][] result = GroupArrayElements(arr, N);

            // Print the result
            PrintArrayGroups(result);

            // Keep console open
            Console.ReadLine();
        }
    }
}
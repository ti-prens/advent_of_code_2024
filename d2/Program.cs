using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Opens a file containing the input data for the problem
        StreamReader sr = new StreamReader("C:\\Users\\Prince\\Documents\\aoc_2024\\d2\\d2_input.txt");

        string? line; // Variable to hold each line of input as it is read
        // List<int> num = new List<int>(); // List to store the parsed numbers from a single line
        // string[] numbers; // Array to hold split numbers from the line
        int safe = 0; // Counter for the number of safe reports

        int safeReports = 0; // Counter for the number of safe reports
        int line_num = 0;

            // Reads the file line by line
        while((line = sr.ReadLine()) != null)
        {
            // Split the line into individual numbers, removing any extra spaces
            // numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Convert the string array into a list of integers
            var num = line.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            line_num++;
            // Check if the current report is safe. Allow one failure(Problem Dampener)
            if(CheckSafe(num, 1))
            {
                // Increment the safe counter if the report is deemed safe
                safe++;
                Console.WriteLine($"line n* {line_num} is safe");
            }
            if (IsSafe(num, 1))
            {
                safeReports++;
                // Console.WriteLine($"line n* {line_num} is safe");
            }
        }

        // Print the total number of safe reports
        Console.WriteLine($"\n\n Total Safe line is {safe}");
    }

    // Function to check if a report is safe, with an allowance for a certain number of failures
    static bool CheckSafe(List<int> ch, int failure)
    {
        // Print the current list for debugging purposes
        // line_processed(ch);

        // If the list has less than two levels, it's trivially safe
        if(ch.Count < 2) return true;

        bool isIncreasing = ch[1] > ch[0];
        for(int past = 0, pres = 1; pres < ch.Count;past++,pres++){
            int diff = ch[pres]-ch[past];

            if((isIncreasing && diff < 0) || (!isIncreasing && diff > 0) || Math.Abs(diff) < 1 || Math.Abs(diff) > 3 ){
                if(failure>0){
                    var mod = new List<int>(ch);
                    mod.RemoveAt(past);
                    if(CheckSafe(mod,failure-1)) return true;
                    mod = new List<int>(ch);
                    mod.RemoveAt(pres);
                    if(CheckSafe(mod,failure-1)) return true;
                    if(past-1>=0){
                        mod = new List<int>(ch);
                        mod.RemoveAt(past-1);
                        if(CheckSafe(mod,failure-1)) return true;
                    }
                }
                return false;
            }
        }

        // If the loop completes without returning false, the report is safe
        Console.WriteLine($"\n>>>> This line is safe - at level {failure}");
        return true;
    }

    // Helper function to print the current state of the list for debugging
    static void line_processed(List<int> ch)
    {
        Console.WriteLine(" ---");
        for(int c = 0; c < ch.Count; c++)
        {
            Console.Write(ch[c]);
        }
        Console.WriteLine(" --> Is the line processed");
    }

    static bool IsSafe(List<int> levels, int failuresAllowed)
    {
        // If already valid, it's safe
        if (IsValidTrend(levels))
            return true;

        // If no more failures allowed, it's unsafe
        if (failuresAllowed <= 0)
            return false;

        // Try removing each element and check if it becomes safe
        for (int i = 0; i < levels.Count; i++)
        {
            var modifiedLevels = new List<int>(levels);
            modifiedLevels.RemoveAt(i);

            if (IsValidTrend(modifiedLevels) || IsSafe(modifiedLevels, failuresAllowed - 1))
            {
                return true;
            }
        }

        return false;
    }

    static bool IsValidTrend(List<int> levels)
    {
        if (levels.Count < 2)
            return true;

        // Determine the trend (increasing or decreasing)
        bool isIncreasing = levels[1] > levels[0];
        for (int i = 1; i < levels.Count; i++)
        {
            int diff = levels[i] - levels[i - 1];

            // Check if the difference is out of range
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                return false;

            // Check if the trend is broken
            if (isIncreasing && diff < 0)
                return false;
            if (!isIncreasing && diff > 0)
                return false;
        }

        return true;
    }
}

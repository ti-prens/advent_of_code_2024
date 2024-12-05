// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {
        // Opens a file containing the input data for the problem
        StreamReader sr = new StreamReader("C:\\Users\\Prince\\Documents\\aoc_2024\\d2\\d2_test.txt");

        string? line; // Variable to hold each line of input as it is read
        List<int> num = new List<int>(); // List to store the parsed numbers from a single line
        string[] numbers; // Array to hold split numbers from the line
        int safe = 0; // Counter for the number of safe reports

        // Reads the file line by line
        while((line = sr.ReadLine()) != null)
        {
            // Split the line into individual numbers, removing any extra spaces
            numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Convert the string array into a list of integers
            num = numbers.Select(x => Int32.Parse(x)).ToList();

            // Check if the current report is safe. Allow one failure(Problem Dampener)
            if(CheckSafe(num, 1))
            {
                // Increment the safe counter if the report is deemed safe
                safe++;
            }
        }

        // Print the total number of safe reports
        Console.WriteLine($"Safe is {safe}");
    }

    // Function to check if a report is safe, with an allowance for a certain number of failures
    static bool CheckSafe(List<int> ch, int failure)
    {
        // Print the current list for debugging purposes
        line_processed(ch);

        // If the list has less than two levels, it's trivially safe
        if(ch.Count < 2) return true;

        int past; // Variable to store the previous level
        int pres; // Variable to store the current level
        int diff; // Variable to store the difference between levels

        // Loop through the list starting from the second element
        for(int i = 1; i < ch.Count; i++)
        {
            past = ch[i - 1]; // Set the previous level
            pres = ch[i];     // Set the current level
            diff = pres - past; // Calculate the difference between the current and previous levels

            Console.Write($"{pres}"); // Print the current level for debugging

            // Check if the difference violates the valid range
            if(Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                // If no more failures are allowed, the report cannot be made safe
                if(failure == 0)
                {
                    Console.WriteLine($"\n>> Cannot recover");
                }
                else
                {
                    // Otherwise, try to recover by removing one of the levels causing the issue
                    Console.WriteLine($"\n> Try again - diff - pres");

                    // Remove the current level and check if the remaining sequence is safe
                    ch.RemoveAt(i);
                    line_processed(ch);

                    if(CheckSafe(ch, failure - 1)) return true;

                    // If not, restore the current level and try removing the previous level instead
                    ch.Insert(i, pres);
                    ch.RemoveAt(i - 1);

                    Console.WriteLine($"\n> Try again - diff - past");
                    line_processed(ch);

                    if(CheckSafe(ch, failure - 1)) return true;
                }

                // If both attempts fail, the report is not safe
                return false;
            }

            // Check if the sequence alternates between increasing and decreasing
            if(i < ch.Count - 1)
            {
                int furt = ch[i + 1]; // Look ahead to the next level

                // If the direction changes(increasing to decreasing or vice versa), try to recover
                if((diff < 0 &&(furt - pres) > 0) ||(diff > 0 &&(furt - pres) < 0))
                {
                    // If no more failures are allowed, the report cannot be made safe
                    if(failure == 0)
                    {
                        Console.WriteLine($"\n>> Cannot recover");
                    }
                    else
                    {
                        // Otherwise, attempt to recover by removing the current level
                        Console.WriteLine($"\n> Try again - dir - pres");
                        ch.RemoveAt(i);

                        if(CheckSafe(ch, failure - 1)) return true;

                        // If that fails, restore the level and try removing the next level instead
                        ch.Insert(i, pres);
                        Console.WriteLine($"\n> Try again - dir - past");
                        ch.RemoveAt(i + 1);

                        if(CheckSafe(ch, failure - 1)) return true;
                    }

                    // If both attempts fail, the report is not safe
                    return false;
                }
            }
        }

        // If the loop completes without returning false, the report is safe
        Console.WriteLine($"\n>>>> This line is safe - at level {failure}\n\n");
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
}

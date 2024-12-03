// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader("d2_test.txt");

        string? line;
        List<int> num = new List<int>();
        string[] numbers;
        int safe = 0;

        while ((line = sr.ReadLine()) != null)
        {
            numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // Console.WriteLine($"{line}");
            // for(int i = 0; i < numbers.Length; i++){
            //     Console.Write($"{numbers[i]}");
            // }
            // Console.Write("\n");
            if (CheckSafe(numbers))
            {
                safe++;
            }
        }

        Console.WriteLine($"Safe is {safe}");
    }

    static bool CheckSafe(string[] chaine)
    {
        Console.WriteLine($"\n\n line length : {chaine.Length} \n");
        if(chaine.Length < 2) return true;

        
        int pre = int.Parse(chaine[0]);
        Console.WriteLine($"pre value {pre}");

        int pre_diff = int.Parse(chaine[1]) - pre;

        for(int i =1 ; i<chaine.Length; i++)
        {
            Console.WriteLine($"-> the {i} iemme number of chaine is : {int.Parse(chaine[i])}");
            int diff = int.Parse(chaine[i]) - pre;
            if((diff < 0 && pre_diff > 0) || (diff > 0 && pre_diff < 0)){
                return false;
            }
            pre_diff = diff;
            Console.WriteLine($"the diff is {diff}");
            
            
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                return false;
            }

            pre = int.Parse(chaine[i]);

        }
            Console.WriteLine("\n");

        Console.WriteLine($">>>> This line is safe\n\n");
        return true;
    }
}
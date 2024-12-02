// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        int part = 1;

        StreamReader sr = new StreamReader("d2_test.txt");

        string? line;
        List<int> num = new List<int>();
        string [] numbers = new string;  
        int safe = 0;
        int diff = 0;

        while ((line = sr.ReadLine()) != null)
        {
            numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(checkSafe(numbers)){
               safe++; 
            }
            numbers.Clear();
        }

        Console.WriteLine($"Safe is {safe}");
    }

    static bool checkSafe(string [] chaine){
        Console.WriteLine($"Safe --> {chaine[0]}");
        int pre = int.Parse(chaine[0]);
        int diff = 0;
        for (string n in chaine[1:])
        {
            diff = int.Parse(n)-pre;
            if(diff < 1 || diff > 3){
                return false;
            }
            pre = int.Parse(n);
        }
        return true;
    }
}
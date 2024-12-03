// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader("d2_input.txt");

        string? line;
        List<int> num = new List<int>();
        string[] numbers;
        int safe = 0;

        while ((line = sr.ReadLine()) != null)
        {
            numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (CheckSafe(numbers))
            {
                safe++;
            }
        }

        Console.WriteLine($"Safe is {safe}");
    }

    static bool CheckSafe(string[] chaine)
    {
        if (chaine.Length < 2) return true;

        for (int i = 1; i < chaine.Length; i++)
        {
            int past = int.Parse(chaine[i-1]);
            int pres = int.Parse(chaine[i]);
            int diff = pres - past;
            
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                return false;
            }

            if(i < chaine.Length -1){
                int furt = int.Parse(chaine[i+1]);
               if ((diff < 0 && (furt - pres) > 0) || (diff > 0 && (furt - pres) < 0))
                {
                    return false;
                } 
            }
            
        }

        // Console.WriteLine($">>>> This line is safe\n\n");
        return true;
    }
}
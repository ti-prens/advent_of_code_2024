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
            num = numbers.Select(x => Int32.Parse(x)).ToList();
            if (CheckSafe(num, 1))
            {
                safe++;
            }
        }

        Console.WriteLine($"Safe is {safe}");
    }

    static bool CheckSafe(List<int> ch, int failure)
    {
        if (ch.Count < 2) return true;


        for (int i = 1; i < ch.Count; i++)
        {
            int past = ch[i - 1];
            int pres = ch[i];
            int diff = pres - past;

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                if (failure == 0)
                {
                    return false;
                }
                else
                {
                    ch.RemoveAt(i);
                    return CheckSafe(ch, failure - 1);
                }

            }

            if (i < ch.Count - 1)
            {
                int furt = ch[i + 1];
                if ((diff < 0 && (furt - pres) > 0) || (diff > 0 && (furt - pres) < 0))
                {
                    if (failure == 0)
                    {
                        return false;
                    }
                    else
                    {
                        ch.RemoveAt(i);
                        return CheckSafe(ch, failure - 1);
                    }
                }
            }

        }

        // Console.WriteLine($">>>> This line is safe\n\n");
        return true;
    }
}
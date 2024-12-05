// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader("C:\\Users\\Prince\\Documents\\aoc_2024\\d2\\d2_input.txt");

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
        line_processed(ch);
        if (ch.Count < 2) return true;

        int past ;
        int pres ;
        int diff ;

        for (int i = 1; i < ch.Count; i++)
        {
            past = ch[i - 1];
            pres = ch[i];
            diff = pres - past;
            Console.Write($"{pres}");

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                if (failure == 0)
                {
                    Console.WriteLine($"\n>> Cannot recover");
                }
                else
                {
                    Console.WriteLine($"\n> Try again - diff - pres");
                    ch.RemoveAt(i);
                    line_processed(ch);
                    
                    if(CheckSafe(ch, failure - 1)) return true;
                    
                    ch.Insert(i,pres);
                    ch.RemoveAt(i-1);
                    Console.WriteLine($"\n> Try again - diff - past");
                    line_processed(ch);
                    if(CheckSafe(ch, failure - 1)) return true;                        
                }
                return false;

            }

            if (i < ch.Count - 1)
            {
                int furt = ch[i + 1];
                if ((diff < 0 && (furt - pres) > 0) || (diff > 0 && (furt - pres) < 0))
                {
                    if (failure == 0)
                    {
                        Console.WriteLine($"\n>> Cannot recover");
                    }
                    else
                    {
                        Console.WriteLine($"\n> Try again - dir - pres");
                        ch.RemoveAt(i);
                        if(CheckSafe(ch, failure - 1)) return true;
                        ch.Insert(i,pres);
                        Console.WriteLine($"\n> Try again - dir - past");
                        ch.RemoveAt(i+1);
                        if(CheckSafe(ch, failure - 1)) return true;                        
                    }
                    return false;
                }
            }

        }

        Console.WriteLine($"\n>>>> This line is safe - at level {failure}\n\n");
        return true;
    }
    static void line_processed(List<int> ch){
        Console.WriteLine(" ---");
        for(int c = 0; c<ch.Count;c++){
            Console.Write(ch[c]);
        } Console.WriteLine(" --> Is the line processed");
    }
                    
}
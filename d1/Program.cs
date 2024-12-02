// See https://aka.ms/new-console-template for more information
// using System.IO;
class Program
{
    static void Main()
    {
        Console.WriteLine("I am running");
        int part = 1;
        part = 2;
        List<int> ll = new List<int> {};
        List<int> lr = new List<int> {};

        StreamReader sr = new StreamReader("d1_test.txt");
        sr = new StreamReader("d1_input.txt");
        String? line = sr.ReadLine();


        ll.Clear();
        lr.Clear();

        int distance = 0;
        
        while (line != null)
        {
            String[] temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ll.Add(int.Parse(temp[0]));
            lr.Add(int.Parse(temp[1]));
            // Console.WriteLine($"line is {line} \n line split are : {line.Split("   ")[1]}");
            line = sr.ReadLine();
        }
        if (part == 1)
        {

            ll.Sort();
            lr.Sort();


            for (int i = 0; i < ll.Count; i++)
            {
                distance += Math.Abs(ll[i] - lr[i]);
            }

        }
        else
        {
            for (int i = 0; i< ll.Count;i++){
                distance += lr.Count(x => x == ll[i]) * ll[i];
            }
        }
        Console.WriteLine($"Distance = {distance}");
    }
}
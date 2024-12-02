// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        int part = 1;

        StreamReader sr = new StreamReader("d2_test.txt");

        string? line;
        List<int> num = new List<int>();
        
        int safe = 0;
        int diff = 0;
        
        while ((line = sr.ReadLine()) != null)
        {

            string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            
            num.Append(numbers[0])
            

            for (int i = 1; i < numbers.Length; i++)
            {
                diff = int.Parse(numbers[i])-num[i-1] ;
                if(diff >= 1 && diff <= 3){
                    num.Add(int.Parse(numbers[i]));
                }
                else
                {
                    break;
                }
            }
                if(diff >= 1 && diff <= 3){
                   safe++; 
                }
            num.Clear();
        }

        Console.WriteLine($"Safe is {safe}");
    }
}
// See https://aka.ms/new-console-template for more information
class Program {
    static void Main(){
        Console.WriteLine("I am running");

        List<int> ll = new List<int> {1,2,3,4,5};
        List<int> lr = new List<int> {1,3,5,7,9};
        
        ll.Sort();
        lr.Sort();

        int distance = 0;

        for(int i =0;i<ll.Count;i++){
            distance += Math.Abs(ll[i]-lr[i]);
        }

        Console.WriteLine($"Distance = {distance}");
    }
}
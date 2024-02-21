
public class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9,10};

        var querySyntax = from obj in list
                          where obj > 2
                          select obj;
       
        foreach (var item in querySyntax)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("---------------");

        var methodsSyntax = list.Where(obj => obj > 2);

        foreach (var item in methodsSyntax)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine("---------------");
        
        var mixedSyntax = (from obj in list select obj).Max();
        Console.WriteLine(mixedSyntax);

    }
}
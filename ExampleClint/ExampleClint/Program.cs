namespace ExampleClint;

internal class Program
{
    static void Main(string[] args)
    {
        // ToupleExample();
        //SingletonMain();

        var obj = new ClientBroker();
        obj.GetAll();
        
    }

    public static void SingletonMain()
    {
        var obj1 = SingletonExample.GetInstance();
        var obj2 = SingletonExample.GetInstance();
        var obj3 = SingletonExample.GetInstance();

        obj1.Id = 1;
        Console.WriteLine(obj1.Id); // 1
        obj2.Id = 2;
        obj3.Id = 3;

        bool res = obj1.Equals(obj2);
        Console.WriteLine(res); // true

        bool res2 = object.ReferenceEquals(obj1, obj3);
        Console.WriteLine(res2); // true

        Console.WriteLine(obj1.Id); // 3
        Console.WriteLine(obj2.Id); // 3
        Console.WriteLine(obj3.Id); // 3
    }

    public static void ToupleExample()
    {
        // Touple maximum 8 ta oladi!

        (int, string, char) res = (4, "Hello", 'T');
        Console.WriteLine(res); // (4, "Hello", 'T')
        Console.WriteLine(res.Item1); // 4
        Console.WriteLine(res.Item2); // Hello
        Console.WriteLine(res.Item3); // T
    }
}

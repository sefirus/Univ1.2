namespace Red_BlackTrees;

public static class Io
{
    public static void PrintMenu()
    {
        Console.WriteLine("1. To add element");
        Console.WriteLine("2. To remove element");
        Console.WriteLine("3. To work with integral scheme");
        Console.WriteLine("0. To exit");
        BoldLine();
    }

    public static int Input(string message)
    {
        var value = 0;
        Console.WriteLine(message);
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Wrong data. " + message);
        }

        return value;
    }

    public static void BoldLine() => Console.WriteLine("==========================================");
}
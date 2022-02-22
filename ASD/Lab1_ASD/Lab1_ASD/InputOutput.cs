namespace Lab1_ASD;

public static class InputOutput
{
    public static void BaldLine() => 
        Console.WriteLine("====================================================");
    
    public static void PrintMenu()
    {
        BaldLine();
        Console.WriteLine("1. To run the Linear search");
        Console.WriteLine("2. To run the Barrier search");
        Console.WriteLine("3. To run the Binary search");
        Console.WriteLine("4. To run the Binary search with golden section");
        Console.WriteLine("5. To change the input array");
        Console.WriteLine("6. To change the key");
        Console.WriteLine("7. To print the array");
        Console.WriteLine("8. To print the menu");
        Console.WriteLine("9. To change search iterations count");
        Console.WriteLine("10. To exit");
        BaldLine();
    }

    public static void PrintArray(int[] array)
    {
        int size = array.Length;
        for(int i = 0; i < size - 1; i++) Console.Write(array[i] + " ");
        Console.WriteLine(array[^1]);
    }
    
    public static void Initiate(out int[] array, out LinkedList list, out int key)
    {
        ChangeArray(out array, out list);
        key = ChangeKey();
    }

    public static void ChangeArray(out int[] array, out LinkedList list)
    {
        Console.WriteLine("Please, enter an integer array to search in");
        array = GetArray();
        list = GetList(array);
    }

    public static int ChangeKey()
    {
        Console.WriteLine("Please, enter a key to search for");
        int.TryParse(Console.ReadLine(), out var result);
        return result;
    }
    
    private static int[] GetArray()
    {
        var result = new List<int>();
        var line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int temp;
        foreach (var word in line)
        {
            int.TryParse(word, out temp);
            result.Add(temp);
        }

        return result.ToArray();
    }

    public static LinkedList GetList(int[] array)
    {
        int i = array.Length - 1;
        var last = new LinkedList(array[i], null);
        while (i > 0)
        {
            i--;
            var temp = new LinkedList(array[i], last);
            last = temp;
        }
        return last;
    }
}
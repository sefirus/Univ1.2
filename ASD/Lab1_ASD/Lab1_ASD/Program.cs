namespace Lab1_ASD;

static class Program
{
    public static int SearchIterations = 5;
    
    public static void Main()
    {
        InputOutput.Initiate(out var array, out var list, out var key);
        InputOutput.PrintMenu();

        while (true)
        {
            Console.WriteLine("Please, enter a command");
            int.TryParse(Console.ReadLine(), out var command);
            switch (command)
            {
                case 1:
                    LinearSearch.Perform(key, array, list);
                    break;
                case 2:
                    BarrierSearch.Perform(key, array, list);
                    break;
                case 3:
                    BinarySearch.Perform(key, array, false);
                    break;
                case 4:
                    BinarySearch.Perform(key, array, true);
                    break;
                case 5:
                    InputOutput.BaldLine();
                    InputOutput.ChangeArray(out array, out list);
                    InputOutput.BaldLine();
                    break;
                case 6:
                    InputOutput.BaldLine();
                    key = InputOutput.ChangeKey();
                    InputOutput.BaldLine();
                    break;
                case 7:
                    InputOutput.BaldLine();
                    Console.WriteLine("The array:");
                    InputOutput.PrintArray(array);
                    InputOutput.BaldLine();
                    break;
                case 8:
                    InputOutput.PrintMenu();
                    break;
                case 9:
                    InputOutput.BaldLine();
                    Console.WriteLine("Please, enter a new search iterations count");
                    int.TryParse(Console.ReadLine(), out SearchIterations);
                    InputOutput.BaldLine();
                    break;
                case 10:
                    return;
                case 11:
                    var data = GenerateArray.Generate(1000, 1000);
                    InputOutput.BaldLine();
                    InputOutput.BaldLine();
                    InputOutput.BaldLine();
                    Console.WriteLine($"1000 elements, key {data.Key} on position {data.Position}");
                    Console.WriteLine("Linear Search:");
                    LinearSearch.Perform(data.Key, data.Array, InputOutput.GetList(data.Array));
                    Console.WriteLine("Barrier Search:");
                    BarrierSearch.Perform(data.Key, data.Array, InputOutput.GetList(data.Array));
                    Console.WriteLine("Normal binary Search:");
                    BinarySearch.Perform(data.Key, data.Array, false);
                    Console.WriteLine("Gold binary Search:");
                    BinarySearch.Perform(data.Key, data.Array, true);
                    
                    InputOutput.BaldLine();
                    InputOutput.BaldLine();
                    InputOutput.BaldLine();
                    
                    data = GenerateArray.Generate(1000000, 1000);
                    Console.WriteLine($"1000000 elements, key {data.Key} on position {data.Position}");
                    Console.WriteLine($"1000 elements, key {data.Key} on position {data.Position}");
                    Console.WriteLine("Linear Search:");
                    LinearSearch.Perform(data.Key, data.Array, InputOutput.GetList(data.Array));
                    Console.WriteLine("Barrier Search:");
                    BarrierSearch.Perform(data.Key, data.Array, InputOutput.GetList(data.Array));
                    Console.WriteLine("Normal binary Search:");
                    BinarySearch.Perform(data.Key, data.Array, false);
                    Console.WriteLine("Gold binary Search:");
                    BinarySearch.Perform(data.Key, data.Array, true);
                    break;
                case 12:
                    var tail = new LinkedList(int.Parse(Console.ReadLine()), null);
                    LinkedList counter = tail;
                    for (int i = 0; i < 14; i++)
                    {
                        var buff = new LinkedList(int.Parse(Console.ReadLine()), null);
                        buff.Next = counter;
                        counter = buff;
                    }
                    break;
                default:
                    InputOutput.BaldLine();
                    Console.WriteLine("Wrong command");
                    InputOutput.BaldLine();
                    break;
            }
        }
    }
}
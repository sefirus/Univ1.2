namespace Lab1_ASD;

class Program
{
    public static int SearchIterations = 10;
    
    public static void Main()
    {
        int command;
        InputOutput.Initiate(out var array, out var list, out var key);
        InputOutput.PrintMenu();

        while (true)
        {
            Console.WriteLine("Please, enter a command");
            int.TryParse(Console.ReadLine(), out command);
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
                default:
                    InputOutput.BaldLine();
                    Console.WriteLine("Wrong command");
                    InputOutput.BaldLine();
                    break;
            }
        }
    }
}
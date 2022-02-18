bool WRITE_RESULTS_TO_FILE = true;

while (true)
{
    int n, border, temp, keyQuantity = 0, key;
    int[] keyPositions = new int[1];
    var rand = new Random();
    Console.WriteLine("Please, enter number of elements");
    int.TryParse(Console.ReadLine(), out n);
    Console.WriteLine("Please, enter random border");
    int.TryParse(Console.ReadLine(), out border);
    Console.WriteLine("Do you want key element to be unique? 0 for NO");
    int.TryParse(Console.ReadLine(), out temp);
    var unique = temp != 0;

    int[] array = new int[n];
    if (unique)
    {
        key = rand.Next(2 * border) - border;
        keyQuantity++;
        for (int i = 0; i < n; i++)
        {
            do
            {
                temp = rand.Next(2 * border) - border;
            } while (temp == key);

            array[i] = temp;
        }

        temp = rand.Next(n);
        array[temp] = key;
        keyPositions[0] = temp;
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            array[i] = rand.Next(2 * border) - border;
        }

        key = rand.Next(2 * border) - border;
        temp = rand.Next(rand.Next(n % border));

        for (int i = 0; i < temp; i++)
        {
            array[rand.Next(n)] = key;
        }

        var positions = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (array[i] == key)
            {
                keyQuantity++;
                positions.Add(i);
            }
        }

        keyPositions = positions.ToArray();
    }
    
    Console.WriteLine($"Key: {key}\tappears {keyQuantity} times on positions:");
    for(int i = 0; i < keyQuantity; i++) Console.Write(keyPositions[i] + " ");
    Console.WriteLine("\nThe array");
    for(int i = 0; i < n; i++) Console.Write(array[i] + " ");
    Console.WriteLine("\n====================================================================================");
    
    if(WRITE_RESULTS_TO_FILE)
    {
        using StreamWriter writer = new StreamWriter($"RandomResults{DateTime.Now.Ticks}.txt");
        writer.AutoFlush = true;
        writer.WriteLine($"Key: {key}\tappears {keyQuantity} times on positions:");
        for(int i = 0; i < keyQuantity; i++) writer.Write(keyPositions[i] + " ");
        writer.WriteLine("\nThe array:");
        writer.WriteLine("\n====================================================================================");
        for(int i = 0; i < n; i++) writer.Write(array[i] + " ");
        writer.WriteLine("\n====================================================================================");
    }
}
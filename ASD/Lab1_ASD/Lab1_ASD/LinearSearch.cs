namespace Lab1_ASD;

public static class LinearSearch
{
    public static void Perform(int key, int[] array, LinkedList head)
    {
        InputOutput.BaldLine();
        Console.WriteLine("Linear search results:");
        Console.WriteLine("          Position        Duration (ns)");
        Console.WriteLine("On array:");
        for (int i = 0; i < Program.SearchIterations; i++)
            Search(key, array).PrintResults();
        Console.WriteLine("On list:");
        for (int i = 0; i < Program.SearchIterations; i++)
            Search(key, head).PrintResults();
        InputOutput.BaldLine();
    }

    public static SearchResults Search(int key, int[] array)
    {
        int i = 0, size = array.Length, position = -1;
        bool isFound = false;
        DateTime startTime = DateTime.Now;
        
        while (i < size && !isFound)
        {
            if (array[i] == key)
            {
                position = i;
                isFound = true;
            }
            i++;
        }
        
        return new SearchResults(isFound ? position : "Not Found", DateTime.Now - startTime);
    }
    
    public static SearchResults Search(int key, LinkedList head)
    {
        int i = 0, position = -1;
        bool isFound = false;
        var iterator = head;
        DateTime startTime = DateTime.Now;
        
        while (iterator != null && !isFound)
        {
            if (iterator.Data == key)
            {
                position = i;
                isFound = true;
            }
            i++;
            iterator = iterator.Next;
        }

        return new SearchResults(isFound ? position : "Not Found", DateTime.Now - startTime);
    }
}
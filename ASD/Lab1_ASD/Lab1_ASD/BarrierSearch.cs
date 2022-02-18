using System.Transactions;

namespace Lab1_ASD;

public static class BarrierSearch
{
    public static void Perform(int key, int[] array, LinkedList head)
    {
        InputOutput.BaldLine();
        Console.WriteLine("Barrier search results:");
        Console.WriteLine("          Position        Duration (ns)");
        Console.WriteLine("On array:");
        for (int i = 0; i < Program.SearchIterations; i++)
            Search(key, (int[])array.Clone()).PrintResults();
        Console.WriteLine("On list:");
        for (int i = 0; i < Program.SearchIterations; i++)
        {
            Search(key, head).PrintResults();
            
            var iterator = head;
            while (iterator.Next.Next != null)
            {
                iterator = iterator.Next;
            }
            iterator.Next = null;
        }

        InputOutput.BaldLine();
    }
    
    public static SearchResults Search(int key, int[] array)
    {
        int i = 0, size = array.Length;
        DateTime startTime = DateTime.Now;

        var newArray = new int[size + 1];
        while (i < size)
        {
            newArray[i] = array[i];
            i++;
        }
        newArray[i] = key;
        i = 0;

        while (!newArray[i].Equals(key))
        {
            i++;
        }
        
        return new SearchResults(i < size ? i : "Not Found", DateTime.Now - startTime);
    }

    public static SearchResults Search(int key, LinkedList head)
    {
        int i = 0;
        var iterator = head;
        DateTime startTime = DateTime.Now;

        var newLast = new LinkedList(key, null);
        while (iterator.Next != null)
        {
            iterator = iterator.Next;
        }
        iterator.Next = newLast;
        iterator = head;

        while (iterator.Data != key)
        {
            i++;
            iterator = iterator.Next;
        }
        return new SearchResults(iterator.Next != null ? i : "Not Found", DateTime.Now - startTime);
    }
}
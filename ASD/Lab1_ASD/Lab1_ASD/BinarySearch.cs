using System.Transactions;

namespace Lab1_ASD;

public static class BinarySearch
{
    private static int Partition(int[] array, int startPos, int endPos)
    {
        int temp, m = startPos;
        for (int i = startPos; i < endPos; i++)
        {
            if (array[i] < array[endPos])
            {
                temp = array[m];
                array[m] = array[i];
                array[i] = temp;
                m++;
            }
        }

        temp = array[m];
        array[m] = array[endPos];
        array[endPos] = temp;
        return m;
    }
    
    private static void QuickSort(int[] array, int startPos, int endPos)
    {
        if(startPos >= endPos) return;
        var pivot = Partition(array, startPos, endPos);
        QuickSort(array, startPos, pivot - 1);
        QuickSort(array, pivot + 1, endPos);
    }
    
    public static void Perform(int key, int[] array, bool isGoldenRatio)
    {
        InputOutput.BaldLine();
        Console.WriteLine("DISCLAIMER: All the search will be performed on the sorted array:");
        var sortedArray = (int[])array.Clone();
        QuickSort(sortedArray, 0, sortedArray.Length - 1);
        var sortedListHead = InputOutput.GetList(sortedArray);
        if (array.Length < 1000)
        {
            Console.WriteLine("The sorted array:");
            InputOutput.PrintArray(sortedArray);
        }
        InputOutput.BaldLine();
        Console.WriteLine("          Position        Duration (ns)");
        Console.WriteLine("On array:");
        for (int i = 0; i < Program.SearchIterations; i++)
        {
            Search(key, sortedArray, isGoldenRatio).PrintResults();
        }
        Console.WriteLine("On list:");
        for (int i = 0; i < Program.SearchIterations; i++)
        {
            Search(key, sortedListHead, isGoldenRatio).PrintResults();
        }
        InputOutput.BaldLine();
    }

    public static SearchResult Search(int key, int[] array, bool isGoldenRatio)
    {
        int min = 0, max = array.Length - 1, mid;
        
        double lambda = (Math.Sqrt(5) + 1) / 2;
        double ratio = isGoldenRatio ? 1 + lambda : 2;
        double multiplayer = isGoldenRatio ? lambda : 1;
        
        DateTime start = DateTime.Now;
        while (min <= max)  
        {
            mid = (int)((min + multiplayer*max) / ratio) ;
            if (key < array[mid])  
            {  
                max = mid - 1;  
            }  
            else  
            {  
                min = mid + 1;  
            }  
        }
        return new SearchResult(array[max] == key ? max : "Not found", DateTime.Now - start);
    }

    private static LinkedList GetElement(LinkedList start, int position)
    {
        for (int i = 0; i < position; i++)
        {
            start = start.Next;
        }
        return start;
    }

    private static int GetLength(LinkedList head)
    {
        int i = 0;
        while (head.Next != null)
        {
            i++;
            head = head.Next;
        }

        return i;
    }

    public static SearchResult Search(int key, LinkedList head, bool isGoldenRatio)
    {
        int minIndex = 0, maxIndex = GetLength(head), midIndex = 0;
        LinkedList minNode = head, maxNode = null, midNode = null;

        double lambda = (Math.Sqrt(5) + 1) / 2;
        double ratio = isGoldenRatio ? 1 + lambda : 2;
        double multiplayer = isGoldenRatio ? lambda : 1;

        DateTime start = DateTime.Now;
        while (maxNode == null || minNode.Data != maxNode.Data)
        {
            midIndex = (int) ((minIndex + multiplayer * maxIndex) / ratio);
            midNode = GetElement(minNode, midIndex - minIndex);
            if (key <= midNode.Data)
            {
                maxNode = midNode;
                maxIndex = midIndex;
            }
            else
            {
                minNode = midNode.Next;
                minIndex = midIndex + 1;
            }
        }

        return new SearchResult(maxNode.Data == key ? maxIndex : "Not found", DateTime.Now - start);
    }
}
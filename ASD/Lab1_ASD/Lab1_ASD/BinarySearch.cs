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
        var x = (int[])array.Clone();
        QuickSort(x, 0, x.Length - 1);
        Console.WriteLine("The sorted array:");
        InputOutput.PrintArray(x);
        InputOutput.BaldLine();
        Console.WriteLine("          Position        Duration (ns)");
        Console.WriteLine("On array:");
        for (int i = 0; i < Program.SearchIterations; i++)
            Search(key, x, isGoldenRatio).PrintResults();

        InputOutput.BaldLine();
    }

    public static SearchResults Search(int key, int[] array, bool isGoldenRatio)
    {
        int min = 0, max = array.Length - 1, mid = max/2;
        double lambda = (Math.Sqrt(5) + 1) / 2;
        double ratio = isGoldenRatio ? 1 + lambda : 2;
        double multiplyer = isGoldenRatio ? lambda : 1;
        
        DateTime start = DateTime.Now;
        while (min <= max)  
        {
            mid = (int)((min + multiplyer*max) / ratio) ; 
            //Console.WriteLine(mid + "\t" + min + "\t" + max);
            if (key < array[mid])  
            {  
                max = mid - 1;  
            }  
            else  
            {  
                min = mid + 1;  
            }  
        }
        return new SearchResults(array[max] == key ? max : "Not found", DateTime.Now - start);
    }
}
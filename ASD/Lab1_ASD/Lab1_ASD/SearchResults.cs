namespace Lab1_ASD;

public class SearchResults
{
    public object Result { get; }
    public TimeSpan Duration { get; }

    public SearchResults(object result, TimeSpan duration)
    {
        Result = result;
        Duration = duration;
    }

    public void PrintResults()
    {
        Console.WriteLine("\t" + Result.ToString().PadLeft(10) + (Duration.Ticks + "00").PadLeft(15));
    }
}
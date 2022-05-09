namespace Lab1_ASD;

public static class GenerateArray
{
    public static (int[] Array, int Key, int Position) Generate(int n, int border)
    {
        var rand = new Random();
        int key = rand.Next(2 * border) - border, temp;
        var array = new int[n];
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
        return (array, key, temp);
    }
    
}
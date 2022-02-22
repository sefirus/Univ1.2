    private static LinkedList GetList(int[] array)
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
namespace Lab1_ASD;

public class LinkedList
{
    public LinkedList? Next;
    public int Data;
    public LinkedList(int data, LinkedList? next)
    {
        Data = data;
        Next = next;
    }
}
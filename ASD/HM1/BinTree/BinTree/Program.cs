// See https://aka.ms/new-console-template for more information

using BinTree;

var T = new Tree()
{
    Root = new Node()
    {
        Data = 5, LeftNode = null, RightNode = null
    }
};

T.Add(2);
T.Add(3);
T.Add(1);
T.Remove(2);
Console.WriteLine(T.IsContain(2));
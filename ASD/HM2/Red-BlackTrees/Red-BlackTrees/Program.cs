// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using Red_BlackTrees;

var tree = new RedBlackTree();
Io.PrintMenu();
int command = 1;
while (command != 0)
{
    command = Io.Input("Please, enter command");
    Io.BoldLine();
    switch (command)
    {
        case 1:
            tree.Insert(Io.Input("Please, enter element to insert"));
            Io.BoldLine();
            break;
        case 2:
            tree.Remove(Io.Input("Please, enter element to remove"));
            Io.BoldLine();
            break;
        case 3:
            Io.PrintMenu();
            break;
        case 4:
            var scheme = new IntegralScheme();
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                var x1 = Io.Input("Please, enter x1");
                var y1 = Io.Input("Please, enter y1");
                var x2 = Io.Input("Please, enter x2");
                var y2 = Io.Input("Please, enter y2");
                Console.WriteLine(scheme.AddElement(x1, y1, x2, y2));
                Io.BoldLine();
            }
            break;
        case 0:
            return;
    }
}



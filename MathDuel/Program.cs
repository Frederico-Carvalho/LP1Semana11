using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filename = args[0];
        IView view = new ConsoleView();
        Controller controller = new Controller(view, filename);
        controller.Run();
    }
}
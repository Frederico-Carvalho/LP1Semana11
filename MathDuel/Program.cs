using System;

class Program
{
    static void Main()
    {
        IView view = new ConsoleView();
        Controller controller = new Controller(view);
        controller.Run();
    }
}
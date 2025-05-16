using System;
using System.Collections.Generic;
using System.IO;

namespace PlayerManagerMVC2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filename = args[0];
            IView view = new ConsoleView();
            PlayerController controller = new PlayerController(view, filename);
            controller.Run();
        }
    }
}
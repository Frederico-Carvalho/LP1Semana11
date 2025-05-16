using System;
using System.Collections.Generic;

namespace PlayerManagerMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IView view = new ConsoleView();
            PlayerController controller = new PlayerController(view);
            controller.Run();
        }
    }
}
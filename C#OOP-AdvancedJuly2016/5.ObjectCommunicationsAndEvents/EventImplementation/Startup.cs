namespace EventImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string inputName = Console.ReadLine();
            while (inputName != "END")
            {
                dispatcher.Name = inputName;

                inputName = Console.ReadLine();
            } 
        }
    }
}

namespace EventImplementation
{
    public class Handler
    {
       public void OnDispatcherNameChange(object sender, NameChangeEventsArgs args)
        {
            System.Console.WriteLine("Dispatcher’s name changed to {0}", args.Name);
        }
    }
}

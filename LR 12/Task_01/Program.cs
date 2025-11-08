namespace Dispatcher
{
    using System;
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    class Dispatcher
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnNameChange(name);
                }
            }
        }
        public event NameChangeEventHandler NameChange;
        public void OnNameChange(string name)
        {
            NameChange?.Invoke(this, new NameChangeEventArgs(name));
        }
    }
    public class NameChangeEventArgs : EventArgs
    {
        public string NewName { get; private set; }
        public NameChangeEventArgs(string newName)
        {
            NewName = newName;
        }
    }
    class Handler
    {
        static public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.NewName}");
        }
    }
    internal class Program
    {
        static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.NameChange += Handler.OnDispatcherNameChange;
            while(true)
            {
                string text = Console.ReadLine();
                if(text.ToLower() == "end")
                {
                    break;
                }
                dispatcher.Name = text;
            }
        }
    }
}

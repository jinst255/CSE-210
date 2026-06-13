
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    
    public void Begin()
    {
        Console.Clear();
        Program.SetConsoleColor(ConsoleColor.Green);
        Console.WriteLine($"Welcome to the {_name} activity.");
        Console.ResetColor();

        Program.SetConsoleColor(ConsoleColor.Blue);
        Console.WriteLine($"\n{_description}");
        Console.ResetColor();
        _duration = SetDuration();
        GetReady();
    }

    public void GetReady()
    {
        Console.WriteLine("\nGet ready...");
        Pause(3);
    }
    protected void Pause(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        for (int i = 1; i <= seconds; i++)
        {
            foreach (string s in spinner)
            {
                Console.Write(s);
                Thread.Sleep(250); // 4 * 250ms = 1 second
                Console.Write("\b \b"); 
            }
        }
    }
    public int SetDuration()
    {
        int duration;
        Console.Write("\nHow long, in seconds would you like to do this activity? ");
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Program.SetConsoleColor(ConsoleColor.Red);
            Console.Write("Please enter a valid number of seconds: ");
            Console.ResetColor();
        }
        return duration;
    }
    public void End()
    {
        Console.WriteLine();
        Program.SetConsoleColor(ConsoleColor.Green);
        Console.WriteLine($"\nWell done! You have completed the {_name} activity for {_duration} seconds.");
        Console.ResetColor();
        Pause(3);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--) // I can subract with the i-- opperator    
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}


class BreathingActivity : Activity
{
    private int _inTime;
    private int _outTime;

    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.";
        _inTime = 3;
        _outTime = 4;
    }
    public void Run()
    {
        Begin(); // This is in the parent class
        DisplayMessage();
        End(); // This is also in the parent class
    }
    private void DisplayMessage()
    {
        int timeLeft = _duration;
        while (timeLeft > 0)
        {
            Program.SetConsoleColor(ConsoleColor.Cyan);
            Console.WriteLine("\nBreathe in...");
            Console.ResetColor();
            ShowCountdown(Math.Min(_inTime, timeLeft));

            timeLeft -= _inTime;
            if (timeLeft <= 0) break;

            Program.SetConsoleColor(ConsoleColor.Green);
            Console.WriteLine("Breathe out...");
            Console.ResetColor();
            ShowCountdown(Math.Min(_outTime, timeLeft));
            timeLeft -= _outTime;
        }
        Console.WriteLine();
    }
}


class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private int _itemCount;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _itemCount = 0;
    }
    public void Run()
    {
        Begin();
        DisplayPrompts();
        DisplayEntries();
        End();
    }   
    private void DisplayPrompts()
    {
        // print a random prompt
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
    }

    private void DisplayEntries()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                _itemCount++;
            }
        }

        Console.WriteLine($"\nYou listed {_itemCount} items!"); 
    }
}
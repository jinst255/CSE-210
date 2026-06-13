
class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this that applies elsewhere?",
        "What did you learn about yourself?"
    };

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void Run()
    {
        Begin();
        DisplayPrompt();
        DisplayQuestions();
        End();
    }

    private void DisplayPrompt()
    {
        // print random prompt, then let user think of and write down an answer
        Random random = new Random();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {_prompts[random.Next(_prompts.Count)]} ---");
        Console.Write("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder each of the following questions as they appear.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
    }
    private void DisplayQuestions()
    {
        Random random = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime) 
        {
            Console.Write($"> {_questions[random.Next(_questions.Count)]} "); 
            Pause(5); 
            Console.WriteLine(); 
        }
    }
}
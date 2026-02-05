class ReflectingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you helped someone.",
        "Think of a time when you did something difficult.",
        "Think of a time when you showed courage.",
        "Think of a time when you overcame a challenge."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful?",
        "How did you feel?",
        "What did you learn?",
        "How can you apply this experience in the future?",
        "What made this time successful?"
    };

    private Random _random = new();

    public ReflectingActivity()
        : base("Reflecting Activity",
        "This activity will help you reflect on times you showed strength.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("\nReflect on the following questions:");
        ShowSpinner(3);
    }

    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(4);
        }
    }
}

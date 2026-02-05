class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you helped someone.",
        "Think of a time you did something difficult.",
        "Think of a time you showed courage.",
        "Think of a time you overcame a challenge."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this meaningful?",
        "How did you feel?",
        "What did you learn?",
        "How can you apply this again?",
        "What made this successful?"
    };

    private Random _rand = new Random();

    public ReflectingActivity()
        : base("Reflecting Activity",
        "Reflect on times you showed strength and resilience.")
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
        return _prompts[_rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        return _questions[_rand.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("\nReflect on the following questions:");
        ShowSpinner(3);
    }

    public void DisplayQuestions()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(4);
        }
    }
}

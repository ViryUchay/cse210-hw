class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who are people you have helped recently?",
        "What are moments that brought you joy today?",
        "Who are your personal heroes?"
    };

    private Random _random = new();

    public ListingActivity()
        : base("Listing Activity",
        "This activity will help you list positive things in your life.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\n" + GetRandomPrompt());
        Console.Write("Start in: ");
        ShowCountDown(3);

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"\nYou listed {_count} items!");
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> entries = new();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            entries.Add(Console.ReadLine());
        }

        return entries;
    }
}

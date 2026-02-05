class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>()
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "What made you happy today?",
        "Who are your heroes?"
    };

    private Random _rand = new Random();

    public ListingActivity()
        : base("Listing Activity",
        "List as many positive things as you can in a certain area.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();

        Console.WriteLine($"\n{prompt}");
        Console.Write("Start in: ");
        ShowCountDown(3);

        List<string> items = GetListFromUser();

        _count = items.Count;

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[_rand.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> list = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            list.Add(Console.ReadLine());
        }

        return list;
    }
}

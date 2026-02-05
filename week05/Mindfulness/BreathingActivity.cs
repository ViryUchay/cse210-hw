class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
        "This activity will help you relax by walking you through slow breathing.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;

        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);

            Console.Write("\nBreathe out... ");
            ShowCountDown(4);

            elapsed += 8;
        }

        DisplayEndingMessage();
    }
}

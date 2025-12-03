class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you to breathe in and out slowly.") { }

    public void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountDown(3);
            elapsed += 3;

            if (elapsed >= Duration) break;

            Console.WriteLine("Breathe out...");
            ShowCountDown(3);
            elapsed += 3;
        }
        DisplayEndingMessage();
    }
}
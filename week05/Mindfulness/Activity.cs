class Activity
{
    // Attributes
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    // Constructor
    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Common methods
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"\nActivity: {Name}");
        Console.WriteLine($"{Description}");
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done! You have completed the activity.");
        Console.WriteLine($"Activity: {Name}, Duration: {Duration} seconds");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int i = 0;
        DateTime end = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < end)
        {
            Console.Write($"\r{spinner[i++ % spinner.Length]}");
            Thread.Sleep(200);
        }
        Console.Write("\r ");
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}...");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
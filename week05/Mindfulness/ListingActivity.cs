public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _rand;
    private int _count;

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string> {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _rand = new Random();
    }

    private string GetRandomPrompt() => _prompts[_rand.Next(_prompts.Count)];

    private void GetListFromUser(int duration)
    {
        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            _count++;
        }
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine(GetRandomPrompt());
        ShowCountDown(3);

        GetListFromUser(GetDuration());

        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }
}

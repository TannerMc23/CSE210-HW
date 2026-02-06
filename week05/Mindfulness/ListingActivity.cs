class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List things you are grateful for.",
        "List people who make you happy.",
        "List your personal strengths."
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity helps you list positive things in your life.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        List<string> items = new List<string>();

        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine();
        Console.WriteLine("You may begin in...");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");
    }
}

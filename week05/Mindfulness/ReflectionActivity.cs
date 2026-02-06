class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you overcame a challenge.",
        "Think of a time you helped someone in need.",
        "Think of a time you did something really hard."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How did this make you stronger?",
        "How can you apply this in the future?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity helps you reflect on times in your life when you showed strength.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine();
        Console.WriteLine("Think about this...");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(5);
        }
    }
}

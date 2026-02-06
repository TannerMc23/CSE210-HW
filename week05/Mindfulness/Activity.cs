abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void Run()
    {
        StartActivity();
        PerformActivity();
        EndActivity();
    }

    protected void StartActivity()
    {
        Console.Clear();
        Console.WriteLine(_name);
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }
    protected abstract void PerformActivity();

    protected void EndActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime end = DateTime.Now.AddSeconds(seconds);
        string[] spinner = {"!", "/", "-", "\\"};
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b");
            i = (i + 1) % spinner.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
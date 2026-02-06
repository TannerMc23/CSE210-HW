class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding your breathing.";
    }

    protected override void PerformActivity()
    {
         DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountdown(4);

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(4);
        }
        
    }
}
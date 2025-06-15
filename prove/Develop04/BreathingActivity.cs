class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by guiding you through slow breathing. Focus and clear your mind.")
    { }

    protected override void PerformActivity()
    {
        int duration = GetDuration();
        int cycle = 6; // 3 seconds in, 3 seconds out
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.Write("\nBreathe in... ");
            Countdown(3);
            Console.Write("\nBreathe out... ");
            Countdown(3);
            elapsed += cycle;
        }
    }
}

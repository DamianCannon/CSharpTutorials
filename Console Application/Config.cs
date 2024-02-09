namespace TeleprompterConsole;

internal class Config
{
    public int DelayInMilliseconds { get; set; } = 200;

    public bool Done { get; set; }

    public void UpdateDelay(int increment)
    {
        var newDelay = Math.Min(DelayInMilliseconds + increment, 1000);
        newDelay = Math.Max(newDelay, 20);
        DelayInMilliseconds = newDelay;
    }

    public void SetDone()
    {
        Done = true;
    }
}

using System;

public abstract class Activity
{
    public static void Main()
    {
        var activity = new Program();
        {
            activity.Entry();
        }
    }

    public abstract void Entry();
}
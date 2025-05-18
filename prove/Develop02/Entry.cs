using System;

public class Entry
{
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }

    public Entry(string text)
    {
        Text = text;
        Timestamp = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{Timestamp}: {Text}";
    }
}

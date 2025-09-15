public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }
    public void Display()
    {
        Console.WriteLine("");
        Console.WriteLine("_______________________________________");
        Console.WriteLine($"{_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Input: {_entryText}");
        // Console.WriteLine("************************************");
        Console.WriteLine("");
    }

    public override string ToString()
    {
        return $"Date: {_date} | Prompt: {_promptText} | Entry: {_entryText}";
    }
}
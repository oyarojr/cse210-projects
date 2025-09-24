public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hides the word, ensuring it's visible first
    public void Hide()
    {
        if (_isHidden)
        {
            Show(); // Reset to visible before hiding again
        }
        _isHidden = true;
    }

    // Reveals the word
    public void Show()
    {
        _isHidden = false;
    }

    // Checks if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Displays the word or underscores if hidden
    public string Display()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
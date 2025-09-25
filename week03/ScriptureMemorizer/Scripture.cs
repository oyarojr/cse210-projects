


public class Scripture
{
    private Reference _reference;
    private List<Word> _text;

    private Random newrandom = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = new List<Word>();
        string[] words = text.Split();
        foreach (var nword in words)
        {
            _text.Add(new Word(nword));
        }
    }
    
    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _text.Where(w => !w.IsHidden()).ToList();
        count = Math.Min(count, visibleWords.Count);
        var wordsToHide = visibleWords.OrderBy(x => newrandom.Next()).Take(count);

        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        string displaytext = _reference.GetDisplayText();
        foreach (Word item in _text)
        {
            displaytext += " " + item.Display();
        }
        return displaytext;
    }

    public bool IsFullyHidden()
    {
        // Loop through each word in the scripture
        foreach (Word word in _text)
        {
            // If any word is not hidden, return false
            if (!word.IsHidden())
            {
                return false;
            }
        }

        // If all words are hidden, return true
        return true;
    }   

}
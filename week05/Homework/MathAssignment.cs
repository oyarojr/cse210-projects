public class MathAssignment : Assignment
{
    private string _txtBookSection = "";
    private string _problems = "";

    public MathAssignment(string name, string topic, string txtBookSection, string problems) : base(name, topic)

    {
        _txtBookSection = txtBookSection;
        _problems = problems;
    }

    public string GetMathInformation()
    {
        return $"{_txtBookSection} - {_problems}";
    }
}
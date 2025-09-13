using System.Runtime.InteropServices;

public class Resume
{
    public string _personeName;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"{_personeName}");
        Console.WriteLine("Jobs");

        foreach (Job j in _jobs)
        {
            j.Display();
        }
    }
}
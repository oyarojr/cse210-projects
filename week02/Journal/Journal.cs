using System;
using System.Collections.Generic;
using System.Formats.Asn1;

public class Journal
{
    // List created with the List<Entry> data type to store entries
    private List<Entry> _entries = new List<Entry>();

    // Method that adds input entries from the Program.cs file with the newEntry parameter  created by the constructor
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    //Method (ListEntry data type) which returns the list of entries when called.
    public List<Entry> GetEntries()
    {
        return _entries;
    }

    //   Method to display all entries
    // public void DisplayAllEntries()
    // {
    //     if (_entries.Count == 0)
    //     {
    //         Console.WriteLine("No journal entries found.");
    //         return;
    //     }

    //     Console.WriteLine("\n  Your Journal Entries:");
    //     foreach (Entry entry in _entries)
    //     {
    //         Console.WriteLine("----------------------------------");
    //         entry.Display();
    //     }
    //     Console.WriteLine("----------------------------------");
    // }

    public void SaveToFile(string filename)
    {
        using (StreamWriter write = new StreamWriter(filename))
        {
            foreach (Entry ty in _entries)
            {
                write.WriteLine(ty.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string prompt = parts[1];
            string entry = parts[2];

            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine($"Entry: {entry}");
        }
    }

}
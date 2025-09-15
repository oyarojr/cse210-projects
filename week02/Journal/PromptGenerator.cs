using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // List of prompts
    public List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do different today what would it be?",
        "What's been on your mind lately?",
        "Describe a moment when you felt alive today.",
        "What are three things you want to focus on today?",
        "What challenged you today, how did you respond?",
        "What are you grateful for right now?"
    };

    // Method to select and return a random prompt
    public string GetRandomPrompt()
    {
        Random ranNum = new Random(); // Local variable inside the method
        int i = ranNum.Next(prompts.Count); // Get a random index
        return prompts[i]; // Return the selected prompt
    }
}

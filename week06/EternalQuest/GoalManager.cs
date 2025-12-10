using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EternalQuestApp
{
    class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine();
                DisplayPlayerInfo();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                Console.WriteLine();

                switch (input)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalNames(); break;
                    case "3": RecordEvent(); break;
                    case "4": SaveGoals(); break;
                    case "5": LoadGoals(); break;
                    case "6": return;
                    default: Console.WriteLine("Invalid selection. Try again."); break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Your current score: {_score}");
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            Console.WriteLine("Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                // Show both name and details with checkbox/progress
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
            }
        }

        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            Console.WriteLine("Goal Details:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("Types:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (never complete; earns points each record)");
            Console.WriteLine("3. Checklist Goal (complete after N times with bonus)");
            Console.Write("Choose goal type: ");
            var typeInput = Console.ReadLine();

            Console.Write("Enter short name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter description: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Enter points (integer, stored as string): ");
            string points = Console.ReadLine() ?? "0";

            switch (typeInput)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    int target = ReadInt("Enter target count: ");
                    int bonus = ReadInt("Enter bonus points for completing: ");
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }

            ListGoalNames();
            int choice = ReadInt("Select goal number to record: ");
            if (choice < 1 || choice > _goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Goal g = _goals[choice - 1];

            // Award points based on type and state
            int pointsEarned = 0;

            if (g is SimpleGoal s)
            {
                if (!s.IsComplete())
                {
                    s.RecordEvent();
                    pointsEarned += GetPointsSafe(s.PointsString);
                    Console.WriteLine($"Completed '{s.ShortName}'! Earned {pointsEarned} points.");
                }
                else
                {
                    Console.WriteLine("This simple goal is already complete. No points awarded.");
                }
            }
            else if (g is EternalGoal e)
            {
                e.RecordEvent();
                pointsEarned += GetPointsSafe(e.PointsString);
                Console.WriteLine($"Recorded '{e.ShortName}'. Earned {pointsEarned} points.");
            }
            else if (g is ChecklistGoal c)
            {
                bool wasComplete = c.IsComplete();
                if (!wasComplete)
                {
                    c.RecordEvent();
                    pointsEarned += GetPointsSafe(c.PointsString);

                    if (c.IsComplete())
                    {
                        pointsEarned += c.Bonus;
                        Console.WriteLine($"Checklist progress recorded for '{c.ShortName}'. Target reached!");
                        Console.WriteLine($"Earned {c.PointsString} + {c.Bonus} bonus = {pointsEarned} points.");
                    }
                    else
                    {
                        Console.WriteLine($"Checklist progress recorded for '{c.ShortName}'.");
                        Console.WriteLine($"Currently completed: {c.AmountCompleted}/{c.Target}. Earned {c.PointsString} points.");
                    }
                }
                else
                {
                    Console.WriteLine("This checklist goal is already complete. No points awarded.");
                }
            }
            else
            {
                // Fallback (should not occur)
                g.RecordEvent();
                pointsEarned += GetPointsSafe(g.PointsString);
                Console.WriteLine($"Recorded '{g.ShortName}'. Earned {pointsEarned} points.");
            }

            _score += pointsEarned;
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename to save (e.g., goals.txt): ");
            string filename = Console.ReadLine() ?? "goals.txt";

            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    writer.WriteLine(_score);
                    foreach (var g in _goals)
                    {
                        writer.WriteLine(g.GetStringRepresentation());
                    }
                }

                Console.WriteLine($"Goals saved to '{filename}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine() ?? "goals.txt";

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines(filename);
                if (lines.Length == 0)
                {
                    Console.WriteLine("File is empty.");
                    return;
                }

                _goals.Clear();

                // First line is score
                _score = GetPointsSafe(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split('|');
                    if (parts.Length < 4)
                        continue;

                    string type = parts[0];
                    if (type == "SimpleGoal" && parts.Length >= 5)
                    {
                        string name = parts[1];
                        string desc = parts[2];
                        string pts = parts[3];
                        bool isComp = bool.Parse(parts[4]);

                        var sg = new SimpleGoal(name, desc, pts);
                        if (isComp)
                        {
                            // Mark complete
                            sg.RecordEvent();
                        }
                        _goals.Add(sg);
                    }
                    else if (type == "EternalGoal")
                    {
                        string name = parts[1];
                        string desc = parts[2];
                        string pts = parts[3];
                        var eg = new EternalGoal(name, desc, pts);
                        _goals.Add(eg);
                    }
                    else if (type == "ChecklistGoal" && parts.Length >= 7)
                    {
                        string name = parts[1];
                        string desc = parts[2];
                        string pts = parts[3];
                        int amountCompleted = GetPointsSafe(parts[4]);
                        int target = GetPointsSafe(parts[5]);
                        int bonus = GetPointsSafe(parts[6]);

                        var cg = new ChecklistGoal(name, desc, pts, target, bonus);

                        // Rehydrate amountCompleted by calling RecordEvent() amountCompleted times
                        for (int k = 0; k < amountCompleted; k++)
                            cg.RecordEvent();

                        _goals.Add(cg);
                    }
                }

                Console.WriteLine($"Goals loaded from '{filename}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }

        // -------------------------
        // Helpers
        // -------------------------
        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out int val))
                    return val;
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        private static int GetPointsSafe(string s)
        {
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out int val))
                return val;
            return 0;
        }
    }
}

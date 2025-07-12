using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main()
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        bool running = true;
        while (running)
        {
            DisplayLevel();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": Console.WriteLine($"Current Score: {score}"); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Select type: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        int points;
        while (true)
        {
            Console.Write("Enter points: ");
            if (int.TryParse(Console.ReadLine(), out points)) break;
            Console.WriteLine("Please enter a valid number.");
        }

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                int target;
                while (true)
                {
                    Console.Write("How many times to complete it? ");
                    if (int.TryParse(Console.ReadLine(), out target)) break;
                    Console.WriteLine("Please enter a valid number.");
                }

                int bonus;
                while (true)
                {
                    Console.Write("Bonus points when finished: ");
                    if (int.TryParse(Console.ReadLine(), out bonus)) break;
                    Console.WriteLine("Please enter a valid number.");
                }

                goals.Add(new ChecklistGoal(name, description, points, target, 0, bonus));
                break;
            case "4":
                goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            var goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetStatus()} {goal.GetName()} ({goal.GetDescription()})");
        }
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        ListGoals();
        Console.Write("Select goal number to record: ");

        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        goals[index - 1].RecordEvent(ref score);
        Console.WriteLine("Event recorded!");
    }

    static void SaveGoals()
    {
        try
        {
            using (StreamWriter output = new StreamWriter("goals.txt"))
            {
                output.WriteLine(score);
                foreach (Goal g in goals)
                    output.WriteLine(g.SaveData());
            }
            Console.WriteLine("Goals saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    static void LoadGoals()
    {
        try
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No save file found.");
                return;
            }

            string[] lines = File.ReadAllLines("goals.txt");
            if (lines.Length == 0)
            {
                Console.WriteLine("Save file is empty.");
                return;
            }

            score = int.Parse(lines[0]);
            goals.Clear();
            foreach (string line in lines.Skip(1))
            {
                goals.Add(Goal.LoadData(line));
            }
            Console.WriteLine("Goals loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    static void DisplayLevel()
    {
        int level = score / 1000 + 1;
        string title = level switch
        {
            1 => "Novice Seeker",
            2 => "Diligent Disciple",
            3 => "Virtue Guardian",
            4 => "Scripture Sage",
            5 => "Temple Master",
            _ => "Eternal Legend"
        };
        Console.WriteLine($"\n=== Level {level}: {title} ===");
    }
}

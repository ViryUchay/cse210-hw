using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private int _streak = 0;
    private DateTime _lastActivity;
    private BadgeSystem _badgeSystem = new BadgeSystem();

    public void Start()
    {
        string choice = "";

        while (choice != "7")
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Show Badges");
            Console.WriteLine("7. Quit");

            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") SaveGoals();
            else if (choice == "5") LoadGoals();
            else if (choice == "6") _badgeSystem.DisplayBadges();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nScore: {_score} | Level: {_level} | Streak: {_streak}");
    }

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("1. Simple  2. Eternal  3. Checklist");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int pts = int.Parse(Console.ReadLine());

        if (type == 1)
            _goals.Add(new SimpleGoal(name, desc, pts));

        else if (type == 2)
            _goals.Add(new EternalGoal(name, desc, pts));

        else if (type == 3)
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("Select goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();

        // ⭐ streak logic
        if (_lastActivity.Date == DateTime.Now.Date.AddDays(-1))
            _streak++;
        else
            _streak = 1;

        _lastActivity = DateTime.Now;

        if (_streak >= 5)
            earned *= 2;

        _score += earned;

        LevelUp();

        _badgeSystem.CheckBadges(_score, _level, _streak);
    }

    private void LevelUp()
    {
        if (_score >= _level * 1000)
        {
            _level++;
            Console.WriteLine("🎉 LEVEL UP!");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter output = new StreamWriter("goals.txt"))
        {
            output.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt")) return;

        string[] lines = File.ReadAllLines("goals.txt");

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            if (parts[0] == "Simple")
            {
                SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])) goal.RecordEvent();
                _goals.Add(goal);
            }
            else if (parts[0] == "Eternal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (parts[0] == "Checklist")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])
                );

                int completed = int.Parse(parts[4]);

                for (int j = 0; j < completed; j++)
                    goal.RecordEvent();

                _goals.Add(goal);
            }
        }
    }
}

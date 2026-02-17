using System;
using System.Collections.Generic;

public class BadgeSystem
{
    private List<string> _badges = new List<string>();

    public void CheckBadges(int score, int level, int streak)
    {
        if (score >= 1000 && !_badges.Contains("Rising Star"))
        {
            Award("Rising Star ⭐");
        }

        if (level >= 5 && !_badges.Contains("Goal Master"))
        {
            Award("Goal Master 🏆");
        }

        if (streak >= 7 && !_badges.Contains("Consistency Champion"))
        {
            Award("Consistency Champion 🔥");
        }
    }

    private void Award(string badge)
    {
        _badges.Add(badge);
        Console.WriteLine($"\n🎉 NEW BADGE: {badge}");
    }

    public void DisplayBadges()
    {
        Console.WriteLine("\nBadges Earned:");
        foreach (var b in _badges)
        {
            Console.WriteLine($"- {b}");
        }
    }
}

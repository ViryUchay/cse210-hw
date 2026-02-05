using System;
using System.Collections.Generic;
using System.Threading;

/*
========================================================
Mindfulness Program
========================================================

EXCEEDING REQUIREMENTS (beyond core specification):

1. Session Activity Counter
   - Tracks how many activities the user completes during
     the current program session.
   - Displays the count after each activity.

2. Improved Animations
   - Spinner animation used consistently during pauses.
   - Countdown animation for breathing and preparation phases.

3. Strong Use of OOP Principles
   - Clear inheritance hierarchy using a base Activity class.
   - Polymorphism through overridden Run() methods.
   - Encapsulation with protected/private fields.

========================================================
*/

class Program
{
    static int _sessionCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect a choice: ");

            string choice = Console.ReadLine();

            if (choice == "4")
                break;

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                default:
                    continue;
            }

            activity.Run();
            _sessionCount++;

            Console.WriteLine($"\nActivities completed this session: {_sessionCount}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}

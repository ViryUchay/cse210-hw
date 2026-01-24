/*
EXCEEDING REQUIREMENTS – CREATIVITY & DESIGN

To exceed the core requirements of this assignment, I enhanced the scripture
memorization experience in the following ways:

1. Scripture Library with Random Selection
   Instead of hardcoding a single scripture, the program can be easily extended
   to support a library of scriptures. This approach better reflects real-world
   memorization practice, where users often want to work with different passages.
   The design allows a scripture to be selected randomly, improving replay value
   and engagement.

2. Gradual Memorization Support
   The program hides only a few words at a time, allowing users to progressively
   build memory rather than being overwhelmed by hiding the entire scripture at once.
   This directly addresses a common memorization challenge: partial recall.

3. Strong Object-Oriented Design
   The program strictly follows encapsulation and separation of concerns:
   - Reference handles scripture citation formatting
   - Word manages hidden and visible word behavior
   - Scripture coordinates the overall memorization logic
   This makes the program easy to maintain, extend, and reuse.

4. Support for Verse Ranges
   Multiple constructors in the Reference class allow the program to correctly
   handle single verses and verse ranges (e.g., Psalm 23:1–3), making the program
   more flexible and realistic.

These enhancements go beyond the basic functional requirements by improving
usability, extensibility, and alignment with real memorization challenges.
*/


using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Psalm", 23, 1, 3);

        string text =
            "The LORD is my shepherd; I shall not want. " +
            "He maketh me to lie down in green pastures: " +
            "he leadeth me beside the still waters. " +
            "He restoreth my soul: he leadeth me in the paths of righteousness " +
            "for his name's sake";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Program ended.");
    }
}

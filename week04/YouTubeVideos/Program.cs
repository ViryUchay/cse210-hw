using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learning C#", "CodeAcademy", 1200);
        Video video2 = new Video("Brand Awareness Analysis", "MarketWatch", 1500);
        Video video3 = new Video("Tech Trends 2025", "TechWorld", 1800);

        video1.AddComment(new Comment("Vivian", "Very helpful."));
        video1.AddComment(new Comment("Samuel", "Clear explanation."));
        video1.AddComment(new Comment("Ada", "Easy to understand."));

        video2.AddComment(new Comment("Michael", "Interesting insights."));
        video2.AddComment(new Comment("Grace", "Well explained."));
        video2.AddComment(new Comment("Daniel", "Very informative."));

        video3.AddComment(new Comment("Tunde", "Great content."));
        video3.AddComment(new Comment("Blessing", "Loved this video."));
        video3.AddComment(new Comment("John", "Looking forward to more."));

        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}

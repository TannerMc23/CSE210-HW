using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("C# Abstraction Explained", "Alice Smith", 300);
        v1.AddComment(new Comment("Bob", "Great explanation!"));
        v1.AddComment(new Comment("Charlie", "This helped me a lot."));
        v1.AddComment(new Comment("Dana", "Thanks for the video!"));

        Video v2 = new Video("Learning C# Classes", "John Doe", 420);
        v2.AddComment(new Comment("Eve", "Nice examples."));
        v2.AddComment(new Comment("Frank", "Good pace."));
        v2.AddComment(new Comment("Grace", "Can you do more?"));

        videos.Add(v1);
        videos.Add(v2);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (sec): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
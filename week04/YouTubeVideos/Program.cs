using System;
using System.Collections.Generic;

// Class to represent a comment
class Comment
{
    public string CommenterName { get; private set; }
    public string CommentText { get; private set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        CommentText = text;
    }
}

// Class to represent a YouTube video
class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }
    private List<Comment> Comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenter, string text)
    {
        Comments.Add(new Comment(commenter, text));
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}\nAuthor: {Author}\nLength: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}\n");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }
        Console.WriteLine("\n========================\n");
    }
}

// Main program class
class Program
{
    static void Main()
    {
        // Creating a list of videos
        List<Video> videos = new List<Video>();

        // Creating and adding videos
        Video video1 = new Video("Learn C# in 10 Minutes", "The Tech Guru", 600);
        video1.AddComment("Alice", "Great explanation! Thanks!");
        video1.AddComment("Bob", "This was very helpful.");
        video1.AddComment("Charlie", "Can you do one for Python?");
        videos.Add(video1);

        Video video2 = new Video("Top 10 Programming Languages in 2025", "Code Master", 720);
        video2.AddComment("David", "I love Python!");
        video2.AddComment("Eva", "C# is underrated!");
        video2.AddComment("Frank", "JavaScript all the way!");
        videos.Add(video2);

        Video video3 = new Video("How to Build a Website", "Web Dev Pro", 900);
        video3.AddComment("Grace", "This was so easy to follow!");
        video3.AddComment("Hank", "Can you show more CSS tricks?");
        video3.AddComment("Ivy", "Awesome tutorial!");
        videos.Add(video3);

        // Display all video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}

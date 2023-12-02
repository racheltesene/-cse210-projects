using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos and comments
        Video video1 = new Video("Video 1", "Author 1", 120);
        video1.AddComment("UserA", "Great video!");
        video1.AddComment("UserB", "I learned a lot.");

        Video video2 = new Video("Video 2", "Author 2", 180);
        video2.AddComment("UserC", "Interesting content.");
        video2.AddComment("UserD", "Could be better.");

        Video video3 = new Video("Video 3", "Author 3", 150);
        video3.AddComment("UserE", "Awesome!");
        video3.AddComment("UserF", "Not my cup of tea.");

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.UserName}: {comment.Text}");
            }

            Console.WriteLine(); // Add a blank line for better readability
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string userName, string text)
    {
        Comments.Add(new Comment(userName, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string UserName { get; }
    public string Text { get; }

    public Comment(string userName, string text)
    {
        UserName = userName;
        Text = text;
    }
}
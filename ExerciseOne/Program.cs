using System;
using System.Threading;

namespace ExerciseOne
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var post = new Post("First Post", "This is my First Post");
            post.Create();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();

            post.DownVote();
            post.DownVote();
            post.DownVote();


            Console.WriteLine("On {0} Alan created a post titled {1}, with the caption {2}. It was liked {3} times and disliked {4} times", post.DateofPost, post.Title, post.Description, post.UpVotes, post.DownVotes);

        }

        public void CallStopwatch()
        {
            var sw = new MyStopWatch();
            sw.Start();
            Thread.Sleep(1000);
            sw.Stop();
            TimeSpan te = sw.Elapsed();

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", te.Hours, te.Minutes, te.Seconds, te.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        public void CallStackOverFlowPost()
        {
        }
  
    }
}

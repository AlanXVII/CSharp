using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseOne
{
    class Post
    {
        public string Title;
        public string Description;
        public bool Created = false;

        public DateTime DateofPost { get; private set; }
        public int UpVotes { get; private set; }
        public int DownVotes { get; private set; }

        //Constructors
        public Post()
        {

        }
        public Post(string title, string description)
            :this()
        {
            this.Title = title;
            this.Description = description;
        }

        //Methods
        public void Create()
        {
            Created = true;
            DateofPost = DateTime.Now;
        }
        public void UpVote()
        {
            UpVotes += 1;
        }
        public void DownVote()
        {
            DownVotes += 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceC
{
    class Post
    {

        private static int currentPostId; //available outside of this post class

        public static int CurrentPostId { get { return currentPostId; } }
        // properties protected means that it can only be used by this class, and any deriving classes
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string SendByUsername { get; set; }
        protected bool IsPublic { get; set; }
        public Post()
        {
            ID = 0;
            Title = "My First Post";
            Console.WriteLine("I am POST(1) CALLED");
            IsPublic = true;
            SendByUsername = "Denis Panjuta";
        }

        // Instance constructor that has three parameters
        public Post(string title, bool isPublic, string sendByUsername)
        {

            Console.WriteLine("I am POST(3) CALLED");

            ID = GetNextID();
            Title = title;
            SendByUsername = sendByUsername;
            IsPublic = isPublic;
        }

        protected int GetNextID()
        {
            return ++currentPostId;
        }

        public void Update(string title, bool isPublic)
        {
            Title = title;
            IsPublic = isPublic;
        }

        // Virtual method override of the ToString method that is inherited
        // from System.Object.
        public override string ToString()
        {
            //Console.WriteLine(base.ToString());
            return String.Format("{0} - {1} - by {2}", this.ID, this.Title, this.SendByUsername);
        }



    }
}

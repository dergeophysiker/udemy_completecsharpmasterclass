using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceC
{
    class ImagePost : Post
    {
        public string ImageURL { get; set; }
        public ImagePost() : base("some author iamge2", true, "some user image2") { }

        public ImagePost(string title, bool isPublic, string sendByUsername,string imageURL)
        {
            Console.WriteLine("begin  calls to base class default constructor");
            Console.WriteLine(this.SendByUsername);
            Console.WriteLine(this.Title);
            Console.WriteLine("end calls to base class default constructor");
            ID = GetNextID();
            Title = title;
            SendByUsername = sendByUsername;
            IsPublic = isPublic;
            ImageURL = imageURL;
        }

    }
}

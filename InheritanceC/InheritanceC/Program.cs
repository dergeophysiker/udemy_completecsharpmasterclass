using System;
using System.Threading;

namespace InheritanceC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing image section");
            Console.WriteLine(Post.CurrentPostId);
            //ImagePost image1 = new ImagePost("awesome image", true, "james earl jones", "someURL");
            ImagePost image2 = new ImagePost();
            Console.WriteLine(image2.ToString());
            Console.WriteLine(Post.CurrentPostId);
            Console.WriteLine("Executing next image section");
            ImagePost image1 = new ImagePost("awesome image1", true, "james earl jones image1", "someURL iamge1");
            Console.WriteLine(image1.ToString());
            Console.WriteLine("Executing post section");

            Post post1 = new Post("thanks for the birday wishes", true, "Dennis Dude");
            Console.WriteLine(post1);
            Post post2 = new Post("thanks for the morning wishes", true, "James Dude");
            Console.WriteLine(post2);
            Console.WriteLine(Post.CurrentPostId);

            VideoPost vpost = new VideoPost("here is my video", true, "video producer", "somevideourl", 10.4);
            vpost.Play();
            Console.ReadKey();
            vpost.Stop();
           
       
        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InheritanceC
{
    class VideoPost : Post
    {
        protected bool isPlaying = false;
        protected double currentDuration = 0;
        Timer timed;


        public string VideoURL { get; set; }
        public double VideoLength { get; set; }
        public VideoPost() { }

        public VideoPost(string title, bool isPublic, string sendByUsername, string videoURL, double videoLength) : base(title,isPublic,sendByUsername)
        {
            ID = GetNextID();
            VideoLength = videoLength;
            VideoURL = videoURL;
            this.Play();
        }

        public void Play()
        {
            if (!isPlaying)

            {
                isPlaying = true;
                Console.WriteLine("Playing");
                timed = new Timer(TimerCallback, null, 0, 1000);

            }


        }

        public void Stop()
        {
            // Console.ReadLine();
            if (isPlaying)
            {
                
                Console.WriteLine("stopped at {0}", currentDuration);
                currentDuration = 0;
                
                timed.Dispose();
            }

        }

        private void TimerCallback(object o)
        {
           // Console.WriteLine("In timer call back " + DateTime.Now);
            
            if(currentDuration < VideoLength)
            {
                currentDuration++;
                Console.WriteLine("Video at {0}s",currentDuration);
                
            }
            else
            {
                Stop();
            }

        }

    }

}


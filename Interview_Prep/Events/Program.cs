using System;
/*
 * what is an event?
 * a mechanim for communication between objects
 * used in building loosely coupled applicaitons
 * helps extending applications
 * 
 */
namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailserver = new Mailservice(); //subscriber

            //the event needs to trigger before the action happens.
            videoEncoder.VideoEncoded += mailserver.OnVideoEncoded;
            videoEncoder.Encode(video);
        }
    }

    //example subscriber to our event system
    public class Mailservice
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("sending mail.");
        }
    }

    public class Video
    {
        public string Title { get; set; }
    }

    //three steps to a event
    //define delegate
    //define an event based on the delegate
    //raise the event

    public class VideoEncoder
    {
        //common practice is that the first item of the even delgate be the source and the second be eventargs. 
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        //we can set a different type of event args by defining a custom adt args set.
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);


        //setup the even as a event handler.
        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("we are encoding the video");
            //add in the method for raising into your specified event method.
            OnVideoEncoded();
        }

        //common practice is to call your raising method as a protected virtual.
        protected virtual void OnVideoEncoded()  //this would change to have OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);
            //you would set the VideoEventArgs as so:
            //VideoEncoded(this, new VideoEventArgs(){Video = video}
        }
    }


    public class VideoEventArgs: EventArgs
    {
        public Video Video { get; set; }
    }
}

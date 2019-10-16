using System;
/*
 * delegeate is an object that nows how to call a method or group of methods
 * 
 * it is a type safe function pointer that can be set as a 
 * single delegate
 * multicast delegate 
 * or generic delegate
 * 
 * Single delegate can be used to invoke a single method
 * 
 * Multicast delegate can be used to invoke the multiple methods. 
 * The delegate instance can do multicasting (adding new method on existing delegate instance)
 * using the + operator and – operator can be used to remove a method from a delegate instance. 
 * All methods will invoke in sequence as they are assigned.
 * 
 * 
 * Generic Delegate was introduced in .NET 3.5 that don't require to define the delegate instance in order to invoke the methods.
 *
 * There are three types of generic delegates:
 *
 * Func
 * Action
 * Predicate
 * 
 * use delegates where you have a eventing design pattern
 * or when the caller doesnt need to access other properties or methods on the object implementing the method.
 * 
 * usable for extensible and flexible applications (ex: frameworks)
 * 
 */
namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;

            processor.Process("Photo.jpg", filterHandler);
        }
    }




    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }
    //holds a pointer or group of pointers to a function or method(s)
    
    public class PhotoProcessor
    {
        //System.Predicate<> //predicate points to a method that returns a bool
        //System.Action<>  //action points to a method that returns void
        //System.Func<>  // func points to a method that returns a value

        public delegate void PhotoFilterHandler(Photo photo);
        public void Process(string path, Action<Photo> filterhandler)
        {
            var photo = Photo.Load(path);
            filterhandler(photo);



                photo.Save();
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("apply brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("apply contrast");

        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("photo resized");
        }
    }



}

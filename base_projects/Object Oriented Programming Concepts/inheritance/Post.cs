using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance 
{
    class Post
    {
        private static int currentPostId;
        //properties
        protected int ID { get; set;}
        protected string Title{ get; set;}
        protected string sendByUserName {get; set;}
        protected bool isPublic {get; set;}


        public Post()
        {
            ID = 0;
            Title = "My First Post";
            isPublic = true;
            sendByUserName = "James Sherman";
        } 


        //Instance constructor 3 peram

        public Post(string peram_title, bool peram_isPublic, string peram_sendByUserName)
        {
            this.ID = GetNextID();
            this.Title = peram_title;
            this.isPublic = peram_isPublic;
            this.sendByUserName = peram_sendByUserName;

        }

        protected int GetNextID()
        {
            return ++currentPostId;
        }

        public void Update(string peram_title, bool peram_isPublic)
        {
            this.Title = peram_title;
            this.isPublic = peram_isPublic;
        }


        //virtual method that overrieds tostring method
        public override string ToString()
        {
            return String.Format("{0} - {1} - by {2}", this.ID, this.Title, this.sendByUserName);
        }

    }
}
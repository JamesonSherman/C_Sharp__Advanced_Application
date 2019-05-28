using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance 
{
    /*
     */
    class ImagePost: Post
    {
        public string ImageURL { get; set; }

        public ImagePost()
        {

        }

        public ImagePost(string Peram_Title, string Peram_sendByUserName, string Peram_imageURL, bool Peram_isPublic)
        {
            this.ID = GetNextID();
            this.Title = Peram_Title;
            this.sendByUserName = Peram_sendByUserName;
            this.isPublic = Peram_isPublic;
            //own url member
            this.ImageURL = Peram_imageURL;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - by {3}", this.ID, this.Title,this.ImageURL, this.sendByUserName);
        }

    }
}
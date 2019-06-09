using flightApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flightApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience Updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience Update Failed", "Ok");
                }
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience Deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience Deletion Failed", "Ok");
                }
            }
        }
    }
}
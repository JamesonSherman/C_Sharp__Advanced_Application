using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace flightApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LogInButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailTrue = string.IsNullOrEmpty(emailEntry.Text);
            bool isPassTrue = string.IsNullOrEmpty(passwordEntry.Text);

            if(isEmailTrue || isPassTrue)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage()); 
            }
        }
    }
}

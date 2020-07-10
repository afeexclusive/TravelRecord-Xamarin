using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetails : ContentPage
    {
        Post selectedPost;
        public PostDetails(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            ExperienceDetails.Text = selectedPost.Experience;
        }

        private void UpdateBtn_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = ExperienceDetails.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);
                if (rows > 0)
                {
                    DisplayAlert("Done", "Experience successfully updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failed", "An Error occured while updating record", "Ok");
                }
            }
            
        }

        private void DelBtn_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);
                if (rows > 0)
                {
                    DisplayAlert("Done", "Experience Post has been deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failed", "An Error occured while deleting record", "Ok");
                }
            }
        }
    }
}
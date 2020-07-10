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
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                ExpList.ItemsSource = posts;

            }
        }

        private void ExpList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = ExpList.SelectedItem as Post;
            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetails(selectedPost));
            }
        }
    }
}
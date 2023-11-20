using Cine.Models;
using Cine.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cine.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private string url = $"{Constants.host}/api/movies/get/movies/post";
        HttpClient client = new HttpClient();
        private ObservableCollection<Movie> _movies;
        public MoviesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string payload = "";
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(data);
                _movies = new ObservableCollection<Movie>(movies);
                lmovies.ItemsSource = _movies;
            } else
            {
                Console.WriteLine("Error fetching data.");
            }
            base.OnAppearing();
        }

        private async void lmovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Movie movie)
            {
                await Navigation.PushAsync(new MovieDetailPage(movie));
            }
        }
    }
}
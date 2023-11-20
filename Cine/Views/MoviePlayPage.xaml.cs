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
    public partial class MoviePlayPage : ContentPage
    {
        private string url = $"{Constants.host}/api/movies/get/plays";
        HttpClient client = new HttpClient();
        private ObservableCollection<MoviePlay> _moviePlays;
        public MoviePlayPage()
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
                List<MoviePlay> moviePlays = JsonConvert.DeserializeObject<List<MoviePlay>>(data);
                _moviePlays = new ObservableCollection<MoviePlay>(moviePlays);
                lmovies.ItemsSource = _moviePlays;
            }
            else
            {
                Console.WriteLine("Error fetching data.");
            }
            base.OnAppearing();
        }

        private async void lmovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MoviePlay moviePlay)
            {
                await Navigation.PushAsync(new RoomPage(moviePlay));
            }
        }
    }
}
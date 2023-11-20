using Cine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cine.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomPage : ContentPage
    {
        private int Rows = 6;
        private int Columns = 5;
        public RoomPage(MoviePlay moviePlay)
        {
            InitializeComponent();
            CreateSeatGrid();
        }

        private void CreateSeatGrid()
        {
            for (int i = 0; i < Rows; i++)
            {

                for (int j = 0; j < Columns; j++)
                {
                    var seatButton = new ImageButton
                    {
                        Source = "seat_gray.png",
                        WidthRequest = 60,
                        HeightRequest = 60,
                        Margin = new Thickness(1, 3),
                        BackgroundColor = Color.Transparent,
                        BorderColor = Color.Black,
                        Padding = new Thickness(0, 0, 0, 3)
                    };

                    seatButton.Clicked += OnSeatClicked;

                    seatGrid.Children.Add(seatButton, j, i);
                }
            }
        }

        private void OnSeatClicked(object sender, EventArgs e)
        {
            var seatButton = (ImageButton)sender;

            if (seatButton.Source.ToString().Contains("seat_red"))
            {
                seatButton.Source = "seat_gray.png";
            }
            else
            {
                seatButton.Source = "seat_red.png";
            }
        }

        private void OnReserveSeatClicked(object sender, EventArgs e)
        {

            // await Navigation.PushAsync(new ReservaPage());
            DisplayAlert("Error","Servicio no disponible. Por favor intenta de nuevo más tarde", "Aceptar");
        }
    }
}
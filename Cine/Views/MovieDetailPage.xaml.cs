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
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage(Movie movie)
        {
            InitializeComponent();
            BindingContext = movie;
            lblCategoriaDuracion.Text = $"{movie.category.name} | {movie.duration} Minutos";
        }
    }
}
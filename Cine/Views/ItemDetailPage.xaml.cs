using Cine.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Cine.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
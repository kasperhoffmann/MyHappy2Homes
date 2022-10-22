using System.ComponentModel;
using Xamarin.Forms;
using MyHappy2Homes.ViewModels;

namespace MyHappy2Homes.Views
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
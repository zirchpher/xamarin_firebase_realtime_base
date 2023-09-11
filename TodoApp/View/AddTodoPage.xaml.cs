using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTodoPage : ContentPage
    {
        public AddTodoPage()
        {
            InitializeComponent();
        }

        private async void BackButton_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            //await Navigation.PushAsync(new HomePage());
        }
    }
}
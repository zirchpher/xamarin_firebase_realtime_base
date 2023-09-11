using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(Navigation, ReminderContainer);
        }

        private async void AddTodo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTodoPage());
        }
    }
}
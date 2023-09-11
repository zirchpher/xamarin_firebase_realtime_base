using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Model;
using TodoApp.ModelView;
using TodoApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace TodoApp.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<Reminder> _reminderList;
        #endregion

        #region CONSTRUCTOR
        public HomePageViewModel(INavigation navigation, StackLayout reminderContainer)
        {
            Navigation = navigation;
            DisplayReminders(reminderContainer);
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }

        public List<Reminder> ReminderList
        {
            get { return _reminderList; }
            set { SetValue(ref _reminderList, value); }
        }
        #endregion

        #region PROCESOS
        public async Task DisplayReminders(StackLayout reminderContainer)
        {
            var function = new ReminderService();
            ReminderList = await function.GetReminders();

            foreach (var reminder in ReminderList)
            {
                RenderReminder(reminder, reminderContainer);
            }
        }

        public void RenderReminder(Reminder reminder, StackLayout reminderContainer)
        {

            // Frame contenedor total
            var frameTotal = new Frame
            {
                HeightRequest = 160,
                Padding = 0,
                CornerRadius = 12
            };

            // Grid dentro del Frame
            var grid = new Grid
            {
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(12, GridUnitType.Absolute) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
            };

            // BoxView en la columna 0 del Grid
            var boxView = new BoxView
            {
                BackgroundColor = Color.Orange
            };
            Grid.SetColumn(boxView, 0);

            // Agregar el BoxView al Grid
            grid.Children.Add(boxView);

            // Establecer el contenido del Frame como el Grid
            frameTotal.Content = grid;

            //////////////////////// Hasta acá error

            // Grid contenedor de todo el recordatorio en la columna 1
            var gridRecordatorio = new Grid
            {
                ColumnDefinitions = { new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) } },
                RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(4, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    },
                Padding = new Thickness(0, 0, 0, 12)
            };

            Grid.SetColumn(gridRecordatorio, 1);
            frameTotal.Content = gridRecordatorio;

            // Header
            var headerStackLayout = new StackLayout
            {
                Padding = new Thickness(8, 4),
                Orientation = StackOrientation.Vertical
            };

            Grid.SetRow(headerStackLayout, 0);
            gridRecordatorio.Children.Add(headerStackLayout);

            headerStackLayout.Children.Add(new Label
            {
                Text = reminder.title,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            headerStackLayout.Children.Add(new Label
            {
                Text = reminder.description,
                TextColor = Color.FromHex("#201F1F"),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            });

            // Body
            var bodyFrame = new Frame
            {
                BackgroundColor = Color.FromHex("#DEDBDB"),
                Padding = new Thickness(12, 0),
                CornerRadius = 12,
                Margin = new Thickness(0, 0, 8, 0),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new Image
                            {
                                Source = "calendar.png",
                                HeightRequest = 28
                            },
                            new Label
                            {
                                Text = "5/9/2023",
                                TextColor = Color.FromHex("#6A6A6A"),
                                VerticalTextAlignment = TextAlignment.Center,
                                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                            }
                        }
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        Children =
                        {
                            new Image
                            {
                                Source = "time.png",
                                HeightRequest = 24
                            },
                            new Label
                            {
                                Text = "4:45 p. m.",
                                TextColor = Color.FromHex("#6A6A6A"),
                                VerticalTextAlignment = TextAlignment.Center,
                                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                            }
                        }
                    }
                }
                }
            };

            Grid.SetRow(bodyFrame, 1);
            gridRecordatorio.Children.Add(bodyFrame);

            reminderContainer.Children.Add(frameTotal);
        }

        public async Task ProcesoAsyncrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}

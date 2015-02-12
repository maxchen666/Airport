using System;

using Xamarin.Forms;

namespace Airport
{
	public class App : Application
	{
		public App ()
		{ 
			AirportViewModel airports = new AirportViewModel ();

			ListView list = new ListView () {
				ItemTemplate = new DataTemplate (typeof(AirportItemCell)),
				ItemsSource = airports.airports
			};

			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = { list }
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


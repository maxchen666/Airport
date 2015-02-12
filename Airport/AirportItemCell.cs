using System;
using Xamarin.Forms;

namespace Airport
{
	public class AirportItemCell : ViewCell
	{
		public AirportItemCell ()
		{
			Label name = new Label () { Font = Font.SystemFontOfSize (10) };
			name.SetBinding(Label.TextProperty, "name");

			Label code = new Label () { Font = Font.SystemFontOfSize (10) };
			code.SetBinding(Label.TextProperty, "code");
			 
			Label type = new Label () { Font = Font.SystemFontOfSize (10) };
			type.SetBinding(Label.TextProperty, "type");

			Label city = new Label () { Font = Font.SystemFontOfSize (10) };
			city.SetBinding(Label.TextProperty, "city");

			Label location = new Label () { Font = Font.SystemFontOfSize (10) };
			location.SetBinding(Label.TextProperty, "location");

			Grid grid = new Grid () {
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
				},
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) }
				}
			};

			grid.Children.Add (name, 0, 2, 0, 1);
			grid.Children.Add (code, 0, 1, 1, 2);
			grid.Children.Add (type, 1, 2, 1, 2);
			grid.Children.Add (city, 0, 1, 2, 3);
			grid.Children.Add (location, 1, 2, 2, 3);

			View = grid;

		}
	}
}

using System;
using System.ComponentModel;

namespace Airport
{
	public class AirportModel:INotifyPropertyChanged
	{
		public string name { get; set; }
		public string code { get; set; }
		public string city { get; set; }
		public string type { get; set; }
		public string lat { get; set; }
		public string lon { get; set; }
		public string location { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public AirportModel () 
		{
			name = "";
			code = "";
			city = "";
			type = "";
			lat = "";
			lon = "";
			location = "";
		}

		protected virtual void OnPropertyChanged(string name)
		{
			var ev = PropertyChanged;
			if (ev != null)
			{
				ev(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skype_Customizer
{
	public class Song
	{
		public string Author;
		public string Title;

		public string ToString(string format)
		{
			return format.Replace("{author}", Author).Replace("{title}", Title);
		}

		public override string ToString()
		{
			if (Author != null && Title != null) { 
				return Author + ": " + Title;
			}
			return String.Empty;
		}
	}
}

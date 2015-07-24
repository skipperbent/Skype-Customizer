using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkypeCustomizer.Skype
{
	public class Current
	{

		private SKYPE4COMLib.Skype SkypeInstance;

		public Current()
		{
			SkypeInstance = new SKYPE4COMLib.Skype();
		}

		public string GetUsername()
		{
			if (SkypeInstance.CurrentUser != null)
			{
				return SkypeInstance.CurrentUser.DisplayName;
			}
			return null;
		}

	}
}

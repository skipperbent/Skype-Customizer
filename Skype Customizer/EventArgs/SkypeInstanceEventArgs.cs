using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKYPE4COMLib;

namespace SkypeCustomizer.EventArgs
{
	public class SkypeInstanceEventArgs : System.EventArgs
	{
		public bool? Online;
		public Skype SkypeInstance;
	}
}

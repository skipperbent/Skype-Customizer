using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SkypeCustomizer.EventArgs;
using SKYPE4COMLib;

namespace SkypeCustomizer
{
	public delegate void InstanceFoundEventHandler(object sender, SkypeInstanceEventArgs e);
	public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);

	public class SkypeInstance
	{
		public Skype Skype;
		public bool Online;
		public event InstanceFoundEventHandler InstanceFound;
		public event ErrorEventHandler Error;

		protected virtual void OnInstanceFound(SkypeInstanceEventArgs e)
		{
			if (InstanceFound != null) {
				InstanceFound(this, e);
			}
		}

		protected virtual void OnError(ErrorEventArgs e)
		{
			if (Error != null)
			{
				Error(this, e);
			}
		}

		public void FindInstance()
		{
			// Lets avoid the UI freezing
			var thread = new Thread(new ThreadStart(delegate
			{
				// If skype is startet but the user hasn't excepted the integration
				try
				{
					Skype = new Skype();
					Online = (Skype.Client.IsRunning && Skype.CurrentUserHandle != null);
				}
				catch (Exception)
				{
					OnError(new ErrorEventArgs(new Exception("Please accept our application to communicate with Skype and click OK.")));
					return;
				}

				if (!Online)
				{
					OnError(new ErrorEventArgs(new Exception("Failed communicate with Skype.\nIs Skype open and are you sure you are signed in?\n\nClick OK to try again or Cancel to quit.")));
					return;
				}

				OnInstanceFound(new SkypeInstanceEventArgs()
				{
					Online = Online,
					SkypeInstance = Skype
				});
			}));

			thread.Priority = ThreadPriority.Lowest;
			thread.Start();
		}
	}
}

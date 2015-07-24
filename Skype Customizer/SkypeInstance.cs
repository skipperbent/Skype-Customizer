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
		protected Skype Skype;
		protected bool? Online;
		protected Form Caller;
		public event InstanceFoundEventHandler InstanceFound;
		public event ErrorEventHandler Error;

		public SkypeInstance(Form caller = null)
		{
			Caller = caller;
			Online = null;
			FindInstance();
		}

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
				var running = false;
				foreach (var process in Process.GetProcesses())
				{
					try
					{
						if (process.Modules.Count > 0 && process.Modules[0].FileName.ToLower().Contains("skype.exe"))
						{
							running = true;
							break;
						}
					}
					catch (Exception)
					{
						// Ignore any errors as some process modules we might not have access to...
					}
				}


				// If skype is startet but the user hasn't excepted the integration
				try
				{
					if (Online == null && running)
					{
						Skype = new Skype();
						Online = (Skype.Client.IsRunning && Skype.CurrentUserHandle != null);
					}
				}
				catch (Exception)
				{
					OnError(new ErrorEventArgs(new Exception("Please accept our application to communicate with Skype and click OK.")));
					return;
				}

				if (!running || Online == null || Online == false)
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

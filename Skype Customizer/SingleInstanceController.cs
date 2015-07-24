using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using Skype_Customizer;

namespace SkypeCustomizer
{
	public class SingleInstanceController : WindowsFormsApplicationBase
	{
		public SingleInstanceController()
		{
			IsSingleInstance = true;

			StartupNextInstance += this_StartupNextInstance;
		}

		void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
		{
			Main form = MainForm as Main;
			if (form != null)
			{
				form.Show();
				form.Focus();
				form.Activate();
			}
		}

		protected override void OnCreateMainForm()
		{
			MainForm = new Main();
		}
	}
}

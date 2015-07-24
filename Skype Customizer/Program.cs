using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SkypeCustomizer;

namespace Skype_Customizer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			string[] args = Environment.GetCommandLineArgs();
			try
			{
				SingleInstanceController controller = new SingleInstanceController();
				controller.Run(args);
			}
			catch (Exception)
			{
				Application.Run(new Main());
			}
		}
	}
}

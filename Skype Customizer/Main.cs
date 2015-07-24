using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SkypeCustomizer.Skype;
using SKYPE4COMLib;

namespace Skype_Customizer
{
	
	public partial class Main : Form
	{
		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		protected Config Config;

		private readonly Skype SkypeInstance;

		protected bool Online { get;set; }
		
		public Main()
		{
			InitializeComponent();
			SkypeInstance = new Skype();

			var config = SkypeCustomizer.Config.Instance();

			if (config.OriginalFullName == null)
			{
				config.OriginalFullName = SkypeInstance.CurrentUserProfile.FullName;
			}

			Closing += delegate
			{
				// Reset name
				if (SkypeInstance.Client.IsRunning)
				{
					SkypeInstance.CurrentUserProfile.FullName = config.OriginalFullName;
				}
				config.Save();
			};

			Resize += delegate(object sender, EventArgs args)
			{
				if (this.WindowState == FormWindowState.Minimized)
				{
					this.Hide();
				}
			};

			notifyIcon1.MouseClick += delegate(object sender, MouseEventArgs args)
			{
				if (args.Button == MouseButtons.Left)
				{
					this.Show();
					this.Focus();
				}
			};

			aboutText.Text = "Version: " + System.Windows.Forms.Application.ProductVersion + System.Environment.NewLine + Environment.NewLine + aboutText.Text;
		}

		protected void CheckOnline()
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
					
				}
			}

			if(running) {
				Online = (SkypeInstance.Client.IsRunning && SkypeInstance.CurrentUserHandle != null);
			}

			if (!running || !Online)
			{
				if (
					MessageBox.Show(
						"Failed communicate with Skype.\nIs Skype open and are you sure you are signed in?\n\nClick OK to try again or Cancel to quit.", "Error", MessageBoxButtons.OKCancel) ==
					DialogResult.Cancel)
				{
					Environment.Exit(0);
				}
				CheckOnline();
			}
		}

		protected Song GetSongInfo()
		{
			var song = new Song();
			var processes = Process.GetProcesses();
			var handle = IntPtr.Zero;
			string processTitle = null;
			foreach (var process in processes)
			{
				if (process.ProcessName.ToLower().Contains("spotify") && process.MainWindowHandle != IntPtr.Zero)
				{
					handle = process.MainWindowHandle;
					break;
				}
			}

			if (handle != IntPtr.Zero)
			{
				const int nChars = 256;
				var sb = new StringBuilder(nChars);

				if (GetWindowText(handle, sb, nChars) > 0)
				{
					processTitle = sb.ToString();
				}


				if (processTitle != null && processTitle.Contains("-") && !processTitle.ToLower().Contains("spotify"))
				{
					var info = processTitle.Split('-');
					song.Author = info[0].Trim();
					song.Title = info[1].Trim();
					return song;
				}
			}

			return song;
		}

		private void refresh_Tick(object sender, EventArgs e)
		{
			var song = GetSongInfo();

			statusExampleLbl.Text = song.ToString(SkypeCustomizer.Config.Instance().StatusFormat);

			var status = SkypeCustomizer.Config.Instance().OriginalFullName;

			if (SkypeCustomizer.Config.Instance().ShowSpotifyMusic && song.Title != null && song.Author != null)
			{
				status = SkypeCustomizer.Config.Instance()
					.StatusFormat.Replace("{status}", SkypeCustomizer.Config.Instance().OriginalFullName);
			}

			SkypeInstance.CurrentUserProfile.FullName = song.ToString(status);
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			CheckOnline();

			// Save Skype configuration
			Config.DisableAds = disableAds.Checked;
			Config.Save();

			// Reset username if spotify option is disabled
			if (!showSpotify.Checked)
			{
				SkypeInstance.CurrentUserProfile.FullName = SkypeCustomizer.Config.Instance().OriginalFullName;
			}

			// Save app configuration
			SkypeCustomizer.Config.Instance().ShowSpotifyMusic = showSpotify.Checked;
			SkypeCustomizer.Config.Instance().StatusFormat = statusFormat.Text;
			SkypeCustomizer.Config.Instance().Save();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			CheckOnline();

			Config = new Config(SkypeInstance.CurrentUserHandle);
			disableAds.Checked = !Config.DisableAds;

			showSpotify.Checked = SkypeCustomizer.Config.Instance().ShowSpotifyMusic;
			statusFormat.Text = SkypeCustomizer.Config.Instance().StatusFormat;

			refresh.Start();
		}

		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

	}
}

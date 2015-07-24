using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SkypeCustomizer;
using SkypeCustomizer.EventArgs;
using SKYPE4COMLib;

namespace Skype_Customizer
{
	
	public partial class Main : Form
	{
		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		protected SkypeConfig SkypeConfig;
		protected Config Config;
		private SkypeInstance _skypeInstance;
		
		public Main()
		{
			InitializeComponent();

			HideConnecting();

			_skypeInstance = new SkypeInstance();
			_skypeInstance.Error += SkypeOnError;
			_skypeInstance.InstanceFound += SetForm;

			Config = Config.Instance();

			Closing += delegate
			{
				try
				{
					_skypeInstance.Skype.CurrentUserProfile.FullName = Config.OriginalFullName;
				}
				catch (Exception)
				{
					// Ignore any errors here
				}
				Config.Save();
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

		protected Song GetSongInfo()
		{
			var song = new Song();
			//var processes = Process.GetProcesses();
			var handle = IntPtr.Zero;
			string processTitle = null;

			var processes = Process.GetProcessesByName("spotify");
			foreach (var process in processes)
			{
				if (process.MainWindowHandle != IntPtr.Zero)
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
			try
			{
				SetForm(this, new SkypeInstanceEventArgs()
				{
					Online = _skypeInstance.Online,
					SkypeInstance = _skypeInstance.Skype
				});
			}
			catch (Exception)
			{
				refresh.Stop();
				_skypeInstance.FindInstance();
			}
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			var skype = new SkypeInstance();
			skype.Error += SkypeOnError;
			skype.InstanceFound += SaveSettings;
			skype.FindInstance();
		}

		protected void SaveSettings(object sender, SkypeInstanceEventArgs args)
		{
			HideConnecting();
			// Save Skype configuration
			SkypeConfig.DisableAds = disableAds.Checked;
			SkypeConfig.Save();

			// Reset username if spotify option is disabled
			if (!showSpotify.Checked)
			{
				args.SkypeInstance.CurrentUserProfile.FullName = Config.OriginalFullName;
			}

			// Save app configuration
			Config.ShowSpotifyMusic = showSpotify.Checked;
			Config.StatusFormat = statusFormat.Text;
			Config.Save();
		}

		protected void ShowConnecting()
		{
			if (InvokeRequired)
			{
				Invoke(new Action(ShowConnecting));
				return;
			}
			loadingPanel.BringToFront();
			loadingPanel.Visible = true;
		}

		protected void HideConnecting()
		{
			if (InvokeRequired)
			{
				Invoke(new Action(HideConnecting));
				return;
			}

			loadingPanel.Visible = false;
		}

		protected void SetForm(object sender, SkypeInstanceEventArgs args)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<object, SkypeInstanceEventArgs>(SetForm), new object[] { sender, args });
				return;
			}

			if (Config.OriginalFullName == null)
			{
				Config.OriginalFullName = args.SkypeInstance.CurrentUserProfile.FullName;
			}

			if (SkypeConfig == null)
			{
				SkypeConfig = new SkypeConfig(args.SkypeInstance.CurrentUserHandle);
			}

			disableAds.Checked = !SkypeConfig.DisableAds;
			showSpotify.Checked = Config.ShowSpotifyMusic;
			statusFormat.Text = Config.StatusFormat;

			var song = GetSongInfo();

			statusExampleLbl.Text = song.ToString(Config.StatusFormat);

			var status = Config.OriginalFullName;

			if (Config.ShowSpotifyMusic && song.Title != null && song.Author != null)
			{
				status = Config.StatusFormat.Replace("{status}", Config.OriginalFullName);
			}

			if (args.SkypeInstance.CurrentUserProfile.FullName != song.ToString(status))
			{
				args.SkypeInstance.CurrentUserProfile.FullName = song.ToString(status);
			}

			if (!refresh.Enabled)
			{
				refresh.Start();
			}

			HideConnecting();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			ShowConnecting();
			refresh.Start();
		}

		private void SkypeOnError(object sender, ErrorEventArgs errorEventArgs)
		{
			if (refresh != null && refresh.Enabled)
			{
				refresh.Stop();
			}

			if (InvokeRequired)
			{
				Invoke(new Action<object, ErrorEventArgs>(SkypeOnError), new object[] {sender, errorEventArgs});
				return;
			}

			if (
				MessageBox.Show(this, errorEventArgs.GetException().Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) ==
				DialogResult.Cancel)
			{
				Environment.Exit(0);
			}

			// Try again
			_skypeInstance.FindInstance();
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

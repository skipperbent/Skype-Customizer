using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SkypeCustomizer
{
	public class Config
	{
		protected string RegistryKey = "HKEY_CURRENT_USER\\SOFTWARE\\" + Application.ProductName;

		public string OriginalFullName { get; set; }
		public bool ShowSpotifyMusic { get; set; }

		private string _statusFormat;

		public string StatusFormat
		{
			get
			{
				if (string.IsNullOrEmpty(_statusFormat))
				{
					return "{status} - {author}: {title}";
				}
				return _statusFormat;
			}
			set { _statusFormat = value; }
		}

		private static Config _instance;

		public Config()
		{
			// Load config
			Load();
		}

		public void Load()
		{
			var originalFullName = Registry.GetValue(RegistryKey, "OriginalFullname", null);
			if (originalFullName != null)
			{
				OriginalFullName = originalFullName.ToString();
			}

			var statusFormat = Registry.GetValue(RegistryKey, "StatusFormat", null);
			if (statusFormat != null)
			{
				StatusFormat = statusFormat.ToString();
			}

			var showSpotifyMusicValue = Registry.GetValue(RegistryKey, "ShowSpotifyMusic", false);
			if (showSpotifyMusicValue != null)
			{
				bool showSpotifyMusic;
				bool.TryParse(showSpotifyMusicValue.ToString(), out showSpotifyMusic);
				ShowSpotifyMusic = showSpotifyMusic;
			}
		}

		public void Save()
		{
			if (OriginalFullName != null)
			{
				Registry.SetValue(RegistryKey, "OriginalFullname", OriginalFullName);
			}

			Registry.SetValue(RegistryKey, "ShowSpotifyMusic", ShowSpotifyMusic);

			if (StatusFormat != null)
			{
				Registry.SetValue(RegistryKey, "StatusFormat", StatusFormat);
			}
		}

		public static Config Instance()
		{
			if (_instance == null)
			{
				_instance = new Config();
			}
			return _instance;
		}

	}
}

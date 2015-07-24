using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SkypeCustomizer
{
	public class SkypeConfig
	{
		public bool DisableAds { get; set; }
		public string ConfigFile { get; set; }
		protected string ConfigText { get; set; }

		public SkypeConfig(string username)
		{
			var config = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + String.Format(@"\Skype\{0}\config.xml", username);
			if (!File.Exists(config))
			{
				throw new Exception("Skype config does not exist!");
			}
			ConfigFile = config;
			ConfigText = File.ReadAllText(config);
			Read();
		}

		protected object GetValue(string key)
		{
			var r = new Regex("<"+key+">(.*?)<\\/"+key+">");
			var result = r.Match(ConfigText);
			if (result.Success && result.Groups.Count > 0)
			{
				return result.Groups[1].Value;
			}
			return null;
		}

		protected void SetValue(string key, string value)
		{
			ConfigText = Regex.Replace(ConfigText, "(<" + key + ">)(.*?)(<\\/" + key + ">)", m => m.Groups[1].Value + value + m.Groups[3].Value, RegexOptions.IgnorePatternWhitespace);
		}

		public void Read()
		{
			var ads = GetValue("AdvertPlaceholder");
			if (ads != null)
			{
				ads = (ads.ToString() == "1") ? "true" : "false";
				DisableAds = Boolean.Parse(ads.ToString());
			}
		}

		public void Save()
		{
			try
			{
				string[] sitesToBlock = {"apps.skype.com", "g.msn.com"};

				var hostFile = Environment.SystemDirectory + @"\drivers\etc\hosts";

				List<string> hosts = File.ReadAllLines(hostFile).ToList();

				foreach (var site in sitesToBlock)
				{
					var host = (from t in hosts where t.ToLower().Contains(site.ToLower()) select t).FirstOrDefault();
					if (host != null) { 
						hosts.Remove(host);
					}
				}

				// Add blocked sites if they exists
				if (DisableAds)
				{
					hosts.AddRange(sitesToBlock.Select(site => "127.0.0.1	" + site + "	# Disable Skype ads"));
				}

				File.WriteAllLines(hostFile, hosts.Where(s => !String.IsNullOrEmpty(s)).ToArray());

				var ads = (DisableAds) ? "0" : "1";
				SetValue("AdvertPlaceholder", ads);

				var attributes = File.GetAttributes(ConfigFile);
				var newAttributes = attributes & ~FileAttributes.ReadOnly;

				File.SetAttributes(ConfigFile, newAttributes);

				File.WriteAllText(ConfigFile, ConfigText);
				File.SetAttributes(ConfigFile, FileAttributes.ReadOnly);
			}
			catch (Exception e)
			{
				MessageBox.Show("There was a problem saving some of the settings. Please try again.");
			}
		}
		
	}
}

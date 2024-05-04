using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using System.Diagnostics;

namespace Front.Pages
{
    public class IndexModel : PageModel
    {
		public const string xcheminreg = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications";

		private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }


		public List<ApplicationInfo> lecturereg() //renvoi une liste des applications, chaque applications contient 0-IconPath, 1-Name, 2-Path, 3-KeyName
		{
			List<ApplicationInfo> xlisteapplications = new List<ApplicationInfo>();
			RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(xcheminreg);
			RegistryKey xapplicationcle;
			string[] xcles = xsubcle.GetSubKeyNames();
			foreach (string keyname in xcles)
			{
				xapplicationcle = Registry.LocalMachine.OpenSubKey(xcheminreg + "\\" + keyname);
				ApplicationInfo xapplication = new ApplicationInfo(xapplicationcle.GetValue("IconPath").ToString(), xapplicationcle.GetValue("Name").ToString(), xapplicationcle.GetValue("Path").ToString());
				xlisteapplications.Add(xapplication);
			}

			return xlisteapplications;
		}
	}

	public struct ApplicationInfo
	{
		public string iconPath;
		public string name;
		public string path;

		public ApplicationInfo(string iconPath, string name, string path)
		{
			this.iconPath = iconPath;
			this.name = name;
			this.path = path;
		}
	}
}

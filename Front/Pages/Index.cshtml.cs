using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Text;

namespace Front.Pages
{
    public class IndexModel : PageModel
    {
		public const string xcheminreg = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications";
        public List<ApplicationInfo> applications;
 
		private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public IActionResult OnGet(string download)
        {
            applications = lecturereg();
            if (download?.Length > 0)
            {
                return DownloadRdpData(download);
            }

            return Page();
        }


		public List<ApplicationInfo> lecturereg() //renvoi une liste des applications, chaque applications contient 0-IconPath, 1-Name, 2-Path, 3-KeyName
		{
            applications = new List<ApplicationInfo>();
			RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(xcheminreg);
			RegistryKey xapplicationcle;
			string[] xcles = xsubcle.GetSubKeyNames();

            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] adresses = ipEntry.AddressList;
            

            string ip = adresses.FirstOrDefault(addr => addr.ToString().Split(".")[0] == "192").ToString();

			foreach (string keyname in xcles)
			{
				xapplicationcle = Registry.LocalMachine.OpenSubKey(xcheminreg + "\\" + keyname);
				ApplicationInfo xapplication = new ApplicationInfo(xapplicationcle.GetValue("IconPath").ToString(), xapplicationcle.GetValue("Name").ToString(), xapplicationcle.GetValue("Path").ToString(), ip);
                applications.Add(xapplication);
			}

            return applications;
		}


        public FileContentResult DownloadRdpData(string serviceName)
        {
            serviceName = WebUtility.HtmlDecode(serviceName);
            ApplicationInfo applicationInfo = applications.FirstOrDefault(appInfo => appInfo.name == serviceName);


            return File(Encoding.ASCII.GetBytes(applicationInfo.GenerateRdpData()), "text/plain", applicationInfo.name + ".rdp");
        }
    }

	public struct ApplicationInfo
	{
		public string iconPath;
		public string name;
		public string path;
		public string image64;
        public string ip;

		public ApplicationInfo(string iconPath, string name, string path, string ip)
		{
			this.iconPath = iconPath;
			this.name = name;
			this.path = path;
            this.ip = ip;

            Bitmap bitmap = Icon.ExtractAssociatedIcon(iconPath).ToBitmap();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Enregistrer l'image bitmap au format PNG dans le MemoryStream
                bitmap.Save(memoryStream, ImageFormat.Png);

                // Obtenir le tableau d'octets de l'image binaire
                byte[] imageBytes = memoryStream.ToArray();

                // Afficher l'image binaire dans le div
                image64 = Convert.ToBase64String(imageBytes);
            }
        }
        
        public string GenerateRdpData()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("alternate shell:s:rdpinit.exe");
            stringBuilder.AppendLine($"full address:s:{ip}");
            stringBuilder.AppendLine("remoteapplicationmode:i:1");
            stringBuilder.AppendLine($"remoteapplicationname:s:{this.name}");
            stringBuilder.AppendLine($"remoteapplicationprogram:s:||{this.name}");
            stringBuilder.AppendLine("disableremoteappcapscheck:i:1");
            stringBuilder.AppendLine("drivestoredirect:s:*");
            stringBuilder.AppendLine("prompt for credentials:i:1");
            stringBuilder.AppendLine("promptcredentialonce:i:0");
            stringBuilder.AppendLine("redirectcomports:i:1");
            stringBuilder.AppendLine("span monitors:i:1");
            stringBuilder.AppendLine("use multimon:i:1");
	
            return stringBuilder.ToString();
        }
    }
}

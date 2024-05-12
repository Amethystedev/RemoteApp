using Microsoft.Win32;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace RemoteApp
{


    public partial class Main : Form
    {
        public static string xcheminreg = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications";
        public Main()
        {
            InitializeComponent();
            lbl_ip.Text = iplocale();
            creerkey();
            rdponoff();
        }

        private void refreshdgv()
        {
            DGV_Applications.Rows.Clear();
            List<string[]> xapplications = lecturereg();
            foreach (string[] xapplication in xapplications)
            {
                DGV_Applications.Rows.Add(xapplication[1], xapplication[2], xapplication[3]);
            }
        }

        private List<string[]> lecturereg() //renvoi une liste des applications, chaque applications contient 0-IconPath, 1-Name, 2-Path, 3-KeyName
        {
            string[] xapplications;
            List<string[]> xlisteapplications = new List<string[]>();
            RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(xcheminreg);
            RegistryKey xapplicationcle;
            string[] xcles = xsubcle.GetSubKeyNames();
            foreach (string keyname in xcles)
            {
                xapplicationcle = Registry.LocalMachine.OpenSubKey(xcheminreg + "\\" + keyname);
                xapplications = new string[4] { xapplicationcle.GetValue("IconPath").ToString(), xapplicationcle.GetValue("Name").ToString(), xapplicationcle.GetValue("Path").ToString(), keyname.ToString() };
                xlisteapplications.Add(xapplications);
            }
            return xlisteapplications;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit("Add", "", "");
            edit.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string xapplication = string.Empty;
            string xcheminapplication = string.Empty;
            string xcle = string.Empty;
            foreach (DataGridViewRow row in DGV_Applications.Rows)
            {
                if (row.Selected || row.Cells[0].Selected)
                {
                    xapplication = row.Cells[0].Value.ToString();
                    xcheminapplication = row.Cells[1].Value.ToString();
                    xcle = row.Cells[2].Value.ToString();
                    break;
                }
            }
            Edit edit = new Edit(xapplication, xcheminapplication, xcle);
            edit.ShowDialog();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            string xcle = string.Empty;
            foreach (DataGridViewRow row in DGV_Applications.Rows)
            {
                if (row.Selected || row.Cells[0].Selected)
                {
                    xcle = row.Cells[2].Value.ToString();
                    break;
                }
            }
            if (xcle != string.Empty)
            {
                Registry.LocalMachine.DeleteSubKeyTree(xcheminreg + "\\" + xcle);
            }
            refreshdgv();
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            refreshdgv();
        }

        private void creerkey()
        {
            RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList");
            if (xsubcle == null)
            {
                Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList");
            }

            RegistryKey xsubcle2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications");
            if (xsubcle2 == null)
            {
                Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications");
            }
        }

        private string iplocale()
        {
            string xip = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i].ToString().Contains("192.168"))
                {
                    xip = addr[i].ToString();
                }
            }
            return xip;
        }

        private void rdponoff()
        {
            if (readrdp())
            {
                btn_add.Enabled = true;
                btn_edit.Enabled = true;
                btn_remove.Enabled = true;
                refreshdgv();
                pb_rdp.BackgroundImage = Properties.Resources.on;
            }
            else
            {
                btn_add.Enabled = false;
                btn_edit.Enabled = false;
                btn_remove.Enabled = false;
                DGV_Applications.Rows.Clear();
                pb_rdp.BackgroundImage = Properties.Resources.off;
            }
        }

        private void pb_rdp_Click(object sender, EventArgs e)
        {
            RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server",true);
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "netsh";
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            if (readrdp())
            {
                xsubcle.SetValue("fDenyTSConnections", 1);
                psi.Arguments="advfirewall firewall set rule group = \"remote desktop\" new enable= no";
            }
            else
            {
                xsubcle.SetValue("fDenyTSConnections", 0);
                psi.Arguments = "advfirewall firewall set rule group = \"remote desktop\" new enable= yes";
            }
            Process proc = Process.Start(psi);
            proc.WaitForExit();
            rdponoff();
        }

        private bool readrdp()
        {
            RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server");
            string xtype = xsubcle.GetValue("fDenyTSConnections").ToString();
            if (xtype == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

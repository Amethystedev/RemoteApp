using Microsoft.Win32;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using Cassia;
using System.DirectoryServices;
using System.Collections;
using System.Globalization;

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

        private void refreshdgv()   //rafraichir la table qui donne les applications
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

        private void Main_Activated(object sender, EventArgs e) //on rafraichit la table à chaque fois que l'on reviens sur l'ecran main
        {
            refreshdgv();
        }

        private void creerkey() //créer les clés de registre de base en cas de nouvelle installation
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

        private string iplocale() //renvoie l'ip locale de la machine
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

        private void rdponoff() //procedure qui mets la lumiere en jaune ou blanc puis bloque tout si rdp non activé sur le poste
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

        private void pb_rdp_Click(object sender, EventArgs e) //active ou desactive rdp sur le poste si on cliques sur la lumiere
        {
            RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server", true);
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "netsh";
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            if (readrdp())
            {
                xsubcle.SetValue("fDenyTSConnections", 1);
                psi.Arguments = "advfirewall firewall set rule group = \"remote desktop\" new enable= no";
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

        private bool readrdp() //lecture de la base de registre pour savoir si rdp activé ou non
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

        private string ListRDPUser() //renvoie la liste des utilisateurs possibles du rdp (attention, renvoie uniquement si rdp activé)
        {
            string xrdpuser  = "List of RDP Users"+"\n";
            if (readrdp())
            {
                //l'utilisateur en cours
                ITerminalServicesManager manager = new TerminalServicesManager();
                using (ITerminalServer server = manager.GetRemoteServer(Environment.MachineName))
                {
                    server.Open();
                    foreach (ITerminalServicesSession session in server.GetSessions())
                    {
                        NTAccount account = session.UserAccount;
                        if (account != null)
                        {
                            int xtotal = account.ToString().Length;
                            int xstartindex = Environment.MachineName.Length + 1;
                            int xlength = xtotal - xstartindex;
                            //decoupage car ça ecris "machine/nom user" pour ne garder que le nom user
                            xrdpuser += account.ToString().Substring(xstartindex,xlength) + "\n";
                        }
                    }
                }
                //on ajoute aussi ceux du groupe desktop user
                DirectoryEntry machine = new DirectoryEntry("WinNT://" + Environment.MachineName);
                DirectoryEntry group = machine.Children.Find(nomgrouperdp_fonction_langue(), "group");
                if (group != null)
                {
                    foreach (object member in (IEnumerable)group.Invoke("Members"))
                    {
                        DirectoryEntry memberEntry = new DirectoryEntry(member);
                        xrdpuser += memberEntry.Name + "\n";           
                    }
                }
            }
            else
            {
                xrdpuser += "Can't retrieve RDP users, RDP not open" + "\n";
            }
            return xrdpuser;
        }

        private void pb_rdp_MouseHover(object sender, EventArgs e) //donne la liste des users du rdp si survol de la lumiere
        {
            Control senderObject = sender as Control;
            ToolTip info = new ToolTip
            {
                AutomaticDelay = 500
            };
            string tooltipMessage = ListRDPUser();
            info.SetToolTip(senderObject, tooltipMessage);
        }

        private string nomgrouperdp_fonction_langue()
        {
            string xnomgroupe = string.Empty;
            CultureInfo ci = CultureInfo.InstalledUICulture;
            switch (ci.Name)
            {
                case "en-US": xnomgroupe = "Remote Desktop Users";
                    break;
                case "fr-FR": xnomgroupe = "Utilisateurs du Bureau à distance";
                    break;
            }
            return xnomgroupe;
        }
    }
}

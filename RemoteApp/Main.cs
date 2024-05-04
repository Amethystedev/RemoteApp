using Microsoft.Win32;
using System.Reflection;

namespace RemoteApp
{


    public partial class Main : Form
    {
        public static string xcheminreg = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications";
        public Main()
        {
            InitializeComponent();
            refreshdgv();
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

        }

        private void Main_Activated(object sender, EventArgs e)
        {
            refreshdgv();
        }
    }
}

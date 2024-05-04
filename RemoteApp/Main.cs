using Microsoft.Win32;
using System.Reflection;

namespace RemoteApp
{


    public partial class Main : Form
    {
        public string xcheminreg = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Terminal Server\TSAppAllowList\Applications";
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
                DGV_Applications.Rows.Add(xapplication[1], xapplication[2]);
            }
        }

        private List<string[]> lecturereg()
        {
            string[] xapplications;
            List<string[]> xlisteapplications = new List<string[]>();
            RegistryKey xsubcle = Registry.LocalMachine.OpenSubKey(xcheminreg);
            RegistryKey xapplicationcle;
            string[] xcles = xsubcle.GetSubKeyNames();
            foreach (string keyname in xcles)
            {
                xapplicationcle = Registry.LocalMachine.OpenSubKey(xcheminreg + "\\" + keyname);
                xapplications = new string[3] { xapplicationcle.GetValue("IconPath").ToString(), xapplicationcle.GetValue("Name").ToString(), xapplicationcle.GetValue("Path").ToString() };
                xlisteapplications.Add(xapplications);
            }
            return xlisteapplications;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit("Add","");
            edit.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            string xapplication = string.Empty;
            string xcheminapplication = string.Empty;
            foreach (DataGridViewRow row in DGV_Applications.Rows)
            {
                if (row.Selected || row.Cells[0].Selected)
                {
                    xapplication = row.Cells[0].Value.ToString();
                    xcheminapplication = row.Cells[1].Value.ToString();
                    break;
                }
            }
            Edit edit = new Edit(xapplication, xcheminapplication);
            edit.ShowDialog();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

        }
    }

}

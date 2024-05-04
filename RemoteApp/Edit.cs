using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteApp
{
    public partial class Edit : Form
    {
        public string xtype;
        public string xcle;
        public string xcheminapp;
        public Edit(string type, string cheminapp, string cle)
        {
            InitializeComponent();
            xtype = type;
            xcle = cle;
            xcheminapp = cheminapp;
            if (xtype != "Add")
            {
                tb_app.Text = xtype;
                tb_cheminapp.Text = xcheminapp;
            }
        }

        private void btn_file_explore_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Fichiers exe (*.exe)|*.exe",
                Title = "Ouvrir Fichier Exe"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_cheminapp.Text = openFileDialog1.FileName;
                FileInfo xfileinfo = new FileInfo(tb_cheminapp.Text);
                tb_app.Text = FileVersionInfo.GetVersionInfo(tb_cheminapp.Text).FileDescription.ToString();
            }
        }

        private void btn_valid_Click(object sender, EventArgs e)
        {
            if (tb_app.Text !=string.Empty && tb_cheminapp.Text != string.Empty)
            {
                if (xtype == "Add")
                {
                    RegistryKey xregistre = Registry.LocalMachine.CreateSubKey(Main.xcheminreg+"\\"+tb_app.Text);
                    xregistre.SetValue("CommandLineSetting", 1);
                    xregistre.SetValue("IconIndex", 0);
                    xregistre.SetValue("IconPath", tb_cheminapp.Text);
                    xregistre.SetValue("Name", tb_app.Text);
                    xregistre.SetValue("Path", tb_cheminapp.Text);
                    xregistre.SetValue("RequiredCommandLine", "");
                    xregistre.SetValue("ShowInTSWA", 0);
                    xregistre.SetValue("VPath",tb_cheminapp.Text);
                    xregistre.Close();
                    this.Close();
                }
                else
                {
                    RegistryKey xregistre = Registry.LocalMachine.OpenSubKey(Main.xcheminreg + "\\" + xcle);
                    xregistre.SetValue("CommandLineSetting", 1);
                    xregistre.SetValue("IconIndex", 0);
                    xregistre.SetValue("IconPath", tb_cheminapp.Text);
                    xregistre.SetValue("Name", tb_app.Text);
                    xregistre.SetValue("Path", tb_cheminapp.Text);
                    xregistre.SetValue("RequiredCommandLine", "");
                    xregistre.SetValue("ShowInTSWA", 0);
                    xregistre.SetValue("VPath", tb_cheminapp.Text);
                    xregistre.Close();
                    this.Close();
                }
            }
        }
    }
}

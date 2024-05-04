using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteApp
{
    public partial class Edit : Form
    {
        public Edit(string type, string cheminapp)
        {
            InitializeComponent();
            if (type != "Add") 
            {
                tb_app.Text = type;
                tb_cheminapp.Text = cheminapp;
            }

        }
    }
}

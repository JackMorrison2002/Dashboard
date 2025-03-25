using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashb
{
    public partial class DashBoard : Form
    {
        public String Username;
        public DashBoard()
        {
            InitializeComponent();
        }

        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy  hh:mm:ss tt");
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelUsername.Text = Username;
        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

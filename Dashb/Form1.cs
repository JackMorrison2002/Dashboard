using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dashb
{
    public partial class FormLogin : Form
    {
        DataSet dsHotel = new DataSet();

        // Create a command builder
        SqlCommandBuilder cmdBUser;

        // Create a data row
        DataRow dUser;

        // Create a connection to the database
        SqlConnection connStr = new SqlConnection(@"Data Source = JACKS-PC; Initial Catalog = HotelBooking; Integrated Security = true");

        public FormLogin()
        {
            InitializeComponent();
        }
      


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String username, password;
   
            username = textBoxUsername.Text;
            password = textBoxPassword.Text;

            try
            {
                String Querry = "SELECT * FROM User_Table WHERE user_Name = '" + textBoxUsername.Text + "' And User_Password = '" + textBoxPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Querry, connStr);

                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    username = textBoxUsername.Text;
                    password = textBoxPassword.Text;

                    //// Page that need load next
                    DashBoard df = new DashBoard();
                    // Bringing username to dashboard
                    df.Username = textBoxUsername.Text;
                    textBoxPassword.Clear();
                    textBoxUsername.Clear();
                    df.Show();

                }
                else
                {
                    MessageBox.Show("Invalid Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Clear();
                    textBoxUsername.Clear();
                    textBoxPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connStr.Close();

            }
        }

    

        

private void pictureBoxClose_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxClose, "Close");
        }

       

        private void pictureBoxClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void pictureBoxHide_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxHide, "Hide Password");
        }

        private void pictureBoxShow_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxShow, "Show Password");
        }

        private void pictureBoxShow_Click_1(object sender, EventArgs e)
        {
            pictureBoxShow.Hide();
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click_1(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
        }
    }

}


    
    
    
    


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

namespace ICT_Project_SSW_Store
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblclear_Click(object sender, EventArgs e)
        {
            cmbUserType.SelectedIndex = -1;
            txtUsername.Clear();
            txtPassword.Clear();
            cmbUserType.Focus();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BBTAH6R5\SQLEXPRESS;Initial Catalog=SSWdbms;Integrated Security=True");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "" || cmbUserType.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from Usertbll where username='"+txtUsername.Text+"' and password='"+txtPassword.Text+ "'and usertype='" + cmbUserType.SelectedItem.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {


                        Main_Menu Hm = new Main_Menu();
                        Hm.Show();
                        this.Hide();
                        



                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or Password");
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       

        private void lblRegister_Click(object sender, EventArgs e)
        {
            StaffRegistration staff = new StaffRegistration();
            staff.Show();
            this.Hide();
        }
    }
}

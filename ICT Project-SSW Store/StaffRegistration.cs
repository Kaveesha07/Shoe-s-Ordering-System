using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ICT_Project_SSW_Store
{
    public partial class StaffRegistration : Form
    {
        public StaffRegistration()
        {
            
            InitializeComponent();
           
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BBTAH6R5\SQLEXPRESS;Initial Catalog=SSWdbms;Integrated Security=True");

        private void label9_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Cateogries cat = new Cateogries();
            cat.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Item_Mangement itm = new Item_Mangement();
            itm.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Order_Management ord = new Order_Management();
            ord.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Inquiry inq = new Inquiry();
            inq.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
           
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm log = new LoginForm();
            log.Show();
            this.Hide();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            
            try
                
            {
                string gender = Convert.ToString(cmbgender.SelectedValue);
                if (txtRef.Text == "" || txtFname.Text == "" || txtLname.Text == "" || cmbgender.Text=="" || txtAge.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" ) 
                {
                    MessageBox.Show("Missing Information");
                }
                else {
                    
                    con.Open();
                    string query = "insert into Stafftbl values('" + txtRef.Text + "','" + txtFname.Text + "','" + txtLname.Text + "','" + gender + "','" + txtAge.Text + "','" + txtPhone.Text + "','" + txtAddress.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff Registration forum submited Successfully");
                    con.Close();
                    staffIDincrement();
                }

            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        

       
            
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtRef.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtPhone.Clear();
            txtAge.Clear();
            cmbgender.SelectedIndex = -1;
            txtAddress.Clear();
            staffIDincrement();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "" || cmbCjobroles.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Missing Information");
                }
             else

                con.Open();
                string query = "insert into Usertbll values('" + txtUsername.Text + "','" + cmbCjobroles.SelectedItem.ToString() + "','" + txtPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Registration forum submited Successfully");
                con.Close();
            

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("User ID Already Exsists. Enter New User ID");
                    con.Close();

                }
                else
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "" || cmbCjobroles.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {

                    con.Open();
                    string query = "update Usertbll set usertype='" + cmbCjobroles.SelectedItem.ToString() + "',password='" + txtPassword.Text + "' where username='" + txtUsername.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User details Successfully updated");  
                    con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void StaffRegistration_Load(object sender, EventArgs e)
        {
            populate();
            staffIDincrement();


        }
        private void staffIDincrement()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(RefId)from Stafftbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtRef.Text = "Ref0" + i.ToString();
        }

        private void dgvstaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUsername.Text = dgvstaff.SelectedRows[0].Cells[0].Value.ToString();
                cmbCjobroles.SelectedItem = dgvstaff.SelectedRows[0].Cells[1].Value.ToString();
                txtPassword.Text = dgvstaff.SelectedRows[0].Cells[2].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
            con.Open();
            string query = "select * from Usertbll ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvstaff.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Select the user to Delete");
                }
                else
                {
                    con.Open();
                    String query = "delete from Usertbll where username ='" + txtUsername.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully");
                    con.Close();
                    populate();
                    clearcell();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clearcell()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbCjobroles.SelectedIndex = -1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
    
        
        {
            if (txtsearch.Text != "")
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataView dv = new DataView();
                string cmd = "select username,usertype from Usertbll where username like '%" + txtsearch.Text + "%';";
                da = new SqlDataAdapter(cmd, con);
                da.Fill(ds);
                dv = new DataView(ds.Tables[0]);
                dgvstaff.DataSource = dv;
                con.Close();
            }
            else if(txtsearch.Text == "")
            {
                dgvstaff.Refresh();
            }
        }

        private void lblsearch_Click(object sender, EventArgs e)
        {

        }
        private void userType()
        {
            
        }
    }
}

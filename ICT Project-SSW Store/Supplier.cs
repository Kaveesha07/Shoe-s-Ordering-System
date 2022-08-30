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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BBTAH6R5\SQLEXPRESS;Initial Catalog=SSWdbms;Integrated Security=True");

        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm log = new LoginForm();
            log.Show();
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
            StaffRegistration staff = new StaffRegistration();
            staff.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string query = "insert into Suppliertbl values('" + txtSupplierID.Text + "','" + txtSupplierName.Text + "','" + txtSupplierAddress.Text + "','" + txtSupplierEmail.Text + "','" + txtSupplierPhone.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supplier Details Added Successfully");
                con.Close();
                populate();
                clearcell();
                SupplierIDIncrement();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Supplier ID Already Exsists. Enter New Supplier ID");
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
        private void populate()
        {
            con.Open();
            string query = "select * from Suppliertbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvsup.DataSource = ds.Tables[0];
            con.Close();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierID.Text == "" || txtSupplierName.Text == "" || txtSupplierEmail.Text == "" || txtSupplierAddress.Text == "" || txtSupplierPhone.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {

                    con.Open();
                    string query = "update Suppliertbl set SupplierName='" + txtSupplierName.Text + "',SupplierAddress='" + txtSupplierAddress.Text + "',SupplierEmail='" + txtSupplierEmail.Text + "',SupplierPhone='" + txtSupplierPhone.Text + "' where SupplierID ='" + txtSupplierID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier Information Successfully updated");
                    con.Close();
                    populate();
                    clearcell();
                    SupplierIDIncrement();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierID.Text == "")
                {
                    MessageBox.Show("Select the Category to Delete");
                }
                else
                {
                    con.Open();
                    String query = "delete from Suppliertbl where SupplierID ='" + txtSupplierID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier Information Deleted Successfully");
                    con.Close();
                    populate();
                    clearcell();
                    SupplierIDIncrement();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            {
                if (txtSupplierSearch.Text != "")
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    DataView dv = new DataView();
                    string cmd = "select * from Suppliertbl where SupplierName like '%" + txtSupplierSearch.Text + "%';";
                    da = new SqlDataAdapter(cmd, con);
                    da.Fill(ds);
                    dv = new DataView(ds.Tables[0]);
                    dgvsup.DataSource = dv;
                    con.Close();
                    
                }
                else if (txtSupplierSearch.Text == "")
                {
                    dgvsup.Refresh();
                }
            }
        }

        private void dgvsup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtSupplierID.Text = dgvsup.SelectedRows[0].Cells[0].Value.ToString();
                txtSupplierName.Text = dgvsup.SelectedRows[0].Cells[1].Value.ToString();
                txtSupplierAddress.Text = dgvsup.SelectedRows[0].Cells[2].Value.ToString();
                txtSupplierEmail.Text = dgvsup.SelectedRows[0].Cells[3].Value.ToString();
                txtSupplierPhone.Text = dgvsup.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.Show();
            this.Hide();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            txtSupplierID.ReadOnly = true;
            // SupplierID Increment
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(SupplierID)from Suppliertbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtSupplierID.Text = "SUP0" + i.ToString();
        }
        private void SupplierIDIncrement()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(SupplierID)from Suppliertbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtSupplierID.Text = "SUP0" + i.ToString();
        }
        private void clearcell()
        {
            txtSupplierName.Clear();
            txtSupplierAddress.Clear();
            txtSupplierPhone.Clear();
            txtSupplierEmail.Clear();
            
        }
    }
}

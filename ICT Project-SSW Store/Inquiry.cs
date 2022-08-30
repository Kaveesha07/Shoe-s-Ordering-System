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
    public partial class Inquiry : Form
    {
        public Inquiry()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BBTAH6R5\SQLEXPRESS;Initial Catalog=SSWdbms;Integrated Security=True");

        private void Inquiry_Load(object sender, EventArgs e)
        {
            populate();
            txtInqID.ReadOnly = false;
            // CustomerID Increment
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(InqID)from Inqtbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtInqID.Text = "INQ0" + i.ToString();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

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

        private void label9_Click(object sender, EventArgs e)
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

        private void label18_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.Show();
            this.Hide();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if ( txtInqID.Text == "" || txtInqName.Text == "" || txtInqContact.Text == "" || cmbgender.SelectedItem.ToString() == "" || cmbInqtype.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Missing Information ");
            }
            else
            {
                
                try
                {
                    
                    con.Open();
                    string query = "insert into Inqtbl values('" + txtInqID.Text + "','" + dateTimePicker1.Value.Date + "','" + cmbInqtype.SelectedItem.ToString() + "','" + txtInqName.Text + "','" + txtInqContact.Text + "','" + txtInq.Text + "','" + cmbgender.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inquiry Added Successfully");
                    con.Close();
                    populate();
                    clearcell();
                    InquiryIdIncrement();

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Inquiry ID Already Exsists. Enter New Inquiry ID");
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
        }
        private void populate()
        {
            con.Open();
            string query = "select * from Inqtbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvInq.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dgvInq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dateTimePicker1.Text = dgvInq.SelectedRows[0].Cells[1].Value.ToString();
                txtInqID.Text = dgvInq.SelectedRows[0].Cells[0].Value.ToString();
                cmbInqtype.SelectedItem = dgvInq.SelectedRows[0].Cells[2].Value.ToString();
                txtInqName.Text = dgvInq.SelectedRows[0].Cells[3].Value.ToString();
                txtInqContact.Text = dgvInq.SelectedRows[0].Cells[4].Value.ToString();
                cmbgender.SelectedItem = dgvInq.SelectedRows[0].Cells[6].Value.ToString();
                txtInq.Text = dgvInq.SelectedRows[0].Cells[5].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSupplierSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (txtInquirySearch.Text != "")
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    DataView dv = new DataView();
                    string cmd = "select * from Inqtbl where InqType like '%" + txtInquirySearch.Text + "%';";
                    da = new SqlDataAdapter(cmd, con);
                    da.Fill(ds);
                    dv = new DataView(ds.Tables[0]);
                    dgvInq.DataSource = dv;
                    con.Close();

                }
                else if (txtInquirySearch.Text == "")
                {
                    dgvInq.Refresh();
                }
            }
        }

        private void txtInquirySearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInqID.Text == "" || txtInqName.Text == "" || txtInqContact.Text == "" || cmbgender.SelectedItem.ToString() == "" || cmbInqtype.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {

                    con.Open();
                    string query = "update Inqtbl set InqDate='" + dateTimePicker1.Value.Date + "',InqType='" + cmbInqtype.SelectedItem.ToString() + "',Name='" + txtInqName.Text + "',ContactNumber='" + txtInqContact.Text + "',Inquiry='" + txtInq.Text + "',Gender='" + cmbgender.SelectedItem.ToString() + "' where InqID ='" + txtInqID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inquiry Successfully updated");
                    con.Close();
                    populate();
                    clearcell();
                    InquiryIdIncrement();
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
                if (txtInqID.Text == "")
                {
                    MessageBox.Show("Select the Category to Delete");
                }
                else
                {
                    con.Open();
                    String query = "delete from Inqtbl where InqID ='" + txtInqID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inquiry Deleted Successfully");
                    con.Close();
                    populate();
                    clearcell();
                    InquiryIdIncrement();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Inquiry inq = new Inquiry();
            inq.Show();
            this.Hide();
        }

        private void txtInqID_TextChanged(object sender, EventArgs e)
        {

        }
        private void InquiryIdIncrement()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(InqID)from Inqtbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtInqID.Text = "INQ0" + i.ToString();
        }

        private void txtInq_TextChanged(object sender, EventArgs e)
        {

        }
        private void clearcell()
        {
            txtInqName.Clear();
            txtInqContact.Clear();
            cmbgender.SelectedIndex = -1; 
            cmbInqtype.SelectedIndex = -1;
            txtInq.Clear();
        }
    }
}

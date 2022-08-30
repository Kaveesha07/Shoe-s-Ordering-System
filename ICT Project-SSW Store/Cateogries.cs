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
    public partial class Cateogries : Form
    {
        public Cateogries()
        {
            InitializeComponent();
        }



        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BBTAH6R5\SQLEXPRESS;Initial Catalog=SSWdbms;Integrated Security=True");


        private void label13_Click(object sender, EventArgs e)
        {
            Order_Management ord = new Order_Management();
            ord.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Item_Mangement itm = new Item_Mangement();
            itm.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            StaffRegistration staff = new StaffRegistration();
            staff.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Inquiry inq = new Inquiry();
            inq.Show();
            this.Hide();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }


        private void btCatAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCatID.Text == "" || txtCatName.Text == "" || txtCatDes.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "insert into Cattbl values('" + txtCatID.Text + "','" + txtCatName.Text + "','" + txtCatDes.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("category Added Successfully");
                    con.Close();
                    populate();
                    clearcell();
                    catincrement();
                }

            }
            
            catch (SqlException ex)
            {
                if (ex.Number ==2627)
                {
                    MessageBox.Show("Category ID Already Exsists. Enter New Category ID");
                    con.Close();

                }
                else {
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
            string query = "select * from Cattbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvCat.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnCatClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatID.Text == "")
                {
                    MessageBox.Show("Select the Category to Delete");
                }
                else
                {
                    con.Open();
                    String query = "delete from Cattbl where CatID ='" + txtCatID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Successfully");
                    con.Close();
                    populate();
                    clearcell();
                    catincrement();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Cateogries_Load(object sender, EventArgs e)
        {
            grpSubCat.Hide();
            dgvSubCat.Hide();
            populate();
            populate2();
            txtSubsearch.Hide();
            lblsearch.Hide();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(CatID)from Cattbl",con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtCatID.Text = "Cat0"+ i.ToString();
            subcatincrement();



        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            populate();
            grpSubCat.Show();
            dgvSubCat.Show();
            txtSubsearch.Show();
            lblsearch.Show();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatID.Text == "" || txtCatName.Text == "" || txtCatDes.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {

                    con.Open();
                    string query = "update Cattbl set CatName='" + txtCatName.Text + "',CatDesc='" + txtCatDes.Text + "' where CatID='" + txtCatID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully updated");
                    con.Close();
                    populate();
                    clearcell();
                    catincrement();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Category ID Already Exsists. Enter New Category ID");

                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCatID.Text = dgvCat.SelectedRows[0].Cells[1].Value.ToString();
                txtCatName.Text = dgvCat.SelectedRows[0].Cells[2].Value.ToString();
                txtCatDes.Text = dgvCat.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubcatAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtSubCatId.Text == "" || txtSubCatName.Text == "" || txtSubCatDes.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "insert into SubCattbl values('" + txtSubCatId.Text + "','" + txtSubCatName.Text + "','" + txtSubCatDes.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sub category Added Successfully");
                    con.Close();
                    populate2();
                    clearcell2();
                    subcatincrement();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Sub Category ID Already Exsists. Enter New Sub Category ID");
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
        private void populate2()
        {
            con.Open();
            string query = "select * from SubCattbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvSubCat.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnSubCateClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubCatId.Text == "")
                {
                    MessageBox.Show("Select the Category to Delete");
                }
                else
                {
                    con.Open();
                    String query = "delete from SubCattbl where SubCatId ='" + txtSubCatId.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sub Category Deleted Successfully");
                    con.Close();
                    populate2();
                    clearcell2();
                    subcatincrement();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void clearcell2()
        {
            
            txtSubCatName.Clear();
            txtSubCatDes.Clear();
        }

        private void btnSubCatEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubCatId.Text == "" || txtSubCatName.Text == "" || txtSubCatDes.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {

                    con.Open();
                    string query = "update SubCattbl set SubCatName='" + txtSubCatName.Text + "',SubCatDes='" + txtSubCatDes.Text + "' where SubCatId='" + txtSubCatId.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sub Category Successfully updated");
                    con.Close();
                    populate2();
                    clearcell2();
                    subcatincrement();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void clearcell()
        {
            
            txtCatName.Clear();
            txtCatDes.Clear();
        }

        private void dgvSubCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtSubCatId.Text = dgvSubCat.SelectedRows[0].Cells[0].Value.ToString();
                txtSubCatName.Text = dgvSubCat.SelectedRows[0].Cells[1].Value.ToString();
                txtSubCatDes.Text = dgvSubCat.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCat_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCatID.Text = dgvCat.SelectedRows[0].Cells[0].Value.ToString();
                txtCatName.Text = dgvCat.SelectedRows[0].Cells[1].Value.ToString();
                txtCatDes.Text = dgvCat.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCatsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCatsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (txtCatsearch.Text != "")
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    DataView dv = new DataView();
                    string cmd = "select * from Cattbl where CatName like '%" + txtCatsearch.Text + "%';";
                    da = new SqlDataAdapter(cmd, con);
                    da.Fill(ds);
                    dv = new DataView(ds.Tables[0]);
                    dgvCat.DataSource = dv;
                    con.Close();
                }
                else if (txtCatsearch.Text == "")
                {
                    dgvCat.Refresh();
                }
            }
        }

        private void txtSubsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (txtSubsearch.Text != "")
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    DataView dv = new DataView();
                    string cmd = "select * from SubCattbl where SubCatName like '%" + txtSubsearch.Text + "%';";
                    da = new SqlDataAdapter(cmd, con);
                    da.Fill(ds);
                    dv = new DataView(ds.Tables[0]);
                    dgvSubCat.DataSource = dv;
                    con.Close();
                }
                else if (txtSubsearch.Text == "")
                {
                    dgvSubCat.Refresh();
                }
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Cateogries cat = new Cateogries();
            cat.Show();
            this.Hide();
        }
        private void catincrement(){
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(CatID)from Cattbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtCatID.Text = "Cat0" + i.ToString();
        }
        private void subcatincrement()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(SubCatId)from SubCattbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtSubCatId.Text = "SubCat0" + i.ToString();
        }
    }
}

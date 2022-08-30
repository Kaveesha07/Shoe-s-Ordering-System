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
    public partial class Item_Mangement : Form
    {
        public Item_Mangement()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BBTAH6R5\SQLEXPRESS;Initial Catalog=SSWdbms;Integrated Security=True");



        private void label20_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Cateogries cat = new Cateogries();
            cat.Show();
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

        private void label14_Click(object sender, EventArgs e)
        {
            Inquiry inq = new Inquiry();
            inq.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into Itemtbl values('" + txtItemId.Text + "','" + txtItemName.Text + "','" + txtItemDesc.Text + "','" + txtitemQ.Text + "','" + txtItemSize.Text + "','" + txtprice.Text + "','" + cmbCatId.SelectedValue.ToString() + "','" + cmbCatName.SelectedValue.ToString() + "','" + cmbSubCatId.SelectedValue.ToString() + "','" + cmbsubCat.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Added Successfully");
                con.Close();
                populate();
                
                clearcell();
                itemincrement();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Item ID Already Exsists. Enter New Item ID");
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
            string query = "select * from Itemtbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvItem.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            {
                if (txtitemsearch.Text != "")
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    DataView dv = new DataView();
                    string cmd = "select * from Itemtbl where ItemName like '%" + txtitemsearch.Text + "%';";
                    da = new SqlDataAdapter(cmd, con);
                    da.Fill(ds);
                    dv = new DataView(ds.Tables[0]);
                    dgvItem.DataSource = dv;
                    con.Close();
                    clearcell();
                }
                else if (txtitemsearch.Text == "")
                {
                    dgvItem.Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemId.Text == "" || txtItemName.Text == "" || txtItemDesc.Text == "" || txtItemSize.Text == "" || cmbCatName.Text == "" || cmbsubCat.Text == "" || cmbCatId.SelectedItem.ToString() == "" || cmbSubCatId.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {

                    con.Open();
                    string query = "update Itemtbl set ItemName='" + txtItemName.Text + "',ItemDesc='" + txtItemDesc.Text + "',ItemQuantity='" + txtitemQ.Text + "',ItemSize='" + txtItemSize.Text + "',ItemPrice='" + txtprice.Text + "',CatID='" + cmbCatId.SelectedValue.ToString() + "' ,CatName='" + cmbCatName.SelectedValue.ToString() + "',SubCatId='" + cmbSubCatId.SelectedValue.ToString() + "',SubCatName='" + cmbsubCat.SelectedValue.ToString() + "'where ItemId='" + txtItemId.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully updated");
                    con.Close();
                    populate();
                    clearcell();
                    itemincrement();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemId.Text == "")
                {
                    MessageBox.Show("Select the Category to Delete");
                }
                else
                {
                    con.Open();
                    String query = "delete from Itemtbl where ItemId ='" + txtItemId.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted Successfully");
                    con.Close();
                    populate();
                    clearcell();
                    itemincrement();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clearcell()
        {
            txtItemId.Clear();
            txtItemName.Clear();
            txtItemDesc.Clear();
            txtItemSize.Clear();
            txtitemQ.Clear();
            txtprice.Clear();
            cmbsubCat.SelectedIndex = -1; ;
            cmbCatName.SelectedIndex = -1; ;
            cmbSubCatId.SelectedIndex = -1;
            cmbCatId.SelectedIndex = -1;
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtItemId.Text = dgvItem.SelectedRows[0].Cells[0].Value.ToString();
                txtItemName.Text = dgvItem.SelectedRows[0].Cells[1].Value.ToString();
                txtItemDesc.Text = dgvItem.SelectedRows[0].Cells[2].Value.ToString();
                txtItemSize.Text = dgvItem.SelectedRows[0].Cells[3].Value.ToString();
                txtitemQ.Text = dgvItem.SelectedRows[0].Cells[4].Value.ToString();
                txtprice.Text = dgvItem.SelectedRows[0].Cells[5].Value.ToString();
                cmbCatId.SelectedItem = dgvItem.SelectedRows[0].Cells[4].Value.ToString();
                cmbCatName.SelectedItem = dgvItem.SelectedRows[0].Cells[5].Value.ToString();
                cmbSubCatId.SelectedItem = dgvItem.SelectedRows[0].Cells[6].Value.ToString();
                cmbsubCat.SelectedItem = dgvItem.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            Item_Mangement itm = new Item_Mangement();
            itm.Show();
            this.Hide();
        }
        private void fillcombo()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CatID from Cattbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatID", typeof(string));
            dt.Load(rdr);
            cmbCatId.ValueMember = "CatID";
            cmbCatId.DataSource = dt;
            con.Close();


        }
        private void fillcombo2()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select SubCatId from SubCattbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SubCatId", typeof(string));
            dt.Load(rdr);
            cmbCatId.ValueMember = "SubCatId";
            cmbCatId.DataSource = dt;
            con.Close();


        }

        private void Item_Mangement_Load(object sender, EventArgs e)
        {
            //Category Id import from Category Table
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CatID from Cattbl", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            cmbCatId.DataSource = ds.Tables[0];
            cmbCatId.DisplayMember = "CatID";
            cmbCatId.ValueMember = "CatID";

            //Category Name import from Category Table
            con.Open();
            SqlCommand cmds = new SqlCommand("Select CatName from Cattbl", con);
            SqlDataAdapter daa = new SqlDataAdapter(cmds);
            DataSet dss = new DataSet();
            daa.Fill(dss);
            cmds.ExecuteNonQuery();
            con.Close();
            cmbCatName.DataSource = dss.Tables[0];
            cmbCatName.DisplayMember = "CatName";
            cmbCatName.ValueMember = "CatName";

            //Sub Category id import from Sub Category Table
            con.Open();
            SqlCommand cmdss = new SqlCommand("Select SubCatId from SubCattbl", con);
            SqlDataAdapter daaa = new SqlDataAdapter(cmdss);
            DataSet dsss = new DataSet();
            daaa.Fill(dsss);
            cmdss.ExecuteNonQuery();
            con.Close();
            cmbSubCatId.DataSource = dsss.Tables[0];
            cmbSubCatId.DisplayMember = "SubCatId";
            cmbSubCatId.ValueMember = "SubCatId";

            //Sub Category name import from Sub Category Table
            con.Open();
            SqlCommand cmdsss = new SqlCommand("Select SubCatName from SubCattbl", con);
            SqlDataAdapter daaaa = new SqlDataAdapter(cmdsss);
            DataSet dssss = new DataSet();
            daaaa.Fill(dssss);
            cmdsss.ExecuteNonQuery();
            con.Close();
            cmbsubCat.DataSource = dssss.Tables[0];
            cmbsubCat.DisplayMember = "SubCatName";
            cmbsubCat.ValueMember = "SubCatName";

            txtItemId.ReadOnly = true;

            //itemID increment
            con.Open();
            SqlCommand cmda = new SqlCommand("Select Count(ItemId)from Itemtbl", con);
            int i = Convert.ToInt32(cmda.ExecuteScalar());
            con.Close();
            i++;
            txtItemId.Text = "ITM0" + i.ToString();
        }
        private void itemincrement()
        {
            con.Open();
            SqlCommand cmda = new SqlCommand("Select Count(ItemId)from Itemtbl", con);
            int i = Convert.ToInt32(cmda.ExecuteScalar());
            con.Close();
            i++;
            txtItemId.Text = "ITM0" + i.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
   

}

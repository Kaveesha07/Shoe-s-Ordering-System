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
    public partial class Order_Management : Form
    {
        public Order_Management()
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

        private void label12_Click(object sender, EventArgs e)
        {
            Item_Mangement itm = new Item_Mangement();
            itm.Show();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            {
                if (txtSearch.Text != "")
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    DataView dv = new DataView();
                    string cmd = "select ItemId,ItemName,ItemQuantity,ItemSize,ItemPrice from Itemtbl where ItemName like '%" + txtSearch.Text + "%';";
                    da = new SqlDataAdapter(cmd, con);
                    da.Fill(ds);
                    dv = new DataView(ds.Tables[0]);
                    dgvItem.DataSource = dv;
                    con.Close();
                    
                }
                else if (txtSearch.Text == "")
                {
                    dgvItem.Refresh();
                }
            }
        }
        private void populate()
        {
            con.Open();
            string query = "select ItemId,ItemName,ItemQuantity,ItemSize,ItemPrice from Itemtbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgvItem.DataSource = ds.Tables[0];
            con.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Order_Management_Load(object sender, EventArgs e)
        {
            populate();
            btnShow.Hide();
            txtItemId.ReadOnly = true;

            // CustomerID Increment
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(orderId)from Ordertbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtOrderId.Text = "ORDER0" + i.ToString();

        }

        private void dgvItem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtItemId.Text = dgvItem.SelectedRows[0].Cells[0].Value.ToString();
                txtItemName.Text = dgvItem.SelectedRows[0].Cells[1].Value.ToString();
                txtItemSize.Text = dgvItem.SelectedRows[0].Cells[3].Value.ToString();
                txtItemQ.Text = dgvItem.SelectedRows[0].Cells[2].Value.ToString();
                txtItemP.Text = dgvItem.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        int grdtotal=0;
        private void button6_Click(object sender, EventArgs e)
        {
            if (txtItemId.Text == "" || txtItemName.Text == "" || txtItemP.Text == "" || txtItemQ.Text == "" || txtItemSize.Text == "" )
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                int total = Convert.ToInt32(txtItemP.Text) * Convert.ToInt32(txtItemQ.Text);

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvorder);
                newRow.Cells[0].Value = txtItemId.Text;
                newRow.Cells[1].Value = txtItemName.Text;
                newRow.Cells[2].Value = txtItemSize.Text;
                newRow.Cells[3].Value = txtItemQ.Text;
                newRow.Cells[4].Value = txtItemP.Text;
                newRow.Cells[5].Value = Convert.ToInt32(txtItemP.Text) * Convert.ToInt32(txtItemQ.Text);
                dgvorder.Rows.Add(newRow);
                grdtotal = grdtotal + total;
                lblgrandtotal.Text = "Rs " + grdtotal;
                clearcell();
                

            }
        }
        int flag ;
        private void dgvorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            flag = 0;
            txtItemId.Text = dgvorder.SelectedRows[0].Cells[0].Value.ToString();
            txtItemName.Text = dgvorder.SelectedRows[0].Cells[1].Value.ToString();
            txtItemSize.Text = dgvorder.SelectedRows[0].Cells[3].Value.ToString();
            txtItemQ.Text = dgvorder.SelectedRows[0].Cells[2].Value.ToString();
            txtItemP.Text = dgvorder.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("SSW SHOES COMPANY PRIVATE LIMITED", new Font("Century Gothic", 25, FontStyle.Bold),Brushes.Red,new Point (100,20) );
            e.Graphics.DrawString("------------------------INVOICE--------------------------", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.DarkOrange, new Point(0,70));
            e.Graphics.DrawString("Date :" +dateOrder.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(50,140));
            e.Graphics.DrawString("Order ID :" + txtOrderId.Text , new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(50, 210));
            e.Graphics.DrawString("Customer Name :" + txtCusName.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(50, 280));
            e.Graphics.DrawString("Customer Phone :" + txtCusPhone.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(50, 350));
            e.Graphics.DrawString("Item ID" , new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(50, 420));
            e.Graphics.DrawString("Item Name", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(200, 420));
            e.Graphics.DrawString("Item Size", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(350, 420));
            e.Graphics.DrawString("Item Quantity", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(500, 420));
            e.Graphics.DrawString("Item Price", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(650, 420));
          
            int i = 0, l= 0;
            int a = 420 , b=50;
            i = dgvorder.Rows.Count ;
            l = dgvorder.Columns.Count ;
            
            i--;
            l--;
            lbltest.Text = l.ToString();


            try
            {


                for (int j = 0; j < i; j++)
                {

                    a = a + 50;
                    b = 50;
                    for (int m = 0; m < l; m++)
                    {
                        e.Graphics.DrawString(dgvorder.SelectedRows[j].Cells[m].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(b, a));
                        b = b + 150;
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            a = a + 70;
            e.Graphics.DrawString("Bill Total =  " +lblgrandtotal.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Black, new Point(50, a));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();
                
            }
            else
            {
                
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Order_Management ord = new Order_Management();
            ord.Show();
            this.Hide();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOrderId.Text == "" || txtCusName.Text == "" || txtCusPhone.Text == "" || dgvorder.Rows.Count <=1)
            {
                MessageBox.Show("Missing Information ");


            }
            else
            {

                
                DialogResult dialogResult = MessageBox.Show("Do you want to confirm Order?", "Important Messeage", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {


                        con.Open();
                        string query = "insert into Ordertbl values('" + txtOrderId.Text + "','" + dateOrder.Value + "','" + txtCusName.Text + "','" + txtCusPhone.Text + "','" + lblgrandtotal.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Order submited Successfully");
                        con.Close();
                        btnShow.Show();
                        clearcell();
                        txtCusName.Clear();
                        txtCusPhone.Clear();
                        con.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Order unsuccessfull");
                }
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowindex = dgvorder.CurrentCell.RowIndex;
            string total;
            total = dgvorder.SelectedRows[0].Cells[5].Value.ToString();
            grdtotal = grdtotal - Convert.ToInt32(total);
            lblgrandtotal.Text = grdtotal.ToString();
            dgvorder.Rows.RemoveAt(rowindex);
            clearcell();

        }
        private void customerIdIncrement()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(orderId)from Ordertbl", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            txtOrderId.Text = "ORDER0" + i.ToString();
        }

        private void clearcell()
        {
            
            txtItemId.Clear();
            txtItemName.Clear();
            txtItemP.Clear();
            txtItemQ.Clear();
            txtItemSize.Clear();
            
        }
    }
}

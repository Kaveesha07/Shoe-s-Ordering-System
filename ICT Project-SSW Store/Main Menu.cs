using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT_Project_SSW_Store
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
         
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Cateogries cat = new Cateogries();
            cat.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            StaffRegistration staff = new StaffRegistration();
            staff.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm log = new LoginForm();
            log.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Item_Mangement itm = new Item_Mangement();
            itm.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnstaffreg_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StaffRegistration staff = new StaffRegistration();
            staff.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Order_Management ord = new Order_Management();
            ord.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Cateogries cat = new Cateogries();
            cat.Show();
            this.Hide();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Inquiry inq = new Inquiry();
            inq.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Item_Mangement itm = new Item_Mangement();
            itm.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}

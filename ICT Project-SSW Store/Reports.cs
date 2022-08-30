using Microsoft.Reporting.WinForms;
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
    public partial class Reports : Form
    {
        public Reports()
        {
            
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BBTAH6R5\SQLEXPRESS;Initial Catalog=SSWdbms;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbReport.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("select * from Itemtbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = @"F:\BIT\Semester 02\ICT Project\ICT Project Final\ICT Project-SSW Store\ICT Project-SSW Store\Inventory.rdlc";
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            else if (cmbReport.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand("select * from Ordertbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = @"F:\BIT\Semester 02\ICT Project\ICT Project Final\ICT Project-SSW Store\ICT Project-SSW Store\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            else if (cmbReport.SelectedIndex == 3)
            {
                SqlCommand cmd = new SqlCommand("select * from Suppliertbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = @"F:\BIT\Semester 02\ICT Project\ICT Project Final\ICT Project-SSW Store\ICT Project-SSW Store\Supplier.rdlc";
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            else if (cmbReport.SelectedIndex == 2)
            {
                SqlCommand cmd = new SqlCommand("select * from Stafftbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = @"F:\BIT\Semester 02\ICT Project\ICT Project Final\ICT Project-SSW Store\ICT Project-SSW Store\Staff Details.rdlc";
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            else if (cmbReport.SelectedIndex == 4)
            {
                SqlCommand cmd = new SqlCommand("select * from Inqtbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = @"F:\BIT\Semester 02\ICT Project\ICT Project Final\ICT Project-SSW Store\ICT Project-SSW Store\Inquiry.rdlc";
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Please select the Report Type");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Main_Menu Hm = new Main_Menu();
            Hm.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Item_Mangement itm = new Item_Mangement();
            itm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void label18_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            LoginForm log = new LoginForm();
            log.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Order_Management ord = new Order_Management();
            ord.Show();
            this.Hide();
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

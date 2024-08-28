using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDinADODotNet
{
    public partial class Login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
        SqlConnection con;
        DataTable dt;
        SqlCommand cmd;
        SqlDataAdapter adapter;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            adapter = new SqlDataAdapter("SELECT * FROM Users WHERE UserName= '" + txtBoxUserName.Text + "' AND Password='" + txtBoxPassword.Text + "' AND IsActive=1        ", con);
            dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                Form1 frm1 = new Form1();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Please Provide Valid Information........");
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

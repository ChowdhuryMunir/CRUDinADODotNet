using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDinADODotNet
{
    public partial class Form1 : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        string gender;
        string imageLocation = "";
        string uploadedImages = "G:\\Chowdhury\\C_Sharp\\CRUDinADODotNet\\Images";





        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(cs);
            adapter = new SqlDataAdapter("select * from Student", con);
            dt = new DataTable();
            adapter.Fill(dt);
            dgStudentInfo.DataSource = dt;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            File.Copy(lblImagePath.Text, Path.Combine(@"G:\Chowdhury\C_Sharp\CRUDinADODotNet\Images", Path.GetFileName(lblImagePath.Text)), true);

            if (txtName.Text !="" && dateTimePicker1.Text !="")
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("insert into Student(Name, DOB, Gender, Picture) values (@name,@dob,@gender,@picture)", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                //cmd.Parameters.AddWithValue("@picture", picBoxStudent.ImageLocation);
                cmd.Parameters.AddWithValue("@picture", Path.Combine(uploadedImages + "\\" + Path.GetFileName(lblImagePath.Text)));
                int rowCount = cmd.ExecuteNonQuery();
                if(rowCount > 0)
                {
                    MessageBox.Show("Record Inserted Successfully.....!");
                    adapter = new SqlDataAdapter("select * from Student", con);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    dgStudentInfo.DataSource = dt;

                }
                con.Close();

            }
            else
            {
                MessageBox.Show("Please Enter The Name And Date Of Birth! ");
            }
        }

        private void radBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void dgStudentInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = this.dgStudentInfo.CurrentRow.Cells["Name"].Value.ToString();
            dateTimePicker1.Text = this.dgStudentInfo.CurrentRow.Cells["DOB"].Value.ToString();
            lblSId.Text = this.dgStudentInfo.CurrentRow.Cells["StudentId"].Value.ToString();
            if (this.dgStudentInfo.CurrentRow.Cells["Gender"].Value.ToString() == "Male")
            {
                radBtnMale.Checked = true;
            }
            else
            {
                radBtnFemale.Checked = true;
            }
            btnAdd.Hide();
            btnDelete.Show();
            btnUpdate.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                if (lblSId.Text != "")
                {
                    con = new SqlConnection(cs);
                    con.Open();
                    cmd = new SqlCommand("delete from Student where StudentId=@sid", con);
                    cmd.Parameters.AddWithValue("@sid", lblSId.Text);
                    int rowCount = cmd.ExecuteNonQuery();
                    if (rowCount > 0)
                    {
                        MessageBox.Show("Record Deleted Successfully...");
                        adapter = new SqlDataAdapter("select * from Student", con);
                        dt = new DataTable();
                        adapter.Fill(dt);
                        dgStudentInfo.DataSource = dt;
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please Select any row....");
                }
                lblSId.Text = "";
                txtName.Text = "";
                dateTimePicker1.ResetText();
                radBtnFemale.Checked = false;
                radBtnMale.Checked = false;
                btnAdd.Show();
                btnDelete.Show();

            } 

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && dateTimePicker1.Text != "")
            {
                con = new SqlConnection(cs);
                con.Open();
                cmd = new SqlCommand("Update Student set Name=@name,DOB=@dob,Gender=@gender Where StudentId=@sid", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@sid", lblSId.Text);
                int rowCount = cmd.ExecuteNonQuery();
                if (rowCount > 0)
                {
                    MessageBox.Show("Record Updated Successfully...");
                    adapter = new SqlDataAdapter("select * from Student", con);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    dgStudentInfo.DataSource = dt;
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please Select any row....");
            }
            lblSId.Text = "";
            txtName.Text = "";
            dateTimePicker1.ResetText();
            radBtnFemale.Checked = false;
            radBtnMale.Checked = false;
            btnAdd.Show();
            btnDelete.Show();
            btnUpdate.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblImagePath.Text = openFileDialog.FileName;
                picBoxStudent.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picBoxStudent.Image = null;
        }
    }
}

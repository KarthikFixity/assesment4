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

namespace Assesment4
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void Task1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-QRGJ8GTV;Initial catalog=ASSESMENT4;user id=sa;password=123456");
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_GETALLDEPTDATA", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                department.DisplayMember = "NAME";
                department.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-QRGJ8GTV;Initial catalog=ASSESMENT4;user id=sa;password=123456");

            try
            {

                long uid = Convert.ToInt64(this.uid.Text);
                long salary = Convert.ToInt64(this.salary.Text);
                DateTime dateOfBirth = Convert.ToDateTime(this.dateOfBirth.Text);
                String qualification = "";
                if (this.checkBox1.Checked)
                {
                    qualification = qualification + this.checkBox1.Text + ",";
                }
                else if (this.checkBox2.Checked)
                {
                    qualification = qualification + this.checkBox2.Text + ",";

                }
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_INSERT_NEW_EMP_DATA",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@name", this.name.Text);
                cmd.Parameters.AddWithValue("@email", this.email.Text);
                cmd.Parameters.AddWithValue("@password", this.password.Text);
                cmd.Parameters.AddWithValue("@gender", this.groupBox1.SelectedRadioButton().Text);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@dateofbirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@qualification", qualification);
                cmd.Parameters.AddWithValue("@department", this.department.Text);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Inserted successfully");

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

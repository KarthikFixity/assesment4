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
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void Task3_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-QRGJ8GTV;Initial catalog=NORTHWIND;user id=sa;password=123456");

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_GETALLORDERSDATA", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                viewOrders.DataSource = dt;

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
    }
}

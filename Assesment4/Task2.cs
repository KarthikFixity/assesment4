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

namespace Assesment4
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void Task2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClient_Name.Text))
            {
                MessageBox.Show("Client_Name cannot be Empty");
            }
            else if (string.IsNullOrEmpty(txtPayment_Mode.Text))
            {
                MessageBox.Show("Payment_Mode  cannot be Empty");
            }
            else if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("DOP cannot be empty");
            }
            else if (string.IsNullOrEmpty(txtInvoice_Type.Text))
            {
                MessageBox.Show("Invoice Type cannot be Empty");
            }
            else if (string.IsNullOrEmpty(txtDepartment_name.Text))
            {
                MessageBox.Show("Department_name cannot be Empty");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data source=LAPTOP-QRGJ8GTV; Initial catalog=HTD_BATCH1; user id=sa; password=123456");
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into tbl_invoices(Client_Name,Payment_mode,DOP,Invoice_type,Department_name) values(@Client_Name, @Payment_mode, @DOP, @Invoice_type, @Department_name)", con);

                    cmd.Parameters.AddWithValue("@Client_Name", txtClient_Name.Text);
                    cmd.Parameters.AddWithValue("@Payment_mode", txtPayment_Mode.Text);
                    cmd.Parameters.AddWithValue("@DOP", Convert.ToDateTime(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@Invoice_type", txtInvoice_Type.Text);
                    cmd.Parameters.AddWithValue("@Department_name", txtDepartment_name.Text);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Data inserted successsfully");
                        txtClient_Name.Text = "";
                        txtPayment_Mode.Text = "";
                        txtInvoice_Type.Text = "";
                        txtDepartment_name.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
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
}

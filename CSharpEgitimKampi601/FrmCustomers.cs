using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Services;
using DevExpress.Utils.VisualEffects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }
        CustomerOperations customerOperations = new CustomerOperations();
        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname=txtCustomerSurname.Text,
                CustomerBalance=decimal.Parse(txtCustomerBalance.Text),
                CustomerCity=txtCustomerCity.Text,
                CustomerShoppingCount=int.Parse(txtCustomerCount.Text)  
            };

            customerOperations.AddCustomer(customer);
            MessageBox.Show("Ekleme Başarılı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Müşteri başarıyla silindi.","Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;

            var updateCustomer = new Customer()
            {
                CustomerId=id,
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerCity = txtCustomerCity.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerShoppingCount = int.Parse(txtCustomerCount.Text),
            };

            customerOperations.UpdateCustomer(updateCustomer);
            MessageBox.Show("Müşteri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetByCustomerId_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            Customer customers = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customers };
        }
    }
}

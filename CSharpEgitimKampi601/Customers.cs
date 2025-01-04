using Npgsql;
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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        string connectionString = "Server= localhost; Port= 5432; Database= EgitimKampi_Db; User Id=postgres; Password= 12345";

        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select * From Customers";
            var command = new NpgsqlCommand(query, connection); // postgresql de queryleri göndermek için kullanılır.
            var adapter = new NpgsqlDataAdapter(command); // nesneler arasında köprü görevi görür, nesneler ile veritabanı arasında veri alışverişi sağlar.
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Insert Into Customers (CustomerName,CustomerSurname,CustomerCity) Values (@customerName,@customerSurname,@customerCity)";
            
            var command = new NpgsqlCommand(query, connection);

            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);

            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme İşlemi Başarıyla Tamamlandı.");
            connection.Close();

            GetAllCustomers();
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);

            connection.Open();
            string query = "Delete From Customers Where CustomerId=@customerId";

            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("customerId", id);
            command.ExecuteNonQuery();

            MessageBox.Show("Silme İşlemi Başarıyla Tamalandı.");
            connection.Close();

            GetAllCustomers();
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerId.Text);
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = "Update Customers Set CustomerName=@customerName,CustomerSurname=@customerSurname,CustomerCity=@customerCity Where CustomerId=@customerId";

            var command = new NpgsqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@customerSurname", customerSurname);
            command.Parameters.AddWithValue("@customerCity", customerCity);
            command.Parameters.AddWithValue("@customerId", id);

            command.ExecuteNonQuery();

            MessageBox.Show("Güncelleme İşlemi Başarıyla Tamamlandı.");
            connection.Close();

            GetAllCustomers();
        }
    }
}

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



namespace Lab5ofDatabase
{
    public partial class AdmiralPizza : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AdmiralPizza;Integrated Security=True");


        public AdmiralPizza()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdmiralPizza_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Menu' table. You can move, or remove it, as needed.
            this.menuTableAdapter.Fill(this.dataSet1.Menu);

        }
        private void LoadMenuData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Menu", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            menuDataGridView.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMenuData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Menu VALUES (@id, @desc, @price)", connection);
            cmd.Parameters.AddWithValue("@id", menu_idTextBox.Text);
            cmd.Parameters.AddWithValue("@desc", descriptionTextBox.Text);
            cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data inserted successfully");
            LoadMenuData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Menu SET description = @desc, price = @price WHERE menu_id = @id", connection);
                cmd.Parameters.AddWithValue("@id", menu_idTextBox.Text);
                cmd.Parameters.AddWithValue("@desc", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", priceTextBox.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data updated successfully");
                LoadMenuData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Menu WHERE menu_id = @id", connection);
                cmd.Parameters.AddWithValue("@id", menu_idTextBox.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data deleted successfully");
                LoadMenuData();
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Menu WHERE menu_id = @id", connection);
            cmd.Parameters.AddWithValue("@id", menu_idTextBox.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            menuDataGridView.DataSource = dt;
            connection.Close();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
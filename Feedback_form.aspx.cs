using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Feedback_form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
            string productName = txtProductName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            DateTime date = DateTime.Parse(txtDate.Text);
            string description = txtDescription.Text;

            // Create a connection to the database
            //string connectionString = ConfigurationManager.ConnectionStrings[@"Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;MultipleActiveResultSets=true;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh"].ConnectionString;
            string connectionString = @"Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;MultipleActiveResultSets=true;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define the SQL query to insert feedback into the database
                string query = "INSERT INTO Feedback (Name, ProductName, PhoneNumber, Date, Description) VALUES (@Name, @ProductName, @PhoneNumber, @Date, @Description)";

                // Create a SqlCommand object to execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Description", description);

                    // Open the database connection
                    connection.Open();

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
            lblThankYouMessage.Text = "Thank you for your feedback!";
        
    }
}
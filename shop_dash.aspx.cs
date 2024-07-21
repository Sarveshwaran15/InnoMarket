using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class shop_dash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // string totalSum = "0";
        string sold = "0";
        string sold2 = "0";
        string sold3 = "0";
        string sold31 = "0";
        if (!IsPostBack)
        {


            // string connectionString = @"Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh";
            // Example values to display
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
            {
                
                //string q1 = "SELECT SUM(CONVERT(INT, o.tot_amt)) FROM ord_tbl2 o JOIN Product p ON o.p_id = p.product_id WHERE p.vendor_id = 'VID4';";
                string q1 = "select SUM(CONVERT(INT,quantity)) from Product where status = 'approved';";
                SqlCommand cmd = new SqlCommand(q1, connection);
                // cmd.Parameters.Add("VendorId", vendorID);
                 connection.Open();
                object result1 = cmd.ExecuteScalar();
                if (result1 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    sold = result1.ToString(); // Convert the result to string
                }
                string q2 = "select SUM(CONVERT(float,tot)) from Product where status = 'approved';";
                    SqlCommand cmd1 = new SqlCommand(q2, connection);
                // cmd.Parameters.Add("VendorId", vendorID);
                 //connection.Open();
                object result2 = cmd1.ExecuteScalar();
                if (result2 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    sold2 = result2.ToString(); // Convert the result to string
                }
                string q3 = "select count(vendor_id) from vendor where status = 'approved';";
                SqlCommand cmd2 = new SqlCommand(q3, connection);
                // cmd.Parameters.Add("VendorId", vendorID);
                //connection.Open();
                object result3 = cmd2.ExecuteScalar();
                if (result3 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    sold3 = result3.ToString(); // Convert the result to string
                }
                string s3 = @"select SUM(CONVERT(INT,Quantity)) from Return_Products";
                SqlCommand cmd24 = new SqlCommand(s3, connection);
                object result31 = cmd24.ExecuteScalar();
                if (result31 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    sold31 = result31.ToString(); // Convert the result to string
                }

            }
            displayDiv2.InnerText = sold.ToString();

            Div1.InnerText = sold2.ToString();
            Div2.InnerText = sold3.ToString();
            Div5.InnerText = sold31.ToString();
            //BindChart();
           // hello();
        }
    }
     protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve input values
            string fromDate = txtFromDate.Text;
            string toDate = txtToDate.Text;
            string vendorID = txtVendorID.Text;
            string s1 = "0";

            // Database connection string
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
            {

            // SQL query to get the number of items sold
            string query = @"SELECT SUM(CONVERT(INT,TOTAL)) 
                             FROM Orders o
                             JOIN Product p ON o.ProductID = p.product_id
                             WHERE o.DateField BETWEEN @FromDate AND @ToDate
                             AND p.vendor_id = @VendorID";

         
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    command.Parameters.AddWithValue("@VendorID", vendorID);

                    connection.Open();
                    object itemCount = command.ExecuteScalar();
                    s1 = itemCount.ToString();
                    connection.Close();
                    Div3.InnerText = s1.ToString();

                    //lblResult.Text = "Number of items sold by Vendor {vendorID} between {fromDate} and {toDate}: {itemCount}";
                }
            }
            }
     protected void btnSubmit_Click2(object sender, EventArgs e)
     {
         using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
         {
             string sum = "0";
             string vendor_id =TextBox1.Text;
             string new1 = "0";
             string n1 = "0";
             string r = "0";
             string s = @"SELECT SUM(CONVERT(INT,TOTAL)) 
                             FROM Orders o
                             JOIN Product p ON o.ProductID = p.product_id
                             WHERE  p.vendor_id = @vendor_id";
             string s1 = @"update issue_tbl set amount = @new1 where v_id = @vendor_id";
             string s2 = @"select amount from issue_tbl where v_id =@vendor_id";
            
             using (SqlCommand command = new SqlCommand(s, connection))
             {
                 connection.Open();
                 command.Parameters.AddWithValue("@vendor_id", vendor_id);
                  object sumResult = command.ExecuteScalar();
                  if (sumResult != DBNull.Value)
    {
                // command.Parameters.AddWithValue("@vendor_id", vendor_id);
                 //connection.Open();
                 object abc = command.ExecuteScalar();
                 sum = abc.ToString();
                 //connection.Close();
                 using (SqlCommand command2 = new SqlCommand(s1, connection))
                 {
                     new1 = sum.ToString();
                     command2.Parameters.AddWithValue("@new1", new1);
                     command2.Parameters.AddWithValue("@vendor_id", vendor_id);
                     object a = command2.ExecuteScalar();
                     using (SqlCommand command3 = new SqlCommand(s1, connection))
                     {

                         int a1 = int.Parse(sum);
                         int b1 = int.Parse(new1);
                         int c1 = a1 - b1;
                         command3.Parameters.AddWithValue("@new1", c1.ToString());
                         command3.Parameters.AddWithValue("@vendor_id", vendor_id);
                         object ab = command3.ExecuteScalar();
                         // n1 = ab.ToString();
                         using (SqlCommand command4 = new SqlCommand(s2, connection))
                         {
                             command4.Parameters.AddWithValue("@vendor_id", vendor_id);
                             object n2 = command4.ExecuteScalar();
                             Div4.InnerText = n2.ToString();
                         }

                     }
                 }

                 }
             }
         

                
                // connection.Open();
             }
         }
     
}

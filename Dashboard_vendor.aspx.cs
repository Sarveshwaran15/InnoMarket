using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Services;
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Script.Serialization;





public partial class Dashboard_vendor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string totalSum = "0";
        string sold = "0";
        string avail = "0";
        string bal = "0";
        string re = "0";
        if (!IsPostBack)
        {
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // Redirect the user to the login page if they are not authenticated
                Response.Redirect("Vendor_Login.aspx");
            }
                string vendorID = Session["VendorID"].ToString();
                lblUsername.Text = vendorID;
                //display();
                lblUsername.Visible = false;
            

            // string connectionString = @"Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh";
            // Example values to display
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
            {

                string query = "SELECT SUM(CONVERT(INT, o.quantity)) FROM Orders o JOIN Product p ON o.productid = p.product_id WHERE p.vendor_id = '" + lblUsername.Text + "'";

                SqlCommand command = new SqlCommand(query, connection);
                // command.Parameters.Add("VendorId", vendorID);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    totalSum = result.ToString(); // Convert the result to string
                }
                string q1 = "SELECT SUM(CONVERT(INT, o.total)) FROM Orders o JOIN Product p ON o.productid = p.product_id WHERE p.vendor_id = '" + lblUsername.Text + "'";
                SqlCommand cmd = new SqlCommand(q1, connection);
                // cmd.Parameters.Add("VendorId", vendorID);
                // connection.Open();
                object result1 = cmd.ExecuteScalar();
                if (result1 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    sold = result1.ToString(); // Convert the result to string
                }
                string a2 = "select SUM(CONVERT(INT,quantity)) from Product where vendor_id = '" + lblUsername.Text + "'";
                SqlCommand cmd5 = new SqlCommand(a2, connection);
                // cmd.Parameters.Add("VendorId", vendorID);
                // connection.Open();
                object result12 = cmd5.ExecuteScalar();
                if (result12 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    avail = result12.ToString(); // Convert the result to string
                }
                string b1 = "select amount from issue_tbl where v_id = '" + lblUsername.Text + "'";
                SqlCommand cmd6 = new SqlCommand(b1, connection);
                // cmd.Parameters.Add("VendorId", vendorID);
                // connection.Open();
                object result123 = cmd6.ExecuteScalar();
                if (result123 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    bal = result123.ToString(); // Convert the result to string
                }
                string b3 = "select SUM(CONVERT(INT,Quantity)) from Return_Products where vendor_id = '" + lblUsername.Text + "'";
                SqlCommand cmd61 = new SqlCommand(b3, connection);
                // cmd.Parameters.Add("VendorId", vendorID);
                // connection.Open();
                object result1234 = cmd61.ExecuteScalar();
                if (result1234 != DBNull.Value)
                {

                    //object result = command.ExecuteScalar();

                    re = result1234.ToString(); // Convert the result to string
                }

            }
            displayDiv2.InnerText = totalSum.ToString();
            Div1.InnerText = sold.ToString();
            Div2.InnerText = avail.ToString();
            Div3.InnerText = bal;
            Div4.InnerText = re;
            //BindChart();
            hello();
            //DisplayImages();
        }

    }
   /* protected void DisplayImages()
    {
        //SqlConnection cn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\balu_\source\repos\webApp\webApp\App_Data\Database1.mdf;Integrated Security=True");

        string query = "SELECT newimg, vendor_name, age, phone FROM vendor where vendor_id = 'VID8'";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                byte[] imageData = (byte[])reader["newimg"];
                string base64String = Convert.ToBase64String(imageData);
                string imageUrl = "data:image/jpeg;base64," + base64String;

                // Create HTML elements for displaying image, name, age, and num
                Image img = new Image();
                img.ImageUrl = imageUrl;
                img.Width = 100; // Set the width of the image
                img.Height = 100; // Set the height of the image

                // Create labels for displaying name, age, and num
                Label nameLabel = new Label();
                nameLabel.Text = "<br/>" + "Name: " + reader["vendor_name"].ToString() + "<br/>";
                Label ageLabel = new Label();
                ageLabel.Text = "Age: " + reader["age"].ToString() + "<br/>";
                Label numLabel = new Label();
                numLabel.Text = "Num: " + reader["phone"].ToString() + "<br/>";

                // Add the image and labels to a container on your ASP.NET page
                PlaceHolder1.Controls.Add(img);
                PlaceHolder1.Controls.Add(nameLabel);
                PlaceHolder1.Controls.Add(ageLabel);
                PlaceHolder1.Controls.Add(numLabel);
            }

            // cn1.Close();

        }
    }



    /*private void BindChart()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            string query = "SELECT o.DateField, SUM(CONVERT(INT,o.TOTAL)) AS TotalAmount FROM Orders o  JOIN Product p ON o.ProductID = p.product_id WHERE p.vendor_id = 'VID4' GROUP BY DateField";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Chart1.Series.Clear();
            Chart1.ChartAreas.Clear();
            Chart1.ChartAreas.Add(new ChartArea());

            Series series = new Series("TotalAmount");
            series.ChartType = SeriesChartType.Column;

            while (reader.Read())
            {
                string datefield = reader["DateField"].ToString();
                double totalAmount = Convert.ToDouble(reader["TotalAmount"]);

                series.Points.AddXY(datefield, totalAmount);
            }

            Chart1.Series.Add(series);
            reader.Close();
        }*/
   /* private void hello()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            string query = "SELECT o.DateField, SUM(CONVERT(INT,o.TOTAL)) AS TotalAmount FROM Orders o  JOIN Product p ON o.ProductID = p.product_id WHERE p.vendor_id = 'VID4' GROUP BY DateField";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            var months = new System.Collections.Generic.List<string>();
            var amounts = new System.Collections.Generic.List<int>();
            while (reader.Read())
            {
                months.Add(reader["DateField"].ToString());
                amounts.Add(Convert.ToInt32(reader["TotalAmount"]));

            }
            reader.Close();
            string[] monthArray = months.ToArray();
            int[] amountArray = amounts.ToArray();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string monthJson = jsSerializer.Serialize(monthArray);
            string amountJson = jsSerializer.Serialize(amountArray);
            monthsHiddenField.Value = monthJson;
            amountsHiddenField.Value = amountJson;

        }
    }*/
    private void hello()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            string query = "SELECT o.DateField, p.Product_Name, SUM(CONVERT(INT, o.TOTAL)) AS TotalAmount FROM Orders o JOIN Product p ON o.ProductID = p.product_id WHERE p.vendor_id = '"+lblUsername.Text +"' GROUP BY DateField, p.Product_Name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            var data = new List<object[]>();
            while (reader.Read())
            {
                // Add an object array containing DateField, ProductName, and TotalAmount to the list
                data.Add(new object[] { reader["DateField"].ToString(), reader["Product_Name"].ToString(), Convert.ToInt32(reader["TotalAmount"]) });
            }
            reader.Close();

            // Serialize the data list to JSON
            string jsonData = new JavaScriptSerializer().Serialize(data);
            dataHiddenField.Value = jsonData;
        }
    }

}
             
            

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

public partial class Purchase_Details_Owner : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //display();
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                Response.Redirect("Owner_Login.aspx");
            }
            BindGridView();
        }

    }
    protected void BindGridView()
    {
        // string connectionString = "YourConnectionString"; // Replace this with your actual connection string
        string query = "SELECT o.ProductID, p.product_name, o.quantity, o.total, p.vendor_id FROM Orders o INNER JOIN Product p ON o.ProductID = p.product_id";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string vendorId = DataBinder.Eval(e.Row.DataItem, "vendor_id").ToString();

            // Fetch vendor name using vendor ID
            string vendorName = GetVendorName(vendorId);

            // Add vendor name to the row
            e.Row.Cells[5].Text = vendorName;
        }
    }

    protected string GetVendorName(string vendorId)
    {
        //string connectionString = "YourConnectionString"; // Replace this with your actual connection string
        string query = "SELECT vendor_name FROM Vendor WHERE vendor_id = @vendorId";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@vendorId", vendorId);
            connection.Open();

            object result = command.ExecuteScalar();
            string vendorName = result != null ? result.ToString() : string.Empty;

            return vendorName;
        }
    }
    /* void display()
     {
         con.Open();

         // Query to retrieve vendor name and vendor ID
         SqlDataAdapter vendorDa = new SqlDataAdapter("SELECT vendor_id, vendor_name FROM vendor", con);
         DataTable vendorDt = new DataTable();
         vendorDa.Fill(vendorDt);

         // Query to retrieve product names
         SqlDataAdapter productNameDa = new SqlDataAdapter("SELECT product_name FROM product", con);
         DataTable productNameDt = new DataTable();
         productNameDa.Fill(productNameDt);

         // Query to retrieve total from Orders
         SqlDataAdapter totalDa = new SqlDataAdapter("SELECT total FROM Orders WHERE ProductID IN (SELECT product_id FROM product)", con);
         DataTable totalDt = new DataTable();
         totalDa.Fill(totalDt);

         // Merge the data into a single DataTable
         DataTable mergedDt = new DataTable();
         mergedDt.Columns.Add("Vendor ID");
         mergedDt.Columns.Add("Vendor Name");
         mergedDt.Columns.Add("Product Name");
         mergedDt.Columns.Add("Total");

         foreach (DataRow vendorRow in vendorDt.Rows)
         {
             string vendorId = vendorRow["vendor_id"].ToString();
             string vendorName = vendorRow["vendor_name"].ToString();

             foreach (DataRow productNameRow in productNameDt.Rows)
             {
                 string productName = productNameRow["product_name"].ToString();

                 // Assuming the rows in totalDt correspond to product names in the same order
                 if (productNameDt.Rows.IndexOf(productNameRow) < totalDt.Rows.Count)
                 {
                     string total = totalDt.Rows[productNameDt.Rows.IndexOf(productNameRow)]["total"].ToString();
                     mergedDt.Rows.Add(vendorId, vendorName, productName, total);
                 }
             }
         }

         // Bind the merged DataTable to GridView
         GridView1.DataSource = mergedDt;
         GridView1.DataBind();

         con.Close();
     }*/
    void display()
    {
        con.Open();

        // Query to retrieve vendor details along with product names and total from Orders
        SqlDataAdapter da = new SqlDataAdapter("SELECT o.purchase_id, o.product_name,v.vendor_name,o.quantity,o.total,o.DateField FROM orders o INNER JOIN vendor v ON o.vendorid = v.vendor_id", con);

        DataTable dt = new DataTable();
        da.Fill(dt);

        // Create a new DataTable to hold unique values
        DataTable mergedDt = new DataTable();
        mergedDt.Columns.Add("Vendor ID");
        mergedDt.Columns.Add("Vendor Name");
        mergedDt.Columns.Add("Product Name");
        mergedDt.Columns.Add("Total");

        // Iterate through the data table and add unique rows to mergedDt
        foreach (DataRow row in dt.Rows)
        {
            string vendorId = row["vendor_id"].ToString();
            string vendorName = row["vendor_name"].ToString();
            string productName = row["product_name"].ToString();
            string total = row["total"].ToString();

            // Check if the combination of vendor ID and product name already exists in mergedDt
            bool found = false;
            foreach (DataRow mergedRow in mergedDt.Rows)
            {
                if (mergedRow["Vendor ID"].ToString() == vendorId && mergedRow["Product Name"].ToString() == productName)
                {
                    found = true;
                    break;
                }
            }

            // If not found, add the row to mergedDt
            if (!found)
            {
                mergedDt.Rows.Add(vendorId, vendorName, productName, total);
            }
        }

        // Bind the merged DataTable to GridView
        GridView1.DataSource = mergedDt;
        GridView1.DataBind();

        con.Close();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string filterText = TextBox1.Text.Trim();
        loaddata(filterText);
    }
    protected void loaddata(string filter)
    {
        // string connectionString = "YourConnectionString"; // Replace this with your actual connection string
        // string connectionString = "YourConnectionString"; // Replace this with your actual connection string
        string query = "SELECT o.purchase_id, o.product_name,v.vendor_name,o.quantity,o.total,o.DateField FROM orders o INNER JOIN vendor v ON o.vendorid = v.vendor_id";

        // Append filter conditions if provided
        if (!string.IsNullOrEmpty(filter))
        {
            query += " WHERE o.product_id LIKE '%{filter}%' OR p.product_name LIKE '%{filter}%' OR p.vendor_id LIKE '%{filter}%'";
        }

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, for example, log the error or display a message.
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string filterText = TextBox1.Text.Trim();
        DateTime startDate = DateTime.Parse(TextBox2.Text);
        DateTime endDate = DateTime.Parse(TextBox3.Text);

        BindGridViewd(filterText, startDate, endDate);
    }
    protected void BindGridViewd(string filter, DateTime startDate, DateTime endDate)
    {
        //string connectionString = "YourConnectionString"; // Replace this with your actual connection string
        string query = "SELECT o.purchase_id, o.product_name,v.vendor_name,o.quantity,o.total,o.DateField FROM orders o INNER JOIN vendor v ON o.vendorid = v.vendor_id";

        // Append filter conditions if provided
        if (!string.IsNullOrEmpty(filter))
        {
            query += " WHERE o.product_id LIKE '%{filter}%' OR p.product_name LIKE '%{filter}%' OR p.vendor_id LIKE '%{filter}%'";
        }

        // Append date range condition
        query += " AND o.DateField BETWEEN @StartDate AND @EndDate";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@EndDate", endDate);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, for example, log the error or display a message.
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
}
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

public partial class Returned_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (!IsPostBack)
        {
            Label1.Visible = false;
            Label3.Visible = false;
            // Initialize gridview
            if (Session["GridViewData"] == null)
            {
                DataTable dt = CreateInvoiceDataTable();
                Session["GridViewData"] = dt;
            }
            BindGridView();
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                Response.Redirect("Owner_Login.aspx");
            }
            GridView2.Visible = false;
        }
    }
    string name1 = "";
    string vendor = "";
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select rate,product_name,vendor_id from Product where product_id ='" + txtProductId.Text + "'", con);
        
        DataTable dt1 = new DataTable();
        da.Fill(dt1);
        con.Close();

        if (dt1.Rows.Count > 0)
        {

            // editddlid.Text = dt.Rows[0][0].ToString();
            Label1.Text = dt1.Rows[0][0].ToString();
            name1 = dt1.Rows[0][1].ToString();
            vendor = dt1.Rows[0][2].ToString();


        }
        double quantity_val = double.Parse(txtQuantity.Text);
        double tot = double.Parse(Label1.Text);
        double ans = quantity_val * tot;
        DataTable dt = Session["GridViewData"] as DataTable;

        DataRow newRow = dt.NewRow();
        newRow["ProductId"] = txtProductId.Text;
        newRow["Quantity"] = txtQuantity.Text;
        newRow["ProductName"] = name1;
        newRow["Total"] = ans.ToString();
        newRow["vendorid"] = vendor;


        dt.Rows.Add(newRow);

        BindGridView();
        CalculateGrandTotal();
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        // Create a new DataTable to hold the data from GridView
        
        DataTable dtOrder = new DataTable();
        dtOrder.Columns.AddRange(new DataColumn[5] { new DataColumn("ProductId"), new DataColumn("Quantity"),new DataColumn("ProductName"), new DataColumn("Total"),new DataColumn("vendorid") });

        // Loop through each row in the GridView and add data to the DataTable
        foreach (GridViewRow row in GridView1.Rows)
        {
            string productId = row.Cells[0].Text; // Product ID is in the first column
            string quantity = row.Cells[1].Text;
            string pname = row.Cells[2].Text;// Quantity is in the second column
            string total = row.Cells[3].Text;
            string vendorid = row.Cells[4].Text; // Total is in the third column

            dtOrder.Rows.Add(productId, quantity, pname, total, vendorid);
        }

        // Loop through each row in the GridView and update the product table
        foreach (GridViewRow row in GridView1.Rows)
        {
            string productId = row.Cells[0].Text; // Product ID is in the first column
            int quantityToPurchase = Convert.ToInt32(row.Cells[1].Text); // Quantity is in the second column

            // Update the stock in the product table
            UpdateStock(productId, quantityToPurchase, dtOrder);
        }

        // Refresh the GridView with updated data
        BindGridView();
    }

    protected void ClearGridView()
    {
        // Clear the DataTable stored in Session
        DataTable dt = CreateInvoiceDataTable();
        Session["GridViewData"] = dt;

        // Bind the GridView to the cleared DataTable
        BindGridView();

        // Clear the grand total label
        Label3.Text = "Sum : 0"; // Assuming Label3 is your grand total label
    }
    protected void UpdateStock(string productId, int quantityToPurchase, DataTable dtOrder)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            con.Open();
            SqlCommand selectCmd = new SqlCommand("SELECT quantity FROM Product WHERE product_id = @ProductID", con);
            selectCmd.Parameters.AddWithValue("@ProductID", productId);
            int currentQuantity = Convert.ToInt32(selectCmd.ExecuteScalar());

            if (currentQuantity >= quantityToPurchase)
            {
                int updatedQuantity = currentQuantity - quantityToPurchase;
                if (updatedQuantity <= -1)
                {
                    // If the updated quantity becomes zero or negative, display an alert
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Insufficient quantity');</script>");
                    return; // Exit the method
                }
                
                SqlCommand updateCmd = new SqlCommand("UPDATE Product SET quantity = @Quantity WHERE product_id = @ProductID", con);

                updateCmd.Parameters.AddWithValue("@Quantity", updatedQuantity);
                updateCmd.Parameters.AddWithValue("@ProductID", productId);
                updateCmd.ExecuteNonQuery();
                foreach (DataRow row in dtOrder.Rows)
                {
                    DateTime today = DateTime.Today;

                    // Convert the date to a string in the desired format
                    string todayString = today.ToString("yyyy-MM-dd");
                    SqlCommand cmd = new SqlCommand("INSERT INTO Return_Products (ProductID, ProductName, Quantity,date_column,vendor_id) VALUES (@ProductID, @ProductName, @Quantity,@date_column,@vendor_id)", con);
                    cmd.Parameters.AddWithValue("@ProductID", row["ProductID"]);
                     cmd.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                   // cmd.Parameters.AddWithValue("@ProductName", name1);
                    cmd.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                    cmd.Parameters.AddWithValue("@date_column", todayString);
                    cmd.Parameters.AddWithValue("@vendor_id", row["vendorid"]);
                    cmd.ExecuteNonQuery();
                }
                txtProductId.Text = " ";
                txtQuantity.Text = " ";
                ClearGridView();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Returned Successfully');</script>");
            }
            else
            {
                // Display an alert if the current quantity is less than the quantity to purchase
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Insufficient quantity');</script>");
            }
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = Session["GridViewData"] as DataTable;
        dt.Rows.RemoveAt(e.RowIndex);
        BindGridView();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button btnDelete = (Button)sender;
        GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
        int index = row.RowIndex;

        DataTable dt = Session["GridViewData"] as DataTable;
        dt.Rows.RemoveAt(index);
        BindGridView();
        CalculateGrandTotal();
    }



    public void CalculateGrandTotal()
    {
        int sum = 0;

        // Assuming your GridView ID is "myGridView"
        foreach (GridViewRow row in GridView1.Rows)
        {
            // Assuming the 3rd column index is 2 (0-based index)
            // Modify this index if your column order is different
            string totalValue = row.Cells[3].Text;
            string productName = row.Cells[2].Text;

            int value;
            if (int.TryParse(totalValue, out value))
            {
                sum += value;
            }
        }

        // Assuming your Label ID is "sumLabel"
        Label3.Text = "Sum : " + sum.ToString();
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            //   CalculateGrandTotal1();
            CalculateGrandTotal();
        }
    }

    private DataTable CreateInvoiceDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ProductId");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("ProductName");
        dt.Columns.Add("Total");
        dt.Columns.Add("vendorid");
        return dt;
    }

    private void BindGridView()
    {
        DataTable dt = Session["GridViewData"] as DataTable;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


}
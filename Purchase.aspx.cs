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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


public partial class Purchase : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  BindBillingData();
            BindBillingData();

            // Populate the receipt panel with the GridView data
            PopulateReceiptPanel();

            // Populate the receipt panel with the GridView data
            // PopulateReceiptPanel();
            Label1.Visible = false;
            Label2.Visible = false;
            // Initialize gridview
            if (Session["GridViewData"] == null)
            {
                DataTable dt = CreateInvoiceDataTable();
                Session["GridViewData"] = dt;
                display();
            }
            BindGridView();
            CreateInvoiceDataTable();
        }
    }
    private void BindBillingData()
    {
        // Sample data source (replace with your actual data source)
        DataTable billingData = new DataTable();
        billingData.Columns.Add("Item");
        billingData.Columns.Add("Quantity", typeof(int));
        billingData.Columns.Add("Price", typeof(decimal));
        billingData.Columns.Add("Total", typeof(decimal));

        // Add sample rows (replace with actual data retrieval)
        billingData.Rows.Add("Item 1", 2, 10.00m, 20.00m);
        billingData.Rows.Add("Item 2", 1, 15.00m, 15.00m);

        GridView3.DataSource = billingData;
        GridView3.DataBind();
    }
    private void PopulateReceiptPanel()
    {
        // Get the data source from the GridView
        DataTable billingData = new DataTable();
    billingData.Columns.Add("ProductId");
    billingData.Columns.Add("Quantity", typeof(int));
    billingData.Columns.Add("ProductName");
    billingData.Columns.Add("Total", typeof(decimal));

    foreach (RepeaterItem item in repeaterItems.Items)
    {
        Label itemLabel = (Label)item.FindControl("lblItem");
        Label quantityLabel = (Label)item.FindControl("lblQuantity");
        Label priceLabel = (Label)item.FindControl("lblPrice");

        // Extract values from the print panel
        string itemText = itemLabel.Text;
        int quantity = Convert.ToInt32(quantityLabel.Text);
        decimal price = Convert.ToDecimal(priceLabel.Text.Substring(1)); // Remove currency symbol
        decimal total = quantity * price;

        // Add to the data table
        billingData.Rows.Add(itemText, quantity, price, total);
    }

    // Bind the GridView with the updated data source
    GridView1.DataSource = billingData;
    GridView1.DataBind();

    // Calculate the total amount and display it
    decimal totalAmount = 0;
    foreach (DataRow row in billingData.Rows)
    {
        totalAmount += Convert.ToDecimal(row["Total"]);
    }

    // Display the total amount
    Label4.Text = totalAmount.ToString("C2");

    }

    /* private void BindBillingData()
     {
         // Sample data source (replace with your actual data source)
         DataTable billingData = new DataTable();
         billingData.Columns.Add("Item");
         billingData.Columns.Add("Quantity", typeof(int));
         billingData.Columns.Add("Price", typeof(decimal));
         billingData.Columns.Add("Total", typeof(decimal));

         // Add sample rows (replace with actual data retrieval)
         billingData.Rows.Add("Item 1", 2, 10.00m, 20.00m);
         billingData.Rows.Add("Item 2", 1, 15.00m, 15.00m);

         GridView1.DataSource = billingData;
         GridView1.DataBind();
     }*/
    /* private void PopulateReceiptPanel()
        {
            // Get the data source from the GridView
            DataTable billingData = (DataTable)GridView1.DataSource;

            // Bind the Repeater with the data
            repeaterItems.DataSource = billingData;
            repeaterItems.DataBind();

            // Calculate the total amount and display it
            decimal totalAmount = 0;
            foreach (DataRow row in billingData.Rows)
            {
                totalAmount += Convert.ToDecimal(row["Total"]);
            }

            lblTotalAmount.Text = totalAmount.ToString("C2");
        }*/
    string name1 = "";
    string vendor;
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


    void display()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select product_id,product_name,quantity,rate from product where quantity>0 and not status='issued'", con);
        SqlDataAdapter dr = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        dr.Fill(ds);
        con.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();
    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        // Create a new DataTable to hold the data from GridView
        DataTable dtOrder = new DataTable();
        dtOrder.Columns.AddRange(new DataColumn[5] { new DataColumn("ProductId"), new DataColumn("Quantity"), new DataColumn("ProductName"), new DataColumn("Total"), new DataColumn("vendorid") });

        // Loop through each row in the GridView and add data to the DataTable
        foreach (GridViewRow row in GridView1.Rows)
        {
            string productId = row.Cells[0].Text; // Product ID is in the first column
            string quantity = row.Cells[1].Text; // Quantity is in the second column
            string pname = row.Cells[2].Text;
            string total = row.Cells[3].Text; // Total is in the third column
            string vendorid = row.Cells[4].Text;
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
                    string pur_id = productId;
                    SqlCommand cmd = new SqlCommand("INSERT INTO Orders (ProductID, ProductName, Quantity,DateField,TOTAL,purchase_id,vendorid) VALUES (@ProductID, @ProductName, @Quantity,@DateField,@TOTAL,@purchase_id,@vendorid)", con);
                    cmd.Parameters.AddWithValue("@vendorid", row["vendorid"]);
                    cmd.Parameters.AddWithValue("@ProductID", row["ProductID"]);
                    cmd.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                    // cmd.Parameters.AddWithValue("@ProductName", name1);
                    cmd.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                    cmd.Parameters.AddWithValue("@DateField", todayString);
                    cmd.Parameters.AddWithValue("@TOTAL", row["Total"]);
                    cmd.Parameters.AddWithValue("@purchase_id", pur_id);


                    cmd.ExecuteNonQuery();
                }
                txtProductId.Text = " ";
                txtQuantity.Text = " ";
                ClearGridView();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Purchase Successfully');</script>");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=TableData.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //this.LoadControl(@"~C:\Users\sivas\OneDrive\Documents\Visual Studio 2012\WebSites\Shop\Purchase.aspx").RenderControl(hw);
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
        HTMLWorker htmlparse = new HTMLWorker(pdfdoc);
        PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
        pdfdoc.Open();
        htmlparse.Parse(sr);
        //pdfdoc.newPage();
        pdfdoc.Close();
        Response.Write(pdfdoc);
        Response.End();
        GridView1.AllowPaging = true;
        GridView1.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        CreateInvoiceDataTable();
    }
}


//select * from Orders;
//select * from vendor;
//select * from Product;

//select v.vendor_name,p.product_name,pur.ProductID  from vendor v join Product p on v.vendor_id=p.vendor_id join Orders pur on p.product_id=pur.ProductID where v.vendor_id='VID$';
//GridView1.Columns[4].Visible = false; for vendor id
//GridView1.Columns[4].Visible = false; for product id
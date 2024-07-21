using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class return_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
    private void BindGridView()
    {
        //string connectionString = "Your_Connection_String_Here";
       
            string query = "SELECT ProductId, ProductName, Quantity, Date_Column, Vendor_Id FROM return_products";

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                query += " WHERE ProductId LIKE @SearchValue OR ProductName LIKE @SearchValue";
            }
            

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            SqlCommand command = new SqlCommand(query, connection);
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                command.Parameters.AddWithValue("@SearchValue", "%" + txtSearch.Text + "%");
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            gvProducts.DataSource = dataTable;
            gvProducts.DataBind();
            }
        }

    }


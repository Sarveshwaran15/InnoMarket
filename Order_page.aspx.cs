using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Order_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["value"] != null)
            {
                if (Request.QueryString["sta"] != null)
                {
                    string passedValue = Request.QueryString["value"];
                    string st = Request.QueryString["sta"];
                    // Now you have the value passed from WebForm1, you can use it in your SqlDataSource
                    // For example:
                    SqlDataSource1.SelectCommand = "SELECT * FROM ord_tbl2 WHERE phone = @PassedValue and status = @st1";
                    SqlDataSource1.SelectParameters.Add("PassedValue", passedValue);
                    SqlDataSource1.SelectParameters.Add("st1", st);

                }
            }
        }


    }
    protected void claim(object sender, EventArgs e)
    {
        if (Request.QueryString["value"] != null)
        {
            if (Request.QueryString["sta"] != null)
            {
                string passedValue = Request.QueryString["value"];
                string st = Request.QueryString["sta"];
                string s = "ordered";
                string connectionString = @"Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "Update ord_tbl2 set status = @a where phone = @p1";
                    connection.Open();
                    SqlCommand cmd1 = new SqlCommand(query, connection);
                    cmd1.Parameters.AddWithValue("@a", s);
                    cmd1.Parameters.AddWithValue("@p1", passedValue);
                    int b = cmd1.ExecuteNonQuery();
                }
            }
        }
        Response.Redirect("Thankyou_page.aspx");
    }
}
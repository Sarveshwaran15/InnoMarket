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
public partial class Vendor_Product_View : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // Redirect the user to the login page if they are not authenticated
                Response.Redirect("Vendor_Login.aspx");
            }
            string vendorID = Session["VendorID"].ToString();
            lblUsername.Text = vendorID;
            display();
            lblUsername.Visible = false;
        }
    }
    public void display()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        cmd.CommandText = "SELECT * FROM Product where not status='issued' and  vendor_id='" + lblUsername.Text + "'";
        cmd.Connection = con;
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        //countdata();
    }


}
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

public partial class Approval : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();

            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // Redirect the user to the login page if they are not authenticated
                Response.Redirect("Owner_Login.aspx");
            }


        }
    }
    void display()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from product where quantity>0 and not status='issued'", con);
        SqlDataAdapter dr = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        dr.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }


    void dropdown()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from product where product_name='" + TextBox1.Text + "' or product_id='" + TextBox1.Text + "' and  quantity>0 and not status='issued'", con);
        SqlDataAdapter dr = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        dr.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        dropdown();
    }
}
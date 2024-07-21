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

public partial class Owner_Product_View : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display();
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                Response.Redirect("Owner_Login.aspx");
            }
        }
    }
    public void display()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        cmd.CommandText = "SELECT * FROM product where not status='approved'";
        cmd.Connection = con;
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        //countdata();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        display();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int sno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        string item_name = (GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text;
        con.Open();
        SqlCommand cmd = new SqlCommand("update product set status='" + item_name + "' where id='" + sno.ToString() + "'", con);
        cmd.ExecuteNonQuery();


        con.Close();
        GridView1.EditIndex = -1;
        display();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        display();
    }
}
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

public partial class Vendor_Waiting_List : System.Web.UI.Page
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
    void display()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from vendor where  status='pending'", con);
       
        SqlDataAdapter dr = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        dr.Fill(ds);
        con.Close();
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        display();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int sno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        string item_name = (GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text;
        con.Open();
        SqlCommand cmd = new SqlCommand("update vendor set status='" + item_name + "' where id='" + sno + "'", con);
        //SqlCommand cmd12 = new SqlCommand("insert into issue_tbl (is_id,v_id,amount) values (@is_id,@v_id,@amount)", con);
        cmd.ExecuteNonQuery();


        con.Close();
        GridView1.EditIndex = -1;

        display();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        display();
    }
}
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

public partial class Category : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                Response.Redirect("Owner_Login.aspx");
            }
            countdata();
            
        }

    }

    void insert()
    {
        string id = Label3.Text;
        string name = TextBox1.Text;
        try
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
            {
                con.Open();
                string query = "insert into Category( Category_id,Category_name) values(@Category_id,@Category_name)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Category_id", id);
                    cmd.Parameters.AddWithValue("@Category_name", name);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Page.RegisterStartupScript("msg", "<script>alert('inserted');</script>");
                    TextBox1.Text = " ";
                    countdata();

                }
            }
        }
        catch (Exception ex)
        {
            Page.RegisterStartupScript("msg", "<script>alert('not inserted');</script>" + ex.Message);
        }

    }


    public void countdata()
    {
        int count = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        cmd.CommandText = "SELECT count(*) FROM Category";

        cmd.Connection = con;
        da.Fill(ds);
        count = Convert.ToInt32(cmd.ExecuteScalar());
        count++;
        Label3.Text = "CID" + count.ToString();
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text))
        {
            // Show error message or handle validation failure
            // For example:
            Page.RegisterStartupScript("msg", "<script>alert('required');</script>");
            return;
        }
        insert();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = " ";
    }
}
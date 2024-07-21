using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class feed_buy : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
          if (!IsPostBack)
        {
            countdata();
           // display();
            //display1();
           // display2();
            Label1.Visible = false;
            Label2.Visible = false;
        }

    }
     public void countdata()
    {
        int count = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        cmd.CommandText = "SELECT count(*) FROM fee";

        cmd.Connection = con;
        da.Fill(ds);
        count = Convert.ToInt32(cmd.ExecuteScalar());
        count++;
        Label1.Text = count.ToString() + "CID";
        con.Close();
    }
     protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("select vendor_id from Product where product_id ='" + TextBox1.Text + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();

        if (dt.Rows.Count > 0)
        {
            // editddlid.Text = dt.Rows[0][0].ToString();
            Label5.Text = dt.Rows[0][0].ToString();
           
        }
        try
        {
            string id = Label1.Text;
            string pid = TextBox1.Text;
            string feedback = TextBox2.Text;
            string vendor_id = Label5.Text;

            using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
            {
                con1.Open();
                string query = "insert into fee(feed_id,product_id,vendor_id,feedback) values(@feed_id,@product_id,@vendor_id,@feedback)";
                using (SqlCommand cmd = new SqlCommand(query, con1))
                {
                    cmd.Parameters.AddWithValue("@feed_id", id);
                   
                    cmd.Parameters.AddWithValue("@product_id", feedback);
                    cmd.Parameters.AddWithValue("@vendor_id", vendor_id);
                     cmd.Parameters.AddWithValue("@feedback", pid);
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    Page.RegisterStartupScript("msg", "<script>alert('inserted');</script>");
                    TextBox1.Text = " ";
                    TextBox2.Text = " ";
                    countdata();

                }
            }
        }
        catch (Exception ex)
        {
            Page.RegisterStartupScript("msg", "<script>alert('inserted');</script>" + ex.Message);
        }



    }
    


}
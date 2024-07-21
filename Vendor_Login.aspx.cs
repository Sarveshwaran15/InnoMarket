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

public partial class Vendor_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

   

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string uid = txtUserName.Text;
            string pass = txtPWD.Text;
            con.Open();
            string qry = "SELECT * FROM vendor WHERE vendor_id=@vendor_id AND password=@password";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@vendor_id", uid);
            cmd.Parameters.AddWithValue("@password", pass);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string role = sdr["status"].ToString(); // Assuming role is stored in a column named 'status'
                if (role == "approved")
                {
                    Session["TextboxValue"] = txtUserName.Text;
                    Session["VendorID"] = uid;

                    // Set a session variable to indicate that the user is authenticated
                    Session["Authenticated"] = true;
                    Response.Redirect("Product.aspx");
                }
                else if (role == "Pending")
                {
                    Session["TextboxValue"] = txtUserName.Text;
                    Response.Redirect("Message.aspx");
                }
            }
            else
            {
                // User not found or invalid credentials, show alert message
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid username or password');</script>");
            }

            // Close the first connection
            con.Close();

            // Open a new connection
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT vendor_name FROM vendor WHERE vendor_id = @vendor_id", con1);
            da.SelectCommand.Parameters.AddWithValue("@vendor_id", txtUserName.Text);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con1.Close();

            if (dt1.Rows.Count > 0)
            {
                Label1.Text = dt1.Rows[0]["vendor_name"].ToString();
                Session["v_name"] = Label1.Text;
            }
        }
        catch (Exception ex)
        {
            // Log the error or display a generic error message
            Response.Write("An error occurred: " + ex.Message);
        }
        finally
        {
            // Make sure to close connections in a finally block to ensure they are closed even if an exception occurs
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
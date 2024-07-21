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



public partial class Owner_Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string uid = txtUserName.Text;
            string pass = txtPWD.Text;

            con.Open();
            string qry = "SELECT * FROM admin WHERE username=@username AND password=@password";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@username", uid);
            cmd.Parameters.AddWithValue("@password", pass);

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string role = sdr["role"].ToString(); // Assuming role is stored in a column named 'role'
                if (role == "admin")
                {
                    Session["TextboxValue"] = txtUserName.Text;
                    // Set a session variable to indicate that the user is authenticated
                    Session["Authenticated"] = true;
                    Response.Redirect("Category.aspx");
                }
                /* else if (role == "user")
                 {
                     Session["TextboxValue"] = txtUserName.Text;
                     Response.Redirect(".aspx");
                 }
                 else
                 {
                     // Unexpected role, show alert message
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid role');</script>");
                 }*/
            }
            else
            {
                // User not found or invalid credentials, show alert message
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid username or password');</script>");
            }

            con.Close();
        }
        catch (Exception ex)
        {
            // Log the error or display a generic error message
            Response.Write("An error occurred: " + ex.Message);
        }


    }


}

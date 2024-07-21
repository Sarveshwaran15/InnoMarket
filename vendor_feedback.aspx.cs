using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class vendor_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Authenticated"] == null || !(bool)Session["Authenticated"])
            {
                // Redirect the user to the login page if they are not authenticated
                Response.Redirect("Vendor_Login.aspx");
            }
            // Check if VendorID is available in session
            if (Session["VendorID"] != null)
            {
                string vendorID = Session["VendorID"].ToString();
                lblUsername.Text = vendorID;
                // Populate GridView with feedback data
                DisplayFeedback(vendorID);
            }
            else
            {
                // Handle the case where VendorID is not found in the session
                // For example, redirect the user to the login page
                Response.Redirect("Login.aspx");
            }
        }
    }

    void DisplayFeedback(string vendorID)
    {
        // Retrieve feedback data from the database based on vendorID
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM fee WHERE vendor_id = @VendorID", con))
            {
                cmd.Parameters.AddWithValue("@VendorID", vendorID);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // If feedbacks are found, bind the data to GridView
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // If no feedbacks are found, display a message
                        lblFeedbackMessage.Text = "No feedbacks found for this vendor.";
                    }
                }
            }
        }
    }

}

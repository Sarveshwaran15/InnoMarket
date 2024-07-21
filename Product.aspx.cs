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

public partial class Product : System.Web.UI.Page
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
            countdata();
            dropdown();

            lblUsername.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
           string vendorID = Session["VendorID"].ToString();
            // string email = Session["email"] as string;

            // Assign values to labels
         lblUsername.Text = vendorID;

        }
    }


    void insert()
    {
        string product_id = Label4.Text;
        string product_name = TextBox1.Text;
        string selectedItem = DropDownList1.SelectedValue;

        // Split the selected item by '/'
        string[] categoryParts = selectedItem.Split('/');

        // Extract the category ID and category name
        string category_id = categoryParts[0];
        string category_name = categoryParts[1];
        string quantity = TextBox2.Text;
        string rate = TextBox3.Text;
        string royalty = Label9.Text;
        string maintenance = Label8.Text;
        string vendor_id = lblUsername.Text;
        double t2 = double.Parse(TextBox4.Text);
        //string ex10 = TextBox3.Text;
        string status = "issued";
        string tot = "0";
        int ex20 = int.Parse(rate);
        //int a1 = int.Parse(royalty);
        double a1 = 0.01 * ex20;

        Label9.Text = a1.ToString();
        // int m = int.Parse(maintenance);
        double m = 0.02 * ex20;
        string id = "6";
        Label10.Text = m.ToString();
        double t = ex20 + 0.01 * ex20 + 0.02 * ex20;
        tot = t.ToString();
        if (t < t2)
        {
            //TextBox4.Text = tot;
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
                {
                    con.Open();
                    DateTime today = DateTime.Today;

                    // Convert the date to a string in the desired format
                    string todayString = today.ToString("yyyy-MM-dd");
                    // Assuming category_id and category_name are concatenated with '/'
                   // string[] categoryParts = category_id.Split('/'); // Splitting the concatenated string

                    // Assuming the category_id is the first part after splitting
                    //string actual_category_id = categoryParts[0];

                    string query = "insert into Product(product_id,product_name,quantity,rate,royalty,maintenance,category_id,vendor_id,status,id,tot,date_column) values(@product_id,@product_name,@quantity,@rate,@royalty,@maintenance,@category_id,@vendor_id,@status,@id,@tot,@date_column)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@product_id", product_id);
                        cmd.Parameters.AddWithValue("@product_name", product_name);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@rate", rate);
                        cmd.Parameters.AddWithValue("@royalty", a1);
                        cmd.Parameters.AddWithValue("@maintenance", m);
                      //  cmd.Parameters.AddWithValue("@category_id", actual_category_id);   
                        cmd.Parameters.AddWithValue("@category_id", category_name);
                        cmd.Parameters.AddWithValue("@vendor_id", vendor_id);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@tot", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@date_column", todayString);


                        cmd.ExecuteNonQuery();
                        con.Close();
                        Page.RegisterStartupScript("msg", "<script>alert('inserted');</script>");

                    }
                }
            }
            catch (Exception ex)
            {
                Page.RegisterStartupScript("msg", "<script>alert('inserted');</script>" + ex.Message);
            }
        }
        else
        {
            Page.RegisterStartupScript("msg", "<script>alert('Give amount more than $`t`');</script>");
        }

    }



    public void countdata()
    {
        int count = 0;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        cmd.CommandText = "SELECT count(*) FROM Product";

        cmd.Connection = con;
        da.Fill(ds);
        count = Convert.ToInt32(cmd.ExecuteScalar());
        count++;
        Label4.Text = "PID" + count.ToString();
        con.Close();
    }
    public void dropdown()
    {


        SqlCommand cmd = new SqlCommand("select Category_id+'/'+Category_name from Category", con);
        //SqlCommand cmd = new SqlCommand("SELECT Category_id + '\\' + Category_name FROM Category", con);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        DropDownList1.Items.Clear();

        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(dt.Tables[0].Rows[i][0].ToString());

        }
        DropDownList1.Items.Insert(0, new ListItem("Select", "0"));

        //  display();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        insert();
        countdata();
    }
}
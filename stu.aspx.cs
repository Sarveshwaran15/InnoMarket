using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class stu : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        display2();
    }

    void display2()
    {
        using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select product_name,quantity,tot from Product", con);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dr.Fill(dataTable);
            Repeater1.DataSource = dataTable;
            Repeater1.DataBind();
            con.Close();
        }
    }
}
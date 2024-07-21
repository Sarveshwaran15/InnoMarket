using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class shop_feedback : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display1();
        }
    }

    void display1()
    {
        using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM fee", con1))
            {
                using (SqlDataAdapter dr = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dr.Fill(dt);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
        }
    }

}
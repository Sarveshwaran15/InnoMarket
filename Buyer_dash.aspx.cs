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

public partial class Buyer_dash : System.Web.UI.Page
{
     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
    }
         protected void btn_click(object sender, EventArgs e)
        {
             
            if (Page.IsValid)
            {
                string name = txtName.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string product_name = TextBox1.Text;
                string quantity = TextBox2.Text;
                string sta = "pending";
               
 string query = "Select product_id,product_name,rate,quantity from Product where product_name =@productname";

                    /* string query = @"
             DECLARE @ProductName NVARCHAR(50) = @ProductParam;

             SELECT p_id, p_name, price
             FROM product_tbl
             WHERE p_name = @ProductName
         ";*/
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    cmd1.Parameters.AddWithValue("@productname", product_name);
                    //SqlCommand command = new SqlCommand("Insert into order_tbl values  ('" + name + "','" + phoneNumber + "','" + product_name + "','" + quantity + "','" + tot + "','" + a + "')", connection);
                    // cmd1.Parameters.AddWithValue("@ProductParam", product_name);
                    //cmd1.Parameters.AddWithValue("@ProductName", product_name);
                    con.Open();
                    //SqlDataReader reader = cmd1.ExecuteReader();
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        //reader.Read();
                        if (reader.Read())
                        {
                            string m = reader.GetString(1);
                            if (m == product_name)
                            {
                                string a = reader.GetString(0);

                                string b = reader.GetString(2);
                                int c = int.Parse(quantity);
                                int d = int.Parse(b);
                                int e1 = c * d;
                                string s1 = reader.GetString(3);

                                string tot = e1.ToString();
                                reader.Close();
                                // cmd1.Parameters.AddWithValue("@name1", name);
                                //cmd1.Parameters.AddWithValue("@phoneNumber1", phoneNumber);
                                //cmd1.Parameters.AddWithValue("@product_name1", product_name);
                                //cmd1.Parameters.AddWithValue("@quantity1", quantity);
                                //cmd1.Parameters.AddWithValue("@tot1", tot);
                                //cmd1.Parameters.AddWithValue("@a1", a);
                                // string q1 = " Insert into order_tbl values(name,phoneNumber,product_name,quantity,tot,a)" ;
                                //connection.Close();

                                // SqlConnection updateConnection = new SqlConnection(connection);
                                // SqlCommand command = new SqlCommand("Insert into order_tbl values  ('" + name + "','" + phoneNumber + "','" + product_name + "','" + quantity + "','" + tot + "','" + a + "')", connection);
                                // int b1 = command.ExecuteNonQuery();
                                string insertQuery = "Insert into ord_tbl2 values (@Name, @PhoneNumber, @ProductName, @Quantity, @tot,@st, @a)";
                                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                                insertCmd.Parameters.AddWithValue("@Name", name);
                                insertCmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                                insertCmd.Parameters.AddWithValue("@ProductName", product_name);
                                insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                                insertCmd.Parameters.AddWithValue("@tot", tot);
                                insertCmd.Parameters.AddWithValue("@st", sta);
                                insertCmd.Parameters.AddWithValue("@a", a);
                                
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                               // string q = "Select product_tbl.availability,order_tbl.quantity from product_tbl inner join order_tbl on product_tbl.p_id=order_tbl.quantity";
                                int s = int.Parse(s1);
                                int avail = s - c;
                                if (avail <= 0)
                                {
                                    avail = 0;
                                    string avail1 = avail.ToString();
                                    SqlCommand d1 = new SqlCommand("Update Product set quantity = " + avail1 + " where product_id = " + a + ";", con);
                                    int d4 = d1.ExecuteNonQuery();
                                    //ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('There is no availability :)');", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('There is no availability');", true);
                                }
                                if (avail > 0)
                                {
                                    string avail1 = avail.ToString();
                                    SqlCommand c1 = new SqlCommand("Update Product set quantity = " + avail1 + " from Product join ord_tbl2 on Product.product_id = ord_tbl2.p_id;", con);
                                    int d5 = c1.ExecuteNonQuery();
                                }
                            }
                        }
                         //reader.Close();

                        








                        con.Close();





                        Response.Redirect("Order_page.aspx?value=" + phoneNumber + "&sta=" + sta);



                    }
                }
            }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
           Response.Redirect("Feedback_form.aspx");
        }


}


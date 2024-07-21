using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class vendor_register : System.Web.UI.Page
{
     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
     protected void Page_Load(object sender, EventArgs e)
     {

         if (!IsPostBack)
         {
             countdata();
             Panel2.Visible = false;
             Panel3.Visible = false;
             

         }

     }
     void countdata()
     {
         int count = 0;
         con.Open();
         SqlCommand cmd = new SqlCommand();
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();

         cmd.CommandText = "SELECT count(*) FROM vendor";

         cmd.Connection = con;
         da.Fill(ds);
         count = Convert.ToInt32(cmd.ExecuteScalar());
         count++;
         Label20.Text = "VID" + count.ToString();
         Label21.Text = "VID" + count.ToString();
         con.Close();
     }
     protected void Button1_Click(object sender, EventArgs e)
     {
         con.Open();
         string role = Button1.Text;
         string vendorName = txtVendorName.Text;
         string phoneNumber = txtPhoneNumber.Text;
         int age = Convert.ToInt32(txtAge.Text);
         string address = txtAddress.Text;
         string gender = ddlGender.SelectedValue;
         string password = txtPassword.Text;
         string date = txtDate.Text;
         string v_id = Label21.Text;
         string status = "pending";
         string id = "6";
         string img = "img";
        // string role = "Student";
         string dept = TextBox7.Text;
         string batch = TextBox8.Text;
         string regno = TextBox9.Text;
        // string year = "img";
         string companyName = "";
         string amount = "0";
         string email = "";
         string is_id = "STU";
         string query = "INSERT INTO vendor (vendor_id,vendor_name,phone,age,address,gender,status,password,id,date_column,image2,batch,REGNO,DEPT,designation,companyName,email) VALUES (@vendor_id, @vendor_name, @phone, @age, @address, @gender, @status,@password,@id,@date_column,@image2,@batch,@REGNO,@DEPT,@designation,@companyName,@email)";
         string q2 = "insert into issue_tbl (is_id,v_id,amount) values(@is_id,@v_id,@amount)";
         using (SqlCommand command = new SqlCommand(query, con))
         {
             

                 command.Parameters.AddWithValue("@vendor_id", v_id);
                 command.Parameters.AddWithValue("@vendor_name", vendorName);
                 command.Parameters.AddWithValue("@phone", phoneNumber);
                 command.Parameters.AddWithValue("@age", age.ToString());
                 command.Parameters.AddWithValue("@address", address);
                 command.Parameters.AddWithValue("@gender", gender);
                 command.Parameters.AddWithValue("@status", status);
                 command.Parameters.AddWithValue("@password", password);
                 command.Parameters.AddWithValue("@id", id);
                 command.Parameters.AddWithValue("@image2", img);
                 command.Parameters.AddWithValue("@date_column", date);

                 command.Parameters.AddWithValue("@batch", batch);
                 command.Parameters.AddWithValue("@REGNO", regno);
                 command.Parameters.AddWithValue("@DEPT", dept);
                 command.Parameters.AddWithValue("@designation", role);

                 command.Parameters.AddWithValue("@companyName", companyName);
              command.Parameters.AddWithValue("@email", email);
             
             command.ExecuteNonQuery();
             Page.RegisterStartupScript("msg", "<script>alert('inserted');</script>");
             using (SqlCommand command8 = new SqlCommand(q2, con))
             {
                 command8.Parameters.AddWithValue("@is_id", is_id);
                 command8.Parameters.AddWithValue("@v_id", v_id);
                 command8.Parameters.AddWithValue("@amount", amount);
                 command8.ExecuteNonQuery();
             }
             con.Close();
         }

         countdata();
         //con.Close();
     }



     protected void Button1_Click1(object sender, EventArgs e)
     {
         Panel2.Visible = true;
         Panel1.Visible = false;
     }
     protected void Button2_Click(object sender, EventArgs e)
     {
         Panel3.Visible = true;
         Panel1.Visible = false;
     }
     protected void Button3_Click(object sender, EventArgs e)
     {
         con.Open();
         string role = Button2.Text;
         string vendorName = TextBox1.Text;
         string phoneNumber = TextBox2.Text;
         int age = Convert.ToInt32(TextBox3.Text);
         string address = TextBox4.Text;
         string gender = DropDownList1.SelectedValue;
         string password = TextBox5.Text;
         string date = TextBox6.Text;
         string v_id = Label20.Text;
         string status = "pending";
         string id = "7";
         string img = "img";
        // string role = "StartUp";
         string dept = "";
         string batch = "";
         string regno = "";
         // string year = "img";
         string companyName = TextBox10.Text;
         string email = TextBox11.Text;
         string query = "INSERT INTO vendor (vendor_id,vendor_name,phone,age,address,gender,status,password,id,date_column,image2,batch,REGNO,DEPT,designation,companyName,email) VALUES (@vendor_id, @vendor_name, @phone, @age, @address, @gender, @status,@password,@id,@date_column,@image2,@batch,@REGNO,@DEPT,@designation,@companyName,@email)";
         using (SqlCommand command = new SqlCommand(query, con))
         {


             command.Parameters.AddWithValue("@vendor_id", v_id);
             command.Parameters.AddWithValue("@vendor_name", vendorName);
             command.Parameters.AddWithValue("@phone", phoneNumber);
             command.Parameters.AddWithValue("@age", age.ToString());
             command.Parameters.AddWithValue("@address", address);
             command.Parameters.AddWithValue("@gender", gender);
             command.Parameters.AddWithValue("@status", status);
             command.Parameters.AddWithValue("@password", password);
             command.Parameters.AddWithValue("@id", id);
             command.Parameters.AddWithValue("@image2", img);
             command.Parameters.AddWithValue("@date_column", date);

             command.Parameters.AddWithValue("@batch", batch);
             command.Parameters.AddWithValue("@REGNO", regno);
             command.Parameters.AddWithValue("@DEPT", dept);
             command.Parameters.AddWithValue("@designation", role);

             command.Parameters.AddWithValue("@companyName", companyName);
             command.Parameters.AddWithValue("@email", email);

             command.ExecuteNonQuery();
             Page.RegisterStartupScript("msg", "<script>alert('inserted');</script>");
             con.Close();
         }
         countdata();
         //con.Close();
     }
}
   

    
   



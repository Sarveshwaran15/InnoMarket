using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class cart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
    String qty1, tbqty1, ordPRD, ordQTY, ordRATE;
    String rate1;
    protected int prdRate;
    protected int OrdrRATE;
    protected int cnt;
    private static int currentQty;
    // DateTime insertionTime; 
    // private static int confirmClickTime;
    int count;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //status.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);

            if (Request.QueryString["prd"] != null)
            {
                // Retrieve the value of "prd" from the query string
                string prdValue = Request.QueryString["prd"];

                // Set the value to the Label control
                Label2.Text = prdValue;
            }

        }

    }
    void disp()
    {
        //SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\balu_\source\repos\webApp\webApp\App_Data\Database1.mdf;Integrated Security=True");

        using (SqlCommand cmd = new SqlCommand("select * from Orders", con))
        {
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet dt = new DataSet();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        disp();

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\balu_\source\repos\webApp\webApp\App_Data\Database1.mdf;Integrated Security=True");

        string item_name = (GridView1.Rows[e.RowIndex].FindControl("StatusTextBox") as TextBox).Text;
        //  int sno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);//
        int sno = 151;
        con.Open();
        SqlCommand cmd = new SqlCommand("update Orders set status='" + item_name + "' where Id='" + sno + "'", con);

        cmd.ExecuteNonQuery();
        GridView1.EditIndex = -1;
        disp();

    }
     protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //DateTime  entryTime = DateTime.Now;
          //  SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\balu_\source\repos\webApp\webApp\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();


            SqlDataAdapter da = new SqlDataAdapter("select quanatity,total from product where product_name ='" + Label2.Text + "'", con);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {

                qty1 = dt1.Rows[0][0].ToString();
                rate1 = dt1.Rows[0][1].ToString();


            }
            currentQty = int.Parse(qty1);
            cnt = int.Parse(Label1.Text);
            int sm = currentQty - cnt;



            prdRate = int.Parse(rate1);
            OrdrRATE = prdRate * cnt;
            //Label6.Text = sm.ToString();

            string updateQuery = "UPDATE product SET quantity = @qty WHERE product_name = @prd";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
            {
                updateCommand.Parameters.AddWithValue("@prd", Label2.Text);
                updateCommand.Parameters.AddWithValue("@qty", sm);
                updateCommand.ExecuteNonQuery();
            }


            String Status = "denied";
            string query = "INSERT INTO orders(product_name, quantity,DateField,total,status) VALUES (@prd, @qty,@EntryTime,@rate,@status)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                DateTime entryTime = DateTime.Now;

                command.Parameters.AddWithValue("@prd", Label2.Text);
                command.Parameters.AddWithValue("@qty", Label1.Text);
                command.Parameters.AddWithValue("@EntryTime", entryTime);
                command.Parameters.AddWithValue("@rate", OrdrRATE);
                command.Parameters.AddWithValue("@status", Status);
                command.ExecuteNonQuery();
            }
            disp1();
        }
      void disp1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\balu_\source\repos\webApp\webApp\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();

            using (SqlCommand selectCommand = new SqlCommand("SELECT Id, prd, qty, time FROM [order] WHERE status = 'denied'", con))
            {
                    // Load all data into a list
                    List<(string prd, TimeSpan time, long Id, int qty)> orders = new List<(string, TimeSpan, long, int)>();

                    // Execute the SELECT command
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        // Iterate through the results
                        while (reader.Read())
                        {
                            string prd = reader.GetString(1);
                            TimeSpan orderTimeOfDay = reader.GetTimeSpan(3); // Get the time as TimeSpan
                            long orderId = reader.GetInt64(0); // Retrieve Id as long
                            int Ordqty = reader.GetInt32(2); // Retrieve quantity as int

                            orders.Add((prd, orderTimeOfDay, orderId, Ordqty));
                        }
                    }

                    // Process orders after closing the first SqlDataReader
                    foreach (var order in orders)
                    {
                        string ordrprd = order.prd;
                        TimeSpan orderTimeOfDay = order.time;
                        long orderId = order.Id;
                        int Ordqty = order.qty;
                        TimeSpan currentTime = DateTime.Now.TimeOfDay;

                        TimeSpan timeDifference = currentTime - orderTimeOfDay;


                        SqlDataAdapter da2 = new SqlDataAdapter("select qty from prdtb WHERE prd ='" + ordrprd + "'", con);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {

                            tbqty1 = dt2.Rows[0][0].ToString();


                        }
                        int tbqty = int.Parse(tbqty1);

                        int updatedQty = tbqty + Ordqty;

                       // Label3.Text = tbqty.ToString();
                       // Label4.Text = Ordqty.ToString();
                       // Label5.Text = updatedQty.ToString();
                       //Label6.Text = ordrprd.ToString();                                               

                        // If time difference is greater than 10 seconds
                        if (timeDifference.TotalSeconds > 20)
                        {
                        using (SqlCommand updateCommand = new SqlCommand("UPDATE prdtb SET qty = @qty WHERE prd = @orderName", con))
                        {
                            updateCommand.Parameters.AddWithValue("@orderName", ordrprd);
                            updateCommand.Parameters.AddWithValue("@qty", updatedQty);

                            updateCommand.ExecuteNonQuery();
                        }
                        using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM [order] WHERE status ='denied' AND id = @orderId", con))

                        //using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM [order] WHERE id = @orderId", con))
                        {
                            deleteCommand.Parameters.AddWithValue("@orderId", orderId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }                   
                     }
             }
            
            disp();
            SqlDataAdapter da3 = new SqlDataAdapter("SELECT prd, qty,rate FROM [order] WHERE status <> 'denied'", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {

                ordPRD = dt3.Rows[0][0].ToString();
                ordQTY = dt3.Rows[0][1].ToString();
                ordRATE = dt3.Rows[0][2].ToString();
            }
            //string ordPRD1 = string.Parse(ordPRD);
          //  int ordQTY1 = int.Parse(ordQTY);
            int ordQTY1;            
            //int ordRATE1 = int.Parse(ordRATE);
            int ordRATE1;           
            if (int.TryParse(ordQTY, out ordQTY1) && int.TryParse(ordRATE, out ordRATE1))

            {
                string query = "INSERT INTO [purchased](prd, qty,rate,time) VALUES (@prd, @qty,@rate,@EntryTime)";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    DateTime entryTime = DateTime.Now;


                    command.Parameters.AddWithValue("@prd", ordPRD);
                    command.Parameters.AddWithValue("@qty", ordQTY1);
                    command.Parameters.AddWithValue("@rate", ordRATE1);
                    command.Parameters.AddWithValue("@EntryTime", entryTime);

                    command.ExecuteNonQuery();
                }
            }
                string deleteQuery = "DELETE FROM [order] WHERE status <> 'denied'";
                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, con))
                {
                     deleteCommand.ExecuteNonQuery();
                }
            
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(Label1.Text, out count))
            {
                count++;
                Label1.Text = count.ToString();

            }
        }
       protected void Button2_Click(object sender, EventArgs e)
        {

            if (int.TryParse(Label1.Text, out count))
            {
                count--;
                Label1.Text = count.ToString();
            }
        }




    




}
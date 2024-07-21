<%@ Page Title="" Language="C#" MasterPageFile="~/Shoper.master" AutoEventWireup="true" CodeFile="Buyer_dash.aspx.cs" Inherits="Buyer_dash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="js/JScript.js" ></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
   <body style="background-color:darkslateblue;">

        <div>
            <h1 style="color:gold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:50px;">Buyer Dashboard</h1><hr /><br /><br />
            <h2 style="color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:40px;"> Enter details</h2>
            <asp:Label ID="lblName" style="color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:30px; font-weight:20px;" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                ErrorMessage="Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Label ID="lblPhoneNumber" runat="server"  pattern="[0-9]{10}" style="color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:30px; font-weight:20px;" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                ErrorMessage="Phone number is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Label ID="Label1" style="color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:30px; font-weight:20px;" runat="server" Text="Product Name:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                ErrorMessage="Product name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Label ID="Label2" runat="server" style="color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:30px; font-weight:20px;" Text="Quantity:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                ErrorMessage="Number of quantity is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />
            <h2 style="color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:40px; font-weight:40px;">Products availabile in the store</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="margin-left:120px; background-color:gold; color:black;  font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-weight:50; font-size:30px;" DataSourceID="SqlDataSource1" Height="214px" Width="714px" >
                <Columns >
                        
                    <asp:BoundField DataField="product_name" HeaderText="product name" SortExpression="p_name" />
                    <asp:BoundField DataField="quantity" HeaderText="availability" SortExpression="availability" />
                    <asp:BoundField DataField="rate" HeaderText="price" SortExpression="price" />

                </Columns>
            </asp:GridView><br />
            <asp:Button ID="Button1" runat="server" style=" margin-left:500px;" CssClass ="btn btn-primary" Width="150px"  Text="Make order" OnClick="btn_click" />
            <asp:Button ID="Button2" runat="server" style=" margin-left:100px;" CssClass ="btn btn-success" Width="150px"  Text="Feedback" OnClick="Button2_Click"  />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh" SelectCommand="SELECT [product_id], [product_name], [quantity], [rate] FROM [Product]"></asp:SqlDataSource>
        </div>
        </body>
</asp:Content>


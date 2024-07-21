<%@ Page Title="" Language="C#" MasterPageFile="~/Shoper.master" AutoEventWireup="true" CodeFile="Order_page.aspx.cs" Inherits="Order_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
    body {
      background-color: #f8f9fa;
    }
    .container {
      margin-top: 50px;
    }
    .gridview {
      background-color: #fff;
      border-radius: 10px;
      box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
    }
    .gridview-header {
      background-color: #007bff;
      color: #fff;
      border-top-left-radius: 10px;
      border-top-right-radius: 10px;
      padding: 10px;
    }
    .gridview-header h2 {
      margin: 0;
    }
    .gridview-body {
      padding: 20px;
    }
    .gridview-row {
      border-bottom: 1px solid #ddd;
    }
    .gridview-row:last-child {
      border-bottom: none;
    }
    .gridview-row:hover {
      background-color: #f0f0f0;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <body style="background-color:darkslateblue;">
        <div>
            <div class="container">
    <div class="row">
      <div class="col-md-8 offset-md-2">
        <div class="gridview">
          <div class="gridview-header">
                          <h1 style="color:azure; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:40px; font-weight:40px;">ORDER DETIALS</h1>
 </div>
          <div class="gridview-body">
            <asp:GridView ID="GridView1"  CssClass="table table-striped" runat="server" AutoGenerateColumns="False" style="background-color:gold; margin-left:50px;  color:black;  font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-weight:50px; font-size:30px;" DataSourceID="SqlDataSource1" Height="214px" Width="404px" >
                <Columns >
                        
                    <asp:BoundField DataField="p_name" HeaderText="Product name" SortExpression="p_name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
                    <asp:BoundField DataField="tot_amt" HeaderText="Grand Total" SortExpression="tot_amt" />

                </Columns>
            </asp:GridView><br />
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh"></asp:SqlDataSource>
                        <asp:Button ID="Button1" runat="server" style=" margin-left:300px;" CssClass ="btn btn-primary" Width="150px"  Text="Claim order!" OnClick="claim" />

        </div>
            </body>
</asp:Content>


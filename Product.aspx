<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
<style>
        /* Custom styles */
        .custom-form {
            max-width: 2400px; 
            padding-left:250px;/* Adjust as needed */
           

        }
    </style>
</asp:Content>

   
       
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container custom-form">
<div  style="padding-left:80px;padding-top:10px; ">
    <h1>Add New Products</h1>
    <table>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td style="padding:10px">
                 <asp:Label ID="Label1" runat="server" Text="Category Id"></asp:Label>
            </td>
            <td style="padding:10px">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td style="padding:10px">
                     <asp:Label ID="Label5" runat="server" Text="Product Id"></asp:Label>
            </td>
            <td style="padding:10px">
                   <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td style="padding:10px">
                <asp:Label ID="Label3" runat="server" Text="Product Name"></asp:Label>
            </td>
            <td style="padding:10px">
                 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td style="padding:10px">
                 <asp:Label ID="Label2" runat="server" Text="Total Quantity"></asp:Label>
            </td>
            <td style="padding:10px">
                  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td style="padding:10px">
                   <asp:Label ID="Label6" runat="server" Text="Seller Cost"></asp:Label>
            </td>
            <td style="padding:10px">
                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
              </tr>
        <tr>
            <td style="padding:10px">
                   <asp:Label ID="Label11" runat="server" Text="Amount can be priced"></asp:Label>
            </td>
            <td style="padding:10px">
                 <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td style="padding:10px;padding-left:110px;">
                <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="btn btn-danger" />
            </td>
            <td style="padding:10px;padding-left:110px;">
                 <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Button1_Click" />
            </td>
        </tr>

    </table>
   
  
</div>
        <asp:Label ID="Label7" runat="server" Text="Tax For Maintenance"></asp:Label>
           <asp:Label ID="Label8" runat="server" Text =""></asp:Label><br />
           <asp:Label ID="Label10" runat="server" Text="Tax For Royalty"></asp:Label>
           <asp:Label ID="Label9" runat="server" Text =""></asp:Label><br />
   


    <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
         </div>

</asp:Content>


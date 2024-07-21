<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
            <div class="col-md-12">
 
     <div style="padding-top:50px">
       <center> 
        
        <table>
            <tr>
   
                <td><h1 style="padding-bottom:50px;text-align:center"> Category Details</h1> </td><td>
            </tr></div></div>
            <tr>
                <td style="padding:10px"> <asp:Label ID="Label1" runat="server" Text="Category Id"></asp:Label></td>
                <td style="padding:10px"> <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="padding:10px">
                     <asp:Label ID="Label2" runat="server" Text="Category Name"></asp:Label>
                </td>
                <td style="padding:10px"> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="padding-left:150px;padding-top:10px"><asp:Button ID="Button2" CssClass=" btn btn-lg btn-danger"  runat="server" Text="Clear" OnClick="Button2_Click"></asp:Button></td>
              <td style="padding-left:10px;padding-top:10px"> <asp:Button ID="Button1" runat="server" CssClass=" btn btn-lg btn-primary" Text="Submit" OnClick="Button1_Click" /></td>
            </tr>
        </table>
        
        </center>

   </div>   
</asp:Content>


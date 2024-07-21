<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor.master" AutoEventWireup="true" CodeFile="Vendor_Product.aspx.cs" Inherits="Vendor_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
    /* Custom styles for textbox and button */
    .form-control-custom {
        border: 1px solid #ced4da; /* Light gray border */
        border-radius: 0.25rem; /* Slightly rounded corners */
        padding: 0.375rem 0.75rem; /* Padding for comfortable input */
        transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out; /* Smooth transition */
    }

    .form-control-custom:focus {
        border-color: #80bdff; /* Border color on focus */
        outline: 0; /* Remove default focus outline */
        box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25); /* Focus shadow */
    }

    .btn-custom {
        color: #fff; /* White text color */
        background-color: #007bff; /* Blue background color */
        border-color: #007bff; /* Blue border color */
        border-radius: 0.25rem; /* Slightly rounded corners */
        padding: 0.375rem 0.75rem; /* Padding for comfortable button size */
        transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out; /* Smooth transition */
    }

    .btn-custom:hover {
        color: #fff; /* White text color on hover */
        background-color: #0056b3; /* Darker blue background color on hover */
        border-color: #0056b3; /* Darker blue border color on hover */
    }

    .btn-custom:focus {
        color: #fff; /* White text color on focus */
        background-color: #0056b3; /* Darker blue background color on focus */
        border-color: #0056b3; /* Darker blue border color on focus */
        box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.5); /* Focus shadow */
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:Label ID="lblUsername" runat="server" ></asp:Label>
   <div class="table-responsive">
       </div><div class="container mt-5">
    <div><center style="color:white;font-size:24px"><h1 class="text-center text-white">Waiting for Approval</h1></center></div>
    <div><div class="row justify-content-center my-3">
    <div class="col-md-4">
        <div class="input-group">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control-custom" placeholder="Enter your text here"></asp:TextBox>
            
                <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-custom rounded-right" />
            
        </div>
    </div>
</div>

        </div>
        </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="99%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
         
           
                    <asp:BoundField  HeaderText="Product Id" DataField="product_id"/>
                     <asp:BoundField  HeaderText="Product Name" DataField="product_name"/>
                     <asp:BoundField  HeaderText="Quantity" DataField="quantity"/>
                     <asp:BoundField  HeaderText="Rate" DataField="rate"/>
                    
           

        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

</asp:Content>


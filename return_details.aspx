<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="return_details.aspx.cs" Inherits="return_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        /* Custom CSS */
        .container {
            margin-top: 50px;
        }

        .search-container {
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="search-container ">
            <h1>Product List</h1>
            <div class="input-group col-md-4">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by Product ID or name"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <asp:GridView ID="gvProducts" runat="server" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Date_Column" HeaderText="Date" />
                <asp:BoundField DataField="Vendor_Id" HeaderText="Vendor ID" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

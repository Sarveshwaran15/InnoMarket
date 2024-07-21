<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor.master" AutoEventWireup="true" CodeFile="Purchased_Details_Vendor.aspx.cs" Inherits="Purchased_Details_Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Additional custom styles */
        body {
            background-color: #0a4580; /* Light gray background */
        }

        .custom-container {
            margin-top: 10px;
        }

        .search-bar {
            margin-bottom: 10px;
        }

        .grid-header {
            background-color: #142d4c; /* Dark blue header */
            color: #ffffff; /* White text color */
            font-size: 24px;
            padding: 10px;
            text-align: center;
            border-radius: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container custom-container">
        <div class="row">
            <div class="col-md-12">
                <div class="grid-header">Available Products</div><br />
            </div>
        </div>
        <div class="row search-bar">
            <div class="col-md-3">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-success" OnClick="Button1_Click" />
            </div>
            <div class="col-md-2">
                From <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="From"></asp:TextBox>
            </div>
            <div class="col-md-2">
                To <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="To"></asp:TextBox>
            </div>
            <div class="col-md-2 mt-4">
                <asp:Button ID="Button2" runat="server" Text="Search" CssClass="btn btn-success" OnClick="Button2_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped">
                    <HeaderStyle CssClass="thead-dark" />
                    <PagerStyle BackColor="#142d4c" Height="20px" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

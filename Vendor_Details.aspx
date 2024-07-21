<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="Vendor_Details.aspx.cs" Inherits="Vendor_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Custom Styles */
        body {
            background-color: #f8f9fa;
        }
        .page-title {
            color: #007bff;
            font-size: 36px;
            margin-top: 20px;
            margin-bottom: 30px;
            text-align: center;
        }
        .search-box {
            margin-bottom: 20px;
            padding:10px;
            text-align: center;
        }
        /* Animation Styles */
        @keyframes fadeInUp {
            from {
                opacity: 0;
                transform: translateY(20px);
            }
            to {
                opacity: 1;
                transform: translateY(0);
            }
        }
        .animated {
            animation-duration: 1s;
            animation-fill-mode: both;
        }
        .fadeInUp {
            animation-name: fadeInUp;
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
    <div class="container">
        <div class="page-title animated fadeInUp" style="background-color:aliceblue;">
            Official Vendors
        </div><h2 class ="text-white">Search for vendors</h2>
        <div class="search-box col-md-4">
            <div class="d-flex flex-row align-items-center">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox><br /><br />
          
         <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="btn btn-primary" />
                </div>
           
        </div> <div class="row">
            <div class="col-md-12">
        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="false">
                <AlternatingRowStyle BackColor="#f2f2f2" />
                <HeaderStyle BackColor="#007bff" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#142d4c" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField DataField="vendor_id" HeaderText="Vendor Id" />
                    <asp:BoundField DataField="vendor_name" HeaderText="Vendor Name" />
                    <asp:BoundField DataField="age" HeaderText="Age" />
                    <asp:BoundField DataField="gender" HeaderText="Gender" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="password" HeaderText="Password" />
                </Columns>
            </asp:GridView>
            </div></div>
        </div>
    </div>
    <!-- Include Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

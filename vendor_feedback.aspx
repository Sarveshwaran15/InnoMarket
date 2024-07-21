<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor.master" AutoEventWireup="true" CodeFile="vendor_feedback.aspx.cs" Inherits="vendor_feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Custom CSS for card design */
        .card {
            border: 1px solid rgba(0, 0, 0, 0.125); /* Gray border */
            border-radius: 0.25rem; /* Rounded corners */
            margin-bottom: 20px; /* Spacing between cards */
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Card shadow */
        }

        .card-header {
            background-color: #007bff; /* Blue header background */
            color: white; /* White header text */
            border-bottom: 1px solid rgba(0, 0, 0, 0.125); /* Gray border bottom */
            border-radius: 0.25rem 0.25rem 0 0; /* Rounded top corners */
            padding: 0.75rem 1.25rem; /* Padding */
        }

        .card-body {
            padding: 1.25rem; /* Padding */
        }

        .table {
            margin-bottom: 0; /* Remove margin bottom from the table */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="card">
            <div class="card-header">
                <asp:Label ID="lblUsername" runat="server"></asp:Label> - Vendor ID
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped"></asp:GridView>
                </div>
            </div>
        </div>
       

    </div>
     <asp:Label ID="lblFeedbackMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</asp:Content>

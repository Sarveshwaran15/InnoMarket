<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="shop_feedback.aspx.cs" Inherits="shop_feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Include Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    
    <!-- Custom CSS -->
    <style>
        /* Custom styles for page elements */
        .container {
            padding-top: 20px;
        }
        
        .card {
            border: 2px solid #007bff; /* Blue border */
            border-radius: 10px;
        }
        
        .card-header {
            background-color: #007bff; /* Blue header background */
            color: white; /* White header text */
        }
        
        /* Animation */
        @keyframes fadeIn {
            from {
                opacity: 0;
            }
            to {
                opacity: 1;
            }
        }

        .fadeIn {
            animation-name: fadeIn;
            animation-duration: 1s;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container fadeIn">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">
                        Feedback List
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-striped"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

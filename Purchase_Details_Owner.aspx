<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="Purchase_Details_Owner.aspx.cs" Inherits="Purchase_Details_Owner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Custom styles can be added here */
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
        <div class="row justify-content-center mt-5">
            <div class="col-md-12 text-left">
                <h2 class="text-white">Purchased Products</h2>
            </div>
        </div>
        <div class="row justify-content-left mt-3">
           <div class="col-md-4">
    <div class="d-flex flex-row align-items-center">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-primary ml-2" OnClick="Button1_Click" />
    </div>
</div>

            <div class="col-md-4 mb-15">From
                 <div class="d-flex flex-row align-items-center">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                     </div></div>
               
                  <div class="col-md-4">To
                       <div class="d-flex flex-row align-items-center">
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control mt-2"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Search" CssClass="btn btn-primary ml-2" OnClick="Button2_Click" />
                     </div>
            </div>
        </div>
        <div class="row">
        <div class="row justify-content-center mt-5">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered">
                    <HeaderStyle BackColor="#3399FF" Height="40px" />
                    <PagerStyle BackColor="#6666FF" Height="20px" />
                </asp:GridView>
            </div>
        </div>
            </div>
    </div>
</asp:Content>

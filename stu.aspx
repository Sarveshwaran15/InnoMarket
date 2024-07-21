<%@ Page Title="" Language="C#" MasterPageFile="~/Shoper.master" AutoEventWireup="true" CodeFile="stu.aspx.cs" Inherits="stu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        /* Custom CSS for styling */
        .card {
            margin: 20px;
            border: 1px solid #dee2e6;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s;
            background-color: #E6E6FA; /* Change background color */
        }

        .card:hover {
            transform: translateY(-5px);
        }

        .card-body {
            padding: 20px;
        }

        .card-title {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .card-text {
            font-size: 16px;
            margin-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Product Name: <asp:HyperLink ID="ProductNameLink" runat="server" NavigateUrl='<%# "cart.aspx?prd=" + Server.UrlEncode(Eval("product_name").ToString()) %>' Text='<%# Eval("product_name") %>'></asp:HyperLink></h5>
                            <p class="card-text">Quantity: <%# Eval("quantity") %></p>
                            <p class="card-text">Rate: <%# Eval("tot") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
</asp:Content>

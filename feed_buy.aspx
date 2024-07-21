<%@ Page Title="" Language="C#" MasterPageFile="~/Shoper.master" AutoEventWireup="true" CodeFile="feed_buy.aspx.cs" Inherits="feed_buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        /* Custom CSS for styling */
        .container {
            margin-top: 50px;
            width: 50%;
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #007bff;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
        }

        input[type="text"],
        textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 5px;
        }

        button {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        button:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <h1>Feedback</h1>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Feedback ID"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Product ID"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>

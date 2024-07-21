<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="shop_dash.aspx.cs" Inherits="shop_dash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        /* Custom styles */
        .content-background {
            background-color:#00246B;
        }
         .form-container {
            background-color: #f8f9fa;
            border-radius: 5px;
            padding: 10px;
            margin-bottom: 10px;
            margin-right:20px;
        }

        .form-container label {
            font-weight: bold;
            color: #007bff;
        }

        .form-container input[type="text"],
        .form-container input[type="submit"] {
            width: 50%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .form-container input[type="submit"] {
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
        }

        .form-container input[type="submit"]:hover {
            background-color: #0056b3;
        }
        .custom-div {
            background-color: #f8f9fa;
            border: 1px solid #dee2e6;
            border-radius: 5px;
            padding: 10px;
            margin: 20px;
            transition: all 0.3s ease;
        }

        .custom-div:hover {
            transform: scale(1.05);
            box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.1);
        }

        /* Colors */
        .first-div {
            background-color: #007bff;
            color: #fff;
        }

        .second-div {
            background-color: #28a745;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div class="container-fluid">
            <h1 style="animation-delay:inherit; color:aliceblue;">Shop Dashboard</h1>
            <div class="row">
                <!-- First Column -->
                <div class="col-md-6">
                    <!-- First Div -->
                    <div class="custom-div first-div">
                        Number of Products Available
                        <p class="mb-2 fw-bold">
                            <div id="displayDiv2" runat="server">
                            </div>
                        </p>
                    </div>
                    <!-- Third Div -->
                    <div class="custom-div first-div">
                        Number of Vendors
                        <p class="mb-2 fw-bold">
                            <div id="Div2" runat="server">
                            </div>
                        </p>
                    </div>
                    <div class="custom-div second-div">
                        Total Amount
                        <p class="mb-2 fw-bold">
                            <div id="Div1" runat="server">
                            </div>
                        </p>
                    </div>
                     <div class="custom-div second-div">
                        Number of Returns
                        <p class="mb-2 fw-bold">
                            <div id="Div5" runat="server">
                            </div>
                        </p>
                    </div>
                    <!-- Fifth Div -->
                    
                    <!-- Seventh Div -->
                    <div class="form-container">
        <label for="TextBox1">Enter Vendor ID :</label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSubmit_Click2" />
    </div>
                     
                </div>
                <!-- Second Column -->
                <div class="col-md-6">
                    <!-- Second Div -->
                    
                    <!-- Form Section -->
                    <div>
                       
                         <div class="form-container">
                             <label> Enter to get sold details</label><br />
        <label for="txtFromDate">From Date:</label>
        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
        <br />
        <label for="txtToDate">To Date:</label>
        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
        <br />
        <label for="txtVendorID">Vendor ID:</label>
        <asp:TextBox ID="txtVendorID" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
                        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                        <br />
                        <div class="custom-div second-div">
                        Number of Products sold
                        <p class="mb-2 fw-bold">
                            <div id="Div3" runat="server">
                            </div>
                        </p>
                    </div>
                           <div class="custom-div first-div">
                        Amount (Rs.)
                        <p class="mb-2 fw-bold">
                            <div id="Div4" runat="server">
                            </div>
                        </p>
                    </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

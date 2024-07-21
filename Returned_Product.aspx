    <%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="Returned_Product.aspx.cs" Inherits="Returned_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Include Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .grid-header {
            background-color: #142d4c; /* Dark blue header */
            color: #ffffff; /* White text color */
            font-size: 24px;
            padding: 10px;
            text-align: center;
            border-radius: 5px;
        }
         .fade-in {
            animation: fadeIn ease-in-out 0.5s;
        }

        #printPanel {
            border: 1px solid #000;
            padding: 10px;
            width: 50%;
            margin: auto;
        }

        /* Styles for the receipt content */
        .receipt {
            font-family: Arial, sans-serif;
            font-size: 12px;
            text-align: left;
        }

        /* Print styles to hide unnecessary content */
        @media print {
            #btnPrint {
                display: none; /* Hide print button during printing */
            }
        }
        @keyframes fadeIn {
            0% {
                opacity: 0;
            }
            100% {
                opacity: 1;
            }
        }
        
        .slide-up {
            animation: slideUp ease-in-out 0.5s;
        }
        
        @keyframes slideUp {
            0% {
                transform: translateY(100%);
            }
            100% {
                transform: translateY(0%);
            }
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="table-responsive">
             <div class="row">
            <div class="col-md-12">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                     <asp:BoundField DataField="vendorid" HeaderText="Vendor Id" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>' OnClick="btnDelete_Click" CssClass="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                 <HeaderStyle BackColor="darkslateblue" />
                    <PagerStyle BackColor="#142d4c" Height="20px" />

            </asp:GridView>
                </div></div>
            <asp:Label ID="Label1" runat="server" Text="Label" class="text-white"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label" class="text-white"></asp:Label>
        </div>
        <h2 class="text-white">Return Products Entry</h2>
        <div class="form-group col-md-4">
            <label for="txtProductId" class="text-white">Product ID:</label>
            <asp:TextBox ID="txtProductId" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
        </div>
        <div class="form-group col-md-4">
            <label for="txtQuantity" class="text-white">Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTotalAmount" runat="server" Text="" class="text-white"></asp:Label>
           
        </div>
        <div class="form-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add to Grid" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            <asp:Button ID="Button2" runat="server" Text="Finish" CssClass="btn btn-secondary" OnClick="btnConfirm_Click" />
        </div>
        
    </div>

    <div class="container" style="padding-top: 20px;">
        <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="product_name" HeaderText="Product Name" SortExpression="p_name" />
                <asp:BoundField DataField="quantity" HeaderText="Availability" SortExpression="availability" />
                <asp:BoundField DataField="rate" HeaderText="Price" SortExpression="price" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-UE2TSQG0\SQLEXPRESS;Initial Catalog=stu_panel;User ID=sa;Password=sarvesh" SelectCommand="SELECT [product_id], [product_name], [quantity], [rate] FROM [Product]"></asp:SqlDataSource>
    </div>
     <div id="printPanel">
            <!-- Receipt content -->
           <div class="receipt">
    <h2>Billing System Receipt</h2>
    <p>Date: <asp:Label ID="lblDate" runat="server"></asp:Label></p>
    <p>Customer Name: <asp:Label ID="lblCustomerName" runat="server"></asp:Label></p>
    <p>Receipt Number: <asp:Label ID="lblReceiptNumber" runat="server"></asp:Label></p>
</div>
              <!-- Table for items -->
                <table border="1" style="width:100%;">
                    <thead>
                        <tr>
                            <th>Item</th>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Rows for items will be dynamically added here -->
                        <asp:Repeater ID="repeaterItems" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("ProductId") %></td>
                                    <td><%# Eval("Quantity") %></td>
                                    <td><%# Eval("Price", "{0:C2}") %></td>
                                    <td><%# Eval("Total", "{0:C2}") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

                <p>Total Amount: <asp:Label ID="Label4" runat="server"></asp:Label></p>
                <p>Thank you for your business!</p>
            </div>
    </div>
    
</asp:Content>

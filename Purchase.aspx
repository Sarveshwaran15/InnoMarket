<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Purchase" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        /* Add custom CSS for animations */
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
        .grid-header {
            background-color: #142d4c; /* Dark blue header */
            color: #ffffff; /* White text color */
            font-size: 24px;
            padding: 10px;
            text-align: center;
            border-radius: 5px;
        }


    </style>
    <script type="text/javascript">
        function printReceipt() {
            var printContents = document.getElementById('printPanel').innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;

        }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="height: 480px;">
        <div class="row">
            <div class="col">
                <div class="row" style="height: 200px;">
                    <!-- GridView Section -->
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                            <asp:BoundField DataField="vendorid" HeaderText="Vendor ID  " />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>' OnClick="btnDelete_Click" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                  
                    <!-- End GridView Section -->
                    
                    <br /><br />
                    
                    <!-- Labels Section -->
                    <asp:Label ID="Label3" runat="server" Text="price"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <!-- End Labels Section -->
                </div>
               
                <!-- Add Product Section with Fade-in Animation -->
                <div class="row fade-in">
                    <div class="col-md-2">
                        <label for="txtProductId" class="form-label">Product ID:</label>
                        <asp:TextBox ID="txtProductId" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label for="txtQuantity" class="form-label">Quantity:</label>
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lblTotalAmount" runat="server" Text="" CssClass="form-label"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Label" CssClass="form-label"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnAdd" runat="server" Text="Add More" CssClass="btn btn-primary mb-3" OnClick="btnAdd_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="btn btn-success mb-3" OnClick="btnConfirm_Click" />
                        <asp:Button ID="Button3" runat="server" Text="Print" CssClass="btn btn-info" OnClick="Button1_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:GridView ID="GridView3" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
                    </div>
                </div>
                <!-- End Add Product Section -->
            </div>
        </div>
 <!-- Print panel for the receipt -->
      <div id="printPanel">
        <!-- Receipt content -->
        <div class="receipt">
            <h2>Billing System Receipt</h2>
            <p>Date: <asp:Label ID="lblDate" runat="server"></asp:Label></p>
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
                <asp:Repeater ID="repeaterItems" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>'></asp:Label></td>
                            <td><asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label></td>
                            <td><asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price", "{0:C2}") %>'></asp:Label></td>
                            <td><asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total", "{0:C2}") %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <p>Total Amount: <asp:Label ID="Label4" runat="server"></asp:Label></p>
        <p>Thank you for your business!</p>
    </div>

    <!-- Print button -->
    <button type="button" id="btnPrint" onclick="printReceipt()">Print</button>
</asp:Content>

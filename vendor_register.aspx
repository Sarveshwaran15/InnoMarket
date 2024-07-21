<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor.master" AutoEventWireup="true" CodeFile="vendor_register.aspx.cs" Inherits="vendor_register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container mt-2 col-md-6">
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="Button1" runat="server" Text="Student" OnClick="Button1_Click1" />
            <asp:Button ID="Button2" runat="server" Text="Start-Up" OnClick="Button2_Click" />
        </asp:Panel>
        <h2 class="mb-4">Vendor Registration Form</h2>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Label ID="Label20" runat="server" Text="Vendor ID(Note for Login Username):"></asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="Vendor Name:" AssociatedControlID="txtVendorName"></asp:Label>
            <asp:TextBox ID="txtVendorName" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvVendorName" runat="server" ControlToValidate="txtVendorName" ErrorMessage="Vendor Name is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />
               <asp:Label ID="Label15" runat="server" Text="Department:" AssociatedControlID="TextBox7"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox7" ErrorMessage="Department is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />
             <br />
               <asp:Label ID="Label16" runat="server" Text="Batch:" AssociatedControlID="TextBox8"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox8" ErrorMessage="Batch is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />
             <br />
               <asp:Label ID="Label17" runat="server" Text="Register Number:" AssociatedControlID="TextBox9"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox9" ErrorMessage="Register number is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label2" runat="server" Text="Phone Number:" AssociatedControlID="txtPhoneNumber"></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label3" runat="server" Text="Age:" AssociatedControlID="txtAge"></asp:Label>
            <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" TextMode="Number" placeholder="enter age" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" ErrorMessage="Age is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label4" runat="server" Text="Address:" AssociatedControlID="txtAddress"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label5" runat="server" Text="Gender:" AssociatedControlID="ddlGender"></asp:Label>
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" required>
                <asp:ListItem Text="Male" Value="male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="female"></asp:ListItem>
                <asp:ListItem Text="Other" Value="other"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddlGender" ErrorMessage="Gender is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label6" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

          

            <asp:Label ID="Label8" runat="server" Text="Date:" AssociatedControlID="txtDate"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate" ErrorMessage="Date is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </asp:Panel>







         <asp:Panel ID="Panel3" runat="server">






               <asp:Label ID="Label21" runat="server" Text="Vendor ID(Note for Login Username):"></asp:Label><br />




                 <asp:Label ID="Label7" runat="server" Text="Vendor Name:" AssociatedControlID="txtVendorName"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVendorName" ErrorMessage="Vendor Name is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />
              

            <asp:Label ID="Label18" runat="server" Text="Company Name:" AssociatedControlID="TextBox10"></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox10" ErrorMessage="Company name is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />
             <asp:Label ID="Label19" runat="server" Text="Email:" AssociatedControlID="TextBox11"></asp:Label>
            <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox11" ErrorMessage="Email is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />
             

            <asp:Label ID="Label9" runat="server" Text="Phone Number:" AssociatedControlID="txtPhoneNumber"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label10" runat="server" Text="Age:" AssociatedControlID="txtAge"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Number" placeholder="enter age" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAge" ErrorMessage="Age is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label11" runat="server" Text="Address:" AssociatedControlID="txtAddress"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label12" runat="server" Text="Gender:" AssociatedControlID="ddlGender"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" required>
                <asp:ListItem Text="Male" Value="male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="female"></asp:ListItem>
                <asp:ListItem Text="Other" Value="other"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlGender" ErrorMessage="Gender is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="Label13" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

          

            <asp:Label ID="Label14" runat="server" Text="Date:" AssociatedControlID="txtDate"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" TextMode="Date" required></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDate" ErrorMessage="Date is required" Text="*" CssClass="text-danger"></asp:RequiredFieldValidator>

            <br />

            <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button3_Click"  />



















         </asp:Panel>



















    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

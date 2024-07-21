<%@ Page Title="" Language="C#" MasterPageFile="~/Shoper.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
            Product Name:
            <asp:Label ID="Label2" runat="server" ></asp:Label>
            <br />
<%--            qty:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
            <br />
            <asp:Button ID="Button1" runat="server" Text="+" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="-" OnClick="Button2_Click"/>
           
            <br />
            <br />
            Count:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="0" EnableViewState="true"></asp:Label>
            &nbsp;<br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="order" OnClick="Button3_Click" Width="104px" />
              <br />
<br />
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" />
        <asp:BoundField DataField="prd" HeaderText="Product Name" />
        <asp:BoundField DataField="qty" HeaderText="Quantity" />
        <asp:BoundField DataField="time" HeaderText="Time" />
                <asp:BoundField DataField="rate" HeaderText="Rate" />

        <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Label ID="StatusLabel" runat="server" Text='<%# Bind("status") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary btn-lg" HeaderText="Action">
            <ControlStyle CssClass="btn btn-primary btn-lg"></ControlStyle>
        </asp:CommandField>
    </Columns> 
    <HeaderStyle BackColor="#ADD8E6" />
</asp:GridView>


            <br />
            <br />                   
   <%--         <br />
    tableQTy: <asp:Label ID="Label3" runat="server"></asp:Label>

            <br />
        order qty:    <asp:Label ID="Label4" runat="server"></asp:Label>
              sum:    <asp:Label ID="Label5" runat="server"></asp:Label>
            name :<asp:Label ID="Label6" runat="server"></asp:Label>--%>

        </div>
        

</asp:Content>


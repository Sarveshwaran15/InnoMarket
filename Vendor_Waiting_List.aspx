<%@ Page Title="" Language="C#" MasterPageFile="~/Owner.master" AutoEventWireup="true" CodeFile="Vendor_Waiting_List.aspx.cs" Inherits="Vendor_Waiting_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
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
     <div><center style="color:white;font-size:30px">Vendor Waiting List</center></div>
   

    <div class="row">
            <div class="col-md-12 pl-8">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" CssClass="table table-bordered table-striped" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" DataKeyNames="id" Width="100%">
          <AlternatingRowStyle BackColor="White" />
          <Columns>





              <asp:BoundField DataField="vendor_id" HeaderText="Vendor Id" />
               <asp:BoundField DataField="vendor_name" HeaderText="Vendor Name"  />
               <asp:BoundField DataField="age" HeaderText="Age"  />
              <asp:BoundField DataField="gender" HeaderText="Gender"  />
               <asp:BoundField DataField="phone" HeaderText="Phone"  />
              
               <asp:BoundField DataField="address" HeaderText="Address"  />
               

              

              <asp:TemplateField HeaderText="Status">
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:TextBox ID="TextBox1" runat="server"  Text='<%# Eval("status") %>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
               <asp:BoundField DataField="password" HeaderText="Password"  />
              <asp:CommandField ShowEditButton="true"  ControlStyle-CssClass="btn btn-primary" HeaderText="Action"/>
          </Columns>
          <EditRowStyle BackColor="#7C6F57" />
          <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#E3EAEB" />
          <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
          <SortedAscendingCellStyle BackColor="#F8FAFA" />
          <SortedAscendingHeaderStyle BackColor="#246B61" />
          <SortedDescendingCellStyle BackColor="#D4DFE1" />
          <SortedDescendingHeaderStyle BackColor="#15524A" />
      </asp:GridView>
                </div>
        </div>
</asp:Content>


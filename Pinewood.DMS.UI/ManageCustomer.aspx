<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageCustomer.aspx.cs" Inherits="ManageCustomer" Async="true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
        .customer-list-label {
            margin-top:2%;
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 20px;
            color:#337ab7;
        }
        .customer-grid {
            margin-top:2%;
            width: 100%;
            border-collapse: collapse;
        }
        .customer-grid th, .customer-grid td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .customer-grid th {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            background-color: #337ab7;
            color: white;
        }
        .customer-grid tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .customer-grid tr:hover {
            background-color: #ddd;
        }
        .add-customer-button {
            float: right;
            margin-top: 1%;
            margin-bottom: 20px;           
        }
    </style>

     <div style="margin-top:2%">
        <span class="customer-list-label">Customer List </span>
        <asp:Button ID="btnAddCustomer" runat="server" Text="Add Customer" CssClass="btn btn-primary add-customer-button" OnClick="btnAddCustomer_Click" />
    </div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="customer-grid">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="Address1" HeaderText="Address 1" />
            <asp:BoundField DataField="Address2" HeaderText="Address 2" />
            <asp:BoundField DataField="City" HeaderText="City" />
            <asp:BoundField DataField="State" HeaderText="State" />
            <asp:BoundField DataField="PostCode" HeaderText="Post Code" />
            <asp:BoundField DataField="Country" HeaderText="Country" />
              <asp:TemplateField HeaderText="Customer Status">
                <ItemTemplate>
                    <%# Eval("CustomerStatus").ToString() == "1" ? "Active" : "Inactive" %>
                </ItemTemplate>
            </asp:TemplateField>

           <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-primary"
                        CommandArgument='<%# Eval("CustomerId") %>' OnClick="btnEdit_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>




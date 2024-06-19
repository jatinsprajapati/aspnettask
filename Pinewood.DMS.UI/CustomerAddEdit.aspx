<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerAddEdit.aspx.cs" Inherits="CustomerAddEdit"  Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style>
        .top-label {
            font-size: 24px;
            font-weight: bold;
            color: #337ab7;
        }

        .radio-inline {
            display: flex;            
        }
    </style>
    
    <div class="container">
        <div>
            <asp:Label runat="server" CssClass="top-label" ID="AddEditHeader" />
        </div>
        
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" ErrorMessage="First Name is required." />
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="Email">Email:</asp:Label>
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="Email is required." />
            </div>      
        </div>

        <div class="row">
             <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" ErrorMessage="Last Name is required." />
             </div>
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="Mobile">Mobile:</asp:Label>
                <asp:TextBox runat="server" ID="Mobile" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Mobile" ErrorMessage="Mobile is required." />
            </div>
        </div>
       
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="Address1">Address 1:</asp:Label>
                <asp:TextBox runat="server" ID="Address1" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Address1" ErrorMessage="Address 1 is required." />
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="Address2">Address 2:</asp:Label>
                <asp:TextBox runat="server" ID="Address2" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Address2" ErrorMessage="Address 2 is required." />
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="City">City:</asp:Label>
                <asp:TextBox runat="server" ID="City" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="City" ErrorMessage="City is required." />
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="State">State:</asp:Label>
                <asp:TextBox runat="server" ID="State" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="State" ErrorMessage="State is required." />
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="PostCode">PostCode:</asp:Label>
                <asp:TextBox runat="server" ID="PostCode" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PostCode" ErrorMessage="PostCode is required." />
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="Country">Country:</asp:Label>
                <asp:TextBox runat="server" ID="Country" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Country" ErrorMessage="Country is required." />
            </div>
        </div>

         <div class="row">
              <div class="col-md-6">
                 <asp:Label runat="server" AssociatedControlID="Gender">Gender:</asp:Label>
                 <asp:RadioButtonList runat="server" ID="Gender" RepeatLayout="Flow" CssClass="radio-inline">
                     <asp:ListItem Text="Male" style="margin-left:25px" Value="Male" />
                     <asp:ListItem Text="Female" style="margin-left:25px" Value="Female" />                  
                 </asp:RadioButtonList>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="Gender" ErrorMessage="Gender is required." />
             </div>

              <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="CustomerStatus">Customer Status:</asp:Label>
                  <asp:DropDownList runat="server" ID="CustomerStatus" CssClass="form-control">
                      <asp:ListItem Text="Active" Value="1" />
                      <asp:ListItem Text="InActive" Value="0" />                      
                  </asp:DropDownList>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="CustomerStatus" ErrorMessage="Customer Status is required." InitialValue="Select status" />
              </div>
         </div>
        <div>
            <asp:HiddenField runat="server" ID="CustomerId" />
        </div>        
        <div class="row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                <asp:Button runat="server" ID="CancelButton" CausesValidation="false" Text="Cancel" CssClass="btn btn-default" PostBackUrl="~/ManageCustomer.aspx" />
            </div>
        </div>
    </div>
</asp:Content>

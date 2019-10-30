<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="GreatOutdoors.Web.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Edit Product</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblProductName" runat="server" Text="Product Name:" AssociatedControlID="txtProductName" />
            </td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server" placeholder="Product Name" />

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" runat="server" ErrorMessage="Product Name can't be blank" ControlToValidate="txtProductName" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidatorProductName" runat="server" ErrorMessage="Product Name should contain 2 to 40 characters" ControlToValidate="txtProductName" ValidationExpression="^[A-Za-z-. ]*$"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price:" AssociatedControlID="txtUnitPrice" />
            </td>
            <td>
                <asp:TextBox ID="txtUnitPrice" runat="server" placeholder="Unit Price" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Hyperlink ID="btnCancel" runat="server" Text="Cancel" NavigateUrl="~/Products.aspx" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>


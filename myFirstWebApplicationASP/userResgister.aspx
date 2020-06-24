<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userResgister.aspx.cs" Inherits="myFirstWebApplicationASP.userResgister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>User Register</h1>
    <table class="nav-justified">
        <tr >
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Error Summary" ShowMessageBox="True" />
            </td>
        </tr>
        <tr>
            <td style="width: 150px; height: 25px;">Name:</td>
            <td style="height: 25px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is required." ControlToValidate="TextBox1" Display="None">Name must be entered.</asp:RequiredFieldValidator>
                
            </td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td style="width: 150px">Age:</td>
            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Age must be between 20 - 40." MaximumValue="40" MinimumValue="20" Type="Integer" ForeColor="Red">Age must be between 20 - 40.</asp:RangeValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px; height: 22px;">Email:</td>
            <td style="height: 22px"><asp:TextBox ID="TextBox3" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Enter proper email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Enter proper email</asp:RegularExpressionValidator>
            </td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td style="width: 150px">Password:</td>
            <td><asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px">Confirm Password:</td>
            <td><asp:TextBox ID="TextBox8" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox8" ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="Password and confirm password should match.">Password and confirm password should match.</asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px">Zipcode:</td>
            <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="CustomValidator1" 
                    ClientValidationFunction="pincodeValidate"  
                    runat="server" ControlToValidate="TextBox9" 
                    Display="Dynamic" ErrorMessage="Enter proper zip code" 
                     >Enter proper zip code</asp:CustomValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
     
    
    
    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
    <script type="text/javascript" lang="javascript">        
        //alert(document.getElementById('MainContent_btnSave').value);
        function pincodeValidate(source, args) {
            if (args.Value.length != 6) {
                alert('Pincode must be six digit long');
                args.isValid = false;
            }
            else {
                args.isValid = true;
            }
        }
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserResgisteredDetails_result.aspx.cs" Inherits="myFirstWebApplicationASP.UserResgisteredDetails_result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>User Register Details</h1>
    <table class="nav-justified">
        
        <tr>
            <td style="width: 150px; height: 25px;">Name:</td>
            <td style="height: 25px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td style="width: 150px">Age:</td>
            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 150px; height: 22px;">Email:</td>
            <td style="height: 22px"><asp:TextBox ID="TextBox3" runat="server" TextMode="Email"></asp:TextBox>
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
                
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 150px">Zipcode:</td>
            <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
               
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

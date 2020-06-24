<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facuilty.aspx.cs" Inherits="myFirstWebApplicationASP.Facuilty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
    td {
        color:black;
        background-color:antiquewhite;
        font-family:Arial;
        margin:10px;
        padding:10px; 
        text-decoration:solid;
    }
        table, tr, td {
            border-collapse: collapse;
        }
    td TextBox {
            color:aliceblue;
    }
    #btnSave{   
                margin:20px;
                padding:20px;
                text-decoration:solid;
    }
</style>
<h1>Faculty Details</h1>
<div>
    <table style="width:100%">
        <tr>
            <td style="width: 150px;">FacultyName </td>
            <td> <asp:TextBox ID="txtFacultyName" runat="server" ></asp:TextBox>
            </td>                                                   
        </tr>
        <tr>
            <td style="width: 150px;">SubjectName</td>
            <td> <asp:TextBox ID="txtSubjectName" runat="server" ></asp:TextBox>
            </td>                                  
        </tr>
        <tr>
            <td style="width:150px;">Experience</td>
            <td><asp:TextBox ID="txtExperience" runat="server"></asp:TextBox>
            </td>                              
        </tr>
        <tr>
            <td style="width: 150px;">FeesPerLect</td>                                        
            <td><asp:TextBox ID="txtFeesPerLect" runat="server"></asp:TextBox></td>                                 
        </tr>
        <tr>
            <td style="width:150px;">Lectaken</td>
            <td><asp:TextBox ID="txtLectaken" runat="server"></asp:TextBox>               
            </td>                                   
        </tr>  
        
        <tr>
            <td style="width:150px;">Email</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>               
            </td>                                   
        </tr> 
        <tr>
            <td style="width:150px;">Re-Enter Email</td>
            <td><asp:TextBox ID="txtReEnterEmail" runat="server"></asp:TextBox>               
            </td>                                   
        </tr>  
    </table>
</div>
</asp:Content>

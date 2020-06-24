<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FacultyDetails.aspx.cs" Inherits="myFirstWebApplicationASP.FacultyDetails" %>
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
    <asp:ValidationSummary ID="ValidationSummaryFacultyDetails" runat="server" />
<div>
    <table style="width:100%">
        <tr>
            <td style="width: 150px;">FacultyName </td>
            <td> <asp:TextBox ID="txtFacultyName" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFacultyName" runat="server" ErrorMessage="Enter Valid FacultyName" ControlToValidate="txtFacultyName" Display="Static">Enter FacultyName</asp:RequiredFieldValidator>
            </td>                                                   
        </tr>
        <tr>
            <td style="width: 150px;">SubjectName</td>
            <td> <asp:TextBox ID="txtSubjectName" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubjectName" runat="server" ErrorMessage="Subject Name is required." ControlToValidate= "txtSubjectName" Display="Dynamic">Enter SubjectName</asp:RequiredFieldValidator>
            </td>                                  
        </tr>
        <tr>
            <td style="width:150px;">Experience</td>
            <td><asp:TextBox ID="txtExperience" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidatorExperience" runat="server" ControlToValidate="txtExperience" Display="Dynamic" ErrorMessage="Experience should be between 5 and 30" MaximumValue="30" MinimumValue="5" Type="Integer">Experience should be between 5 and 30</asp:RangeValidator>
            </td>                              
        </tr>
        <tr>
            <td style="width: 150px;">FeesPerLect</td>                                        
            <td><asp:TextBox ID="txtFeesPerLect" runat="server"></asp:TextBox></td>                                 
        </tr>
        <tr>
            <td style="width:150px;">Lectaken</td>
            <td><asp:TextBox ID="txtLectaken" runat="server"></asp:TextBox>               
                <asp:CustomValidator ID="validateLectaken" runat="server" ControlToValidate="txtLectaken" ErrorMessage="CustomValidator" ClientValidationFunction="ValidateLectaken"></asp:CustomValidator>
            </td>                                   
        </tr>  
        
        <tr>
            <td style="width:150px;">Email</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>               
                <asp:RegularExpressionValidator ID="RegularExpressionEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Valid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Enter Valid Email Id</asp:RegularExpressionValidator>
            </td>                                   
        </tr> 
        <tr>
            <td style="width:150px;">Re-Enter Email</td>
            <td><asp:TextBox ID="txtReEnterEmail" runat="server"></asp:TextBox>               
                <asp:CompareValidator ID="CompareValidatorReEnterEmail" runat="server" ControlToCompare="txtEmail" ControlToValidate="txtReEnterEmail" ErrorMessage="Re-EnterEmail should be same as Email" SetFocusOnError="True">Re-Enter Email Id</asp:CompareValidator>
            </td>                                   
        </tr>  
    </table>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
    <script type="text/javascript" lang="javascript" >              
        function ValidateLectaken(source, args)
        {
            if (args.Value == "true")
            {
                args.isValid = true;
            }
            else
            {
                alert('Please enter true as value');
                args.isValid = false;
            }
        }

    </script>
</div>
</asp:Content>

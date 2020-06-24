<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FacultyInUpUsingService.aspx.cs" Inherits="myFirstWebApplicationASP.FacultyInUpUsingService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Faculty Name: <asp:TextBox ID="txtFacultyName" runat="server"  Height="30px" Width="200px" style="padding:3px;margin:1px;"></asp:TextBox>
    Experience: <asp:TextBox ID="txtExperience" runat="server" TextMode="Number" Width="80px" style="padding:3px;margin:1px;"></asp:TextBox>
    Subject Name: <asp:DropDownList ID="ddlSubjectName" runat="server" style="padding:3px;margin:3px;"></asp:DropDownList>
    Lecture Date: <asp:Calendar ID="calendarSelectedLectDate" runat="server"></asp:Calendar>
    FeesPerLecture: <asp:TextBox ID="txtFeePerLect" runat="server" TextMode="Number" width="70px" style="padding:3px;margin:1px;"></asp:TextBox>
    <asp:CheckBox runat="server" ID="chkIsLectTaken" />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click1"  />
</asp:Content>

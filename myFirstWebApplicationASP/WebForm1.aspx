<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="myFirstWebApplicationASP.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1" PageSize="5" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" Visible="False" />
            <asp:BoundField DataField="FacultyID" HeaderText="FacultyID" InsertVisible="False" ReadOnly="True" SortExpression="FacultyID" />
            <asp:BoundField DataField="FacultyName" HeaderText="FacultyName" SortExpression="FacultyName" />
            <asp:BoundField DataField="Experience" HeaderText="Experience" SortExpression="Experience" />
            <asp:BoundField DataField="LectDate" HeaderText="LectDate" SortExpression="LectDate" />
            <asp:BoundField DataField="SubjectName" HeaderText="SubjectName" SortExpression="SubjectName" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:coachinginstituteCS %>" SelectCommand="select f.FacultyID, f.FacultyName, f.Experience, f.FeesPerLect, f.LectDate, f.isLectTaken, fs.SubjectID, fs.SubjectName from Faculty f join FacultySubjectMapping fsm on f.FacultyID = fsm.FacultyID join FacultySubject fs on fsm.SubjectID = fs.SubjectID"></asp:SqlDataSource>
</asp:Content>

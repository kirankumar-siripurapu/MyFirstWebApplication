<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="FacultyListUsingService.aspx.cs" Inherits="myFirstWebApplicationASP.FacultyListUsingService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;">Faculty List</h1>
    <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
    <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click"  />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" PageSize="5" BorderStyle="Solid" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Edit" ID="btnEdit" OnClick="btnEdit_Click" />
                    <asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="btnDelete_Click" />
                    <asp:HiddenField ID="hdnfId" runat="server" Value='<%# Bind("FacultyID") %>' />
                    <asp:HiddenField ID="hdnsId" runat="server" Value='<%# Bind("SubjectID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FacultyID" HeaderText="Faculty ID" SortExpression="FacultyID" Visible="False" />
            <asp:BoundField DataField="SubjectID" HeaderText="SubjectID" Visible="False" />
            <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" SortExpression="FacultyName" />
            <asp:BoundField DataField="Experience" HeaderText="Experience" SortExpression="Experience" />
            <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" SortExpression="SubjectName" />
            <asp:BoundField DataField="FeesPerLect" HeaderText="Fees Per Lect" SortExpression="FeesPerLect" />
            <asp:BoundField DataField="LectDate" HeaderText="Lect Date" SortExpression="LectDate" />
            <asp:BoundField DataField="isLectTaken" HeaderText="is Lect Taken" SortExpression="isLectTaken" />
        </Columns>       
        <EmptyDataTemplate>
            No record found.
        </EmptyDataTemplate>
        <PagerStyle BackColor="#66FFFF" BorderStyle="Dotted" ForeColor="Blue" Height="30px" HorizontalAlign="Center" />
    </asp:GridView>
    
    Faculty Name <asp:TextBox ID="txtFacultyName" runat="server" Width="200px" style="padding:3px;margin:1px;"></asp:TextBox>
    Experience <asp:TextBox ID="txtExperience" runat="server" Width="80px" style="padding:3px;margin:1px;"></asp:TextBox>
    Subject Name <asp:DropDownList ID="ddlSubjectName" runat="server" style="padding:3px;margin:1px;">
    </asp:DropDownList>
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
</asp:Content>

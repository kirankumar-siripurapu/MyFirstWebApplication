using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class FacultyList : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string getDataQuery = "select f.FacultyID, f.FacultyName, f.Experience, f.FeesPerLect, f.LectDate, f.isLectTaken, fs.SubjectID, fs.SubjectName from Faculty f join FacultySubjectMapping fsm on f.FacultyID = fsm.FacultyID join FacultySubject fs on fsm.SubjectID = fs.SubjectID"; 
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["coachinginstituteCS"].ConnectionString;
            getSubjectData();

            if (!IsPostBack)
            {
                ViewState["sortExpression"] = "FacultyName";
                ViewState["sortDirection"] = "asc";                
                displayData(getDataQuery + " order by " + ViewState["sortExpression"] + " " + ViewState["sortDirection"]);
            }
            
        }

        
        public void getSubjectData()
        {
            if (IsPostBack)
            {
                if (ddlSubjectName.SelectedItem.Text != "" && ddlSubjectName.SelectedItem.Text != null)
                {
                    ViewState["selectedSubjectValue"] = ddlSubjectName.SelectedValue;
                }
            }
            cn.Open();
            da = new SqlDataAdapter("select * from FacultySubject", cn);
            ds = new DataSet();
            da.Fill(ds, "subjectData");
            cn.Close();
            ddlSubjectName.DataSource = ds.Tables["subjectData"];
            ddlSubjectName.DataTextField = "SubjectName";
            ddlSubjectName.DataValueField = "SubjectID";
            ddlSubjectName.DataBind();

            if(ViewState["selectedSubjectValue"] != null && ViewState["selectedSubjectValue"].ToString() != "")
            {
                ddlSubjectName.SelectedValue = ViewState["selectedSubjectValue"].ToString();
            }
            
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FacultyList.aspx");
        }
        private void displayData(string command)
        {
            cn.Open();
            if (ds.Tables["listData"] != null)
                ds.Tables["listData"].Clear();
            GridView1.AutoGenerateColumns = false;
            da = new SqlDataAdapter(command, cn);

            da.Fill(ds, "listData");
            cn.Close();
            GridView1.DataSource = ds.Tables["listData"];
            GridView1.DataBind();
            ///label5.Text = "Total records = " + ds.Tables["listData"].Rows.Count;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            displayData(getDataQuery + " order by " + ViewState["sortExpression"] + " " + ViewState["sortDirection"]);
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            
            if (ViewState["sortExpression"].ToString() == e.SortExpression.ToString())
            {
                if (ViewState["sortDirection"].ToString() == "asc")
                {
                    ViewState["sortDirection"] = "desc";
                }
                else
                {
                    ViewState["sortDirection"] = "asc";
                }
            }
            else
            {
                ViewState["sortDirection"] = "asc";
            }
            ViewState["sortExpression"] = e.SortExpression;
            displayData(getDataQuery + " order by " + ViewState["sortExpression"] + " " + ViewState["sortDirection"]);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("FacultyLIstInsertUpdate.aspx?fid=0&sid=0");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            displayData("select f.FacultyID, f.FacultyName, f.Experience, f.FeesPerLect, f.LectDate, f.isLectTaken, fs.SubjectID, fs.SubjectName from Faculty f join FacultySubjectMapping fsm on f.FacultyID = fsm.FacultyID join FacultySubject fs on fsm.SubjectID = fs.SubjectID where f.FacultyName like '%" + txtFacultyName.Text + "%' and f.Experience like '%" + txtExperience.Text + "%' and fs.SubjectName like '%" + ddlSubjectName.SelectedItem.Text + "%' order by " + ViewState["sortExpression"] + " " + ViewState["sortDirection"]);            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hdnfDataId = (HiddenField)gvr.FindControl("hdnfId");
            HiddenField hdnsDataId = (HiddenField)gvr.FindControl("hdnsId");
            Response.Redirect("FacultyLIstInsertUpdate.aspx?fid="+hdnfDataId.Value+"&sid="+hdnsDataId.Value);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hdnfDataId = (HiddenField)gvr.FindControl("hdnfId");
            HiddenField hdnsDataId = (HiddenField)gvr.FindControl("hdnsId");
            cn.Open();
            da = new SqlDataAdapter("delete from FacultySubjectMapping where FacultyID = " + hdnfDataId.Value + " and SubjectID = " + hdnsDataId.Value, cn);
            da.Fill(ds, "listData");
            cn.Close();
            
            displayData(getDataQuery + " order by " + ViewState["sortExpression"] + " " + ViewState["sortDirection"]);
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            displayData(getDataQuery + " order by " + ViewState["sortExpression"] + " " + ViewState["sortDirection"]);
        }
    }
}
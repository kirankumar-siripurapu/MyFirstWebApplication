using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class FacultyListUsingService : System.Web.UI.Page
    {
        ServiceReferencelatest.WebServicelatestSoapClient sr = new ServiceReferencelatest.WebServicelatestSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/Login.aspx");
            }
            getSubjectData();
            if (!IsPostBack)
            {
                ViewState["sortExpression"] = "FacultyName";
                ViewState["sortDirection"] = "asc";
                displayData(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString());                
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

            ddlSubjectName.DataSource = sr.getAllSubjectData();
            ddlSubjectName.DataTextField = "SubjectName";
            ddlSubjectName.DataValueField = "SubjectID";
            ddlSubjectName.DataBind();

            if (ViewState["selectedSubjectValue"] != null && ViewState["selectedSubjectValue"].ToString() != "")
            {
                ddlSubjectName.SelectedValue = ViewState["selectedSubjectValue"].ToString();
            }

        }
        private void displayData(string srtExpression, string srtDirection)
        {            
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = sr.getAllFacultyData(srtExpression, srtDirection);
            GridView1.DataBind();            
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("FacultyInUpUsingService.aspx?fid=0&sid=0");
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            displayData(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = sr.filterFacultyData(txtFacultyName.Text, Convert.ToInt32(txtExperience.Text), ddlSubjectName.SelectedItem.Text);
            GridView1.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hdnfDataId = (HiddenField)gvr.FindControl("hdnfId");
            HiddenField hdnsDataId = (HiddenField)gvr.FindControl("hdnsId");
            Response.Redirect("FacultyInUpUsingService.aspx?fid=" + hdnfDataId.Value + "&sid=" + hdnsDataId.Value);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;
            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hdnfDataId = (HiddenField)gvr.FindControl("hdnfId");
            HiddenField hdnsDataId = (HiddenField)gvr.FindControl("hdnsId");
            sr.deleteFacultyData(Convert.ToInt32(hdnfDataId.Value), Convert.ToInt32(hdnsDataId.Value));
            displayData(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString());
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
            displayData(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString());

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            displayData(ViewState["sortExpression"].ToString(), ViewState["sortDirection"].ToString());
        }
    }
}
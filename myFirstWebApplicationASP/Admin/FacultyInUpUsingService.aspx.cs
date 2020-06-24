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
    public partial class FacultyInUpUsingService : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        int recordId = 0;
        string facultyName, lectDate, subjectName;
        double experience;
        int feePerLect, editedSubjectId, isTakenLect;
        int subjectId = 0;
        int facultyId = 0;
        int NewfacultyId;
        ServiceReferencelatest.WebServicelatestSoapClient sr = new ServiceReferencelatest.WebServicelatestSoapClient();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated == false) {
                Response.Redirect("~/Login.aspx");
            }
            cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["coachinginstituteCS"].ConnectionString;
            facultyId = Convert.ToInt32(Request.QueryString["fid"]);
            subjectId = Convert.ToInt32(Request.QueryString["sid"]);
            getSubjectData();
            if (!IsPostBack)
            {
                if (facultyId > 0 && subjectId > 0)
                    getSelectedRecord(facultyId, subjectId);
            }
        }
        public void getSelectedRecord(int facultyID, int subjectID)
        {
            this.subjectId = subjectID;
            this.facultyId = facultyID;
            DataSet ds = new DataSet();
            ds = sr.getFacultyDataById(this.subjectId, this.facultyId);
            txtFacultyName.Text = ds.Tables["selectedRecord"].Rows[0]["FacultyName"].ToString();
            txtExperience.Text = ds.Tables["selectedRecord"].Rows[0]["Experience"].ToString();
            txtFeePerLect.Text = ds.Tables["selectedRecord"].Rows[0]["FeesPerLect"].ToString();
            chkIsLectTaken.Text = ds.Tables["selectedRecord"].Rows[0]["isLectTaken"].ToString();
            calendarSelectedLectDate.SelectedDate = Convert.ToDateTime(ds.Tables["selectedRecord"].Rows[0]["LectDate"]);
            ddlSubjectName.SelectedValue = ds.Tables["selectedRecord"].Rows[0]["SubjectID"].ToString();

        }
        public void getSubjectData()
        {
            if (IsPostBack && ddlSubjectName.SelectedValue.ToString() != "1")
            {
                editedSubjectId = Convert.ToInt32(ddlSubjectName.SelectedValue.ToString());
            }
            ddlSubjectName.DataSource = sr.getAllSubjectData();
            ddlSubjectName.DataTextField = "SubjectName";
            ddlSubjectName.DataValueField = "SubjectID";
            ddlSubjectName.DataBind();

            if (IsPostBack && editedSubjectId > 0)
                ddlSubjectName.SelectedValue = editedSubjectId.ToString();
            else
            {
                if(subjectId > 0)
                    ddlSubjectName.SelectedValue = subjectId.ToString();
            }


        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.ValidateFields();
            string result = sr.insertUpdateFacultyData(facultyId, facultyName, experience, feePerLect, lectDate, isTakenLect, subjectId, subjectName, editedSubjectId);
            if (result == "success")
            {
                Response.Redirect("FacultyListUsingService.aspx");

            }
        }
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("FacultyListUsingService.aspx");
        }
        protected void MsgBox(string Message)
        {
            Response.Write("<script>alert('" + Message + "')</script>");

        }
        protected void ValidateFields()
        {
            //Faculty Name
            if (this.txtFacultyName.Text != null && this.txtFacultyName.Text != "")
            {
                if (txtFacultyName.Text.Length > 50)
                {
                    MsgBox("FacultyName should be less than or equal to 50");
                }
                else
                {
                    facultyName = txtFacultyName.Text;
                }
            }
            else
            {
                MsgBox("FacultyName should not be Null or Blank");
            }

            //Experience
            if (this.txtExperience.Text != null && this.txtExperience.Text != "")
            {
                bool experienceTextbool = double.TryParse(this.txtExperience.Text, out experience);
                if (!experienceTextbool)
                {
                    MsgBox("Experience should be Numeric");
                }
            }
            else
            {
                MsgBox("Experience should not be Null or Blank");
            }

            //FeePerLect
            if (this.txtFeePerLect.Text != null && this.txtFeePerLect.Text != "")
            {
                bool txtFeePerLectbool = int.TryParse(this.txtFeePerLect.Text, out feePerLect);
                if (!txtFeePerLectbool)
                {
                    MsgBox("FeePerLect should be Numeric");
                }
            }
            else
            {
                MsgBox("FeePerLect should not be Null or Blank");
            }

            //LecDate
            if (this.calendarSelectedLectDate.SelectedDate.Date != null)
            {
                lectDate = this.calendarSelectedLectDate.SelectedDate.ToString("MM/dd/yyyy");

            }
            else
            {
                MsgBox("LectDate should not be Null or Blank");
            }

            //IsLecTaken
            if (chkIsLectTaken.Checked)
            {
                isTakenLect = 1;
            }
            else
            {
                isTakenLect = 0;
            }

            //FacultySubject
            //Faculty Name
            if (this.ddlSubjectName.SelectedItem.Text != null && this.ddlSubjectName.SelectedItem.Text != "")
            {
                subjectName = ddlSubjectName.SelectedItem.Text;
                editedSubjectId = int.Parse(ddlSubjectName.SelectedValue);
            }
            else
            {
                MsgBox("SubjectName should not be Null or Blank");
            }


        }

    }
}
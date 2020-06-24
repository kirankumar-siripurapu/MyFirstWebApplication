using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class Facuilty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFacultyName.Text = Request.QueryString["facultyName"].ToString();
            txtSubjectName.Text = Request.QueryString["subjectName"].ToString();
            txtExperience.Text = Request.QueryString["experience"].ToString();
            txtFeesPerLect.Text = Request.QueryString["feesPerLect"].ToString();
            txtLectaken.Text = Request.QueryString["lecTaken"].ToString();
            txtEmail.Text = Request.QueryString["email"].ToString();
            txtReEnterEmail.Text = Request.QueryString["reEnterEmail"].ToString();
        }
    }
}
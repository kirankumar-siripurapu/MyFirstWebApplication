using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class FacultyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtFacultyName.Text = "Kiran";*//
        }
        protected void ValidateLectaken(object source, ServerValidateEventArgs args)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {            
            Response.Redirect("Facuilty.aspx?facultyName=" + txtFacultyName.Text + "&subjectName=" + txtSubjectName.Text + "&experience=" + txtExperience.Text + "&feesPerLect=" + txtFeesPerLect.Text + "&lecTaken=" + txtLectaken.Text + "&email=" + txtEmail.Text + "&reEnterEmail=" + txtReEnterEmail.Text);

        }
    }
}
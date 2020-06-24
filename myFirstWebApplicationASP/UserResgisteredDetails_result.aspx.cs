using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class UserResgisteredDetails_result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //reading data from application
            TextBox1.Text = Cache["name"].ToString();
            TextBox2.Text = Cache["age"].ToString();
            TextBox3.Text = Cache["email"].ToString();
        }
    }
}
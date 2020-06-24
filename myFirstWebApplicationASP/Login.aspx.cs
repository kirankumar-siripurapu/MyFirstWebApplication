using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 10;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //custom code
            //create table -- login
            //compare username and passsword in table
            //if valid then fetch role of user
            //store fetched role and user name into cookie /session /cache/ applicaton/ querysting
            //befor loading any other page check whether created storage has value or not

            if(FormsAuthentication.Authenticate(TextBox1.Text, TextBox2.Text)){
                FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, false);
            }
        }
    }
}
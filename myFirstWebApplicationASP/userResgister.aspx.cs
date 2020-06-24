using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class userResgister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "Mihir";
            
        }
        protected void pincodeValidate(object source, ServerValidateEventArgs args)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //query string
            //Response.Redirect("userRegisteredDetails.aspx?name=" + TextBox1.Text + "&email=" + TextBox3.Text + "&age=" + TextBox2.Text);

            //creating cookies to transfer data
            //HttpCookie mycookies = new HttpCookie("profile");
            //mycookies["name"] = TextBox1.Text;
            //mycookies["email"] = TextBox3.Text;
            //mycookies["age"] = TextBox2.Text;
            //Response.Cookies.Add(mycookies);


            //creating view state to transfer data
            //ViewState["name"] = TextBox1.Text;
            //ViewState["email"] = TextBox3.Text;
            //ViewState["age"] = TextBox2.Text;

            //creating session to transfer data
            //Session["name"] = TextBox1.Text;
            //Session["email"] = TextBox3.Text;
            //Session["age"] = TextBox2.Text;

            //creating session to transfer data
            //Application["name"] = TextBox1.Text;
            //Application["email"] = TextBox3.Text;
            //Application["age"] = TextBox2.Text;

            //creating session to transfer data
            Cache["name"] = TextBox1.Text;
            Cache["email"] = TextBox3.Text;
            Cache["age"] = TextBox2.Text;
            Response.Redirect("userRegisteredDetails.aspx");

        }
    }
}
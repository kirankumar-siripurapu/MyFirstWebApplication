using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstWebApplicationASP
{
    public partial class userRegisteredDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //querystring
            //TextBox1.Text = Request.QueryString["name"].ToString();
            //TextBox2.Text = Request.QueryString["age"].ToString();
            //TextBox3.Text = Request.QueryString["email"].ToString();

            //reading data from cookies
            //TextBox1.Text = Request.Cookies["profile"]["name"].ToString();
            //TextBox2.Text = Request.Cookies["profile"]["age"].ToString();
            //TextBox3.Text = Request.Cookies["profile"]["email"].ToString();

            //reading data from view state
            //TextBox1.Text = ViewState["name"].ToString();
            //TextBox2.Text = ViewState["age"].ToString();
            //TextBox3.Text = ViewState["email"].ToString();

            //reading data from session
            //TextBox1.Text = Session["name"].ToString();
            //TextBox2.Text = Session["age"].ToString();
            //TextBox3.Text = Session["email"].ToString();

            //reading data from application
            //TextBox1.Text = Application["name"].ToString();
            //TextBox2.Text = Application["age"].ToString();
            //TextBox3.Text = Application["email"].ToString();

            //reading data from cache
            TextBox1.Text = Cache["name"].ToString();
            TextBox2.Text = Cache["age"].ToString();
            TextBox3.Text = Cache["email"].ToString();
        }

        protected void tbnTransfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserResgisteredDetails_result.aspx");
        }
    }
}
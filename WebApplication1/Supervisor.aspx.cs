using System;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("SupStudentY.aspx");

        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupStudentPub.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("GucianDefense.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("NonGucianDefense.aspx");

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("cancel.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("evaluate.aspx");
        }
    }
}
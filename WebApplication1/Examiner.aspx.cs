using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Examiner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Your id is: "+Login.id;
        }

        protected void personal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner_Personal.aspx");

        }

        protected void comment_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner_Comment.aspx");

        }

        protected void search_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner_Search.aspx");
        }

        protected void defense_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner_Defense.aspx");
        }

    }
}
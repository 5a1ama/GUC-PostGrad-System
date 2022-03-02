using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class NonGucian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (NonGucianTheses.ngth == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Theses in the System yet')", true);
                NonGucianTheses.ngth = true;
            }
            if (NonGucianCourses.ngc == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Courses in the System yet')", true);
                NonGucianCourses.ngc = true;
            }
        }

        protected void view(object sender, EventArgs e)
        {
            Response.Redirect("NonGucianProfile.aspx");
        }

        protected void theses(object sender, EventArgs e)
        {
            Response.Redirect("NonGucianTheses.aspx");        
        }

        protected void courses(object sender, EventArgs e)
        {
            Response.Redirect("NonGucianCourses.aspx");
        }

        protected void addfillProgressReport(object sender, EventArgs e)
        {
            Response.Redirect("NonGucianAddFillProgressReport.aspx");
        }

        protected void addlinkPublication(object sender, EventArgs e)
        {
            Response.Redirect("NonGucianAddLinkPublication.aspx");
        }
    }
}
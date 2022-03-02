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
    public partial class Gucian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GucianTheses.gth == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Theses in the System yet')", true);
                GucianTheses.gth = true;
            }
        }

        protected void view(object sender, EventArgs e)
        {
            Response.Redirect("GucianProfile.aspx");
        }

        protected void theses(object sender, EventArgs e)
        {
            Response.Redirect("GucianTheses.aspx");
        }

        protected void addfillProgressReport(object sender, EventArgs e)
        {
            Response.Redirect("GucianAddFillProgressReport.aspx");
        }

        protected void addlinkPublication(object sender, EventArgs e)
        {
            Response.Redirect("GucianAddLinkPublication.aspx");
        }
    }
}
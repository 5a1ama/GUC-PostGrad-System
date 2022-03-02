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
    public partial class NonGucianTheses : System.Web.UI.Page
    {
        public static bool ngth = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("ViewAllMyTheses", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@studentID", Login.id));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (GridView1.Rows.Count == 0)
            {
                ngth = false;
                Response.Redirect("NonGucian.aspx");
            }
            else
            {
                GridView1.Visible = true;
            }
        }
    }
}
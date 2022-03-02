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

    public partial class Examiner_Defense : System.Web.UI.Page
    {
        DataTable tb = new DataTable();
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            tb.Columns.Add("Thesis Title", typeof(string));
            tb.Columns.Add("Student Name", typeof(string));
            tb.Columns.Add("Supervisor Name", typeof(string));
            String connStr = WebConfigurationManager.ConnectionStrings["project"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("defenseAndStudentDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@examinerId", Login.id));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            while (rdr.Read())
            {
               
                dr = tb.NewRow();
                dr["Thesis Title"] = rdr.GetString(rdr.GetOrdinal("Thesis Title")); ;
                dr["Student Name"] = rdr.GetString(rdr.GetOrdinal("Student Name")); ;
                dr["Supervisor Name"] = rdr.GetString(rdr.GetOrdinal("Supervisor Name"));
                tb.Rows.Add(dr);
            }
            Gv1.DataSource = tb;
            Gv1.DataBind();





        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }
    }
}
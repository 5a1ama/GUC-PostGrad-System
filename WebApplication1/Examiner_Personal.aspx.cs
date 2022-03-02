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
    public partial class Examiner_Personal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String mail = email.Text;
            String pass = password.Text;
            String field = fieldofwork.Text;
            String namee = name.Text;
            int id = Login.id;
            Response.Write(id);
            SqlCommand examinerProc = new SqlCommand("examinerUpdateDetails", conn);
            examinerProc.CommandType = CommandType.StoredProcedure;
            examinerProc.Parameters.Add(new SqlParameter("@email", mail));
            examinerProc.Parameters.Add(new SqlParameter("@password", pass));
            examinerProc.Parameters.Add(new SqlParameter("@name", namee));
            examinerProc.Parameters.Add(new SqlParameter("@fieldOfWork", field)) ;
            examinerProc.Parameters.Add(new SqlParameter("@examinerId", id));
            conn.Open();
            examinerProc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Examiner.aspx");

     
        }
    }
}
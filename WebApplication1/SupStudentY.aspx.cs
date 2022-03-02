using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class SupStudentY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            GridView1.Visible = false;
            string strcon = WebConfigurationManager.ConnectionStrings["project"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);

            SqlCommand viewstudentsup = new SqlCommand("ViewSupStudentsYears", con);
            con.Open();
            viewstudentsup.CommandType = System.Data.CommandType.StoredProcedure;


            viewstudentsup.Parameters.Add(new SqlParameter("@supervisorID", Login.id));

            SqlDataReader reader = viewstudentsup.ExecuteReader();

            if (reader.HasRows)
            {
                GridView1.DataSource = reader;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            else
            {
                Label1.Visible = true;
            }
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supervisor.aspx");
        }
    }
}
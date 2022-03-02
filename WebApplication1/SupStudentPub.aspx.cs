using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class SupStudentPub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            Label2.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supervisor.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["project"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            int id = Int32.Parse(TextBox1.Text);
            SqlCommand viewstudentpub = new SqlCommand("ViewAStudentPublications", con);
            viewstudentpub.Parameters.Add(new SqlParameter("@StudentID", id));
            con.Open();
            viewstudentpub.CommandType = System.Data.CommandType.StoredProcedure;
            viewstudentpub.ExecuteNonQuery();


            SqlDataReader reader = viewstudentpub.ExecuteReader();
            if (reader.HasRows)
            {
                GridView1.DataSource = reader;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            else
            {
                Label2.Visible = true;
            }
            con.Close();
        }
    }
}
using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace WebApplication1
{
    public partial class cancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["project"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            int id = 0;

            id = Int32.Parse(TextBox1.Text);
            SqlCommand cancel = new SqlCommand("CancelThesis", con);
            cancel.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));
            con.Open();
            cancel.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand cmd1 = new SqlCommand("select * from GUCianProgressReport where thesisSerialNumber = @ThesisSerialNo", con);
            SqlCommand cmd2 = new SqlCommand("select top 1 eval from GUCianProgressReport where thesisSerialNumber = @ThesisSerialNo order by eval", con);
            SqlCommand cmd4 = new SqlCommand("select * from NonGUCianProgressReport where thesisSerialNumber = @ThesisSerialNo", con);

            SqlCommand cmd3 = new SqlCommand("select top 1 eval from NonGUCianProgressReport where thesisSerialNumber = @ThesisSerialNo order by eval", con);
            cmd1.Parameters.Add("@ThesisSerialNo", id);
            cmd2.Parameters.Add("@ThesisSerialNo", id);
            cmd3.Parameters.Add("@ThesisSerialNo", id);
            cmd4.Parameters.Add("@ThesisSerialNo", id);

            bool f1 = false;
            bool f2 = false;
            int eval1 = -1;
            int eval2 = -1;
            SqlDataReader r1 = cmd1.ExecuteReader();
            if (r1.HasRows) f1 = true;
            r1.Close();
            SqlDataReader r4 = cmd4.ExecuteReader();
            if (r4.HasRows) f2 = true;
            r4.Close();
            SqlDataReader r2 = cmd2.ExecuteReader();
            if(r2.HasRows) if(r2.Read()) eval1 = r2.GetInt32(r2.GetOrdinal("eval"));
            r2.Close();
            SqlDataReader r3 = cmd3.ExecuteReader();
            if(r3.HasRows) if(r3.Read()) eval2 = r3.GetInt32(r3.GetOrdinal("eval"));
            r3.Close();
            if (!f1&& !f2)
            {
                Label2.Visible = true;
            }
            else
            {
                if (f1)
                {
                    if (eval1 != 0) Response.Write("<script>alert('eval not equal to 0')</script>");
                    else
                    {
                        cancel.ExecuteNonQuery(); Label3.Visible = true;
                    }
                }
                if (f2)
                {
                    if (eval2 != 0) Response.Write("<script>alert('eval not equal to 0')</script>");
                    else
                    {
                        cancel.ExecuteNonQuery(); Label3.Visible = true;
                    }
                }
            }
            

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supervisor.aspx");
        }
    }
}
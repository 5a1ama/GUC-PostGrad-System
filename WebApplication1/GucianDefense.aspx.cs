using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class GucianDefense : System.Web.UI.Page
    {
        int national;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Visible = false;
            Label4.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label13.Visible = false;
            Label12.Visible = false;
            int national = 3;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supervisor.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals("") || TextBox2.Text.Equals("") || TextBox3.Text.Equals("")
                || TextBox1.Text.Equals("") || national == 3)
                Label13.Visible = true;
            else
            {
                DateTime d = DateTime.Now;
                string strcon = WebConfigurationManager.ConnectionStrings["project"].ConnectionString;
                //create new sqlconnection and connection to database by using connection string from web.config file  
                SqlConnection con = new SqlConnection(strcon);
                int id = Int32.Parse(idd.Text);

                String dloc = TextBox2.Text;

                SqlCommand guciandefence = new SqlCommand("AddDefenseGucian", con);
                guciandefence.CommandType = System.Data.CommandType.StoredProcedure;
                guciandefence.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));
                try
                {
                    d = DateTime.Parse(TextBox1.Text);
                    guciandefence.Parameters.Add(new SqlParameter("@DefenseDate", d));
                }
                catch (FormatException ee)
                {
                    Label5.Visible = true;
                }

                guciandefence.Parameters.Add(new SqlParameter("@DefenseLocation", dloc));
                con.Open();

                SqlCommand addexaminer = new SqlCommand("insert into ExaminerEvaluateDefense values(@DefenseDate,@ThesisSerialNo,@id,null)", con);
                addexaminer.Parameters.Add(new SqlParameter("@DefenseDate", d));
                addexaminer.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));


                int id1 = Int32.Parse(TextBox3.Text);

                addexaminer.Parameters.Add(new SqlParameter("@id", id1));

                SqlCommand cmd1 = new SqlCommand("select G.sid from dbo.GUCianStudentRegisterThesis G where G.sid=@id", con);
                cmd1.Parameters.Add(new SqlParameter("@id", id));
                SqlCommand cmd2 = new SqlCommand("select E.examinerId from dbo.ExaminerEvaluateDefense E where E.date=@DefenseDate and @ThesisSerialNo=E.serialNo and E.examinerId=@id", con);
                SqlCommand cmd3 = new SqlCommand("select E.id from dbo.Examiner E where E.id=@id", con);
                cmd2.Parameters.Add(new SqlParameter("@id", id1));
                cmd2.Parameters.Add(new SqlParameter("@DefenseDate", d));
                cmd2.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));
                cmd3.Parameters.Add(new SqlParameter("@id", id1));
                Boolean f1 = false;
                Boolean f2 = false;
                Boolean f3 = false;

                SqlDataReader r1 = cmd1.ExecuteReader();
                if (r1.HasRows) f1 = true;
                r1.Close();
                SqlDataReader r2 = cmd2.ExecuteReader();
                if (r2.HasRows) f2 = true;
                r2.Close();
                SqlDataReader r3 = cmd3.ExecuteReader();
                if (r3.HasRows) f3 = true;
                
                
                r3.Close();
                if (f1==false)
                {
                    Label4.Visible = true;

                }
                if (f2==true)
                {
                    Label7.Visible = true;
                }
                if (f3==false)
                {
                    Label12.Visible = true;
                }
                if (f1 && !f2 && f3)
                {
                    Label6.Visible = true;
                    guciandefence.ExecuteNonQuery();
                    addexaminer.ExecuteNonQuery();
                }












                con.Close();
            }
        }


    }
}
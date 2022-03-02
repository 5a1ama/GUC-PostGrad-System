using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace WebApplication1
{
    public partial class NonGucianDefense : System.Web.UI.Page
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
            DateTime d = DateTime.Now;
            string strcon = WebConfigurationManager.ConnectionStrings["project"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            int id = Int32.Parse(idd.Text);

            String dloc = TextBox2.Text;

            SqlCommand nonguciandefence = new SqlCommand("AddDefenseNonGucian", con);
            nonguciandefence.CommandType = System.Data.CommandType.StoredProcedure;
            nonguciandefence.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));
            try
            {
                d = DateTime.Parse(TextBox1.Text);
                nonguciandefence.Parameters.Add(new SqlParameter("@DefenseDate", d));
            }
            catch (FormatException ee)
            {
                Label5.Visible = true;
            }

            nonguciandefence.Parameters.Add(new SqlParameter("@DefenseLocation", dloc));
            con.Open();

            SqlCommand addexaminer = new SqlCommand("insert into ExaminerEvaluateDefense values(@DefenseDate,@ThesisSerialNo,@id,null)", con);
            addexaminer.Parameters.Add(new SqlParameter("@DefenseDate", d));
            addexaminer.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));


            int id1 = Int32.Parse(TextBox3.Text);

            addexaminer.Parameters.Add(new SqlParameter("@id", id1));

            SqlCommand cmd1 = new SqlCommand("select G.sid from dbo.NonGUCianStudentRegisterThesis G where G.serial_no = @ThesisSerialNo", con);
            cmd1.Parameters.Add(new SqlParameter("@id", id));
            SqlCommand cmd2 = new SqlCommand("select E.examinerId from dbo.ExaminerEvaluateDefense E where E.date=@DefenseDate and @ThesisSerialNo=E.serialNo and E.examinerId=@id", con);
            SqlCommand cmd3 = new SqlCommand("select E.id from dbo.Examiner E where E.id=@id", con);
            SqlCommand cmd4 = new SqlCommand("select grade from NonGucianStudentTakeCourse where sid = @idOfStudent and grade < 50", con);
            SqlCommand cmd5 = new SqlCommand("select sid from NonGUCianStudentRegisterThesis where serial_no = @ThesisSerialNo", con);
            cmd5.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));
            int sid = -1 ;
            cmd4.Parameters.Add(new SqlParameter("@idOfStudent", sid));
            cmd1.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));

            cmd2.Parameters.Add(new SqlParameter("@id", id1));
            cmd2.Parameters.Add(new SqlParameter("@DefenseDate", d));
            cmd2.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));
            cmd3.Parameters.Add(new SqlParameter("@id", id1));
            Boolean f1 = false;
            Boolean f2 = false;
            Boolean f3 = false;
            Boolean f4 = false;

            SqlDataReader r1 = cmd1.ExecuteReader();
            if (r1.HasRows)
            {
                f1 = true;
                if(r1.Read())
                    sid = r1.GetInt32(r1.GetOrdinal("sid"));
            }
            r1.Close();
            SqlDataReader r2 = cmd2.ExecuteReader();
            if (r2.HasRows) f2 = true;
            r2.Close();
            SqlDataReader r3 = cmd3.ExecuteReader();
            if (r3.HasRows) f3 = true;


            r3.Close();
            SqlDataReader r5 = cmd4.ExecuteReader();
            if (f1 == false)
            {
                Label4.Visible = true;

            }
            if (f2 == true)
            {
                Label7.Visible = true;
            }
            if (f3 == false)
            {
                Label12.Visible = true;
            }
            if (f1 && !f2 && f3)
            {
                if(sid!=-1)
                {

                    if (r5.HasRows) ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The Student failed a course')", true);
                    else
                    {
                        r5.Close();
                        Label6.Visible = true;
                        nonguciandefence.ExecuteNonQuery();
                        addexaminer.ExecuteNonQuery();
                    }
                }
                

            }












            con.Close();
        }
        }

       
    }

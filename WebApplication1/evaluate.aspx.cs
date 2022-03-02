using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace WebApplication1
{
    public partial class evaluate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["project"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            int id = 0;
            id = Int32.Parse(TextBox1.Text);
            int progressno = Int32.Parse(TextBox3.Text);
            int grade = Int32.Parse(TextBox2.Text);
            if (grade > 3 || grade < 0)
            {
                Response.Write("<script>alert('enter a value between 0 and 3')</script>");
            }

            else
            {
                SqlCommand eval = new SqlCommand("EvaluateProgressReport", con);
                eval.Parameters.Add(new SqlParameter("@ThesisSerialNo", id));
                eval.Parameters.Add(new SqlParameter("@supervisorID", Login.id));
                eval.Parameters.Add(new SqlParameter("@progressReportNo", progressno));
                eval.Parameters.Add(new SqlParameter("@evaluation", grade));

                SqlCommand cmd1 = new SqlCommand("select * from Thesis where serialNumber=@thesisSerialNo", con);
                SqlCommand cmd2 = new SqlCommand("select * from Thesis T inner join GUCianStudentRegisterThesis G on T.serialNumber=G.serial_no where G.serial_no=@thesisSerialNo and G.supid = @supervisorID", con);
                SqlCommand cmd3 = new SqlCommand("select * from Thesis T inner join NonGUCianStudentRegisterThesis G on T.serialNumber=G.serial_no where G.serial_no=@thesisSerialNo and G.supid = @supervisorID", con);
                SqlCommand cmd4 = new SqlCommand("select * from GUCianProgressReport where thesisSerialNumber=@thesisSerialNo and supid=@supervisorID and no=@progress", con);
                SqlCommand cmd5 = new SqlCommand("select * from NonGUCianProgressReport where thesisSerialNumber=@thesisSerialNo and supid=@supervisorID and no=@progress", con);

                cmd1.Parameters.Add(new SqlParameter("@thesisSerialNo", id));
                cmd2.Parameters.Add(new SqlParameter("@thesisSerialNo", id));
                cmd2.Parameters.Add(new SqlParameter("@supervisorID", Login.id));
                cmd3.Parameters.Add(new SqlParameter("@thesisSerialNo", id));
                cmd3.Parameters.Add(new SqlParameter("@supervisorID", Login.id));
                cmd4.Parameters.Add(new SqlParameter("@thesisSerialNo", id));
                cmd4.Parameters.Add(new SqlParameter("@supervisorID", Login.id));
                cmd5.Parameters.Add(new SqlParameter("@thesisSerialNo", id));
                cmd5.Parameters.Add(new SqlParameter("@supervisorID", Login.id));
                cmd4.Parameters.Add(new SqlParameter("@progress", progressno));
                cmd5.Parameters.Add(new SqlParameter("@progress", progressno));



                bool f1 = false;
                bool f2 = false;
                bool f3 = false;
                bool f4 = false;
                bool f5 = false;
                con.Open();
                eval.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader r1 = cmd1.ExecuteReader();
                if (r1.HasRows) f1 = true;
                r1.Close();
                SqlDataReader r2 = cmd2.ExecuteReader();
                if (r2.HasRows) f2 = true;
                r2.Close();
                SqlDataReader r3 = cmd3.ExecuteReader();
                if (r3.HasRows) f3 = true;
                r3.Close();
                SqlDataReader r4 = cmd4.ExecuteReader();
                if (r4.HasRows) f4 = true;
                r4.Close();
                SqlDataReader r5 = cmd5.ExecuteReader();
                if (r5.HasRows) f5 = true;
                r5.Close();
                if (!f1)
                {
                    Label2.Visible = true;

                }


                if (!f2 && !f3)
                    Response.Write("<script>alert('you don't supervise this thesis')</script>");
                if (!f4 && !f5)
                    Response.Write("<script>alert('invalid progress report')</script>");

                if (f1 && ((f2 && f4) || (f3 && f5)))
                {
                    eval.ExecuteNonQuery();
                    Label3.Visible = true;


                }



                con.Close();




            }
        }

        protected void Button2_Click(object sender, EventArgs e) => Response.Redirect("Supervisor.aspx");
    }
}
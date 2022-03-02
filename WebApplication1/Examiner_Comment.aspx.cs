using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WebApplication1
{

    public partial class Examiner_Comment : System.Web.UI.Page
    {
        public static bool flag;
        ArrayList ardate = new ArrayList();
        ArrayList arserialnumber = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String connStr = WebConfigurationManager.ConnectionStrings["project"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("defenseDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@examinerId", Login.id));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            int i = 0;
            while (rdr.Read())
            {
                String defenseDate = rdr.GetString(rdr.GetOrdinal("title")) + "@  ";
                ardate.Add(rdr.GetDateTime(rdr.GetOrdinal("date")));
                arserialnumber.Add(rdr.GetInt32(rdr.GetOrdinal("serialNumber")));
                defenseDate += ((DateTime)ardate[i]).ToString("dd/MM/yyyy HH:mm:ss");
                Button defense = new Button
                {
                    ID = "" + (i++),
                    Text = defenseDate
                };
                defense.Attributes.Add("class", "wrap ");
                defense.Click += new EventHandler(DynamicButton_Click);
                div1.Controls.Add(defense);

            }
            Response.Write("Please type your comments and/or grade then choose the defense for which you want to add them");

        }

        private void DynamicButton_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int index = Int32.Parse(clicked.ID);
            DateTime targetDate = (DateTime)ardate[index];
            int targetSerialNumber = (int)arserialnumber[index];
            String comments = TextBox1.Text;
            String grade = TextBox3.Text;
            String connStr = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand gradeProc = new SqlCommand("AddDefenseGrade", conn);
            if (grade != "")
            {
                decimal grade_num = decimal.Parse(grade);
                gradeProc.CommandType = CommandType.StoredProcedure;
                gradeProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", targetSerialNumber));
                gradeProc.Parameters.Add(new SqlParameter("@DefenseDate", targetDate));
                gradeProc.Parameters.Add(new SqlParameter("@grade", SqlDbType.Decimal)).Value = grade_num;
            }
            SqlCommand commentProc = new SqlCommand("AddCommentsGrade", conn);
            commentProc.CommandType = CommandType.StoredProcedure;
            commentProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", targetSerialNumber));
            commentProc.Parameters.Add(new SqlParameter("@DefenseDate", targetDate));
            commentProc.Parameters.Add(new SqlParameter("@comments", comments));
            commentProc.Parameters.Add(new SqlParameter("@examinerId", Login.id));
            conn.Open();
            if (comments != "") { 
                commentProc.ExecuteNonQuery();
            }
            else
            {
                flag= true;

            }

            if (grade != "")
            {
                gradeProc.ExecuteNonQuery();
            }
            else
            {
                flag = true;
            }
                conn.Close();
            Response.Redirect("Examiner.aspx");
        }

    }
}
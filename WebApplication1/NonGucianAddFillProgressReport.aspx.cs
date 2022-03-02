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
    public partial class NonGucianAddFillProgressReport : System.Web.UI.Page
    {

        static TextBox PRNoT = new TextBox();
        static TextBox PRDC = new TextBox();
        static TextBox ThSNoT = new TextBox();
        static TextBox PRNoT1 = new TextBox();
        static TextBox ThSNoT1 = new TextBox();
        static TextBox STT = new TextBox();
        static TextBox DCT = new TextBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label PRNo = new Label();
            PRNo.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PRNo.Style.Add(HtmlTextWriterStyle.Left, "100px");
            PRNo.Style.Add(HtmlTextWriterStyle.Top, "50px");
            PRNo.Text = "Progress Report Number:";
            PRNoT.ID = "ProgNo";
            PRNoT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PRNoT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            PRNoT.Style.Add(HtmlTextWriterStyle.Top, "50px");

            Label PRD = new Label();
            PRD.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PRD.Style.Add(HtmlTextWriterStyle.Left, "100px");
            PRD.Style.Add(HtmlTextWriterStyle.Top, "100px");
            PRD.Text = "Progress Report Date:";
            PRDC.ID = "ProgDate";
            PRDC.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PRDC.Style.Add(HtmlTextWriterStyle.Left, "280px");
            PRDC.Style.Add(HtmlTextWriterStyle.Top, "100px");

            Label ThSNo = new Label();
            ThSNo.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            ThSNo.Style.Add(HtmlTextWriterStyle.Left, "100px");
            ThSNo.Style.Add(HtmlTextWriterStyle.Top, "150px");
            ThSNo.Text = "Ongoing Thesis Serial NO:";
            ThSNoT.ID = "ThesisNum";
            ThSNoT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            ThSNoT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            ThSNoT.Style.Add(HtmlTextWriterStyle.Top, "150px");

            Label PRNo1 = new Label();
            PRNo1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PRNo1.Style.Add(HtmlTextWriterStyle.Left, "100px");
            PRNo1.Style.Add(HtmlTextWriterStyle.Top, "350px");
            PRNo1.Text = "Progress Report Number:";
            PRNoT1.ID = "ProgNo1";
            PRNoT1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PRNoT1.Style.Add(HtmlTextWriterStyle.Left, "280px");
            PRNoT1.Style.Add(HtmlTextWriterStyle.Top, "350px");

            Label ThSNo1 = new Label();
            ThSNo1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            ThSNo1.Style.Add(HtmlTextWriterStyle.Left, "100px");
            ThSNo1.Style.Add(HtmlTextWriterStyle.Top, "400px");
            ThSNo1.Text = "Ongoing Thesis Serial NO:";
            ThSNoT1.ID = "ThesisNum1";
            ThSNoT1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            ThSNoT1.Style.Add(HtmlTextWriterStyle.Left, "280px");
            ThSNoT1.Style.Add(HtmlTextWriterStyle.Top, "400px");

            Label ST = new Label();
            ST.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            ST.Style.Add(HtmlTextWriterStyle.Left, "100px");
            ST.Style.Add(HtmlTextWriterStyle.Top, "450px");
            ST.Text = "State:";
            STT.ID = "state";
            STT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            STT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            STT.Style.Add(HtmlTextWriterStyle.Top, "450px");

            Label DC = new Label();
            DC.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            DC.Style.Add(HtmlTextWriterStyle.Left, "100px");
            DC.Style.Add(HtmlTextWriterStyle.Top, "500px");
            DC.Text = "Description:";
            DCT.ID = "desc";
            DCT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            DCT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            DCT.Style.Add(HtmlTextWriterStyle.Top, "500px");

            form1.Controls.Add(PRNo);
            form1.Controls.Add(PRNoT);
            form1.Controls.Add(PRD);
            form1.Controls.Add(PRDC);
            form1.Controls.Add(ThSNo);
            form1.Controls.Add(ThSNoT);
            form1.Controls.Add(PRNo1);
            form1.Controls.Add(PRNoT1);
            form1.Controls.Add(ThSNo1);
            form1.Controls.Add(ThSNoT1);
            form1.Controls.Add(ST);
            form1.Controls.Add(STT);
            form1.Controls.Add(DC);
            form1.Controls.Add(DCT);
        }

        protected void ADD(object sender, EventArgs e)
        {

            if (PRNoT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (PRDC.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (ThSNoT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else
            {

                string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
                SqlConnection conn = new SqlConnection(s);


                SqlCommand cmd1 = new SqlCommand("StudentOnGoingTheses", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@studentID", Login.id));
                cmd1.Parameters.Add(new SqlParameter("@serialNo", Int64.Parse(ThSNoT.Text)));

                SqlParameter succ = cmd1.Parameters.Add("@succ", SqlDbType.Bit);
                succ.Direction = ParameterDirection.Output;

                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();

                if (succ.Value.ToString() == "True")
                {
                    SqlCommand cmd2 = new SqlCommand("AddProgressReport", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@studentID", Login.id));
                    cmd2.Parameters.Add(new SqlParameter("@thesisSerialNo", Int64.Parse(ThSNoT.Text)));
                    cmd2.Parameters.Add(new SqlParameter("@progressReportNo", Int64.Parse(PRNoT.Text)));
                    cmd2.Parameters.Add(new SqlParameter("@progressReportDate", PRDC.Text));

                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully Added Progress Report')", true);
                    PRNoT.Text = "";
                    PRDC.Text = "";
                    ThSNoT.Text = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have entered wrong Serial Number')", true);
                }
            }
        }

        protected void FILL(object sender, EventArgs e)
        {
            if (PRNoT1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (ThSNoT1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (STT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (DCT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else
            {
                string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
                SqlConnection conn = new SqlConnection(s);


                SqlCommand cmd1 = new SqlCommand("StudentOnGoingTheses", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@studentID", Login.id));
                cmd1.Parameters.Add(new SqlParameter("@serialNo", Int64.Parse(ThSNoT1.Text)));

                SqlParameter succ = cmd1.Parameters.Add("@succ", SqlDbType.Bit);
                succ.Direction = ParameterDirection.Output;

                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();

                if (succ.Value.ToString() == "True")
                {
                    SqlCommand cmd2 = new SqlCommand("FillProgressReport", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@studentID", Login.id));
                    cmd2.Parameters.Add(new SqlParameter("@thesisSerialNo", Int64.Parse(ThSNoT1.Text)));
                    cmd2.Parameters.Add(new SqlParameter("@progressReportNo", Int64.Parse(PRNoT1.Text)));
                    cmd2.Parameters.Add(new SqlParameter("@state", Int64.Parse(STT.Text)));
                    cmd2.Parameters.Add(new SqlParameter("@description", DCT.Text));

                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully Added Progress Report')", true);
                    PRNoT1.Text = "";
                    ThSNoT1.Text = "";
                    STT.Text = "";
                    DCT.Text = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have entered wrong Serial Number')", true);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;

namespace WebApplication1
{
    public partial class AdminViewSuper : System.Web.UI.Page
    {
        public static bool noSup;
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("AdminListSup", conn);
            SqlDataReader read;
            conn.Open();
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Text = "ID";

            TableCell c1 = new TableCell();
            c1.Text = "Email";

            TableCell c2 = new TableCell();
            c2.Text = "Password";

            TableCell c3 = new TableCell();
            c3.Text = "Name";

            TableCell c4 = new TableCell();
            c4.Text = "Faculty";

            r.Controls.Add(c);
            r.Controls.Add(c1);
            r.Controls.Add(c2);
            r.Controls.Add(c3);
            r.Controls.Add(c4);
            Table1.Controls.Add(r);
            read = cmd.ExecuteReader();
            Table1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            Table1.Style.Add(HtmlTextWriterStyle.Left, "0px");
            Table1.Style.Add(HtmlTextWriterStyle.Top, "100px");

            while (read.Read())
            {
                TableRow r1 = new TableRow();

                TableCell cc = new TableCell();
                cc.Text = read.GetValue(0) + "";


                TableCell c11 = new TableCell();
                c11.Text = read.GetValue(1) + "";

                TableCell c22 = new TableCell();
                c22.Text = read.GetValue(2) + "";

                TableCell c33 = new TableCell();
                c33.Text = read.GetValue(3) + "";

                TableCell c44 = new TableCell();
                c44.Text = read.GetValue(4) + "";



                r1.Controls.Add(cc);
                r1.Controls.Add(c11);
                r1.Controls.Add(c22);
                r1.Controls.Add(c33);
                r1.Controls.Add(c44);
                Table1.Rows.Add(r1);
            }

            if (read.HasRows)
            {
                Table1.Visible = true;
            }
            else
            {
                Table1.Controls.Clear();
                noSup = true;
                Response.Redirect("Admin.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Supervisors registerd yet')", true);

            }

        }
        protected void OnGoing(object sender,EventArgs e)
        {
            Response.Redirect("AdminViewOngoing.aspx");
        }

        protected void Payment(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewPayment.aspx");
        }

        protected void Supervisor(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewSuper.aspx");
        }

        protected void AllThesis(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewThesis.aspx");
        }

        protected void PaymentInst(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewPayInst.aspx");
        }
    }
}
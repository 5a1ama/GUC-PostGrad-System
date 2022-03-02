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
    public partial class AdminViewThesis : System.Web.UI.Page
    {
        public static bool noT;
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("AdminViewAllTheses", conn);
            SqlDataReader read;
            conn.Open();

            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Text = "serialNumber";
            Table1.Controls.Clear();
            TableCell c1 = new TableCell();
            c1.Text = "field";

            TableCell c2 = new TableCell();
            c2.Text = "type";

            TableCell c3 = new TableCell();
            c3.Text = "title";
            TableCell c4 = new TableCell();
            c4.Text = "startDate";
            TableCell c5 = new TableCell();
            c5.Text = "endDate";
            TableCell c6 = new TableCell();
            c6.Text = "defenseDate";
            TableCell c7 = new TableCell();
            c7.Text = "years";
            TableCell c8 = new TableCell();
            c8.Text = "grade";
            TableCell c9 = new TableCell();
            c9.Text = "payment_id";
            TableCell c10 = new TableCell();
            c10.Text = "noOfExtensions";
            r.Controls.Add(c);
            r.Controls.Add(c1);
            r.Controls.Add(c2);
            r.Controls.Add(c3);
            r.Controls.Add(c4);
            r.Controls.Add(c5);
            r.Controls.Add(c6);
            r.Controls.Add(c7);
            r.Controls.Add(c8);
            r.Controls.Add(c9);
            r.Controls.Add(c10);
            Table1.Controls.Add(r);
            read = cmd.ExecuteReader();
            Table1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            Table1.Style.Add(HtmlTextWriterStyle.Left, "0px");
            Table1.Style.Add(HtmlTextWriterStyle.Top, "100px");
            Table1.Style.Add(HtmlTextWriterStyle.Width, "800px");

            while (read.Read())
            {
                TableRow r1 = new TableRow();

                TableCell cc = new TableCell();
                if (read.GetValue(0).ToString() == "" || read.GetValue(0) == null)
                    cc.Text = "no value yet";
                else
                {
                    cc.Text = read.GetValue(0) + "";
                }




                TableCell c11 = new TableCell();
                if (read.GetValue(1).ToString() == "" || read.GetValue(1) == null)
                    c11.Text = "no value yet";
                else
                    c11.Text = read.GetValue(1) + "";

                TableCell c22 = new TableCell();
                if (read.GetValue(2).ToString() == "" || read.GetValue(2) == null)
                    c22.Text = "no value yet";
                else
                    c22.Text = read.GetValue(2) + "";

                TableCell c33 = new TableCell();
                if (read.GetValue(3).ToString() == "" || read.GetValue(3) == null)
                    c33.Text = "no value yet";
                else
                    c33.Text = read.GetValue(3) + "";

                TableCell c44 = new TableCell();
                if (read.GetValue(4).ToString() == "" || read.GetValue(4) == null)
                    c44.Text = "no value yet";
                else
                    c44.Text = read.GetValue(4) + "";
                TableCell c55 = new TableCell();
                if (read.GetValue(5).ToString() == "" || read.GetValue(5) == null)
                    c55.Text = "no value yet";
                else
                    c55.Text = read.GetValue(5) + "";
                TableCell c66 = new TableCell();
                if (read.GetValue(6).ToString() == "" || read.GetValue(6) == null)
                    c66.Text = "no value yet";
                else
                    c66.Text = read.GetValue(6) + "";
                TableCell c77 = new TableCell();
                if (read.GetValue(7).ToString() == "" || read.GetValue(7) == null)
                    c77.Text = "no value yet";
                else
                    c77.Text = read.GetValue(7) + "";
                TableCell c88 = new TableCell();
                if (read.GetValue(8).ToString() == "" || read.GetValue(8) == null)
                    c88.Text = "no value yet";
                else
                    c88.Text = read.GetValue(8) + "";
                TableCell c99 = new TableCell();
                if (read.GetValue(9).ToString() == "" || read.GetValue(9) == null)
                    c99.Text = "no value yet";
                else
                    c99.Text = read.GetValue(9) + "";
                TableCell c101 = new TableCell();
                if (read.GetValue(10).ToString() == "" || read.GetValue(10) == null)
                    c101.Text = "no value yet";
                else
                    c101.Text = read.GetValue(10) + "";
                r1.Controls.Add(cc);
                r1.Controls.Add(c11);
                r1.Controls.Add(c22);
                r1.Controls.Add(c33);
                r1.Controls.Add(c44);
                r1.Controls.Add(c55);
                r1.Controls.Add(c66);
                r1.Controls.Add(c77);
                r1.Controls.Add(c88);
                r1.Controls.Add(c99);
                r1.Controls.Add(c101);
                Table1.Rows.Add(r1);
            }

            if (read.HasRows)
            {
                Table1.Visible = true;
            }
            else
            {
                Table1.Controls.Clear();
                noT = true;
                Response.Redirect("Admin.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Theses in the System yet')", true);

            }
            conn.Close();
            read.Close();
        }
        protected void OnGoing(object sender, EventArgs e)
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
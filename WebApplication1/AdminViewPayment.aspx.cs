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
    public partial class AdminViewPayment : System.Web.UI.Page
    {
        public static string paymentnum;
        public static bool noPay;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AdminSubmitInstall.finish)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully Added the Installments')", true);
                AdminSubmitInstall.finish = false;
            }
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("select * from Payment ", conn);
            SqlDataReader read;
            conn.Open();
            Table1.Controls.Clear();
            TableRow r = new TableRow();
            TableCell c = new TableCell();
            c.Text = "ID";
            Table1.Controls.Clear();
            TableCell c1 = new TableCell();
            c1.Text = "Amount";

            TableCell c2 = new TableCell();
            c2.Text = "Number of Installments";

            TableCell c3 = new TableCell();
            c3.Text = "Fund Percentage";

            r.Controls.Add(c);
            r.Controls.Add(c1);
            r.Controls.Add(c2);
            r.Controls.Add(c3);



            Table1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            Table1.Style.Add(HtmlTextWriterStyle.Left, "220px");
            Table1.Style.Add(HtmlTextWriterStyle.Top, "100px");
            Table1.Style.Add(HtmlTextWriterStyle.Width, "800px");

            read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                Table1.Controls.Add(r);
            }
            else
            {
                noPay = true;
                Response.Redirect("Admin.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Payments in the System yet')", true);

            }
            int count2 = 0;
            while (read.Read())
            {
                TableRow r1 = new TableRow();

                TableCell cc = new TableCell();
                if (read.GetValue(0).ToString() == "" || read.GetValue(0) == null)
                {
                    cc.Text = "no value yet";
                }
                else
                {
                    cc.Text = read.GetValue(0) + "";
                    r1.ID = read.GetValue(0) + "";
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


                r1.Controls.Add(cc);
                r1.Controls.Add(c11);
                r1.Controls.Add(c22);
                r1.Controls.Add(c33);

                Table1.Rows.Add(r1);
                Button b = new Button();
                b.Text = "Add Installments every 6 month";
                b.ID = r1.ID + "////";
                b.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                b.Style.Add(HtmlTextWriterStyle.Left, "0px");
                b.Style.Add(HtmlTextWriterStyle.Top, (120 + count2 * 22) + "px");

                b.Click += Installment;
                
                form1.Controls.Add(b);
                count2++;
            }

            conn.Close();
            read.Close();
        }
        private void Installment(object sender,EventArgs e)
        {
            paymentnum = ((Control)sender).ID.Split('/')[0];
            Response.Redirect("AdminSubmitInstall.aspx");

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
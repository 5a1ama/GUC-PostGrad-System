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
    public partial class AdminViewPayInst : System.Web.UI.Page
    {
        public static bool noPay;
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("select P.*,I.* from Payment P left outer join Installment I on P.id=I.paymentId", conn);
            conn.Open();
            SqlDataReader read = cmd.ExecuteReader();
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
            TableCell c4 = new TableCell();
            c4.Text = "Installment date";
            TableCell c5 = new TableCell();
            c5.Text = "PaymentID";
            TableCell c6 = new TableCell();
            c6.Text = "Amount";
            TableCell c7 = new TableCell();
            c7.Text = "Done Bit";
            r.Controls.Add(c);
            r.Controls.Add(c1);
            r.Controls.Add(c2);
            r.Controls.Add(c3);
            r.Controls.Add(c4);
            r.Controls.Add(c5);
            r.Controls.Add(c6);
            r.Controls.Add(c7);
            Table1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            Table1.Style.Add(HtmlTextWriterStyle.Left, "0px");
            Table1.Style.Add(HtmlTextWriterStyle.Top, "100px");
            Table1.Style.Add(HtmlTextWriterStyle.Width, "800px");
        
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

                r1.Controls.Add(cc);
                r1.Controls.Add(c11);
                r1.Controls.Add(c22);
                r1.Controls.Add(c33);
                r1.Controls.Add(c44);
                r1.Controls.Add(c55);
                r1.Controls.Add(c66);
                r1.Controls.Add(c77);
                Table1.Rows.Add(r1);
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
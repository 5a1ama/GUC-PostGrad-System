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
    public partial class AdminSubmitInstall : System.Web.UI.Page
    {
        public static bool finish;
        protected void Page_Load(object sender, EventArgs e)
        {
            div.Controls.Clear();

            Label l = new Label();

            l.Text = "Installments to Payment " + AdminViewPayment.paymentnum;
            Label l2 = new Label();
            HtmlGenericControl div3 = new HtmlGenericControl("div");
            l2.Text = "start date";
            div3.Controls.Add(l2);
            div3.Controls.Add(TextBox1);
            Button b = new Button();
            b.Text = "Add";
            b.ID = AdminViewPayment.paymentnum + "//////";
            b.Click += Install6;
            Button b2 = new Button();
            b2.Text = "Cancel";
            b2.Click += Cancel6;
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div2.Controls.Add(b);
            div2.Controls.Add(b2);
            div.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            div.Style.Add(HtmlTextWriterStyle.Left, "600px");
            div.Style.Add(HtmlTextWriterStyle.Top, "300px");
            div.Style.Add(HtmlTextWriterStyle.Width, "220px");
            div.Style.Add(HtmlTextWriterStyle.Height, "400px");
            div.Style.Add(HtmlTextWriterStyle.BackgroundColor, "white");
            div.Controls.Add(l);
            div.Controls.Add(div3);
            div.Controls.Add(div2);


            form1.Controls.Add(div);
        }
        private void Install6(object sender,EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("AdminIssueInstallPayment", conn);
            cmd.Parameters.Add(new SqlParameter("@paymentID", Convert.ToInt32(AdminViewPayment.paymentnum)));
            cmd.Parameters.Add(new SqlParameter("@InstallStartDate", TextBox1.Text));
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            finish = true;
            Response.Redirect("AdminViewPayment.aspx");
        }
        private void Cancel6(object sender,EventArgs e)
        {
            Response.Redirect("AdminViewPayment.aspx");
        }
    }
}
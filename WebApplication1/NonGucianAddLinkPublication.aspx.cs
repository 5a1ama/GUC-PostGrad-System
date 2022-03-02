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
    public partial class NonGucianAddLinkPublication : System.Web.UI.Page
    {

        static TextBox PubTitleT = new TextBox();
        static TextBox PubDateT = new TextBox();
        static TextBox HostT = new TextBox();
        static TextBox PlaceT = new TextBox();

        static TextBox PubIDT = new TextBox();
        static TextBox ThSNoT = new TextBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label PubTitle = new Label();
            PubTitle.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PubTitle.Style.Add(HtmlTextWriterStyle.Left, "100px");
            PubTitle.Style.Add(HtmlTextWriterStyle.Top, "50px");
            PubTitle.Text = "Publication Title:";
            PubTitleT.ID = "PubTit";
            PubTitleT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PubTitleT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            PubTitleT.Style.Add(HtmlTextWriterStyle.Top, "50px");

            Label PubDate = new Label();
            PubDate.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PubDate.Style.Add(HtmlTextWriterStyle.Left, "100px");
            PubDate.Style.Add(HtmlTextWriterStyle.Top, "100px");
            PubDate.Text = "Publicaiton Date:";
            PubDateT.ID = "PubD";
            PubDateT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PubDateT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            PubDateT.Style.Add(HtmlTextWriterStyle.Top, "100px");

            Label Host = new Label();
            Host.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            Host.Style.Add(HtmlTextWriterStyle.Left, "100px");
            Host.Style.Add(HtmlTextWriterStyle.Top, "150px");
            Host.Text = "Host:";
            HostT.ID = "HS";
            HostT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            HostT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            HostT.Style.Add(HtmlTextWriterStyle.Top, "150px");

            Label Place = new Label();
            Place.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            Place.Style.Add(HtmlTextWriterStyle.Left, "100px");
            Place.Style.Add(HtmlTextWriterStyle.Top, "200px");
            Place.Text = "Place:";
            PlaceT.ID = "PC";
            PlaceT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PlaceT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            PlaceT.Style.Add(HtmlTextWriterStyle.Top, "200px");

            Label accepted = new Label();
            accepted.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            accepted.Style.Add(HtmlTextWriterStyle.Left, "100px");
            accepted.Style.Add(HtmlTextWriterStyle.Top, "250px");
            accepted.Text = "Accepted:";

            Label PubID = new Label();
            PubID.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PubID.Style.Add(HtmlTextWriterStyle.Left, "100px");
            PubID.Style.Add(HtmlTextWriterStyle.Top, "450px");
            PubID.Text = "Publication ID:";
            PubIDT.ID = "PublicaitonID";
            PubIDT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            PubIDT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            PubIDT.Style.Add(HtmlTextWriterStyle.Top, "450px");

            Label ThSNo = new Label();
            ThSNo.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            ThSNo.Style.Add(HtmlTextWriterStyle.Left, "100px");
            ThSNo.Style.Add(HtmlTextWriterStyle.Top, "500px");
            ThSNo.Text = "Ongoing Thesis Serial NO:";
            ThSNoT.ID = "ThesisNum";
            ThSNoT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            ThSNoT.Style.Add(HtmlTextWriterStyle.Left, "280px");
            ThSNoT.Style.Add(HtmlTextWriterStyle.Top, "500px");


            form1.Controls.Add(PubTitle);
            form1.Controls.Add(PubTitleT);
            form1.Controls.Add(PubDate);
            form1.Controls.Add(PubDateT);
            form1.Controls.Add(Host);
            form1.Controls.Add(HostT);
            form1.Controls.Add(Place);
            form1.Controls.Add(PlaceT);
            form1.Controls.Add(accepted);
            form1.Controls.Add(PubID);
            form1.Controls.Add(PubIDT);
            form1.Controls.Add(ThSNo);
            form1.Controls.Add(ThSNoT);
        }

        protected void ADD(object sender, EventArgs e)
        {

            if (PubTitleT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (PubDateT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (HostT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else if (PlaceT.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have to Fill data')", true);
            }
            else
            {

                int acc = 0;

                if (CheckBox1.Checked)
                {
                    acc = 1;
                }
                else
                {
                    acc = 0;
                }

                string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
                SqlConnection conn = new SqlConnection(s);

                SqlCommand cmd1 = new SqlCommand("addPublication", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@title", PubTitleT.Text));
                cmd1.Parameters.Add(new SqlParameter("@pubDate", PubDateT.Text));
                cmd1.Parameters.Add(new SqlParameter("@host", HostT.Text));
                cmd1.Parameters.Add(new SqlParameter("@place", PlaceT.Text));
                cmd1.Parameters.Add(new SqlParameter("@accepted", acc));

                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully Added a Publication')", true);
                PubTitleT.Text = "";
                PubDateT.Text = "";
                HostT.Text = "";
                PlaceT.Text = "";
            }
        }

        protected void LINK(object sender, EventArgs e)
        {
            if (PubIDT.Text == "")
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
                    SqlCommand cmd2 = new SqlCommand("linkPubThesis", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@thesisSerialNo", Int64.Parse(ThSNoT.Text)));
                    cmd2.Parameters.Add(new SqlParameter("@PubID", Int64.Parse(PubIDT.Text)));

                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully Linked the Publication')", true);
                    PubIDT.Text = "";
                    ThSNoT.Text = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have entered wrong Serial Number')", true);
                }
            }
        }
    }
}
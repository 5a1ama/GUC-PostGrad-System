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
    public partial class NonGucianProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("viewMyProfile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@studentId", Login.id));
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int intid = rdr.GetInt32(rdr.GetOrdinal("id"));
                Label id = new Label();
                id.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                id.Style.Add(HtmlTextWriterStyle.Left, "50px");
                id.Style.Add(HtmlTextWriterStyle.Top, "110px");
                id.Text = "ID:" + " " + intid;
                form1.Controls.Add(id);

                String stringfn = rdr.GetString(rdr.GetOrdinal("firstName"));
                Label fn = new Label();
                fn.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                fn.Style.Add(HtmlTextWriterStyle.Left, "50px");
                fn.Style.Add(HtmlTextWriterStyle.Top, "160px");
                fn.Text = "First name:" + " " + stringfn;
                form1.Controls.Add(fn);

                String stringln = rdr.GetString(rdr.GetOrdinal("lastName"));
                Label ln = new Label();
                ln.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                ln.Style.Add(HtmlTextWriterStyle.Left, "50px");
                ln.Style.Add(HtmlTextWriterStyle.Top, "210px");
                ln.Text = "Last name:" + " " + stringln;
                form1.Controls.Add(ln);

                String stringtype = rdr.GetString(rdr.GetOrdinal("type"));
                Label type = new Label();
                type.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                type.Style.Add(HtmlTextWriterStyle.Left, "50px");
                type.Style.Add(HtmlTextWriterStyle.Top, "260px");
                type.Text = "Type:" + " " + stringtype;
                form1.Controls.Add(type);

                String stringfaculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                Label faculty = new Label();
                faculty.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                faculty.Style.Add(HtmlTextWriterStyle.Left, "50px");
                faculty.Style.Add(HtmlTextWriterStyle.Top, "310px");
                faculty.Text = "Faculty:" + " " + stringfaculty;
                form1.Controls.Add(faculty);

                String stringaddress = rdr.GetString(rdr.GetOrdinal("address"));
                Label address = new Label();
                address.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                address.Style.Add(HtmlTextWriterStyle.Left, "50px");
                address.Style.Add(HtmlTextWriterStyle.Top, "360px");
                address.Text = "Address:" + " " + stringaddress;
                form1.Controls.Add(address);

                Decimal stringGPA = rdr.GetDecimal(rdr.GetOrdinal("GPA"));
                Label GPA = new Label();
                GPA.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                GPA.Style.Add(HtmlTextWriterStyle.Left, "50px");
                GPA.Style.Add(HtmlTextWriterStyle.Top, "410px");
                GPA.Text = "GPA:" + " " + stringGPA;
                form1.Controls.Add(GPA);
            }
        }
    }
}
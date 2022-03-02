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
    public partial class Examiner_Search : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            DataRow dr;
            String key = TextBox1.Text;
            tb.Columns.Add("Serial Number", typeof(int));
            tb.Columns.Add("Field", typeof(string));
            tb.Columns.Add("Type", typeof(string));
            tb.Columns.Add("Title", typeof(string));
            tb.Columns.Add("Start Date", typeof(DateTime));
            tb.Columns.Add("End Date", typeof(DateTime));
            tb.Columns.Add("Defense Date", typeof(DateTime));
            tb.Columns.Add("Years", typeof(int));
            tb.Columns.Add("Grade", typeof(decimal));
            tb.Columns.Add("No Of Extensions", typeof(int));
            String connStr = WebConfigurationManager.ConnectionStrings["project"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("Select * From Thesis", conn);
            

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("Title")))
                {



                    String Value = rdr.GetString(rdr.GetOrdinal("Title"));
                   
                
                    if (Value.ToLower().Contains(key.ToLower()))
                    {
                        dr = tb.NewRow();
                        if (!rdr.IsDBNull(rdr.GetOrdinal("serialNumber")))
                            dr["Serial Number"] = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                        if (!rdr.IsDBNull(rdr.GetOrdinal("field")))
                            dr["Field"] = rdr.GetString(rdr.GetOrdinal("field"));
                        if (!rdr.IsDBNull(rdr.GetOrdinal("type")))
                            dr["Type"] = rdr.GetString(rdr.GetOrdinal("type"));
                        dr["Title"] = Value;
                        if (!rdr.IsDBNull(rdr.GetOrdinal("startDate")))
                            dr["Start Date"] = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                        if (!rdr.IsDBNull(rdr.GetOrdinal("endDate")))
                            dr["End Date"] = rdr.GetDateTime(rdr.GetOrdinal("endDate"));
                        if (!rdr.IsDBNull(rdr.GetOrdinal("defenseDate")))
                            dr["Defense Date"] = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                        dr["Years"] = rdr.GetInt32(rdr.GetOrdinal("years"));
                        if (!rdr.IsDBNull(rdr.GetOrdinal("grade")))
                            dr["Grade"] = rdr.GetInt32(rdr.GetOrdinal("grade"));
                        if (!rdr.IsDBNull(rdr.GetOrdinal("noOfExtensions")))
                            dr["No Of Extensions"] = rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"));
                        tb.Rows.Add(dr);
                    }
                }
            }
            Gv1.DataSource = tb;
            Gv1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }
    }
}
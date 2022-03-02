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
    public partial class AdminViewOngoing : System.Web.UI.Page

    {
        public static TextBox t1;
        public static TextBox t2;
        public static TextBox t3;
        public static bool noOn;
        public static string serial;
        public static string left;
        public static bool finish;
        public static string top;
        public static int paymentnum;
        public static bool first = false;
        public static ArrayList Buttons = new ArrayList();
        public static Button temp = new Button();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (finish)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully Added the Payment')", true);
                finish = false;
            }

            Table1.Controls.Clear();
                string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
                SqlConnection conn = new SqlConnection(s);
                SqlCommand cmd = new SqlCommand("select * from Thesis where endDate > Convert(Date,CURRENT_TIMESTAMP)", conn);
                SqlCommand cmd2 = new SqlCommand("AdminViewOnGoingTheses", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlParameter count = cmd2.Parameters.Add("@thesesCount", SqlDbType.Int);
                count.Direction = ParameterDirection.Output;
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
                cmd2.ExecuteNonQuery();
                read = cmd.ExecuteReader();
                Table1.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                Table1.Style.Add(HtmlTextWriterStyle.Left, "220px");
                Table1.Style.Add(HtmlTextWriterStyle.Top, "100px");
                Table1.Style.Add(HtmlTextWriterStyle.Width, "800px");
                
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
                    TableCell c88 = new TableCell();
                    if (read.GetValue(8).ToString() == "" || read.GetValue(8) == null)
                        c88.Text = "no value yet";
                    else
                        c88.Text = read.GetValue(8) + "";
                    TableCell c99 = new TableCell();
                    if (read.GetValue(9).ToString() == "" || read.GetValue(9) == null)
                        c99.Text = "no value yet";
                    else
                    {
                        c99.Text = read.GetValue(9) + "";
                        r1.ID = r1.ID + "#";
                    }

                    TableCell c101 = new TableCell();
                    if (read.GetValue(10).ToString() == "" || read.GetValue(10) == null)
                        c101.Text = "no value yet";
                    else
                        c101.Text = read.GetValue(10) + "";
                    r1.Style.Add(HtmlTextWriterStyle.Height, "50px");
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
                double maxword = 0;
                double total = 0;
                int maxh = 0;
                Buttons = new ArrayList();
                var buttons = Table1.Controls.OfType<Control>().ToArray();
                for (int i = 0; i < buttons.Length; i++)
                {
                    var buttons2 = buttons[i].Controls.OfType<Control>().ToArray();
                    for (int j = 0; j < buttons2.Length; j++)
                    {
                        var arr = ((TableCell)buttons2[j]).Text.Split(' ');
                        for (int k = 0; k < arr.Length; k++)
                        {
                            if (arr[k].Length > maxword)
                            {
                                maxword = arr[k].Length;
                            }
                        }
                        total = ((TableCell)buttons2[j]).Text.Length;
                        double x = Math.Ceiling((total) / maxword) + 1;
                        if ((int)x > maxh)
                        {
                            maxh = (int)x;
                        }
                    }
                }


                for (int i = 0; i < buttons.Length - 1; i++)
                {
                    Button b = new Button();
                    b.Click += B_Click;

                    b.Text = "Add Payment";
                    b.ID = buttons[i + 1].ID + "//";
                    if (b.ID.Contains("#"))
                        b.Enabled = false;
                    b.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    b.Style.Add(HtmlTextWriterStyle.Left, "0px");
                    b.Style.Add(HtmlTextWriterStyle.Top, (130 + i * maxh * 20) + "px");
                    Buttons.Add(b);
                    Button b2 = new Button();
                    b2.Click += B2_Click;
                    b2.ID = buttons[i + 1].ID + "/";
                    b2.Text = "Update extension";
                    Buttons.Add(b2);
                    b2.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    b2.Style.Add(HtmlTextWriterStyle.Left, "100px");
                    b2.Style.Add(HtmlTextWriterStyle.Top, (130 + i * maxh * 20) + "px");
                }


                for (int i = 0; i < Buttons.ToArray().Length; i++)
                {
                    form1.Controls.Add((Button)Buttons.ToArray()[i]);
                }
                first = false;

                if (read.HasRows)
                {
                    Table1.Visible = true;
                    Label1.Text = "Total number of ongoin theses " + count.Value.ToString();



                }
                else
                {
                    Table1.Controls.Clear();
                noOn = true;
                Response.Redirect("Admin.aspx");


                }
                conn.Close();
                read.Close();

            
        }
        private void B_Click(object sender, EventArgs e)
        {
            
            
            form1.Controls.Add(div);
            div.Controls.Clear();
            div.Visible = true;
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("select @count=count(*) from Payment", conn);
            SqlParameter countP = cmd.Parameters.Add("@count", SqlDbType.Int);
            countP.Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            var id = ((Control)sender).ID.Split('/')[0];
            var arr = Buttons.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (((Button)arr[i]).ID.Split('/')[0] == id)
                {
                    temp = (Button)arr[i];
                }
            }
            left = "0px";
            top = temp.Style[HtmlTextWriterStyle.Top] + "";
            serial = id;
            paymentnum = Convert.ToInt32(countP.Value);
            Response.Redirect("AdminSubmitPayment.aspx");
        }
    private void B2_Click(object sender, EventArgs e)
    {
        string id = ((Control)sender).ID.Split('/')[0];
        if (id.Contains("#"))
        {
            id = id.Substring(0, id.Length - 1);
        }
        string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
        SqlConnection conn = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand("AdminUpdateExtension", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@ThesisSerialNo", Convert.ToInt32(id)));
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thesis was successfully extended')", true);
            Page_Load(sender, e);
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
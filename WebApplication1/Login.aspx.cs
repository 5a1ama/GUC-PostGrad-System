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
    public partial class Login : System.Web.UI.Page
    {
        public static bool guc = false;
        public static int id=0;
        public static string mail;
        public static string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RegisterSup.finish)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully registerd please Login now')", true);
                RegisterSup.finish = false;
            }
            else if (RegisterGuc.finish)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully registerd please Login now')", true);
                RegisterGuc.finish = false;
            }
            else if (RegisterNon.finish)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully registerd please Login now')", true);
                RegisterNon.finish = false;
            }
            else if (RegisterEx.finish)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully registerd please Login now')", true);
                RegisterEx.finish = false;
            }
            mail = TextBox1.Text;
            password = TextBox2.Text;
        }

        protected void signup(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");

        }

        protected void login(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("userLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
                conn.Open();
                mail = TextBox1.Text;
                password = TextBox2.Text;
                SqlCommand cmd2 = new SqlCommand("select * from PostGradUser where email=@email", conn);
                cmd2.Parameters.Add(new SqlParameter("@email", mail));
                
                
                

                SqlDataReader read = cmd2.ExecuteReader();
            bool flag = false;
            if (!read.HasRows)
            {
                flag = true;
            }
                while (read.Read())
                {
                    id = Convert.ToInt32(read.GetValue(0).ToString());
                Session["id"] = id;
                }
            read.Close();
            
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            SqlParameter success = cmd.Parameters.Add("@Success", SqlDbType.Int);
            SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            if (success.Value.ToString() == "1")
                {
                    if (type.Value.ToString() == "1") //gucian
                    {
                        guc = true;
                        Response.Redirect("Gucian.aspx");


                    }
                    else if (type.Value.ToString() == "2")//supervisor
                    {
                        Response.Redirect("Supervisor.aspx");

                    }
                    else if (type.Value.ToString() == "3")//exmainer
                    {
                        Response.Redirect("Examiner.aspx");

                    }
                    else if (type.Value.ToString() == "4")//nongucian
                    {
                        guc = false;
                        Response.Redirect("NonGucian.aspx");

                    }
                    else if (type.Value.ToString() == "5")//admin
                    {
                        Response.Redirect("Admin.aspx");

                    }

                }
                else if(flag || success.Value.ToString()=="0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have entered wrong username or password try again or sign up')", true);

                }
                read.Close();
                conn.Close();
            
            

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            mail = TextBox1.Text;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            password = TextBox2.Text;
        }
    }
}
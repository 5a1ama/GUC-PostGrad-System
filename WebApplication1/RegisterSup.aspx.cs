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
    public partial class RegisterSup : System.Web.UI.Page
    {
        public static TextBox facultyT = new TextBox();
        public static bool finish;
        public static TextBox firstNameT = new TextBox();
        public static TextBox LastNameT = new TextBox();
        public static TextBox emailT = new TextBox();
        public static bool gpaflag;
        public static TextBox passwordT = new TextBox();
        public static TextBox typeT = new TextBox();
        public static TextBox addressT = new TextBox();
        public static int id12;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = false;
            Button4.Enabled = true;
            facultyT.Text = "";
            firstNameT.Text = "";
            LastNameT.Text = "";
            emailT.Text = "";
            passwordT.Text = "";
            typeT.Text = "";
            addressT.Text = "";
            
            var buttons = form1.Controls.OfType<Control>().ToArray();
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].ID != "Label1" && buttons[i].ID != "Button1" && buttons[i].ID != "Button5" && buttons[i].ID != "Button2" && buttons[i].ID != "Button3" && buttons[i].ID != "Button4")
                {
                    form1.Controls.Remove(buttons[i]);
                }
            }
            Button5.Visible = true;
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("select @id=count(*) from PostGradUser ", conn);
            SqlParameter count = cmd.Parameters.Add("@id", SqlDbType.Int);
            count.Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteScalar();
            conn.Close();
            Label id = new Label();
            id.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            id.Style.Add(HtmlTextWriterStyle.Left, "200px");
            id.Style.Add(HtmlTextWriterStyle.Top, "90px");
            id.Text = "Your ID is " + (Convert.ToInt32(count.Value.ToString()) + 1);
            id12 = Convert.ToInt32(count.Value.ToString());
            Label email = new Label();
            email.Text = "Email";
            email.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            email.Style.Add(HtmlTextWriterStyle.Left, "200px");
            email.Style.Add(HtmlTextWriterStyle.Top, "140px");

            emailT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            emailT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            emailT.Style.Add(HtmlTextWriterStyle.Top, "140px");
            emailT.ID = "email";
            Label password = new Label();
            password.Text = "Password";
            password.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            password.Style.Add(HtmlTextWriterStyle.Left, "200px");
            password.Style.Add(HtmlTextWriterStyle.Top, "190px");

            passwordT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            passwordT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            passwordT.Style.Add(HtmlTextWriterStyle.Top, "190px");
            passwordT.ID = "password";
            passwordT.Attributes.Add("type", "password");
            Label firstName = new Label();
            firstName.Text = "First Name";
            firstName.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            firstName.Style.Add(HtmlTextWriterStyle.Left, "200px");
            firstName.Style.Add(HtmlTextWriterStyle.Top, "240px");

            firstNameT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            firstNameT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            firstNameT.Style.Add(HtmlTextWriterStyle.Top, "240px");
            firstNameT.ID = "firstname";
            Label LastName = new Label();
            LastName.Text = "Last Name";
            LastName.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            LastName.Style.Add(HtmlTextWriterStyle.Left, "200px");
            LastName.Style.Add(HtmlTextWriterStyle.Top, "290px");

            LastNameT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            LastNameT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            LastNameT.Style.Add(HtmlTextWriterStyle.Top, "290px");
            LastNameT.ID = "lastname";
            Label faculty = new Label();
            faculty.Text = "Faculty";
            faculty.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            faculty.Style.Add(HtmlTextWriterStyle.Left, "200px");
            faculty.Style.Add(HtmlTextWriterStyle.Top, "340px");

            facultyT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            facultyT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            facultyT.Style.Add(HtmlTextWriterStyle.Top, "340px");
            facultyT.ID = "faculty";
           





            form1.Controls.Add(id);
            form1.Controls.Add(firstName);
            form1.Controls.Add(LastName);
            form1.Controls.Add(faculty);
            form1.Controls.Add(email);
            form1.Controls.Add(password);
            form1.Controls.Add(firstNameT);
            form1.Controls.Add(LastNameT);
            form1.Controls.Add(facultyT);
            form1.Controls.Add(emailT);
            form1.Controls.Add(passwordT);



        }

        protected void Gucian(object sender, EventArgs e)
        {
            Response.Redirect("RegisterGuc.aspx");


        }

        protected void NonGucian(object sender, EventArgs e)
        {
            Response.Redirect("RegisterNon.aspx");

        }

        protected void Supervisor(object sender, EventArgs e)
        {

        }

        protected void Examiner(object sender, EventArgs e)
        {
            Response.Redirect("RegisterEx.aspx");
        }

        protected void Submit(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("SupervisorRegister", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@first_name", firstNameT.Text));
            cmd.Parameters.Add(new SqlParameter("@last_name", LastNameT.Text));
            cmd.Parameters.Add(new SqlParameter("@password", passwordT.Text));
            cmd.Parameters.Add(new SqlParameter("@faculty", facultyT.Text));
            cmd.Parameters.Add(new SqlParameter("@email", emailT.Text));
            if (facultyT.Text == "")
            {
                gpaflag = true;
                Label l = new Label();
                l.Text = "this field is required";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "340px");
                form1.Controls.Add(l);

            }
            if (emailT.Text == "")
            {
                gpaflag = true;
                Label l = new Label();
                l.Text = "this field is required";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "140px");
                form1.Controls.Add(l);
            }
            if (passwordT.Text == "")
            {
                gpaflag = true;
                Label l = new Label();
                l.Text = "this field is required";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "190px");
                form1.Controls.Add(l);

            }
            if (firstNameT.Text == "")
            {
                gpaflag = true;
                Label l = new Label();
                l.Text = "this field is required";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "240px");
                form1.Controls.Add(l);

            }
            if (LastNameT.Text == "")
            {
                gpaflag = true;
                Label l = new Label();
                l.Text = "this field is required";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "290px");
                form1.Controls.Add(l);

            }
            if (!gpaflag)
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    finish = true;
                    Response.Redirect("Login.aspx");
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("unique mail"))
                    {
                        Label l = new Label();
                        l.Text = "this email is already taken";
                        l.Style.Add(HtmlTextWriterStyle.Color, "red");
                        l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                        l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                        l.Style.Add(HtmlTextWriterStyle.Top, "140px");
                        form1.Controls.Add(l);
                    }
                }
            }



        }
    }
}
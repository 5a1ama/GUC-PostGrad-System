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
    public partial class RegisterEx : System.Web.UI.Page
         

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
            Button3.Enabled = true;
            Button4.Enabled = false;
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
            faculty.Text = "Field";
            faculty.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            faculty.Style.Add(HtmlTextWriterStyle.Left, "200px");
            faculty.Style.Add(HtmlTextWriterStyle.Top, "340px");

            facultyT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            facultyT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            facultyT.Style.Add(HtmlTextWriterStyle.Top, "340px");
            facultyT.ID = "Field";
            Label address = new Label();
            address.Text = "Egyptian?";
            address.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            address.Style.Add(HtmlTextWriterStyle.Left, "200px");
            address.Style.Add(HtmlTextWriterStyle.Top, "390px");

            addressT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            addressT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            addressT.Style.Add(HtmlTextWriterStyle.Top, "390px");
            addressT.ID = "address";
            Label mobile = new Label();
            mobile.Text = "Mobile(s)";
            mobile.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            mobile.Style.Add(HtmlTextWriterStyle.Left, "200px");
            mobile.Style.Add(HtmlTextWriterStyle.Top, "440px");

         



            form1.Controls.Add(id);
            form1.Controls.Add(firstName);
            form1.Controls.Add(LastName);
            form1.Controls.Add(faculty);
            form1.Controls.Add(address);
            form1.Controls.Add(email);
            form1.Controls.Add(password);
            form1.Controls.Add(firstNameT);
            form1.Controls.Add(LastNameT);
            form1.Controls.Add(facultyT);
            form1.Controls.Add(addressT);
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
            Response.Redirect("RegisterSup.aspx");
        }

        protected void Examiner(object sender, EventArgs e)
        {

        }

        protected void Submit(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);

            SqlCommand cmd = new SqlCommand("select * from PostGradUser where email=@email", conn);
            SqlDataReader read;
            cmd.Parameters.Add(new SqlParameter("@email", emailT.Text));
            conn.Open();
            read = cmd.ExecuteReader();
            gpaflag = false;
            if (read.HasRows)
            {
                gpaflag = true;
                Label l = new Label();
                l.Text = "this email is already taken";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "140px");
                form1.Controls.Add(l);

            }
            read.Close();
            conn.Close();
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
            if (addressT.Text == "")
            {
                gpaflag = true;
                Label l = new Label();
                l.Text = "this field is required";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "390px");
                form1.Controls.Add(l);

            }
            if (addressT.Text != "" && addressT.Text.ToLower() != "yes" && addressT.Text.ToLower() != "no")
            {
                Response.Write(addressT.Text.ToLower());
                gpaflag = true;
                Label l = new Label();
                l.Text = "Please write yes or no only";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "390px");
                form1.Controls.Add(l);

            }
            if (!gpaflag)
            {
                Response.Write("1");
                SqlCommand cmd3 = new SqlCommand("insert into PostGradUser values(@email,@password)", conn);
                SqlCommand cmd2 = new SqlCommand("insert into Examiner values(@id,@name,@field,@national)", conn);
                cmd3.Parameters.Add(new SqlParameter("@email", emailT.Text));
                cmd3.Parameters.Add(new SqlParameter("@password", passwordT.Text));
                cmd2.Parameters.Add(new SqlParameter("@id", id12 + 1));
                cmd2.Parameters.Add(new SqlParameter("@name", firstNameT.Text + " " + LastNameT.Text));
                cmd2.Parameters.Add(new SqlParameter("@field", facultyT.Text));
                if (addressT.Text.ToLower() == "yes")
                {
                    cmd2.Parameters.Add(new SqlParameter("@national", 1));
                }
                else
                {
                    cmd2.Parameters.Add(new SqlParameter("@national", false));

                }
                conn.Open();
                cmd3.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                conn.Close();
                finish = true;
                Response.Redirect("Login.aspx");



            }
            else
            {
                Response.Write(11);
            }
        }
    }
}
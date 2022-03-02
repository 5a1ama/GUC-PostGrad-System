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
    public partial class RegisterGuc : System.Web.UI.Page
    {
        public static TextBox facultyT = new TextBox();
        public static bool underflag2;
        public static TextBox firstNameT = new TextBox();
        public static TextBox LastNameT = new TextBox();
        public static TextBox emailT = new TextBox();
        public static TextBox passwordT = new TextBox();
        public static TextBox typeT = new TextBox();
        public static TextBox addressT = new TextBox();
        public static TextBox GPAT = new TextBox();
        public static TextBox undergradIdT = new TextBox();
        public static TextBox mobileT = new TextBox();
        public static bool finish;
        public static bool typeflag;
        public static bool gpaflag;
        public static bool underflag;
        public static int countGuc = 0;
        public static int id12;
        protected void Page_Load(object sender, EventArgs e)
        {
            divGuc.Controls.Add(mobileT);
            for (int i = 0; i < 10; i++)
            {
                TextBox t = new TextBox();
                t.Visible = false;
                divGuc.Controls.Add(t);
            }
            Button1.Enabled = false;
            Button2.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
            facultyT.Text = "";
            firstNameT.Text = "";
            LastNameT.Text = "";
            emailT.Text = "";
            passwordT.Text = "";
            typeT.Text = "";
            addressT.Text = "";
            GPAT.Text = "";
            undergradIdT.Text = "";
            mobileT.Text = "";
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
            Label type = new Label();
            type.Text = "Type";
            type.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            type.Style.Add(HtmlTextWriterStyle.Left, "200px");
            type.Style.Add(HtmlTextWriterStyle.Top, "340px");

            typeT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            typeT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            typeT.Style.Add(HtmlTextWriterStyle.Top, "340px");
            typeT.ID = "type";
            Label faculty = new Label();
            faculty.Text = "Faculty";
            faculty.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            faculty.Style.Add(HtmlTextWriterStyle.Left, "200px");
            faculty.Style.Add(HtmlTextWriterStyle.Top, "390px");

            facultyT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            facultyT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            facultyT.Style.Add(HtmlTextWriterStyle.Top, "390px");
            facultyT.ID = "faculty";
            Label address = new Label();
            address.Text = "Address";
            address.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            address.Style.Add(HtmlTextWriterStyle.Left, "200px");
            address.Style.Add(HtmlTextWriterStyle.Top, "440px");

            addressT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            addressT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            addressT.Style.Add(HtmlTextWriterStyle.Top, "440px");
            addressT.ID = "address";
            Label GPA = new Label();
            GPA.Text = "GPA";
            GPA.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            GPA.Style.Add(HtmlTextWriterStyle.Left, "200px");
            GPA.Style.Add(HtmlTextWriterStyle.Top, "490px");

            GPAT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            GPAT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            GPAT.Style.Add(HtmlTextWriterStyle.Top, "490px");
            GPAT.ID = "gpa";
            
           
            
            Label undergradId = new Label();
            undergradId.Text = "UnderGradID";
            undergradId.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            undergradId.Style.Add(HtmlTextWriterStyle.Left, "200px");
            undergradId.Style.Add(HtmlTextWriterStyle.Top, "540px");

            undergradIdT.ID = "undergrad";
            undergradIdT.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            undergradIdT.Style.Add(HtmlTextWriterStyle.Left, "300px");
            undergradIdT.Style.Add(HtmlTextWriterStyle.Top, "540px");
            Label mobile = new Label();
            mobile.Text = "Mobile(s)";
            mobile.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            mobile.Style.Add(HtmlTextWriterStyle.Left, "200px");
            mobile.Style.Add(HtmlTextWriterStyle.Top, "590px");

            divGuc.Style.Add(HtmlTextWriterStyle.Position, "absolute");
            divGuc.Style.Add(HtmlTextWriterStyle.Left, "300px");
            divGuc.Style.Add(HtmlTextWriterStyle.Top, "590px");
            divGuc.Style.Add(HtmlTextWriterStyle.Width, "2000px");
            divGuc.Style.Add(HtmlTextWriterStyle.Height, "30px");
            divGuc.Visible = true;
            mobileT.Style.Add(HtmlTextWriterStyle.Position, "relative");


            for (int i = 0; i < countGuc; i++)
            {
                divGuc.Controls.OfType<TextBox>().ToArray()[i + 1].Visible = true;
            }

            form1.Controls.Add(divGuc);
            form1.Controls.Add(mobile);
            form1.Controls.Add(id);
            form1.Controls.Add(firstName);
            form1.Controls.Add(LastName);
            form1.Controls.Add(type);
            form1.Controls.Add(faculty);
            form1.Controls.Add(address);
            form1.Controls.Add(GPA);
            form1.Controls.Add(undergradId);
            form1.Controls.Add(email);
            form1.Controls.Add(password);
            form1.Controls.Add(firstNameT);
            form1.Controls.Add(LastNameT);
            form1.Controls.Add(typeT);
            form1.Controls.Add(facultyT);
            form1.Controls.Add(addressT);
            form1.Controls.Add(GPAT);
            form1.Controls.Add(undergradIdT);
            form1.Controls.Add(emailT);
            form1.Controls.Add(passwordT);


        }

       

        protected void B2_Click(object sender, EventArgs e)
        {
            countGuc++;
            divGuc.Controls.OfType<TextBox>().ToArray()[countGuc].Visible = true;
        }

        protected void B3_Click(object sender, EventArgs e)
        {
            if (countGuc != 0)
            {
                divGuc.Controls.OfType<TextBox>().ToArray()[countGuc].Visible = false;

            }
            countGuc -= 1;
            if (countGuc < 0)
            {
                countGuc = 0;
            }
        }

        protected void Submit(object sender, EventArgs e)
        {
            string s = WebConfigurationManager.ConnectionStrings["project"].ToString();
            SqlConnection conn = new SqlConnection(s);
            underflag = false;
            typeflag = false;
            gpaflag = false;
            
                SqlCommand cmd = new SqlCommand("StudentRegister", conn);
                SqlCommand cmd2 = new SqlCommand("addUndergradID", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@first_name", firstNameT.Text));
                cmd.Parameters.Add(new SqlParameter("@last_name", LastNameT.Text));
                cmd.Parameters.Add(new SqlParameter("@password", passwordT.Text));
                cmd.Parameters.Add(new SqlParameter("@faculty", facultyT.Text));
                cmd2.Parameters.Add(new SqlParameter("@studentID", id12 + 1));




                cmd2.Parameters.Add(new SqlParameter("@undergradID", undergradIdT.Text));
                cmd.Parameters.Add(new SqlParameter("@Gucian", 1));

                cmd.Parameters.Add(new SqlParameter("@email", emailT.Text));
                cmd.Parameters.Add(new SqlParameter("@address", addressT.Text));
                conn.Open();
                SqlCommand cmd3;

                cmd3 = new SqlCommand("update GucianStudent set GPA=@type where id=@id", conn);

                if (undergradIdT.Text != "")
                {
                    SqlCommand cmd4 = new SqlCommand("select * from GucianStudent where undergradId=@uid ", conn);
                    cmd4.Parameters.Add(new SqlParameter("@uid", undergradIdT.Text));
                    SqlDataReader read;
                    read = cmd4.ExecuteReader();
                    if (read.HasRows == true)
                    {
                        underflag = true;

                    }
                try
                {
                    int x = Convert.ToInt32(undergradIdT.Text);
                }catch(FormatException ex)
                {
                    underflag2 = true;
                }
                    if (typeT.Text != "" && (typeT.Text.ToLower() == "master" || typeT.Text.ToLower() == "phd"))
                    {
                        if (GPAT.Text != "")
                        {
                            try
                            {
                                double temp = Convert.ToDouble(GPAT.Text);
                                if (temp >= 0.7 && temp <= 6)
                                {
                                    read.Close();
                                    cmd4.Dispose();
                                    cmd.ExecuteNonQuery();
                                    cmd2.ExecuteNonQuery();
                                    cmd3.Parameters.Add(new SqlParameter("@type", Convert.ToDouble(GPAT.Text)));
                                    cmd3.Parameters.Add(new SqlParameter("@id", id12 + 1));
                                    cmd3.ExecuteNonQuery();
                                    SqlCommand cmd5;

                                    cmd5 = new SqlCommand("update GucianStudent set type=@type where id=@id", conn);


                                    cmd5.Parameters.Add(new SqlParameter("@type", typeT.Text));
                                    cmd5.Parameters.Add(new SqlParameter("@id", id12 + 1));
                                    cmd5.ExecuteNonQuery();
                                    var arr = divGuc.Controls.OfType<TextBox>().ToArray();
                                    for (int i = 0; i < arr.Length; i++)
                                    {
                                        if (((TextBox)arr[i]).Text != "" && ((TextBox)arr[i]).Visible == true)
                                        {
                                            SqlCommand cmd6 = new SqlCommand("addMobile", conn);
                                            cmd6.Parameters.Add(new SqlParameter("@ID", (id12 + 1) + ""));
                                            cmd6.Parameters.Add(new SqlParameter("@mobile_number", ((TextBox)arr[i]).Text));

                                            cmd6.CommandType = CommandType.StoredProcedure;
                                            cmd6.ExecuteNonQuery();

                                        }
                                    }
                                    finish = true;
                                    Response.Redirect("Login.aspx");

                                }
                                else
                                {
                                    gpaflag = true;

                                }
                            }
                            catch (FormatException ex)
                            {
                                gpaflag = true;


                            }
                            catch (SqlException ex)
                            {
                            Response.Write(ex.Message);
                                
                                if (ex.Message.Contains("Please fill all the boxes"))
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
                    else if (typeT.Text != "")
                    {
                        typeflag = true;
                        if (GPAT.Text != "")
                        {
                            try
                            {
                                double temp = Convert.ToDouble(GPAT.Text);
                                if (temp >= 0.7 && temp <= 6)
                                {
                                    gpaflag = false;
                                }
                                else
                                {
                                    gpaflag = true;
                                }
                            }
                            catch (FormatException ex)
                            {
                                gpaflag = true;
                            }
                        }


                    }
                }

                conn.Close();
                if (emailT.Text == "")
                {
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
                    Label l = new Label();
                    l.Text = "this field is required";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "290px");
                    form1.Controls.Add(l);

                }
                if (typeT.Text == "")
                {
                    Label l = new Label();
                    l.Text = "this field is required";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "340px");
                    form1.Controls.Add(l);

                }
                if (facultyT.Text == "")
                {
                    Label l = new Label();
                    l.Text = "this field is required";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "390px");
                    form1.Controls.Add(l);

                }
                if (addressT.Text == "")
                {
                    Label l = new Label();
                    l.Text = "this field is required";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "440px");
                    form1.Controls.Add(l);

                }
                if (GPAT.Text == "")
                {
                    Label l = new Label();
                    l.Text = "this field is required";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "490px");
                    form1.Controls.Add(l);

                }
                if (undergradIdT.Text == "")
                {
                    Label l = new Label();
                    l.Text = "this field is required";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "540px");
                    form1.Controls.Add(l);

                }
                if (typeflag)
                {
                    Label l = new Label();
                    l.Text = "you must choose either master or phd";
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "340px");
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    form1.Controls.Add(l);
                }
                if (gpaflag)
                {
                    Label l = new Label();
                    l.Text = "this field must be decimal between 0.7 and 6";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "490px");
                    form1.Controls.Add(l);
                }
                if (underflag)
                {
                    Label l = new Label();
                    l.Text = "this id is already taken";
                    l.Style.Add(HtmlTextWriterStyle.Color, "red");
                    l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                    l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                    l.Style.Add(HtmlTextWriterStyle.Top, "540px");
                    form1.Controls.Add(l);
                }
            if (underflag2)
            {
                Label l = new Label();
                l.Text = "Enter Valid Integer ID";
                l.Style.Add(HtmlTextWriterStyle.Color, "red");
                l.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                l.Style.Add(HtmlTextWriterStyle.Left, "500px");
                l.Style.Add(HtmlTextWriterStyle.Top, "540px");
                form1.Controls.Add(l);
            }

        }

        protected void Gucian(object sender, EventArgs e)
        {

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
            Response.Redirect("RegisterEx.aspx");

        }
    }
}
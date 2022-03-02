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
    
    public partial class Admin : System.Web.UI.Page
    {
        public static TextBox t1;
        public static TextBox t2;
        public static TextBox t3;
        public static bool adminon;
        public static HtmlGenericControl div = new HtmlGenericControl("div");
        public static bool Ongoing;
        public static bool payment;
        public static bool paymentsub;
        public static bool instsub;
        public static ArrayList  Buttons=new ArrayList();
        public static Button temp=new Button();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (AdminViewOngoing.noOn)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no  Ongoing Theses in the System ')", true);
                AdminViewOngoing.noOn = false;
            }
            if (AdminViewPayment.noPay)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no Payment in The System ')", true);
                AdminViewPayment.noPay = false;
            }
            if (AdminViewPayInst.noPay)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no Payment in The System ')", true);
                AdminViewPayInst.noPay = false;
            }
            if (AdminViewSuper.noSup)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no Supervisors in The System ')", true);
                AdminViewSuper.noSup = false;
            }
            if (AdminViewThesis.noT)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no Theses in The System ')", true);
                AdminViewThesis.noT = false;
            }




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
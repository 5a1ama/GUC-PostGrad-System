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
    public partial class Register : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            
            
           
            
           
            
            
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

            Response.Redirect("RegisterEx.aspx");


        }
        protected void Submit(object sender, EventArgs e)
        {

        }

    }
}
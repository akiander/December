using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DecemberWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Do not show the login status when on the Login page or Register page. 
            if (ShowLoginStatus)
            {
                LoginView1.Visible = true;
                LoginStatus1.Visible = true;
            }
            else
            {
                LoginView1.Visible = false;
                LoginStatus1.Visible = false;
            }
        }

        private bool ShowLoginStatus
        {
            get
            {
                if (Request.Url.ToString() != null
                && (Request.Url.ToString().ToLower().Contains("login.aspx")
                || Request.Url.ToString().ToLower().Contains("register.aspx")))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}

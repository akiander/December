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

namespace DecemberWeb.Controls
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Set focus on the first field
            myLogin.Focus();


            Trace.Write("User.Identity.Name: " + this.Page.User.Identity.Name);

            string userId = Membership.GetUserNameByEmail(this.Page.User.Identity.Name);
            Trace.Write("ID from Membership.GetUserNameByEmail(User.Identity.Name): " + userId);

            if (!string.IsNullOrEmpty(userId))
            {
                MembershipUser user = Membership.GetUser(userId);
                if (user != null)
                {
                    Trace.Write("MembershipUser.UserName: " + user.UserName);
                    Trace.Write("MembershipUser.Email: " + user.Email);
                    Trace.Write("MembershipUser.ProviderUserKey: " + user.ProviderUserKey);
                    Trace.Write("MembershipUser.ProviderName: " + user.ProviderName);
                    Trace.Write("MembershipUser.Comment: " + user.Comment);
                }
            }

        }
    }
}
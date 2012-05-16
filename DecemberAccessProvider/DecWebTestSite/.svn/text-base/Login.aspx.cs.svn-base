using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace DecWebTestSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblDebug.Text += "<br />" + "User.Identity.Name: " + this.User.Identity.Name;

            string userId = Membership.GetUserNameByEmail(this.User.Identity.Name);
            lblDebug.Text += "<br />" + "ID from Membership.GetUserNameByEmail(User.Identity.Name): " + userId;

            if (!string.IsNullOrEmpty(userId))
            {
                MembershipUser user = Membership.GetUser(userId);
                if (user != null)
                {
                    lblDebug.Text += "<br />" + "MembershipUser.UserName: " + user.UserName;
                    lblDebug.Text += "<br />" + "MembershipUser.Email: " + user.Email;
                    lblDebug.Text += "<br />" + "MembershipUser.ProviderUserKey: " + user.ProviderUserKey;
                    lblDebug.Text += "<br />" + "MembershipUser.ProviderName: " + user.ProviderName;
                    lblDebug.Text += "<br />" + "MembershipUser.Comment: " + user.Comment;
                }
            }



            //Profile Information
            //string QuoteListId = HttpContext.Current.Profile.GetPropertyValue("QuoteListId").ToString();
            //lblDebug.Text += "<br />" + "Profile.QuoteListId: " + QuoteListId;

            //if (string.IsNullOrEmpty(QuoteListId))
            //{
            //    QuoteListId = Guid.NewGuid().ToString();
            //    HttpContext.Current.Profile.SetPropertyValue("QuoteListId", QuoteListId);
            //    lblDebug.Text += "<br />" + "Since the value was null, Profile.QuoteListId was just set to: " + QuoteListId;
            //}
            
        }
    }
}

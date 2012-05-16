using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Web.Profile;

namespace DecWebTestSite
{
    public class Global : System.Web.HttpApplication
    {
        
        //public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args)
        //{
        //    //Great introduction to the Profile functionality:
        //    //http://www.odetocode.com/Articles/440.aspx
            
        //    //ProfileCommon anonymousProfile = Profile.GetProfile(args.AnonymousID); //Does not work
        //    ProfileBase anonymousProfile = ProfileBase.Create(args.AnonymousID);
        //    string anonymousQuoteListId = anonymousProfile.GetPropertyValue("QuoteListId").ToString();

           
        //    //Now set the new profile object
        //    HttpContext.Current.Profile.SetPropertyValue("QuoteListId", anonymousQuoteListId);
        //    //Profile.ZipCode = anonymousProfile.ZipCode; //Does not work


        //    ////////
        //    // Delete the anonymous profile. If the anonymous ID is not 
        //    // needed in the rest of the site, remove the anonymous cookie.

        //    ProfileManager.DeleteProfile(args.AnonymousID);
        //    AnonymousIdentificationModule.ClearAnonymousIdentifier();

        //    // Delete the user row that was created for the anonymous user.
        //    Membership.DeleteUser(args.AnonymousID, true);

        //}

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
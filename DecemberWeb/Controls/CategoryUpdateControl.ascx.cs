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
using DecemberWeb.Wrappers;
using DecemberData;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using DecemberData.BusinessObjects;

namespace DecemberWeb.Controls
{
    public partial class CategoryUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeControl();

        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            if (clicked == null)
                return;

            if (clicked.CommandName == null)
                return;

            QuoteListWrapper wrapper = new QuoteListWrapper();
            Quote quote = (Quote)wrapper.GetQuoteById(GetQuoteId());

            if (quote.Categories.Contains(clicked.CommandName))
            {
                quote.Categories.Remove(clicked.CommandName);
            }

            //update our data structure
            wrapper.UpdateQuote(quote);

            //Show the change to the user
            InitializeControl();

        }

        protected void AddCategoryButton_Click(object sender, EventArgs e)
        {
            ErrorMessages.InnerHtml = string.Empty;

            QuoteListWrapper wrapper = new QuoteListWrapper();
            Quote quote = (Quote)wrapper.GetQuoteById(GetQuoteId());

            if (quote.Categories.Contains(CategoryToAddText.Text))
            {
                ErrorMessages.InnerHtml = "<br>The category you are adding already exists in the list.";
                return;
            }

            //Update our data structure
            quote.Categories.Add(CategoryToAddText.Text);
            wrapper.UpdateQuote(quote);

            //Clear the textbox
            CategoryToAddText.Text = string.Empty;

            //Show the change to the user
            InitializeControl();
        }
        

        private void InitializeControl()
        {
            string QuoteId = GetQuoteId();

            QuoteListWrapper wrapper = new QuoteListWrapper();
            IQuote quote = wrapper.GetQuoteById(QuoteId);

            List<CategoryWrapper> catList = new List<CategoryWrapper>();
            foreach (string category in quote.Categories)
            {
                CategoryWrapper wrap = new CategoryWrapper();
                wrap.Text = category;
                catList.Add(wrap);
            }

            ListView1.DataSource = catList;
            ListView1.DataBind();
        }

        /// <summary>
        /// This method knows how to extract the Quote ID (GUID) from session and
        /// return it. 
        /// 
        /// This method also validates the ID and sends the user back
        /// </summary>
        /// <returns></returns>
        private string GetQuoteId()
        {
            if (Session["QuoteIdToModify"] == null || string.IsNullOrEmpty(Session["QuoteIdToModify"].ToString()))
            {
                Trace.Write("User landed on CategoryUpdateControl without setting Session['QuoteIdToModify'] so we're sending the user back to the default page.");
                Response.Redirect("default.aspx");
            }

            string quoteContextString = Session["QuoteIdToModify"].ToString();
            
            
            //the String has two parts:   [UserGUID]_[QuoteGUID]
            string[] split = quoteContextString.Split(new Char[] { '_' });

            
            //The UserGuid is appended to the Session key to make sure we 
            //don't modify a quote that does not belong to the current user. 
            string UserGuidFromSession = split.First();
            string UserGuid = Membership.GetUserNameByEmail(HttpContext.Current.User.Identity.Name);

            if (UserGuid != UserGuidFromSession)
            {
                Trace.Write(string.Format("UserGuid [{0}] is not equal to UserGuid sent [{0}].",UserGuid, UserGuidFromSession));
                Session["QuoteIdToModify"] = string.Empty;
                Response.Redirect("default.aspx");
            }


            string QuoteId = split.Last();


            Trace.Write("Entire string is: " + quoteContextString);
            Trace.Write("UserGuid from string is: " + UserGuidFromSession);
            Trace.Write("QuoteId from string is: " + QuoteId);

            return QuoteId;
        }
    }
}
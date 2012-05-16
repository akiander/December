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
using System.Collections.Generic;
using DecemberData;
using DecemberData.BusinessObjects;
using System.Threading;

namespace DecemberWeb.Controls
{
    public partial class RandomQuoteViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QuoteListWrapper wrapper;

            if (this.Attributes["UseGlobalQuoteList"] != null
                && this.Attributes["UseGlobalQuoteList"].Trim().ToLower() == "true")
            {
                //Do special logic to use the global quote list. 
                string guidForGlobalList = ConfigurationManager.AppSettings["GlobalQuoteListId"];
                if (string.IsNullOrEmpty(guidForGlobalList))
                    throw new Exception("ERROR: We expect the following section in your config file: <appSettings><add key='GlobalQuoteListId' value='ed32da6e-da85-477e-9b21-ddf131a532e8'/></appSettings>");

                wrapper = new QuoteListWrapper(guidForGlobalList);
            }
            else
            {
                //This will create the QuoteList based on who is currently logged in right now.
                wrapper = new QuoteListWrapper();
            }

            Quote quote = wrapper.GetRandomQuote();

            if (quote == null)
            {
                lblQuote.Text = "This quote collection does not contain any quotes yet.";
                lblCategories.Text = string.Empty;
                lblAuthor.Text = string.Empty;
            }
            else
            {
                lblQuote.Text = quote.Text;
                lblCategories.Text = quote.CategoriesAsString;
                lblAuthor.Text = quote.Author;
            }

            //THIS DOES NOT WORK - Attempt to get some way to make the enter key page forward through quotes.
            //this.Page.Form.DefaultButton = FindControl("btnNext").UniqueID;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //No code necessary - the Page_Load method resets the quote.
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //No code necessary - the Page_Load method resets the quote.
        }

        
    }
}
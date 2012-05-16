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
using DecemberData.BusinessObjects;

namespace DecemberWeb.Controls
{
    public partial class QuoteAddControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ModalPopupExtender.OkControlID = btnOk.ClientID;
        }

        protected void lnkOpenDialog_Click(object sender, EventArgs e)
        {
            //updatePanelInModalDialog.Update();
            //ModalPopupExtender.Show(); - This doesn't work for some reason. 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Validate Input
            if (string.IsNullOrEmpty(QuoteTextToInsert.Text.Trim()))
            {
                lblAddQuoteFeedback.Text = "Quote Text is required before you can save a quote.";
                return;
            }

            //Collect the Quote
            Quote newQuote = new Quote();
            newQuote.Text = QuoteTextToInsert.Text;
            newQuote.CategoriesAsString = CategoryToInsert.Text;
            newQuote.Author = AuthorToInsert.Text;
            
            //Add the quote to the collection
            QuoteListWrapper wrapper = new QuoteListWrapper();
            wrapper.InsertQuote(newQuote);

            //Tell the user that the update was successful.
            lblAddQuoteFeedback.Text = "Last Quote was successfully added.";

            //Clear the text controls for more quotes to be added
            QuoteTextToInsert.Text = string.Empty;
            CategoryToInsert.Text = string.Empty;
            AuthorToInsert.Text = string.Empty;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
        }
    }
}
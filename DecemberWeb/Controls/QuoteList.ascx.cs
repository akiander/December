using System;
using System.Collections;
using System.Collections.Generic;
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
using DecemberData;
using DecemberData.BusinessObjects;
using DecemberWeb.Wrappers;



namespace DecemberWeb.Controls
{
    public partial class QuoteList : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //This allows us to refresh the page after a quote is inserted.
            ListView1.ItemInserted += new EventHandler<ListViewInsertedEventArgs>(ListView1_ItemInserted);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePage();

            
        }

        void ListView1_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            InitializePage();
        }

        private void InitializePage()
        {
            //See if there is a querystring value
            string searchText = string.Empty;
            if (Request.QueryString["s"] != null)
            {
                searchText = Request.QueryString["s"].Trim();
                
                //If this is a postback, we might be trying to change the searchText
                //so do not overwrite that value in the Textbox. Otherwise, viewstate
                //will automatically keep our previous value. 
                if (!IsPostBack)
                {
                    txtSearch.Text = searchText;
                }
            }
            QuoteListWrapper wrapper = new QuoteListWrapper();
            IList<IQuote> quotes = wrapper.GetQuotes(searchText); 
            RecordCount.Text = string.Format("There are {0} quotes.", quotes.Count);


            //Only display the quotes control if we have some quotes.
            bool displayQuotes = (quotes.Count > 0);
            ListView1.Visible = displayQuotes;
            txtSearch.Visible = displayQuotes;
            btnSearch.Visible = displayQuotes;
            DataPager1.Visible = displayQuotes;
            
            
        }

        protected void DeleteButtonInGrid_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            Trace.Write("About to delete: " + deleteButton.CommandName);

            if (deleteButton == null || string.IsNullOrEmpty(deleteButton.CommandName))
            {
                Response.Write("Unable to delete quote - please reload the page and try again.");
            }

            QuoteListWrapper wrapper = new QuoteListWrapper();
            wrapper.DeleteQuote(deleteButton.CommandName);

            //Refresh the list
            ListView1.DataBind();

            //Refresh the page
            InitializePage();
        }

        protected void ListView1_ItemInserting(Object sender, ListViewInsertEventArgs e)
        {
            ////e.Item
            //// Iterate through the values to validate them.
            //foreach (DictionaryEntry de in e.Values)
            //{
            //    if (de.Value != null)
            //    {
            //        Trace.Write(de.Key + ": " + de.Value);
            //        //e.Cancel = true; //This cancels the update.
            //    }
            //    else
            //    {
            //        Trace.Write(de.Key + ": null");
            //    }
            //}
        }

        
        protected void UpdateCategories_Click(object sender, EventArgs e)
        {
            LinkButton editButton = (LinkButton)sender;
            Trace.Write("About to edit categories for: " + editButton.CommandName);

            string UserGuid = Membership.GetUserNameByEmail(HttpContext.Current.User.Identity.Name);
            string Separator = "_";
            string QuoteID = editButton.CommandName;

            Session["QuoteIdToModify"] = UserGuid + Separator + QuoteID;
            Response.Redirect("QuoteUpdate.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string thisUrl = Request.Url.AbsolutePath;

            Response.Redirect(thisUrl + "?s=" + txtSearch.Text);
        }

        

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    Button deleteButton = (Button)sender;
        //    foreach (ListViewDataItem item in ListView1.Items)
        //    {
        //        CheckBox checkBox = (CheckBox)item.FindControl("QuoteCheckbox");
        //        if (checkBox.Checked)
        //        {
        //            HiddenField IdControl = (HiddenField)item.FindControl("IdHiddenField");
        //        }
        //    }
        //}
    }
}
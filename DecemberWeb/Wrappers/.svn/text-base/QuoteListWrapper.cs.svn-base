using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DecemberData.BusinessObjects;
using System.Collections.Generic;
using DecemberData;

namespace DecemberWeb.Wrappers
{
    public class QuoteListWrapper
    {
        public QuoteListWrapper()
        {
            _UserGuid = Membership.GetUserNameByEmail(HttpContext.Current.User.Identity.Name);
            _QuoteList = new QuoteList(_UserGuid);
        }

        public QuoteListWrapper(string GuidToUse)
        {
            _UserGuid = GuidToUse;
            _QuoteList = new QuoteList(_UserGuid);
        }

        private string _UserGuid = string.Empty;
        private QuoteList _QuoteList = null;

        public IList<IQuote> GetQuotes(string searchText)
        {
            //This method handles the case where the searchText 
            //is null or empty by returning all quotes.
            return _QuoteList.GetQuotesBySearchText(searchText);
        }

        public Quote GetRandomQuote()
        {
            //If we have no quotes, return null
            if (_QuoteList.Quotes.Count < 1)
                return null;

            return (Quote) _QuoteList.GetRandomQuote();
        }

        public void InsertQuote(Quote newQuote)
        {
            newQuote.Id = Guid.NewGuid().ToString();

            _QuoteList.AddQuote(newQuote);
            _QuoteList.Save();
        }

        public void DeleteQuote(string quoteToDeleteId)
        {
            _QuoteList.DeleteQuote(quoteToDeleteId);
            _QuoteList.Save();
        }

        public void UpdateQuote(Quote quoteToUpdate)
        {
            IQuote quoteToBeUpdated = _QuoteList.Quotes.First(arg => arg.Id == quoteToUpdate.Id);
            
            if (quoteToBeUpdated == null)
            {
                return;
            }

            //Update the quote that is in the list.
            for (int i = 0; i < _QuoteList.Quotes.Count; i++)
            {
                if (_QuoteList.Quotes[i].Id == quoteToUpdate.Id)
                {
                    _QuoteList.Quotes[i].Author = quoteToUpdate.Author;
                    _QuoteList.Quotes[i].Text = quoteToUpdate.Text;
                    //Don't update Categories if null
                    //DO update Categories if the count is zero since users can remove all categories from a quote and then save.
                    if (quoteToUpdate.Categories != null && quoteToUpdate.Categories.Count >= 0)
                    {
                        _QuoteList.Quotes[i].ClearCategories();
                        foreach (string category in quoteToUpdate.Categories)
                        {
                            _QuoteList.Quotes[i].AddCategory(category);
                        }
                    }
                    _QuoteList.Save();
                }
            }

        }

        internal IQuote GetQuoteById(string QuoteId)
        {
            var result = from q in _QuoteList.Quotes
                         where q.Id == QuoteId
                         select q;

            return result.FirstOrDefault();
        }

        public List<CategoryWrapper> GetCategoryList()
        {
            List<CategoryWrapper> retval = new List<CategoryWrapper>();
            foreach (string category in _QuoteList.Categories)
            {
                CategoryWrapper wrapper = new CategoryWrapper();
                wrapper.Text = category;
                retval.Add(wrapper);
            }
            return retval;
        }
    }
}

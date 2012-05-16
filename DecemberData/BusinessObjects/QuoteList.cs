using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.IO;
using System.Xml.Linq;
using DecemberData.DataAccessLayer;

namespace DecemberData.BusinessObjects
{
    public class QuoteList
    {
        /// <summary>
        /// A unique identifier, which will be used as the file name for the xml data file.
        /// </summary>
        public string Id
        {
            get;
            private set;
        }


        /// <summary>
        /// This constructor is intentionally private to make sure all consumers pass in a unique identifier. 
        /// </summary>
        private QuoteList()
        {
            //Make the default constructor private so we always have to pass in an ID. 
        }

        /// <summary>
        /// The client should pass in a GUID so we can identify which data file to work
        /// with. 
        /// </summary>
        /// <param name="id"></param>
        public QuoteList(string id)
        {
            //Initialize Fields
            this.Id = id;
            this.Quotes = new List<IQuote>();
            _Categories = null;

            //Load up the quotes
            QuoteListDAL.LoadFromDataFile(this);
        }

        

        

        /// <summary>
        /// This is the list of quotes available for this data file. 
        /// </summary>
        public List<IQuote> Quotes
        {
            get;
            private set;
        }

        public void AddQuote(IQuote inQuote)
        {
            //TODO: Add code to detect whether this quote already exists.
            this.Quotes.Add(inQuote);
        }

        public void DeleteQuote(string QuoteId)
        {
            var allQuotesExceptThisOne = from q in this.Quotes
                                 where q.Id != QuoteId
                                 select q;

            //TODO: Fix the delete function. The List<IQuote>.Remove() operation fails silently
            //so I temporarily changed this method to just recreate the entire List, which probably
            //will not perform very well. 
            this.Quotes = new List<IQuote>();
            foreach (IQuote quote in allQuotesExceptThisOne)
            {
                this.Quotes.Add(quote);
            }
        }

        public void Save()
        {
            QuoteListDAL.Save(this);
        }

        /// <summary>
        /// One Quote List is particularly special in that it is the global list for the site. Here is
        /// how we get the ID for that list. 
        /// </summary>
        public static string GlobalQuoteListId
        {
            get
            {
                string setting = ConfigurationManager.AppSettings["GlobalQuoteListId"];

                if (setting == null)
                    throw new Exception(@"The following appSetting is required: <appSettings><add key='GlobalQuoteListId' value='ed32da6e-da85-477e-9b21-ddf131a532e8' /></appSettings>");

                return setting;
            }
        }

        private List<string> _Categories;
        public List<string> Categories
        {
            get
            {                
                //This is how this query was done when I went directly against the XML rather than against the object model
                //var categories = from q in quotesFromFile.Descendants("Category")
                //                 orderby (string)q.Value
                //                 select (string)q.Value;

                var categories = from q in this.Quotes
                                 where q.Categories.Any(p => !string.IsNullOrEmpty(p))
                                 from c in q.Categories
                                 orderby c
                                 select c;

                _Categories =  new List<string>();
                _Categories.AddRange(categories.Distinct());

                return _Categories;

            }
        }


        public List<IQuote> GetQuotesByCategory(string Category)
        {
            List<IQuote> quoteList = new List<IQuote>();

            if (string.IsNullOrEmpty(Category))
                return quoteList;

            //This is how this query was done when I went directly against the XML rather than against the object model
            //    var quotesByCategory = from q in quotesFromFile.Elements("QuoteRecord")
            //                           where q.Descendants("Category").Any(eachCategory => eachCategory.Value == Category)
            //                           select (string)q.Element("Quote").Value;

            var quotes = from q in this.Quotes
                             where q.Categories.Any(p => !string.IsNullOrEmpty(p) && p.ToLower() == Category.ToLower())
                             select q;

            
            quoteList.AddRange(quotes);

            return quoteList;

        }

        /// <summary>
        /// In this case, passing null or an empty string will return all quotes
        /// </summary>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public List<IQuote> GetQuotesBySearchText(string SearchText)
        {
            if (string.IsNullOrEmpty(SearchText))
                return this.Quotes;
            
            var quotes = from q in this.Quotes
                         where q.Categories.Any(p => !string.IsNullOrEmpty(p) && p.ToLower().Contains(SearchText.ToLower()))
                         || (!string.IsNullOrEmpty(q.Author) && q.Author.ToLower().Contains(SearchText.ToLower()))
                         || (!string.IsNullOrEmpty(q.Text) && q.Text.ToLower().Contains(SearchText.ToLower()))
                         select q;

            List<IQuote> quoteList = new List<IQuote>();
            quoteList.AddRange(quotes);

            return quoteList;

        }

        /// <summary>
        /// Retrieves a quote from the list randomly. 
        /// </summary>
        /// <returns></returns>
        public IQuote GetRandomQuote()
        {
            int RandomIndex = new Random().Next(0, Quotes.Count - 1);

            //Wait briefly so the Random number generator works as expected.
            //If any consumers call this function in a loop, it executes so quickly that the Random class
            //generates the same random number since Random uses a time-based algorithm to generate a new
            //number and the amount of time elapsed between executions is less than can be detected. 
            //Don't worry, we're only waiting for 1 millisecond so you can stop hyperventilating now. 
            System.Threading.Thread.Sleep(1); 
                        
            return Quotes[RandomIndex];
        }
    }
}

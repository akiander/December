using DecemberData.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecemberData;
using System.Collections.Generic;
using System;

namespace DecemberData.Tests
{
    
    
    /// <summary>
    ///This is a test class for QuoteListTest and is intended
    ///to contain all QuoteListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class QuoteListTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion




        /// <summary>
        ///A test for Adding a quote to the collection and then saving to disk.
        ///</summary>
        [TestMethod()]
        public void AddQuoteTest()
        {
            string id = Guid.NewGuid().ToString();

            Console.WriteLine("About to test adding a quote and saving to disk for ID: " + id);

            QuoteList target = new QuoteList(id);

            Assert.IsTrue(target.Quotes.Count == 0, "We have not added any quotes yet but the quotelist is full for ID: " + id);

            IQuote inQuote = GetTestingQuote();
            Console.WriteLine("About to add the following test quote: " + inQuote.ToString());
            target.AddQuote(inQuote);

            inQuote = GetTestingQuote();
            Console.WriteLine("About to add the following test quote: " + inQuote.ToString());
            target.AddQuote(inQuote);

            int numberOfQuotesToSave = target.Quotes.Count;
            target.Save();

            //Now test that we get this quote back:
            target = new QuoteList(id);
            Assert.IsTrue(target.Quotes.Count == numberOfQuotesToSave, "We added " + numberOfQuotesToSave + " quote(s) so this collection should contain the same number of quotes.");

            Console.WriteLine("Test was successful.");
        }

        /// <summary>
        ///A test for deleting a quote from the collection and then saving to disk. 
        ///</summary>
        [TestMethod()]
        public void DeleteQuoteTest()
        {
            string id = Guid.NewGuid().ToString();

            Console.WriteLine("About to test adding a quote for ID: " + id);

            QuoteList target = new QuoteList(id);

            IQuote quoteToDeleteLater = GetTestingQuote();
            Console.WriteLine("Adding GUID: " + quoteToDeleteLater.Id);
            target.AddQuote(quoteToDeleteLater);

            //Add a few more...
            target.AddQuote(GetTestingQuote());
            target.AddQuote(GetTestingQuote());

            int quotesAdded = target.Quotes.Count;
            target.Save();

            Console.WriteLine("Verifying all quotes exist.");
            target = new QuoteList(id);
            Assert.IsTrue(target.Quotes.Count == quotesAdded, "This collection should contain " + quotesAdded + " quotes.");

            //Now delete the GUID above. 
            Console.WriteLine("About to delete the quote: " + quoteToDeleteLater.Id);
            target.DeleteQuote(quoteToDeleteLater.Id);
            target.Save();

            target = new QuoteList(id);
            Assert.IsTrue(target.Quotes.Count == (quotesAdded - 1), "This collection should contain " + (quotesAdded - 1) + " quotes.");


            Console.WriteLine("Test was successful.");
        }

        private static IQuote GetTestingQuote()
        {
            List<string> categories = new List<string>();
            categories.Add("Action");
            categories.Add("Principle");
            IQuote inQuote = new Quote(Guid.NewGuid().ToString(), "To be or not to be, that is the question.", "None", categories);

            return inQuote;
        }

        [TestMethod]
        public void CategoriesTest()
        {
            QuoteList quotes = new QuoteList(QuoteList.GlobalQuoteListId);

            List<string> categories = quotes.Categories;

            Console.WriteLine("Found {0} categories.", categories.Count);

            foreach (string category in categories)
            {
                Console.Write(category + " ");
            }
        }

        [TestMethod]
        public void GetQuotesByCategoryTest()
        {
            string category = "action";
            QuoteList quotes = new QuoteList(QuoteList.GlobalQuoteListId);

            List<IQuote> quotesByCategory = quotes.GetQuotesByCategory(category);

            Console.WriteLine("Found {0} quotes with category '{1}'.", quotesByCategory.Count, category);

            foreach (IQuote quote in quotesByCategory)
            {
                Console.WriteLine(quote.ToString());
            }
        }



        [TestMethod]
        public void GetQuotesBySearchTextTest()
        {
            string searchText = "rent";// "action";
            QuoteList quotes = new QuoteList(QuoteList.GlobalQuoteListId);

            List<IQuote> quotesBySearchText = quotes.GetQuotesBySearchText(searchText);

            Console.WriteLine("Found {0} quotes with searchText: '{1}'.", quotesBySearchText.Count, searchText);

            foreach (IQuote quote in quotesBySearchText)
            {
                Console.WriteLine(quote.ToString());
            }
        }


        [TestMethod]
        public void GetRandomQuoteTest()
        {
            QuoteList quotes = new QuoteList(QuoteList.GlobalQuoteListId);

            Console.WriteLine("Testing the GetRandomQuote() Operation.");

            Console.WriteLine(string.Empty);
            Console.WriteLine("GetRandomQuote returned: {0}", quotes.GetRandomQuote());

            Console.WriteLine(string.Empty);
            Console.WriteLine("GetRandomQuote returned: {0}", quotes.GetRandomQuote());
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("GetRandomQuote returned: {0}", quotes.GetRandomQuote());

            Console.WriteLine(string.Empty);
            Console.WriteLine("GetRandomQuote returned: {0}", quotes.GetRandomQuote());
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("GetRandomQuote returned: {0}", quotes.GetRandomQuote());

            

        }



        /// <summary>
        ///I commented the [TestMethod()] attribute because this is a utility that should not be used
        ///unless needed. 
        ///</summary>
        //[TestMethod()]
        public void Utility_ResetQuoteIDs()
        {
            string id = "";//"ed32da6e-da85-477e-9b21-ddf131a532e8";

            Console.WriteLine("About to reset all QuoteIDs for ID: " + id);

            QuoteList target = new QuoteList(id);

            foreach (IQuote quote in target.Quotes)
            {
                quote.Id = Guid.NewGuid().ToString();
                Console.WriteLine("Reset quote: " + quote.ToString());
            }

            target.Save();
            
            Console.WriteLine("Reset was successful.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecemberData.BusinessObjects;
using System.Xml.Linq;
using System.IO;

namespace DecemberData.DataAccessLayer
{
    internal class QuoteListDAL
    {
        internal static void Save(QuoteList inQuoteList)
        {
            XDocument document = new XDocument();
            document.Add(XElement.Parse(@"<QuoteList xmlns='http://kiander.com'></QuoteList>"));
            document.Root.Add(new XAttribute("QuoteListId", inQuoteList.Id));

            foreach (IQuote quote in inQuoteList.Quotes)
            {
                XElement quoteRecord = new XElement("QuoteRecord");
                quoteRecord.Add(new XElement("QuoteID", quote.Id));
                quoteRecord.Add(new XElement("Quote", quote.Text));
                quoteRecord.Add(new XElement("Author", quote.Author));
                XElement categories = new XElement("Categories");
                
                if (quote.Categories != null)
                {
                    foreach (string category in quote.Categories)
                    {
                        categories.Add(new XElement("Category", category));
                    }
                }
                if (quote.Categories == null || quote.Categories.Count < 1)
                {
                    categories.Add(new XElement("Category", string.Empty));
                }
                quoteRecord.Add(categories);
                document.Root.Add(quoteRecord);
            }

            if (File.Exists(DataFileHelper.FullPath(inQuoteList.Id)))
                File.Delete(DataFileHelper.FullPath(inQuoteList.Id));

            document.Save(DataFileHelper.FullPath(inQuoteList.Id));
        }


        internal static void LoadFromDataFile(QuoteList inQuoteList)
        {
            if (File.Exists(DataFileHelper.FullPath(inQuoteList.Id)))
            {
                XElement quoteList = XElement.Load(DataFileHelper.FullPath(inQuoteList.Id));
                foreach (XElement quoteRecord in quoteList.Descendants("QuoteRecord"))
                {
                    string quoteId = (string)quoteRecord.Element("QuoteID");
                    string quoteText = (string)quoteRecord.Element("Quote");
                    string author = (string)quoteRecord.Element("Author");
                    List<string> categories = new List<string>();
                    foreach (XElement category in quoteRecord.Element("Categories").Descendants("Category"))
                    {
                        categories.Add((string)category);
                    }
                    IQuote quote = new Quote(quoteId, quoteText, author, categories);
                    inQuoteList.Quotes.Add(quote);
                }
            }
        }


        


    }
}

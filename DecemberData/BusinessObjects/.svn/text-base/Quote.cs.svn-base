using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecemberData.BusinessObjects
{
    
    public class Quote : DecemberData.IQuote
    {
        string _Id;
        string _Text;
        string _Author;
        IList<string> _Categories;

        public Quote() : this(string.Empty, string.Empty, string.Empty)
        {
            //Parameterless constructor is required for the ObjectDataSource update methods. 
        }
        public Quote(string inId, string inText, string inAuthor)
        {
            this._Id = inId;
            this._Text = inText;
            this._Author = inAuthor;
            this._Categories = new List<string>();
        }

        public Quote(string inId, string inText, string inAuthor, IList<string> inCategories)
        {
            this._Id = inId;
            this._Text = inText;
            this._Author = inAuthor;
            this._Categories = inCategories;
        }

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        public IList<string> Categories
        {
            get { return _Categories; }
            set { /* do nothing - clients should use AddCategory & ClearCategories() methods */ }
        }

        public string CategoriesAsString
        {
            get
            {
                string retval = string.Empty;
                foreach (string category in Categories)
                {
                    //Since commas are the separator, remove them from any category.
                    retval += category.Replace(",", "_");
                    retval += ", ";
                }

                //Remove the last comma
                return retval.TrimEnd(new char[] {',',' '});
            }
            set
            {
                _Categories = new List<string>();

                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                //Extract values from comma-separated string
                string[] split = value.Split(new char[] {','});

                foreach (string category in split)
                {
                    _Categories.Add(category.Trim());
                }
            }
        }

        public void ClearCategories()
        {
            _Categories = new List<string>();
        }

        public void AddCategory(string newCategory)
        {
            _Categories.Add(newCategory);
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat(Environment.NewLine + "ID: [{0}]", this._Id);
            sb.AppendFormat(Environment.NewLine + "Text: [{0}]", this._Text);
            sb.AppendFormat(Environment.NewLine + "Author: [{0}]", this._Author);
            foreach (string category in this.Categories)
            {
                sb.AppendFormat(Environment.NewLine + "Category: [{0}]", category);
            }
            return sb.ToString();
        }

    }
}

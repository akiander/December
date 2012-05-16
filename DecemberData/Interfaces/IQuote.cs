using System;
namespace DecemberData
{
    public interface IQuote
    {
        string Id { get; set; }
        string Text { get; set; }
        string Author { get; set; }
        System.Collections.Generic.IList<string> Categories { get;  }
        void ClearCategories();
        void AddCategory(string newCategory);
    }
}

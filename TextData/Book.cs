using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;
using EBookData;

namespace TextData
{
    public class Book : IBook
    {
        public string Author
        {
            get { return null; }
        }

        public List<IChapter> Chapters
        {
            get;
            set;
        }

        public ICover Cover
        {
            get { return null; }
        }

        public string Identifier
        {
            get { return null; }
        }

        public CultureInfo Language
        {
            get { return null; }
        }

        public string Legal
        {
            get { return null; }
        }

        public DateTime PublicationDate
        {
            get { return DateTime.MinValue; }
        }

        public string Publisher
        {
            get { return null; }
        }

        public string Title
        {
            get { throw null; }
        }
    }
}

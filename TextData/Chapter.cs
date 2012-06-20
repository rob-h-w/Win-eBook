using System;
using System.Xml.Linq;
using EBookData;

namespace TextData
{
    class Chapter : IChapter
    {
        public string Author
        {
            get { return null; }
        }

        public string Title
        {
            get { return null; }
        }

        public System.Xml.Linq.XDocument Content
        {
            get;
            set;
        }
    }
}

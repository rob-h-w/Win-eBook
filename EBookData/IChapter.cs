using System;
using System.Xml.Linq;

namespace EBookData
{
    public interface IChapter
    {
        string Author { get; }
        string Title { get; }
        XDocument Content { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookData
{
    public interface IBook
    {
        string Author { get; }
        IChapter [] Chapters { get; }
        ICover Cover { get; }
        string ISBN { get; }
        string Language { get; }
        string Path { get; }
        DateTime PublicationDate { get; }
        string Publisher { get; }
        string Legal { get; }
        string Title { get; }
    }
}

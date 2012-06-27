using System;
using System.Collections.Generic;

namespace EBookData
{
    public interface IBook : IBookMetaData
    {
        List<IChapter> Chapters { get; }
    }
}

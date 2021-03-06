﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace EBookData
{
    public interface IBookMetaData
    {
        string Author { get; }
        ICover Cover { get; }
        string Identifier { get; } // ISBN
        CultureInfo Language { get; }
        string Legal { get; }
        DateTime PublicationDate { get; }
        string Publisher { get; }
        string Title { get; }
    }
}

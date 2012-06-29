using System;
using System.Collections.ObjectModel;
using System.Globalization;
using EBookData;

namespace WinEbook.DataModel
{
    public sealed class Entry : WinEbook.Common.BindableBase, IBookMetaData
    {
        int _chapter = 0;
        public int Chapter
        {
            get { return _chapter; }
            set { SetProperty<int>(ref _chapter, value, "Chapter"); }
        }

        int _offset = 0;
        public int Offset
        {
            get { return _offset; }
            set { SetProperty<int>(ref _offset, value, "Offset"); }
        }

        string _path;
        public string Path
        {
            get { return _path; }
            set { SetProperty<string>(ref _path, value, "Path"); }
        }

        readonly ObservableCollection<string> _groups = new ObservableCollection<string>();
        public ObservableCollection<string> Groups
        {
            get { return _groups; }
        }

        #region From IBookMetaData
        string _author;
        public string Author
        {
            get { return _author; }
        }

        ICover _cover;
        public ICover Cover
        {
            get { return _cover; }
        }

        string _identifier;
        public string Identifier
        {
            get { return _identifier; }
        }

        CultureInfo _language;
        public CultureInfo Language
        {
            get { return _language; }
        }

        string _legal;
        public string Legal
        {
            get { return _legal; }
        }

        DateTime _publicationDate;
        public DateTime PublicationDate
        {
            get { return _publicationDate; }
        }

        string _publisher;
        public string Publisher
        {
            get { return _publisher; }
        }

        string _title;
        public string Title
        {
            get { return _title; }
        }
        #endregion From IBookMetaData

        public Entry() { }

        public Entry(EBook book)
        {
            _author = book.Author;
            // TODO: copy the relevant data here.
            //_cover = bookMetaData.Cover.SomeStuff;
            _identifier = book.Identifier;
            _language = (CultureInfo) (book.Language == null ? null : book.Language.Clone());
            _legal = book.Legal;
            _publicationDate = book.PublicationDate;
            _publisher = book.Publisher;
            _title = book.Title;
            book.Entry = this;
        }

        static bool Equals<T>(T left, T right)
        {
            return left.Equals(right);
        }

        static bool Equals<T>(ObservableCollection<T> left, ObservableCollection<T> right)
        {
            if (left == null || right == null)
            {
                if (left == null && right == null)
                {
                    return true;
                }

                return false;
            }

            int count = left.Count;
            if (count != right.Count)
            {
                return false;
            }

            for (int i = 0; i < count; ++i)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Equals(Entry other)
        {
            if (other == null)
            {
                return false;
            }

            if (Chapter != other.Chapter)
            {
                return false;
            }

            if (Offset != other.Offset)
            {
                return false;
            }

            if (Path != other.Path)
            {
                return false;
            }

            if (!Equals<string>(Groups, other.Groups))
            {
                return false;
            }

            if (Author != other.Author)
            {
                return false;
            }

            //if (!Equals<Cover>(Cover, other.Cover))
            //{
            //    return false;
            //}

            if (Identifier != other.Identifier)
            {
                return false;
            }

            if (Language != other.Language)
            {
                return false;
            }

            if (Legal != other.Legal)
            {
                return false;
            }

            if (PublicationDate != other.PublicationDate)
            {
                return false;
            }

            if (Publisher != other.Publisher)
            {
                return false;
            }

            if (Title != other.Title)
            {
                return false;
            }

            return true;
        }
    }
}

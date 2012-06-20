using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using System.Globalization;
using EBookData;

namespace WinEbook.DataModel
{
    public sealed class EBook : WinEbook.Common.BindableBase, IBook
    {
        string _path;
        public string Path
        {
            get { return _path; }
            private set { SetProperty<string>(ref _path, value, "Path"); }
        }

        public bool InLibrary { get; set; }

        string _author;
        public string Author
        {
            get { return _author; }
            set { SetProperty<string>(ref _author, value, "Author"); }
        }

        List<IChapter> _chapters;
        public List<IChapter> Chapters
        {
            get { return _chapters; }
            set { SetProperty<List<IChapter>>(ref _chapters, value, "Chapters"); }
        }

        ICover _cover;
        public ICover Cover
        {
            get { return _cover; }
            set { SetProperty<ICover>(ref _cover, value, "Cover"); }
        }

        string _identifier;
        public string Identifier
        {
            get { return _identifier; }
            set { SetProperty<string>(ref _identifier, value, "Identifier"); }
        }

        CultureInfo _language;
        public CultureInfo Language
        {
            get { return _language; }
            set { SetProperty<CultureInfo>(ref _language, value, "Language"); }
        }

        string _legal;
        public string Legal
        {
            get { return _legal; }
            set { SetProperty<string>(ref _legal, value, "Legal"); }
        }

        DateTime _publicationDate;
        public DateTime PublicationDate
        {
            get { return _publicationDate; }
            set { SetProperty<DateTime>(ref _publicationDate, value, "PublicationDate"); }
        }

        string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { SetProperty<string>(ref _publisher, value, "Publisher"); }
        }

        string _title;
        public string Title
        {
            get { return _title; }
            private set { SetProperty<string>(ref _title, value, "Title"); }
        }

        private void Copy(IBook other)
        {
            if (this == other)
            {
                return;
            }

            Author = other.Author;
            Chapters = other.Chapters;
            Cover = other.Cover;
            Identifier = other.Identifier;
            Language = other.Language;
            Legal = other.Legal;
            PublicationDate = other.PublicationDate;
            Publisher = other.Publisher;
        }

        // Rob TODO: This should really be the result of querying the contents of a plugins folder.
        // Windows 8 appears to strenuously resist attempts to use the file system to load executable
        // code. Solving this is beyond the scope of this project at the moment.
        private static readonly MetaData[] _plugins = { new TextData.MetaData() };
        private async void Load(IStorageItem item)
        {
            bool loaderFound = false;
            foreach (MetaData metaData in _plugins)
            {
                if (await metaData.Supports(item))
                {
                    IBook book = await metaData.Load(item);
                    Copy(book);
                    loaderFound = true;
                    break;
                }
            }

            if (!loaderFound)
            {
                throw new PlatformNotSupportedException("Cannot open " + item.Path);
            }

            // The path doesn't need parsing.
            Path = item.Path;
        }

        public EBook(FileActivatedEventArgs bookPath)
        {
            Load(bookPath.Files[0]);
        }
    }
}

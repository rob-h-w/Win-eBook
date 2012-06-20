using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using EBookData;

namespace WinEbook.Data
{
    public sealed class EBook : WinEbook.Common.BindableBase, IBook
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            private set { SetProperty<string>(ref _path, value, "Path"); }
        }

        public bool InLibrary { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            private set { SetProperty<string>(ref _title, value, "Title"); }
        }

        public string Author
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<EBookData.IChapter> Chapters
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public EBookData.ICover Cover
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Identifier
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Language
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime PublicationDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Publisher
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Legal
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        // Rob TODO: This should really be the result of querying the contents of a plugins folder.
        // Windows 8 appears to strenuously resist attempts to use the file system to load executable
        // code. Solving this is beyond the scope of this project at the moment.
        private static readonly MetaData[] _plugins = { new TextData.MetaData() };
        private async void Load(IStorageItem item)
        {
            // The path doesn't need parsing.
            Path = item.Path;

            foreach (MetaData metaData in _plugins)
            {
                if (await metaData.Supports(item))
                {
                    IBook book = await metaData.Load(item);
                    break;
                }
            }
        }

        public EBook(FileActivatedEventArgs bookPath)
        {
            Load(bookPath.Files[0]);
        }
    }
}

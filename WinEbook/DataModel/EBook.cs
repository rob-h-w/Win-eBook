using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
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

        public EBook(FileActivatedEventArgs bookPath)
        {
            Path = bookPath.Files[0].Path;
        }
    }
}

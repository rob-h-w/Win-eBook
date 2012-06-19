using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Xaml.Data;
using Windows.ApplicationModel.Activation;

namespace WinEbook.Data
{
    public class EBook : WinEbook.Common.BindableBase
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            private set { SetProperty<string>(ref _path, value, "Path"); }
        }

        public bool InLibrary { get; set; }

        private string _title;
        public string Title {
            get { return _title; }
            private set { SetProperty<string>(ref _title, value, "Title"); }
        }

        public EBook(FileActivatedEventArgs bookPath)
        {
            Path = bookPath.Files[0].Path;
        }
    }

    public sealed class Library
    {
    }

    public sealed class EReaderModel
    {
        private static EReaderModel _model = new EReaderModel();
        private static EReaderModel Model
        {
            get
            {
                return _model;
            }
        }

        private Library _library = new Library();
        public static Library Library
        {
            get
            {
                return Model._library;
            }
        }

        private EBook _currentBook;
        public static EBook CurrentBook
        {
            get
            {
                return Model._currentBook;
            }
            set
            {
                Model._currentBook = value;
            }
        }

        public EReaderModel()
        {
            // TODO: parse the library contents.
        }
    }
}

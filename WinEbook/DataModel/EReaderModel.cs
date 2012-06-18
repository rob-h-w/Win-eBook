using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Xaml.Data;

namespace WinEbook.Data
{
    public class EBook : WinEbook.Common.BindableBase
    {
        private string _path;
        public string Path
        {
            get
            {
                return _path;
            }
        }

        public bool InLibrary { get; set; }

        private string _title;
        public string Title {
            get
            {
                return _title;
            }
        }

        public EBook(string bookPath)
        {
            _path = bookPath;
        }
    }

    public sealed class Library
    {
    }

    public sealed class EReaderModel
    {
        private static EReaderModel _model = new EReaderModel();
        public static EReaderModel Model
        {
            get
            {
                return _model;
            }
        }

        private Library _library = new Library();
        public Library Library
        {
            get
            {
                return _library;
            }
        }

        private EBook _currentBook;
        public EBook CurrentBook
        {
            get
            {
                return _currentBook;
            }
            set
            {
                _currentBook = value;
            }
        }

        public EReaderModel()
        {
            // TODO: parse the library contents.
        }
    }
}

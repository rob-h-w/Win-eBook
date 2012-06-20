using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Xaml.Data;

namespace WinEbook.Data
{
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

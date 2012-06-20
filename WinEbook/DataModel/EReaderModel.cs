namespace WinEbook.DataModel
{
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

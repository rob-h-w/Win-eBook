using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinEbook.DataModel
{
    public sealed class Entry : WinEbook.Common.BindableBase
    {
        int _chapter;
        public int Chapter
        {
            get { return _chapter; }
            set { SetProperty<int>(ref _chapter, value, "Chapter"); }
        }

        int _offset;
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

        List<string> _groups;
        public List<string> Groups
        {
            get { return _groups; }
            set { SetProperty<List<string>>(ref _groups, value, "Groups"); }
        }
    }
}

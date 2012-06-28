using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WinEbook.DataModel
{
    public sealed class Library : WinEbook.Common.BindableBase
    {
        readonly Dictionary<string, Entry> _entriesByPath = new Dictionary<string, Entry>();
        readonly ObservableCollection<Entry> _entries = new ObservableCollection<Entry>();

        public Entry this[EBook index]
        {
            get
            {
                return _entriesByPath[index.Path];
            }
            set
            {
                if (null == index)
                {
                    // Ignore.
                    return;
                }

                if (!Contains(index))
                {
                    _entriesByPath.Add(index.Path, value);
                    EntryAdded(value);
                    return;
                }

                Entry current = _entriesByPath[index.Path];
                if (null == value)
                {
                    // Remove the entry.
                    _entriesByPath.Remove(index.Path);
                    EntryRemoved(current);
                }
                else
                {
                    if (!current.Equals(value))
                    {
                        // Update the entry.
                        _entriesByPath[index.Path] = value;
                        EntryChanged(value);
                    }
                }
            }
        }

        public delegate void EntryHandler(Entry added);
        public event EntryHandler EntryAdded;
        public event EntryHandler EntryChanged;
        public event EntryHandler EntryRemoved;

        public bool Contains(Entry entry)
        {
            return _entriesByPath.ContainsKey(entry.Path);
        }

        public bool Contains(EBook book)
        {
            return _entriesByPath.ContainsKey(book.Path);
        }
    }
}

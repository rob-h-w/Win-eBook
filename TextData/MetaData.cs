using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextData
{
    public class MetaData : EBookData.MetaData
    {
        protected override EBookData.MetaData.RequiredDataFormat Format
        {
            get { return RequiredDataFormat.Text; }
        }

        protected override Windows.Storage.Streams.UnicodeEncoding Encoding
        {
            get { return Windows.Storage.Streams.UnicodeEncoding.Utf8; }
        }

        protected override bool Supports(Windows.Storage.IStorageItem item, ref bool furtherChecks)
        {
            furtherChecks = false;
            return item.Name.EndsWith(".txt");
        }

        protected override bool Supports(Windows.Storage.Streams.IBuffer buffer)
        {
            throw new NotImplementedException();
        }

        protected override bool Supports(IList<string> lines)
        {
            throw new NotImplementedException();
        }

        protected override bool Supports(string text)
        {
            throw new NotImplementedException();
        }

        protected override EBookData.IBook Load(Windows.Storage.Streams.IBuffer buffer)
        {
            throw new NotImplementedException();
        }

        protected override EBookData.IBook Load(IList<string> lines)
        {
            throw new NotImplementedException();
        }

        protected override EBookData.IBook Load(string text)
        {
            throw new NotImplementedException();
        }

        protected override EBookData.IBook Load()
        {
            throw new NotImplementedException();
        }
    }
}

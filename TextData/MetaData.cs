using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TextData
{
    public class MetaData : EBookData.MetaData
    {
        protected override EBookData.MetaData.RequiredDataFormat Format
        {
            get { return RequiredDataFormat.Lines; }
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
            Book book = new Book();
            List<EBookData.IChapter> chapters = new List<EBookData.IChapter>(1);

            Chapter chapter = new Chapter();
            StringBuilder content = new StringBuilder();
            foreach (string line in lines)
            {
                content.Append(line);
                content.Append("<br />");
            }

            XDocument doc = new XDocument(
                new XElement("html",
                    new XElement("head",
                        new XElement("title")),
                    new XElement("body", content.ToString())));

            chapter.Content = doc;

            chapters.Add(chapter);
            book.Chapters = chapters;
            return book;
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

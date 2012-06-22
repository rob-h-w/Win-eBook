using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
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
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                // <!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
                new XDocumentType("html", "-//W3C//DTD XHTML 1.0 Transitional//EN", "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", ""));

            using (XmlWriter writer = doc.CreateWriter())
            {
                writer.WriteStartElement("html");
                writer.WriteStartElement("body");

                foreach (string line in lines)
                {
                    // Replace broken characters with '?'.
                    string sanitizedLine = line;
                    for (uint i = 0; i < 0x20; ++i)
                    {
                        if (i == 0x9
                            || i == 0xA
                            || i == 0xD)
                        {
                            continue;
                        }
                        sanitizedLine = sanitizedLine.Replace((char)i, '?');
                    }
                    writer.WriteString(sanitizedLine);
                    
                    writer.WriteStartElement("br");
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }

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

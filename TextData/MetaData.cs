using System;
using System.Collections.Generic;
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
                    try
                    {
                        // Documentation http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=EN-US&k=k(System.Xml.XmlWriter.WriteString);k(TargetFrameworkMoniker-.NETCore,Version%3Dv4.5);k(DevLang-csharp)&rd=true
                        // Says that WriteString should throw an ArgumentException if a bad character such as \f is sent. This is not true.
                        foreach (char ch in line)
                        {
                            if (ch >= 0 && ch <= 0x1F)
                            {
                                if (ch == 0x9
                                    || ch == 0xA
                                    || ch == 0xD)
                                {
                                    continue;
                                }

                                throw new ArgumentException("Character '" + ch + "' is not a valid XML character.");
                            }
                        }
                        writer.WriteString(line);
                    }
                    catch (ArgumentException e)
                    {
                    }
                    finally // Ignore unsupported characters in the text file.
                    {
                        writer.WriteStartElement("br");
                        writer.WriteEndElement();
                    }
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace EBookData
{
    public abstract class MetaData
    {
        #region MetaData format requirements description
        protected enum RequiredDataFormat
        {
            IBuffer,
            Lines,
            Text
        }
        protected abstract RequiredDataFormat Format { get; }
        protected abstract Windows.Storage.Streams.UnicodeEncoding Encoding { get; }
        private delegate T BufferDelegate<T>(IBuffer buffer);
        private delegate T LinesDelegate<T>(IList<string> lines);
        private delegate T TextDelegate<T>(string text);

        private async Task<T> DispatchDataToHandlers<T>(IStorageFile file,
            BufferDelegate<T> buffer,
            LinesDelegate<T> lines,
            TextDelegate<T> text)
        {
            switch (Format)
            {
                case RequiredDataFormat.IBuffer:
                    {
                        return buffer(await FileIO.ReadBufferAsync(file));
                    }
                case RequiredDataFormat.Lines:
                    {
                        return lines(await FileIO.ReadLinesAsync(file, Encoding));
                    }
                case RequiredDataFormat.Text:
                    {
                        return text(await FileIO.ReadTextAsync(file, Encoding));
                    }
                default:
                    {
                        throw new NotSupportedException("Invalid data format selected");
                    }
            }
        }
        #endregion MetaData format requirements description.

        #region Logic determining if a Data plugin supports the provided format.
        protected abstract bool Supports(IStorageItem item, ref bool furtherChecks);

        protected abstract bool Supports(IBuffer buffer);
        protected abstract bool Supports(IList<string> lines);
        protected abstract bool Supports(string text);

        private async Task<bool> DoSupports(IStorageFile file)
        {
            return await DispatchDataToHandlers<bool>(file,
                new BufferDelegate<bool>(Supports),
                new LinesDelegate<bool>(Supports),
                new TextDelegate<bool>(Supports));
        }

        private async Task<bool> DoSupports(IStorageFolder folder)
        {
            bool supported = false;

            foreach (IStorageItem item in await folder.GetItemsAsync())
            {
                supported = await Supports(item);
                if (!supported)
                {
                    break;
                }
            }

            return supported;
        }

        public async Task<bool> Supports(IStorageItem item)
        {
            bool furtherChecks = false;
            bool supported = Supports(item, ref furtherChecks);

            if (!furtherChecks || !supported)
            {
                return supported;
            }

            if (item.IsOfType(StorageItemTypes.File))
            {
                return await DoSupports((IStorageFile)item);
            }
            else if (item.IsOfType(StorageItemTypes.Folder))
            {
                return await DoSupports((IStorageFolder)item);
            }

            throw new NotSupportedException("Cannot analyse a file system entity that is neither a file nor a folder");
        }
        #endregion Logic determining if a Data plugin supports the provided format.

        #region Code for actually loading an eBook from the supplied data source.
        protected abstract IBook Load(IBuffer buffer);
        protected abstract IBook Load(IList<string> lines);
        protected abstract IBook Load(string text);
        protected abstract IBook Load();

        private async Task<IBook> DoLoad(IStorageFile file)
        {
            return await DispatchDataToHandlers<IBook>(file,
                new BufferDelegate<IBook>(Load),
                new LinesDelegate<IBook>(Load),
                new TextDelegate<IBook>(Load));
        }

        private async Task DoLoad(IStorageFolder folder)
        {
            foreach (IStorageItem item in await folder.GetItemsAsync())
            {
                await Load(item);
            }
        }

        public async Task<IBook> Load(IStorageItem item)
        {
            if (item.IsOfType(StorageItemTypes.File))
            {
                return await DoLoad((IStorageFile)item);
            }
            else if (item.IsOfType(StorageItemTypes.Folder))
            {
                await DoLoad((IStorageFolder)item);
                return Load();
            }

            throw new NotSupportedException("Cannot Load a file system entity that is neither a file nor a folder");
        }
        #endregion Code for actually loading an eBook from the supplied data source.
    }
}

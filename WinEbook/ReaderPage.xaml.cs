using System;
using Windows.UI.Xaml.Navigation;
using WinEbook.Common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinEbook
{
    /// <summary>
    /// The page that presents the ebook contents.
    /// </summary>
    public sealed partial class ReaderPage : LayoutAwarePage
    {
        public ReaderPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string html = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>\r\n" + DataModel.EReaderModel.CurrentBook.Chapters[0].Content.ToString();
            EReaderView.NavigateToString(html);
            base.OnNavigatedTo(e);
        }
    }
}

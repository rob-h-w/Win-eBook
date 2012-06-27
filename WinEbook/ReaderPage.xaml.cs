using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using EBookData;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WinEbook.Common;
using WinEbook.DataModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinEbook
{
    /// <summary>
    /// The page that presents the ebook contents.
    /// </summary>
    public sealed partial class ReaderPage : LayoutAwarePage
    {
        private WebViewBrush _brush = new WebViewBrush();

        public ReaderPage()
        {
            this.InitializeComponent();
            _brush.SourceName = "EReaderView";
            _brush.Redraw();
            WebViewBrushArea.Fill = _brush;
        }

        private string Html()
        {
            Entry entry = EReaderModel.CurrentBook.Entry;
            IChapter chapter = EReaderModel.CurrentBook.Chapters[entry.Chapter];
            XDocument doc = chapter.Content;

            // Get the body element.
            XElement body = doc.Root.Element("body");
            body.SetAttributeValue("style", String.Format("position:absolute; top: {0}px;", -entry.Offset));
            return doc.ToString();
        }

        private void NextPage()
        {
            EReaderModel.CurrentBook.Entry.Offset += (int)WebViewBrushArea.ActualHeight;
            EReaderView.Visibility = Windows.UI.Xaml.Visibility.Visible;
            EReaderView.NavigateToString(Html());
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            EReaderView.NavigateToString(Html());
            base.OnNavigatedTo(e);
        }

        private void Home_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            App.ResetStackToHome();
        }

        private void EReaderView_LoadCompleted(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            _brush.Redraw();
            EReaderView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void WebViewBrushArea_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            NextPage();
        }

        private void Next_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	NextPage();
        }
    }
}

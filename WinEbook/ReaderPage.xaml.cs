using System;
using System.Text;
using System.Xml;
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
            EReaderView.NavigateToString(DataModel.EReaderModel.CurrentBook.Chapters[0].Content.ToString());
            base.OnNavigatedTo(e);
        }

        private void EReaderView_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			// Go to the next page.
        }

        private void EReaderView_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			// Go to the previous page.
        }

        private void Home_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            App.ResetStackToHome();
        }
    }
}

using System;
using Windows.UI.Xaml;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace WinEbook
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class OpenFilePage : WinEbook.Common.LayoutAwarePage
    {
        public OpenFilePage()
        {
            this.InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ReaderPage));
        }

        private void AddToLibraryButton_Click(object sender, RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }
    }
}

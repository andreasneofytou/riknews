using RikNews.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RikNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MediaPage : Page
    {
        public enum MediaType
        {
            Video,
            Audio
        }

        public MediaPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var type = (MediaType)e.Parameter;
            if (type == MediaType.Video)
            {
                MediaList.ItemsSource = await ApiClient.GetVod();
            }
            else
            {
                MediaList.ItemsSource = await ApiClient.GetAod();
            }
        }

        private void MediaList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Frame.Navigate(typeof(MediaPlayer), e.ClickedItem))
            {
                throw new Exception("Navigation to MediaPlayer failed");
            }
        }
    }
}

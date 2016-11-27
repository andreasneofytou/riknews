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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RikNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = !MainMenu.IsPaneOpen;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!ContentFrame.Navigate(typeof(NewsPage)))
            {
                throw new Exception("Navigation to NewsPage failed");
            }
        }

        private void Vod_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = false;
            if (!ContentFrame.Navigate(typeof(MediaPage), MediaPage.MediaType.Video))
            {
                throw new Exception("Navigation to MediaPage failed");
            }
        }

        private void WorldNews_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = false;
            if (!ContentFrame.Navigate(typeof(NewsPage)))
            {
                throw new Exception("Navigation to NewsPage failed");
            }
        }

        private void SportNews_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = false;
            if (!ContentFrame.Navigate(typeof(SportsPage)))
            {
                throw new Exception("Navigation to SportsPage failed");
            }
        }

        private void Aod_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.IsPaneOpen = false;
            if (!ContentFrame.Navigate(typeof(MediaPage), MediaPage.MediaType.Audio))
            {
                throw new Exception("Navigation to MediaPage failed");
            }
        }
    }
}

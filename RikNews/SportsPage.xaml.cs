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
    public sealed partial class SportsPage : Page
    {
        public SportsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void ArticlesList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Frame.Navigate(typeof(ArticlePage), e.ClickedItem))
            {
                throw new Exception("Navigation to ArticlePage failed");
            }
        }

        private async void ADivisionArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            ADivisionArticlesList.ItemsSource = await ApiClient.GetADivision();
        }

        private async void GreekSportsArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            GreekSportsArticlesList.ItemsSource = await ApiClient.GetGreekSports();
        }

        private async void InternationalSportsArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            InternationalSportsArticlesList.ItemsSource = await ApiClient.GetInternationalSports();
        }

        private async void OtherDivisionsArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            OtherDivisionsArticlesList.ItemsSource = await ApiClient.GetOtherDivisions();
        }

        private async void OtherSportsArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            OtherSportsArticlesList.ItemsSource = await ApiClient.GetOtherSports();
        }
    }
}

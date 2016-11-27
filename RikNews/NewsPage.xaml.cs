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
    public sealed partial class NewsPage : Page
    {
        public NewsPage()
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

        private async void PoliticsArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            PoliticsArticlesList.ItemsSource = await ApiClient.GetPolitics();
        }

        private async void EconomyArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            EconomyArticlesList.ItemsSource = await ApiClient.GetEconomy();
        }

        private async void SocietyArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            SocietyArticlesList.ItemsSource = await ApiClient.GetSociety();
        }

        private async void GreekArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            GreekArticlesList.ItemsSource = await ApiClient.GetGreekNews();
        }

        private async void EuropeanArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            EuropeanArticlesList.ItemsSource = await ApiClient.GetEuropeanNews();
        }

        private async void InternationalArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            InternationalArticlesList.ItemsSource = await ApiClient.GetInternationalNews();
        }

        private async void AllArticlesList_Loaded(object sender, RoutedEventArgs e)
        {
            AllArticlesList.ItemsSource = await ApiClient.GetTopNews();
        }
    }
}

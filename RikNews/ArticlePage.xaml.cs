using HtmlAgilityPack;
using RikNews.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RikNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticlePage : Page
    {
        public ArticlePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Article)
            {
                DataContext = (Article)e.Parameter;
                SetArticleDiscription(((Article)e.Parameter).IntroText + ((Article)e.Parameter).FullText);
            }
        }

        private void SetArticleDiscription(string description)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(description);
            foreach (var node in doc.DocumentNode.DescendantsAndSelf())
            {
                if (node.Name.Equals("p"))
                {
                    var paragraph = new Paragraph();
                    var myRun = new Run { Text = "\n" };
                    paragraph.Inlines.Add(myRun);
                    foreach (var innerNode in node.ChildNodes)
                    {
                        //paragraph.Inlines.Add(GetRun(node));
                        if (innerNode.HasChildNodes)
                        {
                            foreach (var secondNode in innerNode.ChildNodes)
                            {
                                if (secondNode.HasChildNodes)
                                {
                                    foreach (var thirdNode in secondNode.ChildNodes)
                                    {
                                        if (thirdNode.HasChildNodes)
                                        {
                                            foreach (var fourthNode in thirdNode.ChildNodes)
                                            {
                                                if (fourthNode.HasChildNodes)
                                                {
                                                    foreach (var fifthNode in fourthNode.ChildNodes)
                                                    {
                                                        paragraph.Inlines.Add(GetProperInnerText(fifthNode));
                                                    }

                                                }
                                                else
                                                {
                                                    paragraph.Inlines.Add(GetProperInnerText(fourthNode));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            paragraph.Inlines.Add(GetProperInnerText(thirdNode));
                                        }

                                    }
                                }
                                else
                                {
                                    paragraph.Inlines.Add(GetProperInnerText(secondNode));
                                }
                            }
                        }
                        else
                        {
                            paragraph.Inlines.Add(GetProperInnerText(innerNode));
                        }

                    }

                    RichDescription.Blocks.Add(paragraph);

                }
            }
        }

        private Run GetRun(HtmlNode node)
        {
            foreach (var innerNode in node.ChildNodes)
            {
                return GetRun(innerNode);
            }
            return GetProperInnerText(node);
        }

        private Run GetProperInnerText(HtmlNode node)
        {
            switch (node.ParentNode.Name)
            {
                case "strong":
                    return new Run { Text = node.InnerText, FontWeight = FontWeights.Bold };
                case "a":
                case "#text":
                case "span":
                default:
                    return new Run { Text = node.InnerText };
            }
        }

        private void ChangeFontSize(int sizeDelta)
        {
            var newSize = RichDescription.FontSize + sizeDelta;
            if (newSize < 23 && newSize > 7)
            {
                RichDescription.FontSize = newSize;
            }
        }

        private void FontIncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeFontSize(2);
        }

        private void FontDecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeFontSize(-2);
        }
    }
}

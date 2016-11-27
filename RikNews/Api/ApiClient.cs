using Newtonsoft.Json;
using RikNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RikNews.Api
{
    public class ApiClient
    {
        private static readonly string _topNewsUrl = "http://www.riknews.com.cy/index.php/riknews/itemlist?format=json&moduleID=393";
        private static readonly string _politicsUrl = "http://www.riknews.com.cy/index.php/news/politiki/itemlist?format=json&moduleID=274";
        private static readonly string _economyUrl = "http://www.riknews.com.cy/index.php/news/oikonomia/itemlist?format=json&moduleID=281";
        private static readonly string _societyUrl = "http://www.riknews.com.cy/index.php/news/kinonia/itemlist?format=json&moduleID=282";
        private static readonly string _greekUrl = "http://www.riknews.com.cy/index.php/news/ellada/itemlist?format=json&moduleID=283";
        private static readonly string _europeanUrl = "http://www.riknews.com.cy/index.php/news/evropi/itemlist?format=json&moduleID=284";
        private static readonly string _internationalUrl = "http://www.riknews.com.cy/index.php/news/diethni/itemlist?format=json&moduleID=285";

        private static readonly string _aDivisionSportsUrl = "http://www.riknews.com.cy/index.php/sports/a-katigoria/itemlist?format=json&moduleID=341";        
        private static readonly string _greekSportsUrl = "http://www.riknews.com.cy/index.php/sports/greece/itemlist?format=json&moduleID=342";
        private static readonly string _internationalSportsUrl = "http://www.riknews.com.cy/index.php/sports/diethni/itemlist?format=json&moduleID=343";
        private static readonly string _otherDivisionsUrl = "http://www.riknews.com.cy/index.php/sports/mikres-katigories/itemlist?format=json&moduleID=344";
        private static readonly string _otherSportssUrl = "http://www.riknews.com.cy/index.php/sports/alla-athlimata/itemlist?format=json&moduleID=373";

        private static readonly string _vodUrl = "http://www.cybc-media.com/vod2/media/jmsmusic/tmp/xml/video-playlist.xml";
        private static readonly string _aodUrl = " http://www.cybc-media.com/aod2/media/jmsmusic/tmp/xml/audio-playlist.xml";       

        public async static Task<List<Article>> GetTopNews()
        {
           return await GetArticles(_topNewsUrl);
        }

        public async static Task<List<Article>> GetPolitics()
        {
            return await GetArticles(_politicsUrl);
        }

        public async static Task<List<Article>> GetEconomy()
        {
            return await GetArticles(_economyUrl);
        }

        public async static Task<List<Article>> GetSociety()
        {
            return await GetArticles(_societyUrl);
        }

        public async static Task<List<Article>> GetGreekNews()
        {
            return await GetArticles(_greekUrl);
        }

        public async static Task<List<Article>> GetEuropeanNews()
        {
            return await GetArticles(_europeanUrl);
        }

        public async static Task<List<Article>> GetInternationalNews()
        {
            return await GetArticles(_internationalUrl);
        }

        public async static Task<List<Article>> GetADivision()
        {
            return await GetArticles(_aDivisionSportsUrl);
        }

        public async static Task<List<Article>> GetGreekSports()
        {
            return await GetArticles(_greekSportsUrl);
        }

        public async static Task<List<Article>> GetInternationalSports()
        {
            return await GetArticles(_internationalSportsUrl);
        }

        public async static Task<List<Article>> GetOtherDivisions()
        {
            return await GetArticles(_otherDivisionsUrl);
        }

        public async static Task<List<Article>> GetOtherSports()
        {
            return await GetArticles(_otherSportssUrl);
        }

        public async static Task<List<Media>> GetVod()
        {
            return await GetMedia(_vodUrl);
        }

        public async static Task<List<Media>> GetAod()
        {
            return await GetMedia(_aodUrl);
        }

        private async static Task<List<Article>> GetArticles(string url)
        {
            HttpClient client = new HttpClient();
            List<Article> list = new List<Article>();
            using (HttpResponseMessage response = await client.GetAsync(new Uri(url, UriKind.Absolute)))
            {
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<Response>(json).Items;
                }
            }
            return list;
        }

        private async static Task<List<Media>> GetMedia(string url)
        {
            List<Media> media = new List<Media>();
            HttpClient client = new HttpClient();
            using(HttpResponseMessage response = await client.GetAsync(new Uri(url, UriKind.Absolute)))
            {
                if (response.IsSuccessStatusCode)
                {
                    string contentxml = await response.Content.ReadAsStringAsync();
                    XElement elem = XElement.Parse(contentxml);
                    media =
                      (
                        from i in elem.DescendantsAndSelf("item")
                        select new Media(i)
                      ).ToList();
                }
            }

            return media;
        }
    }
}

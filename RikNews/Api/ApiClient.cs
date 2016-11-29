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
        private const string RikBaseUrl = "http://www.riknews.com.cy/index.php/riknews/itemlist?format=json&moduleID=";
        private static readonly int _topNewsUrl = 393;
        private static readonly int _politicsUrl = 274;
        private static readonly int _economyUrl = 281;
        private static readonly int _societyUrl = 282;
        private static readonly int _greekUrl = 283;
        private static readonly int _europeanUrl = 284;
        private static readonly int _internationalUrl = 285;
        private static readonly int _culture = 441;
        private static readonly int _health = 442;
        private static readonly int _environment = 443;
        private static readonly int _science = 444;
        private static readonly int _art = 447;
        private static readonly int _exclusives = 497;
        private static readonly int _rikInAction = 498;
        private static readonly int _analysis = 498;

        private static readonly int _aDivisionSportsUrl = 341;        
        private static readonly int _greekSportsUrl = 342;
        private static readonly int _internationalSportsUrl = 343;
        private static readonly int _otherDivisionsUrl = 344;
        private static readonly int _otherSportssUrl = 373;
        private static readonly int _cars = 412;
        private static readonly int _championsLeague = 413;
        private static readonly int _europaLeague = 414;

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

        private async static Task<List<Article>> GetArticles(int moduleId)
        {
            HttpClient client = new HttpClient();
            List<Article> list = new List<Article>();
            string url = RikBaseUrl + moduleId;
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

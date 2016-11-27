using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RikNews.Models
{
    public class Article
    {
        private readonly string _baseUrl = "http://riknews.com.cy";

        public int Id { get; set; }
        private string _title;
        public string Title {
            get {
                return WebUtility.HtmlDecode(_title);
            }
            set {
                _title = value;
            }
        }

        private string _introText;
        public string IntroText {
            get {
                return WebUtility.HtmlDecode(_introText);
            }
            set {
                _introText = value;
            }
        }

        private string _fullText;
        public string FullText {
            get {
                return WebUtility.HtmlDecode(_fullText);
            }
            set {
                _fullText = value;
            }
        }
        public Author Author { get; set; }
        public string Alias { get; set; }
        public Category Category { get; set; }
        public int CatId { get; set; }
        private string _created;
        public string Created {
            get {
                DateTime dt;
                DateTime.TryParseExact(_created, "yyyy-MM-dd HH:mm:ss",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out dt);
                if (dt != null)
                {
                    return dt.ToString("dddd, dd MMM yyyy HH:mm", new CultureInfo("el-gr"));
                }
                return "";
            }
            set {
                _created = value;
            }
        }
        private string _image;
        public string Image {
            get {
                if (!_image.StartsWith(_baseUrl))
                {
                    return _baseUrl + _image;
                }
                return _image;
            }
            set {
                _image = value;
            }
        }
        private string _imageLarge;
        public string ImageLarge {
            get {
                if (!_imageLarge.StartsWith(_baseUrl))
                {
                    return _baseUrl + _imageLarge;
                }
                return _imageLarge;
            }
            set {
                _imageLarge = value;
            }
        }
        private string _imageMedium;
        public string ImageMedium {
            get {
                if (!_imageMedium.StartsWith(_baseUrl))
                {
                    return _baseUrl + _imageMedium;
                }
                return _imageMedium;
            }
            set {
                _imageMedium = value;
            }
        }
        private string _imageSmall;
        public string ImageSmall {
            get {
                if (!_imageSmall.StartsWith(_baseUrl))
                {
                    return _baseUrl + _imageSmall;
                }
                return _imageSmall;
            }
            set {
                _imageSmall = value;
            }
        }
        private string _imageXLarge;
        public string ImageXLarge {
            get {
                if (!_imageXLarge.StartsWith(_baseUrl))
                {
                    return _baseUrl + _imageXLarge;
                }
                return _imageXLarge;
            }
            set {
                _imageXLarge = value;
            }
        }
        private string _imageXSmall;
        public string ImageXSmall {
            get {
                if (!_imageXSmall.StartsWith(_baseUrl))
                {
                    return _baseUrl + _imageXSmall;
                }
                return _imageXSmall;
            }
            set {
                _imageXSmall = value;
            }
        }
        public string Link { get; set; }
        public string Modified { get; set; }
    }
}

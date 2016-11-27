using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RikNews.Models
{
    public class Response
    {
        public ResponseInfo Site { get; set; }
        public List<Article> Items { get; set; }
    }

    public class ResponseInfo
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
}

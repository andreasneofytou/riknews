using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RikNews.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Ordering { get; set; }
    }
}

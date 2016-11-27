using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RikNews.Models
{
    public class Media
    {
        public Media(XElement media)
        {
            var temp = media.FirstNode;
            while (temp != null)
            {
                SetValue((XElement)temp);
                temp = temp.NextNode;
            }
        }

        private void SetValue(XElement node)
        {
            switch (node.Name.ToString())
            {
                case "id":
                    Id = node.Value;
                    break;
                case "title":
                    Title = node.Value;
                    break;
                case "image":
                    Image = node.Value;
                    break;
                case "description":
                    Description = node.Value;
                    break;
                case "{http://search.yahoo.com/mrss/}content":
                        MediaUrl = node.FirstAttribute.Value;
                    break;
                default:
                    break;
            }
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Image { get; private set; }
        public string Description { get; private set; }
        public string MediaUrl { get; private set; }
    }
}

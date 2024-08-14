using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductFunction
{
    public class Product
    {
        public Guid id { get; set; }
        public Guid categoryId { get; set; }
        public string? categoryName { get; set; }
        public string? sku { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public double price { get; set; }
        public ICollection<Tag>? tags { get; set; }
        public string? _rid { get; set; }
        public string? _self { get; set; }
        public string? _etag { get; set; }
        public string? _attachments { get; set; }
        public int _ts { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this); // makes the model into a json, to return to the end user
        }
    }
    public class Tag
    {
        public Guid id { get; set; }
        public string? name { get; set; }
    }
}

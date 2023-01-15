using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DummyShop.Service.ViewModel
{
    public class RootViewModel
    {
        [JsonPropertyName("products")]
        public ProductViewModel[] products { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }
}

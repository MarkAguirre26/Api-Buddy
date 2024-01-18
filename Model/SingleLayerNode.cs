using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Buddy.Model
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class SingleLayerNode
    {


        public class Header
        {
            public string key { get; set; }
            public string value { get; set; }
            public string type { get; set; }
            public bool? disabled { get; set; }
        }

        public class Info
        {
            public string _postman_id { get; set; }
            public string name { get; set; }
            public string schema { get; set; }
            public string _exporter_id { get; set; }
        }

        public class Item
        {
            public string name { get; set; }
            public Request request { get; set; }
            public List<object> response { get; set; }
        }

        public class Body
        {
            public string mode { get; set; }
            public string raw { get; set; }

        }



        public class Query
        {
            public string key { get; set; }
            public string value { get; set; }
            public bool? disabled { get; set; }
        }

        public class Request
        {
            public string method { get; set; }
            public List<Header> header { get; set; }
            public Url url { get; set; }
            public Body body { get; set; }
        }

        public class SingleLayerNodeMain
        {
            public Info info { get; set; }
            public List<Item> item { get; set; }
        }

        public class Url
        {
            public string raw { get; set; }
            public List<string> host { get; set; }
            public List<string> path { get; set; }
            public List<Query> query { get; set; }
            public string protocol { get; set; }
        }

    }

}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Buddy.Model
{
    public class DoubleLayerNode
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Body
        {
            public string mode { get; set; }
            public string raw { get; set; }
            public Options options { get; set; }
        }

        public class DisabledSystemHeaders
        {
            [JsonProperty("content-type")]
            public bool contenttype { get; set; }

            [JsonProperty("content-length")]
            public bool contentlength { get; set; }
            public bool connection { get; set; }

            [JsonProperty("accept-encoding")]
            public bool acceptencoding { get; set; }
            public bool host { get; set; }

            [JsonProperty("user-agent")]
            public bool useragent { get; set; }
        }

        public class Event
        {
            public string listen { get; set; }
            public Script script { get; set; }
        }

        public class Header
        {
            public string key { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string value { get; set; }
            public bool? disabled { get; set; }
            public string description { get; set; }
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
            public List<Item> item { get; set; }
            public List<Event> @event { get; set; }
            public Request request { get; set; }
            public List<object> response { get; set; }
            public ProtocolProfileBehavior protocolProfileBehavior { get; set; }
        }

        public class Options
        {
            public Raw raw { get; set; }
        }

        public class ProtocolProfileBehavior
        {
            public bool disableBodyPruning { get; set; }
            public DisabledSystemHeaders disabledSystemHeaders { get; set; }
        }

        public class Query
        {
            public string key { get; set; }
            public string value { get; set; }
            public bool disabled { get; set; }
        }

        public class Raw
        {
            public string language { get; set; }
        }

        public class Request
        {
            public string method { get; set; }
            public List<Header> header { get; set; }
            public Body body { get; set; }
            public Url url { get; set; }
        }

        public class DoubaleLayerNodeMain
        {
            public Info info { get; set; }
            public List<Item> item { get; set; }
        }

        public class Script
        {
            public string type { get; set; }
            public List<string> exec { get; set; }
        }

        public class Url
        {
            public string raw { get; set; }
            public List<string> host { get; set; }
            public List<string> path { get; set; }
            public string protocol { get; set; }
            public List<Query> query { get; set; }
        }


    }
}

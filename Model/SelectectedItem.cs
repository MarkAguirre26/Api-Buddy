using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Buddy.Model
{
    public class SelectectedItem
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Body
        {
            public string mode { get; set; }
            public string raw { get; set; }
        }

        public class Header
        {
            public string key { get; set; }
            public string value { get; set; }
            public string type { get; set; }
            public bool? disabled { get; set; }
        }

        public class Request
        {
            public string method { get; set; }
            public List<Header> header { get; set; }
            public Body body { get; set; }
            public Url url { get; set; }
        }

        public class Root
        {
            public string name { get; set; }
            public Request request { get; set; }
            public List<object> response { get; set; }
        }

        public class Url
        {
            public string raw { get; set; }
            public List<string> host { get; set; }
            public List<string> path { get; set; }
        }


    }
}

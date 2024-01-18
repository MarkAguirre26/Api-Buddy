using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Buddy.Model
{
    public class RootNodeCollection
    {
        public int level { get; set; }
        public string method { get; set; }
        public string name { get; set; }
        public List<ParentNode> items { get; set; }
    }

    public class ParentNode
    {
        public int level { get; set; }
        public string method { get; set; }
        public string name { get; set; }
        public List<ChildNode> items { get; set; }
    }

    public class ChildNode
    {
        public int level { get; set; }
        public string method { get; set; }
        public string name { get; set; }
    }
}

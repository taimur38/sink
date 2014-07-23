using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink.Crawlers
{
    public abstract class Crawler
    {
        public Crawler(string name)
        {
            Name = name;
        }

        public abstract int Crawl();
        public string Name { get; protected set; }
        public string Url { get; protected set; }
    }
}

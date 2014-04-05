using sink.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sink
{
    public static class Context
    {
        static Context()
        {
            Mongo = new MongoService();
        }

        public static MongoService Mongo { get; private set; }
    }
}

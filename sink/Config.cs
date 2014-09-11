using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google;
using Google.Apis.Auth.OAuth2;

namespace sink
{
    public static class Config
    {
        public static string LastFmAPIKey
        {
            get
            {
                //TODO: load from config because this is stupid
                return "4fb61b9f3aa975c486531f4e5223d353";
            }
        }

        public static string MongoIP
        {
            get { return "mongodb://metal.fish"; }
        }


    }
}

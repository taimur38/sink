﻿using System;
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
                return "4fb61b9f3aa975c486531f4e5223d353";
            }
        }

        public static ClientSecrets GoogleClientCredential
        {
            get
            {
                return new ClientSecrets 
                { 
                    ClientId = "969643812602-0k7e3vqntt3j6gngggpk8kdicjcrhhbu.apps.googleusercontent.com", 
                    ClientSecret = "2bLoAblWyZ1nUww2LX3nuBHT" 
                };
            }
        }


    }
}
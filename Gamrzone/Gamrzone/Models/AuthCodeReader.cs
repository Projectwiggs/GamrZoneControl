using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamrzone.Models
{
    public sealed class AuthCodeReader
    {
        //locked this away in a thread safe singleton 
        private static AuthCodeReader instance = null;
        private static readonly object padlock = new object();
        private Dictionary<String, String> keyStore;

        AuthCodeReader() {
            keyStore = parsedConfig();
        }

        public static AuthCodeReader Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuthCodeReader();
                    }
                    return instance;
                }
            }
        }
        
        //Parsing the key file
        private Dictionary<String, String> parsedConfig()
        {
            Dictionary<String, String> ApiKeys;
            ApiKeys = File
                        .ReadLines(HttpContext.Current.Server.MapPath("App_Data/ApiKeys.txt"))
                        .Select((v, i) => new { Index = i, Value = v })
                        .GroupBy(p => p.Index / 2)
                        .ToDictionary(g => g.First().Value, g => g.Last().Value);
            return ApiKeys;
        }
        //Place where we can gather keys
        public String getKey(String keyName)
        {
            if (keyStore.ContainsKey(keyName))
            {
                String key = keyStore[keyName];
                return key;
            }
            return "empty";
        }
    
    }
}
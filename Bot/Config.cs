﻿using DSharpPlus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E
{
    public class Config
    {

        [JsonProperty("token")]
        public string Token
        {
            get; set;
        }

        [JsonProperty("token_type")]
        public TokenType TokenType
        {
            get; set;
        }

        [JsonProperty("prefix")]
        public string Prefix
        {
            get; set;
        }

        [JsonProperty("enable_dms")]
        public bool EnableDms
        {
            get; set;
        }
    }
}
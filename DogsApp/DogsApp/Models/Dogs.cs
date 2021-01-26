using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogsApp.Models
{
    public class Dogs
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("bred_for")]
        public string BreedFor { get; set; }

        [JsonProperty("breed_group")]
        public string BreedGroup { get; set; }

        [JsonProperty("life_span")]
        public string LifeSpan { get; set; }

        [JsonProperty("temperament")]
        public string Temperament { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}

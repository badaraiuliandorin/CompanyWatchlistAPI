using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CompanyWatchlistAPI.Models
{
    public class AlphaVantageSearch
    {
        public List<BestMatch> BestMatches { get; set; }
    }

    public class BestMatch
    {
        [JsonProperty(PropertyName = "1. symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "2. name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "3. type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "4. region")]
        public string Region { get; set; }
        [JsonProperty(PropertyName = "5. marketOpen")]
        public string MarketOpen { get; set; }
        [JsonProperty(PropertyName = "6. marketClose")]
        public string MarketClose { get; set; }
        [JsonProperty(PropertyName = "7. timezone")]
        public string Timezone { get; set; }
        [JsonProperty(PropertyName = "8. currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "9. matchScore")]
        public string MatchScore { get; set; }
    }

    public class AlphaVantageSearchProcessed
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string MarketOpen { get; set; }
        public string MarketClose { get; set; }
        public string Timezone { get; set; }
        public string Currency { get; set; }
        public string MatchScore { get; set; }
    }
}

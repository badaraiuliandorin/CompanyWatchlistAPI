using CompanyWatchlistAPI.Extensions;
using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyWatchlistAPI.Controllers
{
    [Route("api/watchlist/[action]")]
    [Route("api/watchlist/[action]/id")]
    [Route("api/watchlist/[action]/userId")]
    [Route("api/watchlist/[action]/symbol")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IWatchlistRepository _watchlistRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public WatchlistController(IWatchlistRepository watchlistRepository, IUserRepository userRepository, IConfiguration configuration)
        {
            _watchlistRepository = watchlistRepository;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var user = _userRepository.GetOne(x => x.Id == userId);

            if (user == null)
            {
                return BadRequest();
            }

            var items = _watchlistRepository.Get(x => x.UserId == user.Id);

            return Ok(items);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _watchlistRepository.GetAll();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var item = _watchlistRepository.GetOne(x => x.Id == id);

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add(Watchlist watchlist)
        {
            if (watchlist == null)
                return BadRequest();

            var result = _watchlistRepository.Insert(watchlist);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _watchlistRepository.Delete(id);

            return Ok();
        }

        [HttpGet("{symbol}")]
        [Authorize]
        public async Task<IActionResult> AlphaVantageSearch(string symbol)
        {
            var alphaVantageApiKey = _configuration["AlphaVantageAPIKey"];
            var alphaVantageSearchEndpoint = string.Format(_configuration["AlphaVantageAPISearchEndpoint"], symbol, alphaVantageApiKey);

            var client = new RestClient(alphaVantageSearchEndpoint) { Timeout = -1 };
            var request = new RestRequest() { Method = Method.GET };

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                return BadRequest();
            }
            var responseDeserialized = JsonConvert.DeserializeObject<AlphaVantageSearch>(response.Content);

            return Ok(AlphaVantageExtensions.ProcessSearchResult(responseDeserialized));
        }

        [HttpGet("{symbol}")]
        [Authorize]
        public async Task<IActionResult> AlphaVantageIntradaily(string symbol)
        {
            var alphaVantageApiKey = _configuration["AlphaVantageAPIKey"];
            var alphaVantageIntradailyEndpoint = string.Format(_configuration["AlphaVantageAPIIntradailyEndpoint"], symbol, alphaVantageApiKey);

            var client = new RestClient(alphaVantageIntradailyEndpoint) { Timeout = -1 };
            var request = new RestRequest() { Method = Method.GET };

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                return BadRequest();
            }
            var responseDeserialized = JsonConvert.DeserializeObject<dynamic>(response.Content);

            if (responseDeserialized != null)
            {
                var timeSeries = responseDeserialized["Time Series (1min)"];

                if (timeSeries != null)
                {
                    var jObjectTimeSeries = (JObject)timeSeries;

                    if (jObjectTimeSeries != null)
                    {
                        var currentStockObject = jObjectTimeSeries.Children().FirstOrDefault();

                        if (currentStockObject != null)
                        {
                            var currentStockProperties = currentStockObject.Children().FirstOrDefault();

                            if (currentStockProperties != null)
                            {
                                var currentStockResult = new AlphaVantageStock
                                {
                                    Close = currentStockProperties.Value<string>("1. open"),
                                    High = currentStockProperties.Value<string>("2. high"),
                                    Low = currentStockProperties.Value<string>("3. low"),
                                    Open = currentStockProperties.Value<string>("4. close"),
                                    Volume = currentStockProperties.Value<string>("5. volume")
                                };

                                return Ok(currentStockResult);
                            }
                        }
                    }
                }
            }

            return BadRequest();
        }

        [HttpGet("{symbol}")]
        [Authorize]
        public async Task<IActionResult> AlphaVantageOverview(string symbol)
        {
            var alphaVantageApiKey = _configuration["AlphaVantageAPIKey"];
            var alphaVantageOverviewEndpoint = string.Format(_configuration["AlphaVantageAPIOverviewEndpoint"], symbol, alphaVantageApiKey);

            var client = new RestClient(alphaVantageOverviewEndpoint) { Timeout = -1 };
            var request = new RestRequest() { Method = Method.GET };

            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                return BadRequest();
            }
            var responseDeserialized = JsonConvert.DeserializeObject<AlphaVantageOverview>(response.Content);

            return Ok(AlphaVantageExtensions.ProcessOverviewResult(responseDeserialized));
        }
    }
}

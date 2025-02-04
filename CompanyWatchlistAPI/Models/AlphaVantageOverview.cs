﻿using Newtonsoft.Json;

namespace CompanyWatchlistAPI.Models
{
    public class AlphaVantageOverview
    {
        public string Symbol { get; set; }
        public string AssetType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string FullTimeEmployees { get; set; }
        public string FiscalYearEnd { get; set; }
        public string LatestQuarter { get; set; }
        public string MarketCapitalization { get; set; }
        public string EBITDA { get; set; }
        public string PERatio { get; set; }
        public string PEGRatio { get; set; }
        public string BookValue { get; set; }
        public string DividendPerShare { get; set; }
        public string DividendYield { get; set; }
        public string EPS { get; set; }
        public string RevenuePerShareTTM { get; set; }
        public string ProfitMargin { get; set; }
        public string OperatingMarginTTM { get; set; }
        public string ReturnOnAssetsTTM { get; set; }
        public string ReturnOnEquityTTM { get; set; }
        public string RevenueTTM { get; set; }
        public string GrossProfitTTM { get; set; }
        public string DilutedEPSTTM { get; set; }
        public string QuarterlyEarningsGrowthYOY { get; set; }
        public string QuarterlyRevenueGrowthYOY { get; set; }
        public string AnalystTargetPrice { get; set; }
        public string TrailingPE { get; set; }
        public string ForwardPE { get; set; }
        public string PriceToSalesRatioTTM { get; set; }
        public string PriceToBookRatio { get; set; }
        public string EVToRevenue { get; set; }
        public string EVToEBITDA { get; set; }
        public string Beta { get; set; }
        [JsonProperty(PropertyName = "52WeekHigh")]
        public string FiftyTwoWeekHigh { get; set; }
        [JsonProperty(PropertyName = "52WeekLow")]
        public string FiftyTwoWeekLow { get; set; }
        [JsonProperty(PropertyName = "50DayMovingAverage")]
        public string FiftyDayMovingAverage { get; set; }
        [JsonProperty(PropertyName = "200DayMovingAverage")]
        public string TwoHundredDayMovingAverage { get; set; }
        public string SharesOutstanding { get; set; }
        public string SharesFloat { get; set; }
        public string SharesShort { get; set; }
        public string SharesShortPriorMonth { get; set; }
        public string ShortRatio { get; set; }
        public string ShortPercentOutstanding { get; set; }
        public string ShortPercentFloat { get; set; }
        public string PercentInsiders { get; set; }
        public string PercentInstitutions { get; set; }
        public string ForwardAnnualDividendRate { get; set; }
        public string ForwardAnnualDividendYield { get; set; }
        public string PayoutRatio { get; set; }
        public string DividendDate { get; set; }
        public string ExDividendDate { get; set; }
        public string LastSplitFactor { get; set; }
        public string LastSplitDate { get; set; }
    }

    public class AlphaVantageOverviewProcessed
    {
        public string Symbol { get; set; }
        public string AssetType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string FullTimeEmployees { get; set; }
        public string FiscalYearEnd { get; set; }
        public string LatestQuarter { get; set; }
        public string MarketCapitalization { get; set; }
        public string EBITDA { get; set; }
        public string PERatio { get; set; }
        public string PEGRatio { get; set; }
        public string BookValue { get; set; }
        public string DividendPerShare { get; set; }
        public string DividendYield { get; set; }
        public string EPS { get; set; }
        public string RevenuePerShareTTM { get; set; }
        public string ProfitMargin { get; set; }
        public string OperatingMarginTTM { get; set; }
        public string ReturnOnAssetsTTM { get; set; }
        public string ReturnOnEquityTTM { get; set; }
        public string RevenueTTM { get; set; }
        public string GrossProfitTTM { get; set; }
        public string DilutedEPSTTM { get; set; }
        public string QuarterlyEarningsGrowthYOY { get; set; }
        public string QuarterlyRevenueGrowthYOY { get; set; }
        public string AnalystTargetPrice { get; set; }
        public string TrailingPE { get; set; }
        public string ForwardPE { get; set; }
        public string PriceToSalesRatioTTM { get; set; }
        public string PriceToBookRatio { get; set; }
        public string EVToRevenue { get; set; }
        public string EVToEBITDA { get; set; }
        public string Beta { get; set; }
        public string FiftyTwoWeekHigh { get; set; }
        public string FiftyTwoWeekLow { get; set; }
        public string FiftyDayMovingAverage { get; set; }
        public string TwoHundredDayMovingAverage { get; set; }
        public string SharesOutstanding { get; set; }
        public string SharesFloat { get; set; }
        public string SharesShort { get; set; }
        public string SharesShortPriorMonth { get; set; }
        public string ShortRatio { get; set; }
        public string ShortPercentOutstanding { get; set; }
        public string ShortPercentFloat { get; set; }
        public string PercentInsiders { get; set; }
        public string PercentInstitutions { get; set; }
        public string ForwardAnnualDividendRate { get; set; }
        public string ForwardAnnualDividendYield { get; set; }
        public string PayoutRatio { get; set; }
        public string DividendDate { get; set; }
        public string ExDividendDate { get; set; }
        public string LastSplitFactor { get; set; }
        public string LastSplitDate { get; set; }
    }
}

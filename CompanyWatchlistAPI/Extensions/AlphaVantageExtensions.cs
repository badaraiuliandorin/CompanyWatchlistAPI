using CompanyWatchlistAPI.Models;
using System;
using System.Collections.Generic;

namespace CompanyWatchlistAPI.Extensions
{
    public static class AlphaVantageExtensions
    {
        public static List<AlphaVantageSearchProcessed> ProcessSearchResult(AlphaVantageSearch input)
        {
            List<AlphaVantageSearchProcessed> result = new List<AlphaVantageSearchProcessed>();
            foreach (var item in input.BestMatches)
            {
                AlphaVantageSearchProcessed processedItem = new AlphaVantageSearchProcessed
                {
                    Symbol = item.Symbol,
                    Name = item.Name,
                    Type = item.Type,
                    Region = item.Region,
                    MarketOpen = item.MarketOpen,
                    MarketClose = item.MarketClose,
                    Timezone = item.Timezone,
                    Currency = item.Currency,
                    MatchScore = item.MatchScore
                };

                result.Add(processedItem);
            }

            return result;
        }

        public static AlphaVantageOverviewProcessed ProcessOverviewResult(AlphaVantageOverview input)
        {
            AlphaVantageOverviewProcessed result = new AlphaVantageOverviewProcessed
            {
                Address = input.Address,
                AnalystTargetPrice = input.AnalystTargetPrice,
                AssetType = input.AssetType,
                Beta = input.Beta,
                BookValue = input.BookValue,
                Country = input.Country,
                Currency = input.Currency,
                Description = input.Description,
                DilutedEPSTTM = input.DilutedEPSTTM,
                DividendDate = input.DividendDate,
                DividendPerShare = input.DividendPerShare,
                DividendYield = input.DividendYield,
                EBITDA = input.EBITDA,
                EPS = input.EPS,
                EVToEBITDA = input.EVToEBITDA,
                EVToRevenue = input.EVToRevenue,
                Exchange = input.Exchange,
                ExDividendDate = input.ExDividendDate,
                FiftyDayMovingAverage = input.FiftyDayMovingAverage,
                FiftyTwoWeekHigh = input.FiftyTwoWeekHigh,
                FiftyTwoWeekLow = input.FiftyTwoWeekLow,
                FiscalYearEnd = input.FiscalYearEnd,
                ForwardAnnualDividendRate = input.ForwardAnnualDividendRate,
                ForwardAnnualDividendYield = input.ForwardAnnualDividendYield,
                ForwardPE = input.ForwardPE,
                FullTimeEmployees = input.FullTimeEmployees,
                GrossProfitTTM = input.GrossProfitTTM,
                Industry = input.Industry,
                LastSplitDate = input.LastSplitDate,
                LastSplitFactor = input.LastSplitFactor,
                LatestQuarter = input.LatestQuarter,
                MarketCapitalization = input.MarketCapitalization,
                Name = input.Name,
                OperatingMarginTTM = input.OperatingMarginTTM,
                PayoutRatio = input.PayoutRatio,
                PEGRatio = input.PEGRatio,
                PERatio = input.PERatio,
                PercentInsiders = input.PercentInsiders,
                PercentInstitutions = input.PercentInstitutions,
                PriceToBookRatio = input.PriceToBookRatio,
                PriceToSalesRatioTTM = input.PriceToSalesRatioTTM,
                ProfitMargin = input.ProfitMargin,
                QuarterlyEarningsGrowthYOY = input.QuarterlyEarningsGrowthYOY,
                QuarterlyRevenueGrowthYOY = input.QuarterlyRevenueGrowthYOY,
                ReturnOnAssetsTTM = input.ReturnOnAssetsTTM,
                ReturnOnEquityTTM = input.ReturnOnEquityTTM,
                RevenuePerShareTTM = input.RevenuePerShareTTM,
                RevenueTTM = input.RevenueTTM,
                Sector = input.Sector,
                SharesFloat = input.SharesFloat,
                SharesOutstanding = input.SharesOutstanding,
                SharesShort = input.SharesShort,
                SharesShortPriorMonth = input.SharesShortPriorMonth,
                ShortPercentFloat = input.ShortPercentFloat,
                ShortPercentOutstanding = input.ShortPercentOutstanding,
                ShortRatio = input.ShortRatio,
                Symbol = input.Symbol,
                TrailingPE = input.TrailingPE
            };

            return result;
        }
    }
}

using System;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;

namespace SEO.API.BLL
{
	public class SearchBLL
	{
        private IConfiguration config { get; set; }
        private ILogger logger { get; set; }

        /// <summary>
        /// Configure the google custom search service. 
        /// </summary>
        /// <returns></returns>
        private CustomsearchService ConfigureService()
        {
            // Get the Google custom search api key from the config.
            // You can get yours herehttps://developers.google.com/custom-search/v1/introduction 
            var apiKey = GetConfigValue("GoogleAPIKey");
            return new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
        }


        /// <summary>
        /// Get a config value by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetConfigValue(string key)
        {
            return config.GetValue<string>(key) ?? "";
        }


        /// <summary>
        /// Get the rankings for a URL in the first 100 results for a string of keywords.
        /// </summary>
        /// <param name="keywords">The string of keywords that will be searched</param>
        /// <param name="address">The url that we want to check the ranking of.</param>
        /// <returns></returns>
        public string GetWebsiteRankings(string keywords, string address)
        {
            var rankingResult = "";
            var customSearchService = ConfigureService();

            // Create a new list request.
            var listRequest = customSearchService.Cse.List();

            // Set the list request params.
            listRequest.Cx = GetConfigValue("GoogleCustomSearchAppID"); ;
            listRequest.Q = keywords;
            var pageIndex = 0;

            // You can only get 10 records per page and you need 10 pages to get 100 results. 
            // You can only request 100 results, any request after that will return an error. 
             while (pageIndex < 10)
             {
                 listRequest.Start = pageIndex * 10;
                 var items = listRequest.Execute().Items;

                 for (var i = 0; i < items.Count(); i++)
                 {
                     if (string.Equals(items[i].DisplayLink, address, StringComparison.InvariantCultureIgnoreCase))
                     {
                         // Append the new ranking to the results string.
                         rankingResult += rankingResult.Length < 1 ? $"{CalculateRanking(pageIndex, 10, i)}" : $", {CalculateRanking(pageIndex, 10, i)}";
                     }
                 }
                 pageIndex++;
             }

            return rankingResult.Length > 0 ? rankingResult : "0";
        }





        /// <summary>
        /// Calculate an indexes ranking.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="itemIndex"></param>
        /// <returns></returns>
        public int CalculateRanking(int pageIndex, int pageSize, int itemIndex)
        {
            return pageIndex * pageSize + itemIndex + 1;
        }


        public SearchBLL(IConfiguration configuration)
		{
            this.config = configuration;
		}
	}
}


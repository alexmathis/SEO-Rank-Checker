using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SEO.API.BLL;
using System.Collections.Generic;

namespace SEO.Test
{


    public class SEOTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RankingCaulculatortest()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"GoogleAPIKey", "test"},
                {"GoogleCustomSearchAppID:SomeKey", "test"},
            };

            var configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
            var BLL =  new SearchBLL(configuration);
            var rankingResult = BLL.CalculateRanking(5, 10, 0);
            //BLL.Calculate
            Assert.AreEqual(rankingResult, 51);
        }
    }
}

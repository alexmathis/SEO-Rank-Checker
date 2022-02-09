using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEO.API.Controllers
{

    
    [Route("searchranking")]
    [ApiController]
    public class SearchRankingController : ControllerBase
    {

        private BLL.SearchBLL searchBLL { get; set; }

        // GET: api/SearchRanking? 
        [HttpGet]
        public IActionResult Get(string keywords, string address)
        {
            try
            {
                return Ok(searchBLL.GetWebsiteRankings(keywords, address));
            }
            catch (Exception ex)
            {
                return BadRequest("There were issues getting your results.");
            }
            
        }

        public SearchRankingController(IConfiguration configuration)
        {
           searchBLL = new BLL.SearchBLL(configuration);
        }
    }
}

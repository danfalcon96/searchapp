using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchApp.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SearchApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string name)
        {
            Searcher searcher = new Searcher();
            JObject result = await searcher.SearchAsync(name);
            if (!string.IsNullOrEmpty(name))
            {
                return Json(JsonConvert.SerializeObject(result));
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
        }
    
    }
}
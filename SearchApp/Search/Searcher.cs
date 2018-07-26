using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SearchApp.Search
{
    public class Searcher
    {
        public async System.Threading.Tasks.Task<JObject> SearchAsync(string name)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://172.16.12.207:8082/api/appointments/");
                HttpResponseMessage res = await client.GetAsync("http://172.16.12.207:8082/api/appointments/" + name);

                if (res.IsSuccessStatusCode)
                {
                    string result = await res.Content.ReadAsStringAsync();
                    JObject jsonresult = JObject.Parse(result);
                    return jsonresult;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
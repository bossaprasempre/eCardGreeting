using Halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Halloween.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public GreetingCard _myGreetingCard { get; set; }

        private DbCard _myDbCard { get; set; }

        private IConfiguration _myConfiguration { get; set; }

        public IndexModel(DbCard DbCard, IConfiguration Configuration)
        {
            _myDbCard = DbCard;
            _myConfiguration = Configuration;
        }

        public void OnGet()
        {

        }

        //reCAPTHCA SERVER SIDE VALIDATION 

        //Create an HttpClient and store the the secret/response pair Await for the server to return a JSON obect

        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    //values.Add("secret", "SECRET KEY");
                    values.Add("secret", _myConfiguration["ReCaptcha:PrivateKey"]);

                    values.Add("response", response);
                    //values.Add("remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString()); 

                    var query = new FormUrlEncodedContent(values);

                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch { }

            return false;
        }
    }
}

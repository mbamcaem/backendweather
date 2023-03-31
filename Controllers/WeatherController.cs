using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace TestXtramile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        public async Task<IActionResult> CallAPI(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");

                    using (HttpResponseMessage response = await client.GetAsync("data/2.5/weather?q=" + city + "&appid=96e778a0420464d6f8801bd84d8ed6a2"))
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;


                        if (response.IsSuccessStatusCode)
                        {
                            var formattedContent = JToken.Parse(responseContent).ToString(Formatting.Indented);
                            return Ok(formattedContent);

                        }
                        else
                        {
                            var formattedContent = JToken.Parse(responseContent).ToString(Formatting.Indented);
                            return Ok(formattedContent);
                            //return BadRequest("Some thing went wrong in the request, please check the request Uri");
                        }


                    }

                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }
        }

    }

    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        public async Task<IActionResult> CallAPI(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://restcountries.com");

                    using (HttpResponseMessage response = await client.GetAsync("/v3.1/all"))
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;


                        if (response.IsSuccessStatusCode)
                        {
                            var formattedContent = JToken.Parse(responseContent).ToString(Formatting.Indented);
                            return Ok(formattedContent);

                        }
                        else
                        {
                            return Ok(responseContent);
                            //return BadRequest("Some thing went wrong in the request, please check the request Uri baru123" + response);
                        }


                    }

                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }
        }

    }
}

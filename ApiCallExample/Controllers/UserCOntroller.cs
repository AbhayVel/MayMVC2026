using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace ApiCallExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        HttpClient _httpClient { get; set; }
        public UserController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("MyApi");
        }

    [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userData)
        {

            //var header=   Request.Headers.FirstOrDefault(x => x.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase));

            //   var str = header.Value.FirstOrDefault();
            //   var client = new HttpClient();
            //   var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7229/api/User");
            //   request.Headers.Add("Authorization", str);
            //   var json = System.Text.Json.JsonSerializer.Serialize(userData);
            //   var content = new StringContent(json, null, "application/json");
            //   request.Content = content;
            //   try
            //   {
            //      var strValue= await RetryApiCalls(client, request,1);
            //   }
            //   catch (Exception ex)
            //   {

            //   }


            var header = Request.Headers.FirstOrDefault(x => x.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase));

            var str = header.Value.FirstOrDefault();        
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/User");
            request.Headers.Add("Authorization", str);
            var json = System.Text.Json.JsonSerializer.Serialize(userData);
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var strResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(strResponse);



            return Ok(userData);
        }

        private static async Task<string> RetryApiCalls(HttpClient client, HttpRequestMessage request,int retry)
        {
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var str = await response.Content.ReadAsStringAsync();
                Console.WriteLine();
                return str;
            }
            catch (Exception ex)
            {

                if(retry < 3)
                {
                     return await RetryApiCalls(client,request,++retry);
                } else
                {
                    throw ex;
                }
            }
        }
    }

    public class UserDTO
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }


        [Required]

        public string RoleName { get; set; }

        public int? MyProperty { get; set; }
    }
}

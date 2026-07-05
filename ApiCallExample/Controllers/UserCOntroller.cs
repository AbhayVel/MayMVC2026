using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiCallExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userData)
        {

         var header=   Request.Headers.FirstOrDefault(x => x.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase));

            var str = header.Value.FirstOrDefault();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7229/api/User");
            request.Headers.Add("Authorization", str);
            var json = System.Text.Json.JsonSerializer.Serialize(userData);
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());


            return Ok(userData);
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

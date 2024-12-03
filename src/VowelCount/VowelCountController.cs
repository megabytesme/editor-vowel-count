using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

[ApiController]
[Route("vowel-count")]
public class VowelCountController : ControllerBase
{
    [HttpGet]
    public IActionResult CountVowels([FromQuery] string text)
    {
        if (string.IsNullOrEmpty(text))
            return Ok(JsonSerializer.Serialize(new { vowel_count = 0 }));

        int vowel_count = text.Count(c => "aeiouAEIOU".Contains(c));
        var result = new { vowel_count };
        var jsonResult = JsonSerializer.Serialize(result);
        Response.ContentType = "application/json";
        Response.ContentLength = jsonResult.Length;

        return Content(jsonResult);
    }
}

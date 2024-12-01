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
            return Ok(0);

        int vowelCount = text.Count(c => "aeiouAEIOU".Contains(c));
        var result = new { vowelCount };
        var jsonResult = JsonSerializer.Serialize(result);
        Response.ContentLength = jsonResult.Length;

        return Ok(jsonResult);
    }
}

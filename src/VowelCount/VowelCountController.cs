using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("vowel")]
public class VowelCountController : ControllerBase
{
    [HttpGet("countvowels")]
    public IActionResult CountVowels([FromQuery] string text)
    {
        if (string.IsNullOrEmpty(text))
            return Ok(0);

        int vowelCount = text.Count(c => "aeiouAEIOU".Contains(c));
        return Ok(new { vowelCount });
    }
}

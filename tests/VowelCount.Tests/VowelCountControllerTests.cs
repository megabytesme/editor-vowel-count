using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace VowelCount.Tests
{
    public class VowelCountControllerTests
    {
        private WebApplicationFactory<Program> _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
        }

        [Test]
        [TestCase("?text=aeiou", 5)]
        public async Task CountVowels_ReturnsCorrectVowelCount(string query, int expected)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/vowel/countvowels{query}");
            var content = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(content);
            var vowelCount = jsonResponse["vowelCount"].Value<int>();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(expected, vowelCount);
        }

        [Test]
        [TestCase("")]
        public async Task CountVowels_MissingText_ReturnsBadRequest(string query)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/vowel/countvowels{query}");
            var content = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(content);
            var statusCode = jsonResponse["status"].Value<int>();

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(400, statusCode);
        }
    }
}

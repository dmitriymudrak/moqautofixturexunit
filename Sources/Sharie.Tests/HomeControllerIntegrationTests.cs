using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Tests.AAAPattern.xUnit.Attributes;
using Xunit;

namespace XUnitTestProject
{
    public class HomeControllerIntegrationTests
    {
        [Theory]
        [MoqInlineAutoData("/Home/Index", "Actuals/Home/Index.html")]
        [MoqInlineAutoData("/Home/Privacy", "Actuals/Home/Privacy.html")]
        public async Task IsAvaibleContentPageTest(string actionUri, string pathToActualContent)
        {
            //arrange
            var actual = File.ReadAllText(pathToActualContent);
            var client = GetTestHttpClient();

            //act
            var response = await client.GetAsync(actionUri);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var expected = await response.Content.ReadAsStringAsync();

            //assert
            actual = RemoveControlCharacters(actual);
            expected = RemoveControlCharacters(expected);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MoqInlineAutoData("/Home/Error", "Actuals/Home/Error.html")]
        public async Task IsAvaibleErrorPageTest(string actionUri, string pathToFormatErrorContent)
        {
            //arrange
            var actualFormat = File.ReadAllText(pathToFormatErrorContent);
            var client = GetTestHttpClient();

            //act
            var response = await client.GetAsync(actionUri);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var expected = await response.Content.ReadAsStringAsync();
            var requestId = Regex.Match(expected, "<code>(.*)</code>").Groups[1].Value;
            var actual = string.Format(actualFormat, requestId);

            //assert
            actual = RemoveControlCharacters(actual);
            expected = RemoveControlCharacters(expected);
            Assert.Equal(expected, actual);
        }

        private static HttpClient GetTestHttpClient()
        {
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Sharie.Startup>());
            return testServer.CreateClient();
        }

        string RemoveControlCharacters(string content)
        {
            var controlCharasters = new[] { "\r", "\t", "\n", " "};
            foreach (var controlCharaster in controlCharasters)
            {
                while (content.IndexOf(controlCharaster, StringComparison.CurrentCultureIgnoreCase) > 0)
                    content = content.Replace(controlCharaster, string.Empty);
            }

            return content;
        }
    }
}
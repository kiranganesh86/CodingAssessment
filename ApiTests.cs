using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System; 
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionalTests
{
    [TestClass]
    public class CatFactsTests
    {

        [TestMethod]
        public async Task ValidateUniqueCatFacts()
        {
            // Store unique facts
            var storeFacts = new HashSet<string>();

            const int requiredUniqueFacts = 10;
            const string ApiUrl = "https://catfact.ninja/fact";

            var client = new HttpClient();

            for (int i = 1; i <= requiredUniqueFacts; i++)
            {
                try
                {
                    // HTTP GET request
                    var response = await client.GetAsync(ApiUrl);

                    // Assert that the response status is 200 OK
                    Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "API did not return a successful response.");

                    // Read and parse the response content
                    var content = await response.Content.ReadAsStringAsync();
                        
                    try
                    {
                        var fact = System.Text.Json.JsonDocument.Parse(content)
                            .RootElement.GetProperty("fact").GetString();

                        // Empty and null check before adding to HashSet
                        if (!string.IsNullOrEmpty(fact))
                        {
                            storeFacts.Add(fact);
                            }
                        }
                        catch (System.Text.Json.JsonException ex)
                        {
                            Assert.Fail($"Failed to parse JSON response: {ex.Message}");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Assert.Fail($"HTTP request failed: {ex.Message}");
                    }
                    catch (TaskCanceledException ex)
                    {
                        Assert.Fail($"Request timed out: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                    Assert.Fail($"Unexpected error occurred: {ex.Message}");
                }
            }

    
            // Assert to check if all the 10 GET call returned unique facts
            Assert.AreEqual(requiredUniqueFacts, storeFacts.Count, 
                $"Out of {requiredUniqueFacts} only {storeFacts.Count} are unique facts.");
            
            // Output is only visible when tests fail
            Console.WriteLine("Collected facts:");
            var factNumber = 1;
            foreach (var fact in storeFacts)
            {
                Console.WriteLine($"{factNumber}. {fact}");
                factNumber++;
            }
        }
    }
}

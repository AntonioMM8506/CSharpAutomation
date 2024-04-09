using TechTalk.SpecFlow;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;



namespace CSharpAutomation.Steps
{

    [Binding]
    public class TestGetAPI
    {
        private HttpClient _client;
        private HttpResponseMessage _response;

        //Instantiates a new HttpClient so it can read the URL.
        [Given(@"I have a URL ""(.*)""")]
        public void GivenIHaveAURL(string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }

        //And async method is required in order to fetch the data through a GET method.
        [When(@"I send a GET request to the API")]
        public async  Task WhenISendAGETRequestToTheAPI()
        {
            _response = await _client.GetAsync("");
            
        }

        //statusCode has to be a numeric number according to a HTTP response, like 200, 201, 500, 404, etc. 
        //Then a conversion is needed in order to convert the HTTP response into a message so it can be compared.
        [Then(@"the response status code should be ""(.*)""")]
        public void ThenTheResponseStatusCodeShouldBe(string statusCode)
        {
            HttpStatusCode expectedStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), statusCode);
            Assert.AreEqual(expectedStatusCode, _response.StatusCode);
        }


    }//End of class
    
}//End of namespace
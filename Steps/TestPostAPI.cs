using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System;
using CSharpAutomation.Drivers;
using CSharpAutomation.Hooks;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text;

namespace CSharpAutomation.Steps
{

    [Binding]
    public class TestPostAPI
    {
        private HttpClient _client;
        private HttpResponseMessage _response;

        public TestPostAPI()
        {
            _client = new HttpClient();
        }

        //Define the headers
        [Given(@"I have a valid payload to send")]
        public void GivenIHaveAValidPayloadToSend()
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer MyTokenExample");
            //_client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        //Define the payload to send in the body for the request
        [When(@"I send a POST request to ""(.*)""")]
        public async Task WhenISendAPOSTRequestTo(string endpoint)
        {
            var requestBody = new StringContent("{\"key\": \"value\"}", Encoding.UTF8, "application/json");
            _response = await _client.PostAsync(endpoint, requestBody);
        }


        //Validate the message
        [Then(@"the response body should contain ""(.*)""")]
        public async Task ThenTheResponseBodyShouldContain(string expectedContent)
        {
            var responseContent = await _response.Content.ReadAsStringAsync();
            StringAssert.Contains(expectedContent, responseContent);
        }


    }//End of class
    
}//End of namespace
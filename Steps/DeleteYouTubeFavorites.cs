using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;
using CSharpAutomation.Drivers;
using CSharpAutomation.Hooks;
using System.Data;
using System;



namespace CSharpAutomation.Steps
{

    [Binding]
    public class DeleteYouTubeFavorites
    {
        private DataTable ironData;


        [BeforeScenario]
        //Before running the actual steps, reads the excel file in order to retrieve the data
        //so it can be used later.
        public void BeforeYouTubeScenario(){
            ExcelHook ironxl = new ExcelHook();
            ironData = ironxl.ReadIronXL("CREDENTIALS.xlsx");
        }//End of BeforeScenario


        [Given("User navigate to YouTube")]
        public void NavigateToYouTube(){
            Driver.NavigateTo("https://youtube.com");
        }//End of Given


        [When("User logs into YouTube")]
        public void LogsIntoYouTube(){
            Driver.ExplicitWait(By.ClassName("yt-spec-touch-feedback-shape__stroke"));

            //Clicks the Sign-In button.
            Driver.FindElement(By.CssSelector(".yt-spec-button-shape-next.yt-spec-button-shape-next--outline.yt-spec-button-shape-next--call-to-action.yt-spec-button-shape-next--size-m.yt-spec-button-shape-next--icon-leading")).Click();
            Driver.ImplicitWait(50);

            //Fulfilss the email input field
            Driver.ExplicitWait(By.Id("identifierId"));
            Driver.FindElement(By.Id("identifierId")).SendKeys(ironData.Rows[0][0].ToString());

            //Clicks on the Next Button 
            Thread.Sleep(1000);
            Console.WriteLine("");
            Driver.ExplicitWait(By.Id("identifierNext"));
            IWebElement nextButton = Driver.FindElement(By.Id("identifierNext"));
            nextButton.Click();
            

            //In this scenario, because chromedriver its beign manipulated by a bot, then, it will
            //not allow to complete the login, so it will looks for a warning message.
            Driver.ExplicitWait(By.Id("headingText"));
            Assert.AreEqual("No puedes acceder", Driver.FindElement(By.Id("headingText")).FindElement(By.TagName("span")).Text, $"Expected Text does not match equal");
        }//End of When


    }//End of class
}//End of namespace

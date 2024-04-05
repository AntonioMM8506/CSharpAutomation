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


namespace CSharpAutomation.Steps
{

    [Binding]
    public class DeleteYouTubeFavorites
    {
        private DataTable ironData;


        [BeforeScenario]
        public void BeforeYouTubeScenario(){
            ExcelHook ironxl = new ExcelHook();
            ironData = ironxl.ReadIronXL("CREDENTIALS.xlsx");

        }



        [Given("User navigate to YouTube")]
        public void NavigateToYouTube(){
            Driver.NavigateTo("https://youtube.com");
        }


        [When("User logs into YouTube")]
        public void LogsIntoYouTube(){
            Driver.ExplicitWait(By.ClassName("yt-spec-touch-feedback-shape__stroke"));
        
            Driver.FindElement(By.CssSelector(".yt-spec-button-shape-next.yt-spec-button-shape-next--outline.yt-spec-button-shape-next--call-to-action.yt-spec-button-shape-next--size-m.yt-spec-button-shape-next--icon-leading")).Click();
            Driver.ImplicitWait(50);

            Driver.ExplicitWait(By.Id("identifierId"));
            Driver.FindElement(By.Id("identifierId")).SendKeys(ironData.Rows[0][0].ToString());

            Driver.FindElement(By.Id("identifierNext")).FindElement(By.TagName("button")).Click();
            Thread.Sleep(1000);

            //Driver.ExplicitWait(By.Id("password"));
            //Driver.FindElement(By.Id("password")).FindElement(By.TagName("input")).SendKeys(ironData.Rows[2][0].ToString());
            //Driver.FindElement(By.Id("passwordNext")).FindElement(By.TagName("button")).Click();
            //Driver.ImplicitWait(1000);

            Driver.ExplicitWait(By.Id("headingText"));
            Assert.AreEqual("No puedes acceder", Driver.FindElement(By.Id("headingText")).FindElement(By.TagName("span")).Text, $"Expected Text does not match equal");
        }


    }//End of class
}//End of namespace
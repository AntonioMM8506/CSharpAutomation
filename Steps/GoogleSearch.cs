using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;
using System;
using CSharpAutomation.Drivers;
using CSharpAutomation.Hooks;
using System.Data;


namespace CSharpAutomation.Steps
{
    [Binding]
    public class GoogleSearchSteps
    {

        [Given("I am on the Google search page")]
        public void GivenIAmOnTheGoogleSearchPage()
        {
            Driver.NavigateTo("https://www.google.com");

        } //End of Given



        [When("I enter (.*) into the search box")]
        public void WhenIEnterTextIntoTheSearchBox(string searchText)
        {
            var searchBox = Driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchText);
        }//End of When



        [When("I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            Thread.Sleep(2000);
            var searchButton = Driver.FindElement(By.Name("btnK"));
            searchButton.Click();
        }//End of When



    }//End of class
}//End of namespace

using OpenQA.Selenium;
using TechTalk.SpecFlow;
using CSharpAutomation.Drivers;
using System;



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
            //Looks for the search bar in the google page
            var searchBox = Driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchText);
        }//End of When


        
        [When("I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            //Clicks the Search button
            Driver.ExplicitWait(By.Name("btnK"));
            var searchButton = Driver.FindElement(By.Name("btnK"));
            Console.WriteLine("");
            searchButton.Click();
        }//End of When



    }//End of class
}//End of namespace

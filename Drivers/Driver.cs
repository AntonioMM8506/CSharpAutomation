using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;


namespace CSharpAutomation.Drivers
{
    [Binding]
    public class Driver
    {
        private static IWebDriver _driver;

        [BeforeScenario]
        public static IWebDriver Intitialize(){
            _driver = new ChromeDriver();
            return _driver;
        }//End of Initialize
        public static IWebDriver Current => _driver;



        [AfterScenario]
        public static void Quit()
        {
            _driver?.Quit();
        }//End of Quit



        public static void ImplicitWait(int sec)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }//End of ImplicitWait
        


        public static void ExplicitWait(By locator){
            WebDriverWait wait  = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(_driver => _driver.FindElement(locator));
        }//End of ExplicitWait



        public static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }//End of NavigatetTo



        public static IWebElement FindElement(By locator){
            return _driver.FindElement(locator);
        }//End of FindElement


    }//End of class
}//End of namespace

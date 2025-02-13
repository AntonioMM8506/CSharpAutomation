using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CSharpAutomation.Drivers
{
    [Binding]
    public class Driver
    {
        private static IWebDriver _driver;
        private static ChromeOptions options = new ChromeOptions();
        

        [BeforeScenario]
        public static IWebDriver Intitialize(){
            
            //For CI/CD Workflows
            options.AddArgument("--headless=new"); 
            _driver = new ChromeDriver(options);
            

            /*
            //For testing locally and starting chrome session.
            try{
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(currentDirectory, @"../../../Extensions/AdBlock.crx");
                filePath = Path.GetFullPath(filePath);
                options.AddExtension(filePath);
                _driver = new ChromeDriver(options); 
            }catch(Exception ex){
                Console.WriteLine(ex);
                _driver = new ChromeDriver();
            }
            */
            
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


        public static List<IWebElement> FindListOfElements(By locator){
            IReadOnlyCollection<IWebElement> elements = _driver.FindElements(locator);
            List<IWebElement> elementList = elements.ToList();
            return elementList;
        }//End of FindListOfElements

    }//End of class
    
}//End of namespace

using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System;
using System.IO;
using CSharpAutomation.Drivers;
using CSharpAutomation.Hooks;
using System.Linq;



namespace CSharpAutomation.Steps
{

    [Binding]
    public class CommonGuru99
    {
        //Guru99 -----------------------------------------------------------------------------------------------------------------------------
        [Given("User navigates to Guru99")]
        public void NavigateToGuru99(){
            Driver.NavigateTo("https://guru99.com/");
        }//End of Given


        //Demo Guru99 ------------------------------------------------------------------------------------------------------------------------
                [When(@"User selects ""(.*)"" from Navgination Bar")]
        public void NavigateNavBar(string site){

            List<IWebElement> navbar =Driver.FindListOfElements(By.ClassName("dropdown")).ToList();

            switch(site){
                case "Insurance Project":
                    navbar[2].Click();
                break;
                case "Agile Project":
                    navbar[3].Click();
                break;
                case "Bank Project":
                    navbar[4].Click();
                break;
                case "Security Project":
                    navbar[5].Click();
                break;
                case "Telecom Project":
                    navbar[7].Click();
                break;
                case "Payment Gateway Project":
                    navbar[8].Click();
                break;
                case "New Tours":
                    navbar[9].Click();
                break;
                default:
                    Console.WriteLine("No valid option in Navigation Bar");
                break;
            }

            Thread.Sleep(1000);
        }//End of When


        [Given("User navigates to Demo Guru 99")]
        public void NavigateToDemoGuru99(){
            Driver.NavigateTo("https://demo.guru99.com/");
        }//End of Given


        [When(@"User navigates to ""(.*)"" Selenium section")]
        public void SeleniumDropdownMenu(string section){
            Driver.ExplicitWait(By.Id("navbar-brand-centered"));
            Driver.FindElement(By.CssSelector(".nav.navbar-nav")).FindElement(By.LinkText("Selenium")).Click();
            Driver.ExplicitWait(By.ClassName("dropdown-menu"));
            List<IWebElement> seleniumMenu = Driver.FindElement(By.ClassName("dropdown-menu")).FindElements(By.TagName("li")).ToList();

            switch(section){
                case "Flash Movide Demo":
                    seleniumMenu[0].Click();
                break;
                case "Radio and Checkbox Demo":
                    seleniumMenu[1].Click();
                break;
                case "Table Demo":
                    seleniumMenu[2].Click();
                break;
                case "Accessing Link":
                    seleniumMenu[3].Click();
                break;
                case "Ajax Demo":
                    seleniumMenu[4].Click();
                break;
                case "Inside and Outside Block Level Tag":
                    seleniumMenu[5].Click();
                break;
                case "Delete Customer Form":
                    seleniumMenu[6].Click();
                break;
                case "Yahoo":
                    seleniumMenu[7].Click();
                break;
                case "Tooltip":
                    seleniumMenu[8].Click();
                break;
                case "File Upload":
                    seleniumMenu[9].Click();
                break;
                case "Login":
                    seleniumMenu[10].Click();
                break;
                case "Social Icon":
                    seleniumMenu[11].Click();
                break;
                case "Selenium Auto IT":
                    seleniumMenu[12].Click();
                break;
                case "Selenium IDE Test":
                    seleniumMenu[13].Click();
                break;
                case "Guru99 Demo Page":
                    seleniumMenu[14].Click();
                break;
                case "Scrollbar Demo":
                    seleniumMenu[15].Click();
                break;
                case "File Upload using SiKuli Demo":
                    seleniumMenu[16].Click();
                break;
                case "Cookie Handling Demo":
                    seleniumMenu[17].Click();
                break;
                case "Drag and Drop Action":
                    seleniumMenu[18].Click();
                break;
                case "Selenium DatePicker Demo":
                    seleniumMenu[19].Click();
                break;
                default:
                    Console.WriteLine("No option available");
                break;
            }

            Thread.Sleep(500);
        }//End of When

    }//End of class
    
}//End of namespace
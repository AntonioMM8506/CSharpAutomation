using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System;
using System.IO;
using CSharpAutomation.Drivers;
using System.Linq;



namespace CSharpAutomation.Steps
{

    [Binding]
    public class UploadDocument
    {
        [Given("User navigates to Guru99")]
        public void NavigateToGuru99(){
            Driver.NavigateTo("https://guru99.com/");
        }//End of Given


        [Given("User navigates to Demo Guru 99")]
        public void NavigateToDemoGuru99(){
            Driver.NavigateTo("https://demo.guru99.com/");
        }//End of Given


        [When(@"User navigates to ""(.*)"" section")]
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


        [When("User uploads a document")]
        public void UploadADocument(){
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "test.txt");

            if(!File.Exists(filePath)){
                string mockContent = "This is a mock file";
                File.WriteAllText(filePath, mockContent);
            }

            //Send the filepath to the file search window
            Driver.FindElement(By.ClassName("upload_txt")).SendKeys(filePath);
            
            //Click the checkbox button
            Driver.FindElement(By.Id("terms")).Click();
            
            //Click the submit butoon
            Driver.FindElement(By.Id("submitbutton")).Click();

            //Wait for the response to appear and then validates the message content.
            Driver.ExplicitWait(By.Id("res"));
            Assert.AreEqual("1 file\nhas been successfully uploaded.", Driver.FindElement(By.Id("res")).Text);
            Thread.Sleep(1000);

        }//End of When

    }//End of class

}//End of namespace
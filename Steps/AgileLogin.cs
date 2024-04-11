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
    public class AgileLogin
    {
        private RandomGeneratorHook myTestinString;

        [BeforeScenario]
        public void BeforeAgileScenario(){
            RandomGeneratorHook randomString = new RandomGeneratorHook();
            myTestinString = randomString;
        }//End of BeforeAgileScenario


        [Then("User validates Agile Project page")]
        public void validateAgileProjectPage(){

            //Validate Page content
            Assert.AreEqual("Guru99 Bank", Driver.FindElement(By.TagName("h2")).Text);
            Assert.AreEqual("Access", Driver.FindElement(By.TagName("h4")).Text);
            List<IWebElement> tableAgile = Driver.FindElement(By.Name("frmLogin")).FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).ToList();
            List<IWebElement> firstRow = tableAgile[0].FindElements(By.TagName("td")).ToList();
            List<IWebElement> secondRow = tableAgile[1].FindElements(By.TagName("td")).ToList();
            List<IWebElement> thirdRow = tableAgile[2].FindElements(By.TagName("td")).ToList();
            IWebElement loginButton = thirdRow[1].FindElement(By.Name("btnLogin"));
            IWebElement resetButton = thirdRow[1].FindElement(By.Name("btnReset"));
            IWebElement userIdInput = Driver.FindElement(By.Name("uid"));
            IWebElement passwordInput = Driver.FindElement(By.Name("password"));
            Assert.AreEqual("UserID", firstRow[0].Text);
            Assert.AreEqual("Password", secondRow[0].Text);
            Assert.AreEqual("LOGIN", loginButton.GetAttribute("value"));
            Assert.AreEqual("RESET", resetButton.GetAttribute("value"));

            //Validate Warning Messages
            userIdInput.Click();
            passwordInput.Click();
            userIdInput.Click();
            IWebElement userIdwarningMessage = Driver.FindElement(By.Id("message23"));
            IWebElement passwordWarningMessage = Driver.FindElement(By.Id("message18"));
            Assert.AreEqual("User-ID must not be blank", userIdwarningMessage.Text);
            Assert.AreEqual("Password must not be blank", passwordWarningMessage.Text);

            //Validate Reset Button
            userIdInput.SendKeys(myTestinString.RandomAlphanumericString(5));
            passwordInput.SendKeys(myTestinString.RandomString(10));
            resetButton.Click();
            Assert.AreEqual("", userIdInput.Text);
            Assert.AreEqual("", passwordInput.Text);
            
            //Validate Login
            userIdInput.SendKeys("1303");
            passwordInput.SendKeys("Guru99");
            loginButton.Click();
            Thread.Sleep(500);

            //Validate Bank Page
            //Validate Customer Page
            Driver.ExplicitWait(By.ClassName("heading3"));
            Assert.AreEqual("Welcome To Customer's Page of Guru99 Bank", Driver.FindElement(By.ClassName("heading3")).Text);
            List<IWebElement> leftMenu = Driver.FindElement(By.ClassName("menusubnav")).FindElements(By.TagName("li")).ToList();
            List<IWebElement> customerPictures = Driver.FindElement(By.ClassName("layout1")).FindElements(By.TagName("img")).ToList();
            Assert.AreEqual("Customer", leftMenu[0].FindElement(By.TagName("a")).Text);
            Assert.AreEqual("Mini Statement", leftMenu[1].FindElement(By.TagName("a")).Text);
            Assert.AreEqual("Log out", leftMenu[2].FindElement(By.TagName("a")).Text);
            Assert.IsTrue(customerPictures[0].GetAttribute("src").Contains("images/1.gif"));
            Assert.IsTrue(customerPictures[1].GetAttribute("src").Contains("images/3.gif"));
            Assert.IsTrue(customerPictures[2].GetAttribute("src").Contains("images/2.gif"));
            //Validate MiniStatement page
            leftMenu[1].Click(); 
            Thread.Sleep(1000);
            Assert.AreEqual("Mini Statement Form", Driver.FindElement(By.ClassName("heading3")).Text);
            Driver.FindElement(By.Name("accountno")).Click();
            Thread.Sleep(500);
            List<IWebElement> accountOptions = Driver.FindElement(By.Name("accountno")).FindElements(By.TagName("option")).ToList();
            Assert.AreEqual("Select Account", accountOptions[0].Text);
            Assert.AreEqual("3308", accountOptions[1].Text);
            Assert.AreEqual("3309", accountOptions[2].Text);
            Assert.AreEqual("106081", accountOptions[3].Text);
            Assert.AreEqual("Submit", Driver.FindElement(By.Name("AccSubmit")).GetAttribute("value"));
            Assert.AreEqual("Reset",Driver.FindElement(By.Name("res")).GetAttribute("value"));
            IWebElement homeButton = Driver.FindElement(By.XPath("/html/body/table/tbody/tr/td/p/a"));
            Assert.AreEqual("Home", homeButton.Text);
            homeButton.Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Welcome To Customer's Page of Guru99 Bank", Driver.FindElement(By.ClassName("heading3")).Text);            

        }//End of Then


    }//End of class
}//End of namespace

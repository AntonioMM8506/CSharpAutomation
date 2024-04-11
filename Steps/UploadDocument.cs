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

        [Then("User uploads a document")]
        public void UploadADocument(){
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "test.txt");

            if(!File.Exists(filePath)){
                string mockContent = "This is a mock file";
                File.WriteAllText(filePath, mockContent);
            }

            //Send the filepath to the file search window
            Driver.ExplicitWait(By.Id("uploadfile_0"));
            Driver.FindElement(By.Id("uploadfile_0")).SendKeys(filePath);
            
            //Click the checkbox button
            Driver.FindElement(By.Id("terms")).Click();
            
            //Click the submit butoon
            Driver.FindElement(By.Id("submitbutton")).Click();

            //Wait for the response to appear and then validates the message content.
            Driver.ExplicitWait(By.Id("res"));
            Console.WriteLine(Driver.FindElement(By.Id("res")).Text);
            Thread.Sleep(1000);
            Assert.AreEqual("1 file\nhas been successfully uploaded.", Driver.FindElement(By.Id("res")).Text);

        }//End of When

    }//End of class

}//End of namespace
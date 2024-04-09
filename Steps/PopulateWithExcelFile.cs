using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Threading;
using CSharpAutomation.Drivers;
using CSharpAutomation.Hooks;
using System.Data;

namespace CSharpAutomation.Steps
{

    [Binding]
    public class PopluateWithExcelFile
    {
        private DataTable ironData;


        [BeforeScenario]
        public void BeforePopulateScenario(){
            ExcelHook ironXl = new ExcelHook();
            ironData = ironXl.ReadIronXL("WIP.xlsx");
        }//End of BeforeScenario


        [Given("user navigates to online text editor")]
        public void GivenUserNavigatesToOnlineTextEditor()
        {
            Driver.NavigateTo("https://www.onlinetexteditor.com/");
        }//End of Given



        [When("user fulfills the form with the excel data")]
        public void WhenUserFulfillsWithExcelData(){
            //read the data contained in the DataTable and then sends it to the form.
            var textArea = Driver.FindElement(By.Id("text"));
            textArea.Clear();

            string auxString = "";
            foreach (DataRow row in ironData.Rows)
            {
                auxString += row[0] + "\n";
            }

            textArea.SendKeys(auxString);
            Thread.Sleep(5000);
        }//End of When



    }//End of class
    
}//End of namespace
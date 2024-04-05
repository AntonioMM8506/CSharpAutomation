using TechTalk.SpecFlow;
using IronXL;
using System.Linq;
using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;



namespace CSharpAutomation.Hooks
{
    [Binding]
    public class ExcelHook
    {
        public DataTable ReadIronXL(string filePath){
            DataTable dt;

            //Try-Catch declaration, in the case that the given path file does not exists, it creates
            //a mock datatable in order to be consumed in the test scenarios. Mainly used for the
            //CICD Workflows, and avoiding to upload sensitive data to the repository.
            try{
                WorkBook wb = WorkBook.Load(filePath);
                WorkSheet ws = wb.WorkSheets.First();
                dt = ws.ToDataTable(true);

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
                dt = new DataTable();
                dt.Columns.Add("Mock Data", typeof(string));
                dt.Rows.Add("Mock");
                dt.Rows.Add("Data");

            }catch(IndexOutOfRangeException ex){
                Console.WriteLine(ex);
                dt = new DataTable();
                dt.Columns.Add("Mock Data", typeof(string));
                dt.Rows.Add("Mock");
                dt.Rows.Add("Data");
                
            }


            return dt;
        }//End of ReadIronXL


        public void PrintIronXL(DataTable ironXL){
            foreach (DataRow row in ironXL.Rows) //access rows
            {
                for (int i = 0; i < ironXL.Columns.Count; i++) //access columns of corresponding row
                {
                    Console.WriteLine(row[i]);
                }
                Console.WriteLine();
            }
        }//End of PrintIronXL


    }//End of class
}//End of namespace

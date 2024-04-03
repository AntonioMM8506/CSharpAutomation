using TechTalk.SpecFlow;
using IronXL;
using System.Linq;
using System;
using System.Data;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;


namespace CSharpAutomation.Hooks
{
    [Binding]
    public class ExcelHook
    {
        public DataTable ReadIronXL(string filePath){
            WorkBook wb = WorkBook.Load(filePath);
            WorkSheet ws = wb.WorkSheets.First();
            DataTable dt = ws.ToDataTable(true);

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

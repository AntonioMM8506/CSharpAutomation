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
            DataTable dt;

            try{
                WorkBook wb = WorkBook.Load(filePath);
                WorkSheet ws = wb.WorkSheets.First();
                dt = ws.ToDataTable(true);
                
            }catch(IndexOutOfRangeException ex){
                dt = new DataTable();
                dt.Columns.Add("Mock Data", typeof(string));
                dt.Rows.Add("Mock");
                dt.Rows.Add("Data");
                Console.WriteLine(ex);
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

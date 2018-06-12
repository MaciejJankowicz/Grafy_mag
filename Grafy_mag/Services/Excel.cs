using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafy_mag.Models;
using OfficeOpenXml;

namespace Grafy_mag.Services
{
    public class Excel
    {
        public static void WritePareto(List<Cycle> pareto, int[][][] matrices)
        {
            string s = "";
            foreach (var item in pareto)
            {
                s += $"{item.GetCyclesString()},{item.GetCost(matrices[0])},{item.GetCost(matrices[1])},{item.GetCost(matrices[2])}" + Environment.NewLine;
            }

            s = s.Trim();
            File.WriteAllText("x.txt",s);


            MemoryStream ms = new MemoryStream();
            using (FileStream fs = File.OpenRead(@"Scatterplot3D_v21.xlsm"))
            using (ExcelPackage excelPackage = new ExcelPackage(fs))
            {
                ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets.First();
                var x = excelWorksheet.Cells[2, 33].Value;
                excelWorksheet.Cells[2, 33].Value = "999";
                excelWorksheet.Cells[3, 33].Value = "999";
                excelWorksheet.Cells[4, 33].Value = "999";


                excelPackage.SaveAs(ms); // This is the important part.
            }

            ms.Position = 0;
            using (FileStream file = new FileStream("x.xlsm", FileMode.Create, System.IO.FileAccess.Write))
            {
                ms.WriteTo(file);
            }

            ms.Close();
            //return new FileStreamResult(ms, "application/xlsx")
            //{
            //    FileDownloadName = "Tester.xlsx"
            //};
        }
    }       
}

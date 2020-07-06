using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Helpers
{
    public class Utiles
    {

        public static DateTime ToDD_MM_AAAA_Multi(string dtObj)
        {
            if (string.IsNullOrEmpty(dtObj))
                return DateTime.Now;
            else
            {
                DateTime returnValue = new DateTime();
                if (DateTime.TryParseExact(dtObj, @"dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out returnValue))
                    return returnValue;
                if (DateTime.TryParseExact(dtObj, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out returnValue))
                    return returnValue;
                if (DateTime.TryParse(dtObj, out returnValue))
                    return returnValue;
                return DateTime.Now;
            }
        }

        public static List<List<string>> LeerExcel(List<IFormFile> files)
        {
            byte[] fileBytes = null;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                }
            }
            List<List<string>> ReturnValues = new List<List<string>>();

            using (MemoryStream stream = new MemoryStream(fileBytes))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        //loop all columns in a row
                        List<string> excelData = new List<string>();
                        for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                        {
                            //add the cell data to the List
                            if (worksheet.Cells[i, j].Value != null)
                            {

                                excelData.Add(worksheet.Cells[i, j].Value.ToString());

                            }
                        }
                        ReturnValues.Add(excelData);
                    }
                }
            }

            return ReturnValues;

        }

    }
}

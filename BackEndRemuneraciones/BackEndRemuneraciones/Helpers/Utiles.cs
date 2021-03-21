using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackEndRemuneraciones.Helpers
{
    public class Utiles
    {
        public static NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CreateSpecificCulture("es").NumberFormat;



        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
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
        public static string NumeroConPuntosDeMiles(int val)
        {
            nfi.NumberGroupSeparator = ".";
            return val.ToString("#,0", nfi);
        }

        public static string NumeroConPuntosDeMiles(decimal val)
        {
            nfi.NumberGroupSeparator = ".";
            nfi.NumberDecimalSeparator = ",";
            return val.ToString("#,0", nfi);
        }

        public static string NumeroConPuntosDeMiles(string val)
        {
            nfi.NumberGroupSeparator = ".";
            string Formato = string.Format("#,0", nfi);
            return Formato;
        }
        public static string MayusculaPrimeraLetra(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;
            if (value.Length > 1)
                return char.ToUpper(value[0]) + value.Substring(1);
            else
                return value.ToUpper();
        }
        public static string obtenerNombreMes(int mesNumero)
        {
            string nombreMes = string.Empty;
            if (mesNumero > 12 || mesNumero < 1)
                return nombreMes;
            DateTime tmpDateObj = new DateTime(1987, mesNumero, 1);
            nombreMes = tmpDateObj.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            return MayusculaPrimeraLetra(nombreMes);
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

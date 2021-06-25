using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelCargoApp.Data
{
    public class RaporService
    {
        public List<Rapor> GetRapors()
        {

            List<Rapor> rapors = new List<Rapor>();
            string filePath = @"C:\Users\Nuh Cem Akmermer\Desktop\TEST-01\RAPOR.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage =new ExcelPackage(fileInfo)) {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int Colums = excelWorksheet.Dimension.End.Column;
                int Rows = excelWorksheet.Dimension.End.Row;
                for (int row = 2; row <= Rows; row++)
                {
                    Rapor rapor = new Rapor();
                    for (int colum = 1; colum <= Colums; colum++)
                    {
                        if (colum == 1) rapor.SIRA_NO =Convert.ToInt32( excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 2) rapor.ADET = Convert.ToInt32(excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 3) rapor.KG_DESİ = Convert.ToInt32(excelWorksheet.Cells[row, colum].Value.ToString());
                        if (colum == 4) rapor.MESAFE = excelWorksheet.Cells[row, colum].Value.ToString();
                        if (colum == 5) rapor.UCRET = Convert.ToInt32(excelWorksheet.Cells[row, colum].Value.ToString());
                    }
                
                    rapors.Add(rapor);
                }
                foreach (var item in rapors)
                {
                    if (item.MESAFE == "YAKIN" || item.MESAFE == "ŞEHİRİÇİ" || item.MESAFE == "KISA")
                    {
                        if (item.KG_DESİ < 6)
                        {
                            item.UCRET = 7;
                        }
                        if (item.KG_DESİ >= 6 && item.KG_DESİ <= 10)
                        {
                            item.UCRET = 9;
                        }
                        if (item.KG_DESİ > 10 && item.KG_DESİ <= 15)
                        {
                            item.UCRET = 13;
                        }
                        if (item.KG_DESİ > 15 && item.KG_DESİ <= 20)
                        {
                            item.UCRET = 15;
                        }
                        if (item.KG_DESİ > 20 && item.KG_DESİ <= 30)
                        {
                            item.UCRET = 21;
                        }
                    }
                    if (item.MESAFE == "UZAK" || item.MESAFE == "ORTA")
                    {
                        if (item.KG_DESİ < 6)
                        {
                            item.UCRET = 7.75;
                        }
                        if (item.KG_DESİ >= 6 && item.KG_DESİ <= 10)
                        {
                            item.UCRET = 10;
                        }
                        if (item.KG_DESİ > 10 && item.KG_DESİ <= 15)
                        {
                            item.UCRET = 14.5;
                        }
                        if (item.KG_DESİ > 15 && item.KG_DESİ <= 20)
                        {
                            item.UCRET = 16.5;
                        }
                        if (item.KG_DESİ > 20 && item.KG_DESİ <= 30)
                        {
                            item.UCRET = 23.5;
                        }



                        if (item.KG_DESİ >= 31)
                        {
                            item.UCRET = 23.5 + ((item.KG_DESİ - 30) * 0.78);
                        };

                    }

                }

                return rapors;
            }
            
        } 
    }
}

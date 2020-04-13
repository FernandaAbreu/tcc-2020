using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpreadsheetGear;

namespace ui.helpers
{
    public class Excel
    {
        
            

            
            private int _baseRowIndex;

            public int BaseRowIndex
            {
                get { return _baseRowIndex; }
                set { _baseRowIndex = value; }
            }
            

            public Excel()
            {
               
               
            }

            
            public FileStreamResult ExportData(string worksheetName, DataTable dt)
            {
                IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
                IWorksheet worksheet = workbook.Worksheets["Sheet1"];
                IRange cells = worksheet.Cells;



                worksheet.Name = worksheetName;
                int row = 0;
                int col = 0;

                for (int indexColumn = 0; indexColumn < dt.Columns.Count; indexColumn++)
                {
                    row = 1;
                    col = indexColumn;
                    AddHeader(cells, indexColumn, dt.Columns[indexColumn].ToString());
                    for (int indexRow = 0; indexRow < dt.Rows.Count; indexRow++)
                    {
                        var cell = cells[row + indexRow, col];
                        cell.NumberFormat = "@";
                        cell.Value = dt.Rows[indexRow][indexColumn];

                    }
                }
                System.IO.Stream stream = workbook.SaveToStream(
                        SpreadsheetGear.FileFormat.OpenXMLWorkbook);

                // Reset stream's current position back to the beginning.
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return new FileStreamResult(stream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }



            private void AddHeader(IRange cells, int columnIndex, string value)
            {
                var cell = cells[0, columnIndex];
                cell.Value = value;
                cell.Interior.Color = SpreadsheetGear.Color.FromArgb(128, 128, 128);
                cell.Font.Color = SpreadsheetGear.Color.FromArgb(255, 255, 255);
                cell.Font.Bold = true;
            }


           

           

            private string Space(int nivel)
            {
                string str = string.Empty;
                for (int i = 0; i < nivel; i++)
                {
                    str += "    ";
                }
                return str;
            }

        }

        
    
}

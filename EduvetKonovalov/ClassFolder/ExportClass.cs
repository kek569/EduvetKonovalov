using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EduvetKonovalov.ClassFolder
{
    internal class ExportClass
    {
        public static void ToExcelFile(DataGrid listDataGrid, string nameList)
        {
            Microsoft.Office.Interop.Excel.Application app = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            var process = Process.GetProcessesByName("EXCEL");

            SaveFileDialog openDlg = new SaveFileDialog();
            openDlg.FileName = nameList;
            openDlg.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
            openDlg.FilterIndex = 2;
            openDlg.RestoreDirectory = true;
            string path = openDlg.FileName;

            if (openDlg.ShowDialog() == true)
            {
                app = new Microsoft.Office.Interop.Excel.Application();

                app.DisplayAlerts = false;
                wb = app.Workbooks.Add();
                ws = wb.ActiveSheet;

                listDataGrid.SelectAllCells();
                listDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, listDataGrid);

                ws.Paste();
                ws.Range["A1", "I1"].Font.Bold = true;
                int number = ws.UsedRange.Rows.Count;

                Range myRange = ws.Range["A1", "I" + number];
                myRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                myRange.WrapText = false;
                ws.Columns.EntireColumn.AutoFit();
                app.Visible = true;
            }
        }
    }
}

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
        public static void ToExcelFile(DataGrid listDataGrid, string nameList, int DgLastColumns)
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

                if (DgLastColumns == 1) { (App.Current as App).ColumsExcel = "A"; }
                else if (DgLastColumns == 2) { (App.Current as App).ColumsExcel = "B"; }
                else if (DgLastColumns == 3) { (App.Current as App).ColumsExcel = "C"; }
                else if (DgLastColumns == 4) { (App.Current as App).ColumsExcel = "D"; }
                else if (DgLastColumns == 5) { (App.Current as App).ColumsExcel = "E"; }
                else if (DgLastColumns == 6) { (App.Current as App).ColumsExcel = "F"; }
                else if (DgLastColumns == 7) { (App.Current as App).ColumsExcel = "G"; }
                else if (DgLastColumns == 8) { (App.Current as App).ColumsExcel = "H"; }
                else if (DgLastColumns == 9) { (App.Current as App).ColumsExcel = "I"; }
                else if (DgLastColumns == 10) { (App.Current as App).ColumsExcel = "J"; }
                else if (DgLastColumns == 11) { (App.Current as App).ColumsExcel = "K"; }
                else if (DgLastColumns == 12) { (App.Current as App).ColumsExcel = "L"; }
                else if (DgLastColumns == 13) { (App.Current as App).ColumsExcel = "M"; }
                else if (DgLastColumns == 14) { (App.Current as App).ColumsExcel = "N"; }
                else if (DgLastColumns == 15) { (App.Current as App).ColumsExcel = "O"; }
                string ColumsExcel = (App.Current as App).ColumsExcel;

                string a = ColumsExcel + "1";

                ws.Paste();
                ws.Range["A1", a].Font.Bold = true;
                int number = ws.UsedRange.Rows.Count;

                Range myRange = ws.Range["A1", ColumsExcel + number];
                myRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                myRange.WrapText = false;
                ws.Columns.EntireColumn.AutoFit();
                app.Visible = true;
            }
        }
    }
}

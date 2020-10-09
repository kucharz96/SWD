using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWD
{
    public class Operator
    {
        public static DataTable Dt = new DataTable();

        #region HelpersMethod

        public static List<double> ConvertToListDouble(string columnName)
        {
            return Dt
                .AsEnumerable()
                .Select(row => Convert.ToDouble(row[columnName])).ToList();
        }

        public static double GetMinValueFormColumn(string columnName)
        {
            var values = ConvertToListDouble(columnName);
            return values.Min();
        }
        public static double GetMaxValueFormColumn(string columnName)
        {
            var values = ConvertToListDouble(columnName);
            return values.Max();
        }

        public static List<string> GetRealColumns()
        {
            List<string> realColumns = new List<string>();
            for(int col= 0; col < Dt.Columns.Count; col++)
            {
                if(double.TryParse((string)Dt.Rows[0][col],out double a))
                {
                    realColumns.Add(Dt.Columns[col].ColumnName);
                }
            }
            return realColumns;
        }

        public static List<string> GetStringColumns()
        {
            List<string> stringColumns = new List<string>();
            for (int col = 0; col < Dt.Columns.Count; col++)
            {
                if (!double.TryParse((string)Dt.Rows[0][col], out double a))
                {
                    stringColumns.Add(Dt.Columns[col].ColumnName);
                }
            }
            return stringColumns;
        }

        public static double CalculateStandardDeviation(string colName)
        {
            var valuesList = ConvertToListDouble(colName);
            var avg = valuesList.Average();
            double sum = 0;
            foreach(var value in valuesList)
            {
                sum += Math.Pow((value - avg), 2);
            }
            return Math.Sqrt(sum / valuesList.Count);
        }




        #endregion


        public static void LoadData(string filePath)
        {
            Dt = new DataTable();
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(newline) || newline[0] == '#')
                    continue;
                string[] values = newline.Trim().Split('\t');
                if (Dt.Columns.Count == 0)
                {
                    foreach (string c in values)
                    {
                        Dt.Columns.Add(c);
                    }
                }
                else
                {
                    DataRow dr = Dt.NewRow();

                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i];
                    }
                    Dt.Rows.Add(dr);
                }

            }
            file.Close();
        }

        public static void ChangeToNumber(string columnName)
        {
            Dictionary<string, int> valueNumbers = new Dictionary<string, int>();
            List<string> allValuesFromColumn = Dt
                .AsEnumerable()
                .Select(row => row.Field<string>(columnName)).Distinct().ToList();
            int cont = 0;
            foreach(string val in allValuesFromColumn)
            {
                valueNumbers.Add(val, ++cont);
            }
            string newNameCol = columnName + "_ctn";
            Dt.Columns.Add(newNameCol);
            foreach(DataRow row in Dt.Rows)
            {
                row[newNameCol] = valueNumbers[(string)row[columnName]];
            }

        }

        public static void NormalizeData(string columnName)
        {
            var sd = CalculateStandardDeviation(columnName);
            var avg = Dt
              .AsEnumerable()
              .Select(row => Convert.ToDouble(row[columnName])).Average();
            string newNameCol = columnName + "_nd";
            Dt.Columns.Add(newNameCol);
            foreach (DataRow row in Dt.Rows)
            {
                double val = Convert.ToDouble(row[columnName]);
                double newVal = (val - avg) / sd;

                row[newNameCol] = newVal;
            }
        }

        public static void SelectSpecificsData(DataGridView gridView,string columnName,int percentOfData,bool biggerData = false)
        {
            var values = ConvertToListDouble(columnName);
            if (biggerData)
            {
                values = values.OrderByDescending(i => i).ToList();
            }
            else
            {
                values = values.OrderBy(i => i).ToList();
            }
            float per = (float)percentOfData / 100;

            int takeCountElements = (int)(values.Count * per);
            values = values.Take(takeCountElements).ToList();
            int ro = 0;
            foreach (DataRow row in Dt.Rows)
            {
                double val = Convert.ToDouble(row[columnName]);
                if (values.Contains(val))
                {
                    gridView.Rows[ro].Selected = true;
                }
                else
                {
                    gridView.Rows[ro].Selected = false;
                }
                ro++;
            }

        }
    }
}

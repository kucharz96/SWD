using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD
{
    public class Operator
    {
        public static DataTable Dt = new DataTable();

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
    }
}

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
    }
}

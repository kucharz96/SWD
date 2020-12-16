﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;
using Accord.Math.Distances;
using Accord.Statistics;


namespace SWD
{
    public class Operator
    {
        public static DataTable Dt = new DataTable();


        public static double[,] InverseCovarianceMatrix = null;

        #region HelpersMethod

        public static double CalculateMetrics(int row, int rowToCount, MetricsEnum metricsEnum)  
        {
            switch (metricsEnum)
            {
                case MetricsEnum.Manhattan:
                    return ManhattanMetrics(row, rowToCount);
                case MetricsEnum.Euclides:
                    return EuclidesMetrics(row, rowToCount);
                case MetricsEnum.Czebyszew:
                    return CzebyszewMetrics(row, rowToCount);
                case MetricsEnum.Mahalanobis:
                    return MahalanobisMetrics(row, rowToCount);
                default:
                    throw new NotImplementedException();
            }
        }



        public static List<string> GetColumnsWithoutLast()
        {
            List<string> columns = new List<string>();
            int diff =
                Dt.Columns
                .Cast<DataColumn>()
                .Where(i => i.ColumnName.Contains("kmean")) 
                .Count() + 1;

            for (int col = 0; col < Dt.Columns.Count-diff; col++)
            {
               
               columns.Add(Dt.Columns[col].ColumnName);
                
            }
            return columns;
        }

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
            for (int col = 0; col < Dt.Columns.Count; col++)
            {
                if (double.TryParse((string)Dt.Rows[0][col], out double a))
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
                if (!double.TryParse((string)Dt.Rows[0][col], out double a) || col == Dt.Columns.Count-1)
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
            foreach (var value in valuesList)
            {
                sum += Math.Pow((value - avg), 2);
            }
            return Math.Sqrt(sum / valuesList.Count);
        }

        public static double ConvertRange(double originalStart, double originalEnd, double newStart, double newEnd, double value)
        {
            double scale = (newEnd - newStart) / (originalEnd - originalStart);
            return (newStart + ((value - originalStart) * scale));
        }




        #endregion

        #region BasicOperations
        public static void LoadData(string filePath , bool withoutColumn = false)
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
                    if (withoutColumn)
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            Dt.Columns.Add((i + 1).ToString());
                        }
                        DataRow dr = Dt.NewRow();

                        for (int i = 0; i < values.Length; i++)
                        {
                            dr[i] = values[i].Replace('.',',');
                        }
                        Dt.Rows.Add(dr);

                    }
                    else
                    {
                        foreach (string c in values)
                        {
                            Dt.Columns.Add(c);
                        }
                    }
                }
                else
                {
                    DataRow dr = Dt.NewRow();

                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i].Replace('.', ',');
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
            foreach (string val in allValuesFromColumn)
            {
                valueNumbers.Add(val, ++cont);
            }
            string newNameCol = columnName + "_ctn";
            Dt.Columns.Add(newNameCol);
            foreach (DataRow row in Dt.Rows)
            {
                row[newNameCol] = valueNumbers[(string)row[columnName]];
            }

        }

        public static void NormalizeData(string columnName, bool noAddCol = false)
        {
            var sd = CalculateStandardDeviation(columnName);
            var avg = Dt
              .AsEnumerable()
              .Select(row => Convert.ToDouble(row[columnName])).Average();
            string newNameCol;
            if (noAddCol)
            {
                newNameCol = columnName;
            }
            else
            {
                newNameCol = columnName + "_nd";
                Dt.Columns.Add(newNameCol);
            }
             
            foreach (DataRow row in Dt.Rows)
            {
                double val = Convert.ToDouble(row[columnName]);
                double newVal = (val - avg) / sd;
                if (double.IsNaN(newVal)){
                    newVal = 0;
                }
                row[newNameCol] = newVal;
            }
        }

        public static void DiscretizeData(string columnName, int sections)
        {
            double min = GetMinValueFormColumn(columnName);
            double max = GetMaxValueFormColumn(columnName);
            double diff = (max - min) / sections;
            double pom = min;
            string newNameCol = columnName + "_dd";
            Dt.Columns.Add(newNameCol);
            for (int counter = 1; pom < max; counter++)
            {
                foreach (DataRow row in Dt.Rows)
                {
                    double val = Convert.ToDouble(row[columnName]);
                    if (((val >= pom && val < pom + diff)) || ((pom + diff * 2) > max && val == max))
                    {
                        row[newNameCol] = counter;

                    }


                }
                pom = pom + diff;
            }

        }




        public static void ChangeRange(string columnName, double a, double b)
        {
            double min = GetMinValueFormColumn(columnName);
            double max = GetMaxValueFormColumn(columnName);
            string newNameCol = columnName + "_cr";
            Dt.Columns.Add(newNameCol);
            foreach (DataRow row in Dt.Rows)
            {
                double val = Convert.ToDouble(row[columnName]);
                row[newNameCol] = ConvertRange(min, max, a, b, val);
            }

        }

        public static void SelectSpecificsData(DataGridView gridView, string columnName, int percentOfData, bool biggerData = false)
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




        #endregion

        #region Metrics

        public static double EuclidesMetrics(int row,int rowToCount)
        {
            double metrics = 0;
            foreach(string column in GetColumnsWithoutLast())
            {
                var aaa = Dt.Rows[row][column];
                double firstVal = Convert.ToDouble(Dt.Rows[row][column]);
                double secondVal = Convert.ToDouble(Dt.Rows[rowToCount][column]);

                metrics += Math.Pow(firstVal - secondVal, 2);

            }
            
            return Math.Sqrt(metrics);
        }

        public static double ManhattanMetrics(int row, int rowToCount)
        {
            double metrics = 0;
            foreach (string column in GetColumnsWithoutLast())
            {
                double firstVal = Convert.ToDouble(Dt.Rows[row][column]);
                double secondVal = Convert.ToDouble(Dt.Rows[rowToCount][column]);

                metrics += Math.Abs(firstVal - secondVal);

            }

            return metrics;
        }

        public static double MahalanobisMetrics(int row,int rowToCount)
        {
            var columns = GetColumnsWithoutLast();
            if (InverseCovarianceMatrix == null)
            {
                var matrix = new double[Dt.Rows.Count, columns.Count];

                for(int rowC =0; rowC< Dt.Rows.Count; rowC++)
                {

                    for(int colC = 0; colC < columns.Count; colC++)
                    {
                        matrix[rowC,colC] = Convert.ToDouble(Dt.Rows[rowC][colC]);
                    }
                }
                var covarianceMatrix = matrix.Covariance();

                try
                {
                    InverseCovarianceMatrix = covarianceMatrix.Inverse();
                }
                catch
                {
                    InverseCovarianceMatrix = covarianceMatrix.PseudoInverse();
                }


                
            }



            
            double[] xValues = new double[columns.Count];
            double[] yValues = new double[columns.Count];
            for (int a = 0; a < columns.Count; a++) 
            {
                double x = Convert.ToDouble(Dt.Rows[row][a]);
                double y = Convert.ToDouble(Dt.Rows[rowToCount][a]);
                xValues[a] = x;
                yValues[a] = y;

            }





            return Mahalanobis.FromPrecisionMatrix(InverseCovarianceMatrix).Distance(xValues, yValues);



        }



        public static double CzebyszewMetrics(int row, int rowToCount)
        {
            double max = 0;
            foreach (string column in GetColumnsWithoutLast())
            {
                double firstVal = Convert.ToDouble(Dt.Rows[row][column]);
                double secondVal = Convert.ToDouble(Dt.Rows[rowToCount][column]);
                
                double diff = Math.Abs(firstVal - secondVal);
                if (max < diff)
                {
                    max = diff;
                }

            }

            return max;
        }

        


        #endregion

        #region KNNClasification



        public static void KNNClasifications(int currRow, int k, MetricsEnum metricsEnum)
        {
            InverseCovarianceMatrix = null;
            var distance = KNNClasificationDistances(currRow, metricsEnum);
            string newVariable = KNNPredictVariable(distance, k);
            Dt.Rows[currRow][Dt.Columns[Dt.Columns.Count - 1]] = newVariable;
        }




        public static Dictionary<int, KNNValuePair> KNNClasificationDistances(int currRow, MetricsEnum metricsEnum)
        {
            Dictionary<int,KNNValuePair> distanses = new Dictionary<int, KNNValuePair>();
            for(int a=0;a<Dt.Rows.Count;a++)
            {
                if(a != currRow)
                {
                    double metrics = CalculateMetrics(a, currRow, metricsEnum);

                    distanses.Add(a, new KNNValuePair {
                        Value = (string)Dt.Rows[a][Dt.Columns[Dt.Columns.Count - 1]],
                        Weight = metrics
                    });
                }
            }
            return distanses;
        }


        public static string KNNPredictVariable(Dictionary<int, KNNValuePair> distanses,int k)
        {
            List<string> listOfNearestDistanseDecisions = distanses.OrderBy(i => i.Value.Weight)
                .Take(k).Select(i => i.Value.Value).ToList();

            var confidences = listOfNearestDistanseDecisions.GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());

            int maxConfidence = confidences.Max(i => i.Value);

            var nearestDecisions = confidences.Where(i => i.Value == maxConfidence).Select(i=>i.Key).ToList();


            if (nearestDecisions.Count() == 1)
            {
                return nearestDecisions.FirstOrDefault();
            }
            else
            {
                Random rnd = new Random();
                int r = rnd.Next(nearestDecisions.Count());
                return nearestDecisions[r];
            }
        }








        #endregion


        #region KMean

        public static List<KNNValuePair> KMeanGroup(MetricsEnum metricsEnum, int k)
        {
            List<KNNValuePair> distToMeans = new List<KNNValuePair>();
            InverseCovarianceMatrix = null;
            var columns = GetColumnsWithoutLast();
            string colName = "kmean_" + k +"_" + metricsEnum.ToString();
            Dt.Columns.Add(colName);
            List<Dictionary<string, double>> tempMeans = new List<Dictionary<string, double>>();
            //wybór losowych punktów (tymczasowe)
            for (int a = 0; a < k; a++)
            {
                DataRow randRow = Dt.NewRow();
                var dict = new Dictionary<string, double>();
                foreach (var column in columns)
                {
                    var min = Dt
                            .AsEnumerable()
                            .Select(row => Convert.ToDouble(row[column])).ToList().Min();
                    var max = Dt
                            .AsEnumerable()
                            .Select(row => Convert.ToDouble(row[column])).ToList().Max();
                    Random rng = new Random(a);
                    dict.Add(column, 0);
                    
                    var rngNumber = rng.NextDouble();
                    randRow[column] = rngNumber * (max - min) + min;

                }
                tempMeans.Add(dict);
                randRow[colName] = (a + 1);
                Dt.Rows.Add(randRow);
            }


            while (!CompareKMeans(tempMeans, k))
            {
                distToMeans = new List<KNNValuePair>();
                FillMeansTemp(tempMeans, k);
                //szacowanie nowej klasy

                for (int a = 0; a < Dt.Rows.Count - k; a++)
                {
                    Dictionary<int, double> distances = new Dictionary<int, double>();
                    for (int b = Dt.Rows.Count - k; b < Dt.Rows.Count; b++)
                    {
                        distances.Add(b, CalculateMetrics(b, a, metricsEnum));
                    }

                    var minMean = distances.Min(i => i.Value);
                    var indexMean = distances.Where(i => i.Value == minMean).FirstOrDefault().Key;
                    Dt.Rows[a][colName] = Dt.Rows[indexMean][colName];

                    distToMeans.Add(new KNNValuePair { Value = (string)Dt.Rows[indexMean][colName], Weight = minMean });

                }
                //nowa średnia
                for (int b = Dt.Rows.Count - k; b < Dt.Rows.Count; b++)
                {
                    foreach (var column in GetColumnsWithoutLast())
                    {
                        var avg = Dt.Rows.Cast<DataRow>()
                        .Take(Dt.Rows.Count - k)
                        .Where(i => i[colName] == Dt.Rows[b][colName]);

                        if (avg.Count() == 0)
                        {
                            Dt.Rows[b][column] = 0;
                        }
                        else
                        {
                            Dt.Rows[b][column] = avg
                                .Select(row => Convert.ToDouble(row[column]))
                                .Average();
                        }




                    }
                }




            }
            //usuniecie zbędnych kolumn
            for (int a = 0; a < k; a++)
            {
                Dt.Rows.RemoveAt(Dt.Rows.Count - 1);
            }


            return distToMeans;

        }




        public static bool CompareKMeans(List<Dictionary<string, double>> current, int k)
        {
            int counter = 0;
            for(int a = Dt.Rows.Count - k;a< Dt.Rows.Count; a++)
            {
                foreach(var col in GetColumnsWithoutLast())
                {
                    if(current[counter][col] != Convert.ToDouble(Dt.Rows[a][col]))
                    {
                        return false;
                    }
                }
                counter++;
            }
            return true;
        }


        public static void FillMeansTemp(List<Dictionary<string, double>> current, int k)
        {
            int counter = 0;
            for (int a = Dt.Rows.Count - k; a < Dt.Rows.Count; a++)
            {
                foreach (var col in GetColumnsWithoutLast())
                {
                    current[counter][col] = Convert.ToDouble(Dt.Rows[a][col]);
                    

       
                }
                counter++;
            }

        }

        #endregion

    }

    public struct KNNValuePair
    { 
        public string Value;
        public double Weight;
    }
}

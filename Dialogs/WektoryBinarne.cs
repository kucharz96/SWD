using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWD.Dialogs
{
    public partial class WektoryBinarne : Form
    {
        public WektoryBinarne()
        {
            InitializeComponent();

            Init();



        }


        public void Init()
        {
            int decisionIndex = Operator.Dt.Columns.Count - 1;
            List<DiagOfCuts> allCuts = new List<DiagOfCuts>();

            while (true)
            {
                bool checker = false;
                List<DataRow> tempRows = new List<DataRow>(Operator.Dt.Rows.Cast<DataRow>().ToList());

                //wyznaczamy granice
                foreach (var column1 in Operator.GetColumnsWithoutLast())
                {
                    double? upDivider = null, downDivider = null;
                    var downDividerS = allCuts
                        .Where(i => i.Column == column1 && i.Direction == 1)
                        .OrderByDescending(i => i.Coordinate)
                        .Select(i => i.Coordinate);
                    var upDividerS = allCuts
                        .Where(i => i.Column == column1 && i.Direction == 0)
                        .OrderBy(i => i.Coordinate)
                        .Select(i => i.Coordinate);

                    if (downDividerS.Count() != 0)
                    {
                        downDivider = downDividerS.FirstOrDefault();
                    }
                    if(upDividerS.Count() != 0)
                    {
                        upDivider = upDividerS.FirstOrDefault();
                    }

                    if (downDivider.HasValue && upDivider.HasValue)
                    {
                        tempRows = tempRows
                        .Where(i => double.Parse((string)i[column1]) > downDivider && double.Parse((string)i[column1]) < upDivider.Value)
                        .ToList();
                    }
                    else if (downDivider.HasValue)
                    {
                        tempRows = tempRows
                        .Where(i => double.Parse((string)i[column1]) > downDivider)
                        .ToList();
                    }
                    else if (upDivider.HasValue)
                    {
                        tempRows = tempRows
                        .Where(i => double.Parse((string)i[column1]) < upDivider.Value)
                        .ToList();
                    }
                }
                Dictionary<DiagOfCuts, int> objectsForCuts = new Dictionary<DiagOfCuts, int>();
                foreach (var column in Operator.GetColumnsWithoutLast())
                {
                    int backMode = 1;

                    for (; backMode >= 0; backMode--)
                    {
                        List<double> tempValues;
                        if (backMode == 0)
                        {
                            //od najmniejszej do nawiekszej
                            tempValues = tempRows.Select(i => double.Parse((string)i[column])).OrderByDescending(i => i).ToList();


                        }
                        else
                        {
                            //od najmniejszej do nawiekszej
                            tempValues = tempRows.Select(i => double.Parse((string)i[column])).OrderBy(i => i).ToList();
                        }

                        if (tempValues.Count() != 0 && tempRows.Count() != 0)
                        {
                            string firstLabel = (string)tempRows.Where(i=> double.Parse((string)i[column]) == tempValues.FirstOrDefault()).FirstOrDefault()[decisionIndex];
                            int objectsCount = 0;
                            double tempCoord = 0;

                            foreach (var value in tempValues)
                            {
                                checker = true;
                                List<DataRow> objects = tempRows.Where(i => double.Parse((string)i[column]) == value).ToList();
                                if (objects.Any(i => (string)i[decisionIndex] != firstLabel))
                                {
                                    break;
                                }
                                objectsCount += objects.Count();
                                tempCoord = value;


                            }
                            if (objectsCount != 0)
                            {
                                DiagOfCuts cut = new DiagOfCuts
                                {
                                    Column = column,
                                    Coordinate = tempCoord,
                                    Direction = backMode

                                };


                                objectsForCuts.Add(cut, objectsCount);
                            }
                        }
                    }





                }

                if(objectsForCuts.Count() != 0)
                {
                    var bestCut = objectsForCuts.OrderByDescending(i => i.Value).FirstOrDefault();
                    allCuts.Add(bestCut.Key);

                }
                else
                {
                    if(checker == true)
                    {

                    }

                    allCuts.RemoveAt(allCuts.Count() -1);
                    //warunek stopu
                    break;
                }
            }
                
        }
            
    


        public class DiagOfCuts
        {
            public double Coordinate;
            public int Direction;
            public string Column;
        }
    }
}

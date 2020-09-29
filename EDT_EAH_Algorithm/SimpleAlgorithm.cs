using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAH.DataModel;
using Google.OrTools.Sat;

namespace EDT_EAH_Algorithm
{
    public class SimpleAlgorithm
    {
        public List<string> Compute(Database pSource)
        {
            List<IntVar> lVariables = new List<IntVar>();
            CpModel lModel = new CpModel();

            List<Student> lDayStudents = pSource.GetDayStudent();
            List<Teacher> lDayTeachers = pSource.GetDayTeacher();

            // Create all variables.
            WorkDay lWorkDay = pSource.WorkDays.First(pItem => pItem.Name == pSource.DayOfWeek);
            foreach (var lStudent in lDayStudents)
            {

                //  Now, create all variables.
                foreach (var lTeacher in lDayTeachers)
                {
                    foreach (var lOpeningHour in lWorkDay.OpeningHours)
                    {
                        string lVarName = lStudent.Name + "_SEP_" + lTeacher.Name + "_SEP_" + lOpeningHour;
                        lVariables.Add(lModel.NewBoolVar(lVarName));
                    }
                }
            }

            // Set available slots for students.
            foreach (var lStudent in lDayStudents)
            {
                int lIndex = 0;
                foreach (var lOpeningHour in lWorkDay.OpeningHours)
                {
                    List<IntVar> lHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lOpeningHour) && pDecision.Name().Contains(lStudent.Name)).ToList();
                    // Force to false, all slots not available for a student.
                    if (lStudent.IsPresent[lIndex] == "NOP")
                    {
                        lModel.Add(LinearExpr.Sum(lHourDecisions.ToArray()) == 0);
                    }
                    // Only one slot at a time.
                    else
                    {
                        lModel.Add(LinearExpr.Sum(lHourDecisions.ToArray()) <= 1);
                    }
                    lIndex++;
                }
            }

            // Force to false, all slots not allowed with a teacher.
            foreach (var lStudent in lDayStudents)
            {
                foreach (var lTeacher in lDayTeachers)
                {
                    List<IntVar> lHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lTeacher.Name) && pDecision.Name().Contains(lStudent.Name)).ToList();
                    List<FieldArea> lCanTeach = lStudent.FieldAreas.Intersect(lTeacher.FieldAreas).ToList();
                    if (lCanTeach.Count == 0)
                    {
                        lModel.Add(LinearExpr.Sum(lHourDecisions.ToArray()) == 0);
                    }
                    else
                    {
                        lModel.Add(LinearExpr.Sum(lHourDecisions.ToArray()) <= 1);
                    }
                }
            }

            // Force to false, all slots not available for a teacher.
            foreach (var lTeacher in lDayTeachers)
            {
                int lIndex = 0;
                foreach (var lOpeningHour in lWorkDay.OpeningHours)
                {
                    List<IntVar> lHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lOpeningHour) && pDecision.Name().Contains(lTeacher.Name)).ToList();
                    if (lIndex < lTeacher.IsPresent.Count)
                    {
                        string[] lDayHour = lTeacher.IsPresent[lIndex].Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                        if (lDayHour.Length == 2 && lDayHour[1] == lOpeningHour)
                        {
                            lModel.Add(LinearExpr.Sum(lHourDecisions.ToArray()) <= 1);
                            lIndex++;
                        }
                        else
                        {
                            lModel.Add(LinearExpr.Sum(lHourDecisions.ToArray()) == 0);
                        }
                    }
                    else
                    {
                        lModel.Add(LinearExpr.Sum(lHourDecisions.ToArray()) == 0);
                    }
                }
            }

            // Avoid two consecutives slots with the same student.
            // Set available slots for students.
            foreach (var lStudent in lDayStudents)
            {

                for (int lHourIndex = 0; lHourIndex < lWorkDay.OpeningHours.Count; lHourIndex++)
                {
                    // Avoid two consecutives slots if the ratio is less than 0.5
                    if (lHourIndex > 0)
                    {
                        List<IntVar> lHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lWorkDay.OpeningHours[lHourIndex]) && pDecision.Name().Contains(lStudent.Name)).ToList();
                        List<IntVar> lPreviousHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lWorkDay.OpeningHours[lHourIndex - 1]) && pDecision.Name().Contains(lStudent.Name)).ToList();
                        List<IntVar> lAll = new List<IntVar>();
                        lAll.AddRange(lHourDecisions);
                        lAll.AddRange(lPreviousHourDecisions);
                        double lNbFields = lStudent.FieldAreas.Where(pItem => pItem.Code != "NOP").Count();
                        double lNbSlots = lStudent.IsPresent.Where(pItem => pItem != "NOP").Count();
                        double lRatio = lNbFields / lNbSlots;
                        if (lRatio <= 0.5)
                        {
                            lModel.Add(LinearExpr.Sum(lAll.ToArray()) < 2);
                        }
                        else
                        {
                            lModel.Add(LinearExpr.Sum(lAll.ToArray()) <= 2);
                        }
                    }

                    if (lHourIndex > 1)
                    {
                        List<IntVar> lHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lWorkDay.OpeningHours[lHourIndex]) && pDecision.Name().Contains(lStudent.Name)).ToList();
                        List<IntVar> lPreviousHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lWorkDay.OpeningHours[lHourIndex - 1]) && pDecision.Name().Contains(lStudent.Name)).ToList();
                        List<IntVar> lPreviousPreviousHourDecisions = lVariables.Where(pDecision => pDecision.Name().Contains(lWorkDay.OpeningHours[lHourIndex - 2]) && pDecision.Name().Contains(lStudent.Name)).ToList();
                        List<IntVar> lAll = new List<IntVar>();
                        lAll.AddRange(lHourDecisions);
                        lAll.AddRange(lPreviousHourDecisions);
                        lAll.AddRange(lPreviousPreviousHourDecisions);
                        double lNbFields = lStudent.FieldAreas.Where(pItem => pItem.Code != "NOP").Count();
                        double lNbSlots = lStudent.IsPresent.Where(pItem => pItem != "NOP").Count();
                        double lRatio = lNbFields / lNbSlots;
                        if (lRatio <= 0.75)
                        {
                            lModel.Add(LinearExpr.Sum(lAll.ToArray()) < 3);
                        }
                    }
                }
            }

            lModel.Maximize(LinearExpr.Sum(lVariables.ToArray()));


            List<string> lResult = new List<string>();
            CpSolver lSolver = new CpSolver();
            CpSolverStatus lStatus = lSolver.Solve(lModel);
            Console.WriteLine(lStatus);
            if (lStatus == CpSolverStatus.Optimal)
            {
                foreach (var lVariable in lVariables)
                {
                    if (lSolver.Value(lVariable) == 1)
                    {
                        string[] lValues = lVariable.Name().Split(new string[] { "_SEP_" }, StringSplitOptions.RemoveEmptyEntries);
                        lResult.Add(lValues[0] + "@" + lWorkDay.Name + "@" + lValues[2] + "@" + lValues[1] + "@" + "No desc");
                    }
                }
            }

            return lResult;
        }
    }
}

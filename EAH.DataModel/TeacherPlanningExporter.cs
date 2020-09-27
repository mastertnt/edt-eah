using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace EAH.DataModel
{
    public class TeacherPlanningExporter
    {
        public void Write(string pPath, string pSuffix, List<string> pSlots, DateTime pDate, Database pDatabase)
        {
            using (var lPackage = new ExcelPackage(new FileInfo("TEMPLATE_PROFS.xlsx")))
            {
                // Write the date.
                lPackage.Workbook.Worksheets[0].Cells["B1"].Value = pDate.ToShortDateString();

                // Write the student name.
                int lColIndex = 2;

                List<Teacher> lDayTeachers = pDatabase.Teachers.FindAll(pTeacher => pTeacher.IsPresent.FirstOrDefault(pSlot => pSlot.Contains(pDatabase.DayOfWeek)) != null).ToList();

                for (int lTeacherIndex = 0; lTeacherIndex < lDayTeachers.Count; lTeacherIndex++)
                {
                    lPackage.Workbook.Worksheets[0].Cells[2, lColIndex + lTeacherIndex].Value = lDayTeachers[lTeacherIndex].Name;
                    int lRowIndex = 3;
                    while (lPackage.Workbook.Worksheets[0].Cells[lRowIndex, 1].Value != null)
                    {
                        string lHour = lPackage.Workbook.Worksheets[0].Cells[lRowIndex, 1].Value.ToString();
                        string lFoundSlot = pSlots.FirstOrDefault(pSlot => pSlot.Contains(pDatabase.DayOfWeek + "@" + lHour + "@" + lDayTeachers[lTeacherIndex].Name));
                        if (lFoundSlot != null)
                        {
                            string[] lSlotInfos = lFoundSlot.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                            lPackage.Workbook.Worksheets[0].Cells[lRowIndex, lColIndex + lTeacherIndex].Value = lSlotInfos[0];
                        }
                        lRowIndex++;
                    }
                }

                lPackage.SaveAs(new FileInfo(pPath + pSuffix + ".xlsx"));
            }
        }
    }
}

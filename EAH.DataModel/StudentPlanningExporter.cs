using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace EAH.DataModel
{
    public class StudentPlanningExporter
    {
        public void Write(string pPath, string pSuffix, List<string> pSlots, DateTime pDate, Database pDatabase)
        {
            using (var lPackage = new ExcelPackage(new FileInfo("TEMPLATE.xlsx")))
            {
                // Write the date.
                lPackage.Workbook.Worksheets[0].Cells["C1"].Value = pDate.ToShortDateString();

                // Write the student name and room code.
                int lRowIndex = 3;
                foreach (Student lStudent in pDatabase.Students)
                {
                    lPackage.Workbook.Worksheets[0].Cells[lRowIndex, 1].Value = lStudent.RoomCode;
                    lPackage.Workbook.Worksheets[0].Cells[lRowIndex, 2].Value = lStudent.Name;
                    lRowIndex++;
                }

                foreach (string lSlot in pSlots)
                {
                    string[] lSlotInfos = lSlot.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                    if (lSlotInfos.Length == 5)
                    {
                        lRowIndex = 3;
                        bool lIsFound = false;  
                        while (lIsFound == false)
                        {
                            if (lPackage.Workbook.Worksheets[0].Cells[lRowIndex, 2].Value != null)
                            {
                                if (lPackage.Workbook.Worksheets[0].Cells[lRowIndex, 2].Value.ToString() == lSlotInfos[0])
                                {
                                    lIsFound = true;
                                }
                                else
                                {
                                    lRowIndex++;
                                }
                            }
                            else
                            {
                                lRowIndex++;
                            }

                        }

                        int lColIndex = 3;
                        while (lPackage.Workbook.Worksheets[0].Cells[2, lColIndex].Value.ToString() != lSlotInfos[2])
                        {
                            lColIndex++;
                        }

                        lPackage.Workbook.Worksheets[0].Cells[lRowIndex, lColIndex].Value = lSlotInfos[3] + "\n" + lSlotInfos[4];
                    }
                }

                lPackage.SaveAs(new FileInfo(pPath + pSuffix + ".xlsx"));
            }
        }
    }

}

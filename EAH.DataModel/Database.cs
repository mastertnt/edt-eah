using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;

namespace EAH.DataModel
{
    /**
     * This class reprensents the whole file.
     */
    public class Database
    {
        /**
         * Gets the field of areas.
         */
        public List<FieldArea> FieldAreas
        {
            get;
            private set;
        }

        /**
         * Gets the teachers.
         */
        public List<Teacher> Teachers
        {
            get;
            private set;
        }

        /**
         * Gets the work days.
         */
        public List<WorkDay> WorkDays
        {
            get;
            private set;
        }

        /**
         * Gets the students.
         */
        public List<Student> Students
        {
            get;
            private set;
        }

        /**
         * Get the day of the week.
         */
        public string DayOfWeek
        {
            get;
            set;
        }

        /**
        * Get the date.
        */
        public string Date
        {
            get;
            set;
        }

        /**
         * Default constructor.
         */
        public Database()
        {
            this.FieldAreas = new List<FieldArea>();
            this.Teachers = new List<Teacher>();
            this.WorkDays = new List<WorkDay>();
            this.Students = new List<Student>();
        }

        /**
         * Initialize the database.
         * 
         * @param pFilename The filename.
         */
        public void Initialize(string pFilename)
        {
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var lPackage = new ExcelPackage(new FileInfo(pFilename)))
            {
                if (this.ReadFieldAreas(lPackage.Workbook.Worksheets.FirstOrDefault(pWorksheet => pWorksheet.Name == "FieldAreas")) != 0)
                {
                    this.FieldAreas.Add(new FieldArea() { Code = "NOP", Description= "NoPriority (internal value)" });
                    this.FieldAreas.Add(new FieldArea() { Code = "USED", Description = "USED (internal value)" });
                    if (this.ReadTeachers(lPackage.Workbook.Worksheets.FirstOrDefault(pWorksheet => pWorksheet.Name == "Teachers")) != 0)
                    {
                        if (this.ReadWorkDays(lPackage.Workbook.Worksheets.FirstOrDefault(pWorksheet => pWorksheet.Name == "TeacherPlanning")) != 0)
                        {
                            if (this.ReadStudents(lPackage.Workbook.Worksheets.FirstOrDefault(pWorksheet => pWorksheet.Name == "Planning")) != 0)
                            {
                                if (this.ReadStudentPlanning(lPackage.Workbook.Worksheets.FirstOrDefault(pWorksheet => pWorksheet.Name == "Planning")) != 0)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }

        protected int ReadFieldAreas(ExcelWorksheet pWorksheet)
        {
            if (pWorksheet != null)
            {
                int lRowIndex = 2;
                while (pWorksheet.Cells[lRowIndex, 1].Value != null)
                {
                    FieldArea lArea = new FieldArea();
                    lArea.Code = pWorksheet.Cells[lRowIndex, 1].Value.ToString();
                    lArea.Description = pWorksheet.Cells[lRowIndex, 2].Value.ToString();
                    this.FieldAreas.Add(lArea);
                    lRowIndex ++;
                }
                return 1;
            }
            return 0;
        }

        protected int ReadTeachers(ExcelWorksheet pWorksheet)
        {
            if (pWorksheet != null)
            {
                int lRowIndex = 2;
                while (pWorksheet.Cells[lRowIndex, 1].Value != null)
                {
                    Teacher lTeacher = new Teacher();
                    lTeacher.Name = pWorksheet.Cells[lRowIndex, 1].Value.ToString();

                    int lColIndex = 2;
                    while (pWorksheet.Cells[lRowIndex, lColIndex].Value != null)
                    {
                        FieldArea lFieldArea = this.FieldAreas.FirstOrDefault(pField => pField.Code == pWorksheet.Cells[lRowIndex, lColIndex].Value.ToString());
                        if (lFieldArea != null)
                        {
                            lTeacher.FieldAreas.Add(lFieldArea);
                            lColIndex++;
                        }
                     }                    
                    this.Teachers.Add(lTeacher);
                    lRowIndex++;
                }
                return 1;
            }
            return 0;
        }

        protected int ReadStudents(ExcelWorksheet pWorksheet)
        {
            if (pWorksheet != null)
            {
                FieldArea lNop = this.FieldAreas.FirstOrDefault(pField => pField.Code == "NOP");
                int lRowIndex = 3;
                while (pWorksheet.Cells[lRowIndex, 1].Value != null)
                {
                    if (pWorksheet.Cells[lRowIndex, 2].Value != null)
                    {
                        Student lStudent = new Student();
                        lStudent.RoomCode = pWorksheet.Cells[lRowIndex, 1].Value.ToString();
                        lStudent.Name = pWorksheet.Cells[lRowIndex, 2].Value.ToString();

                        for (int lColIndex = 3; lColIndex < 9; lColIndex++)
                        {
                            if (pWorksheet.Cells[lRowIndex, lColIndex].Value != null)
                            {
                                FieldArea lFieldArea = this.FieldAreas.FirstOrDefault(pField => pField.Code == pWorksheet.Cells[lRowIndex, lColIndex].Value.ToString());
                                if (lFieldArea != null)
                                {
                                    lStudent.FieldAreas.Add(lFieldArea);
                                }
                            }                            
                            else
                            {
                                lStudent.FieldAreas.Add(lNop);
                            }
                        }
                        this.Students.Add(lStudent);
                    }
                    
                    lRowIndex++;
                }
                return 1;
            }
            return 0;
        }

        protected int ReadWorkDays(ExcelWorksheet pWorksheet)
        {
            if (pWorksheet != null)
            {
                int lRowIndex = 2;
                while (pWorksheet.Cells[lRowIndex, 1].Value != null)
                {
                    WorkDay lWorkDay = new WorkDay();
                    lWorkDay.Name = pWorksheet.Cells[lRowIndex, 1].Value.ToString().ToUpper();
                    lWorkDay.OpeningHours.Add(pWorksheet.Cells[lRowIndex, 2].Value.ToString());
                    this.WorkDays.Add(lWorkDay);

                    this.ReadTeacherPlanning(pWorksheet, lRowIndex, lWorkDay.Name, pWorksheet.Cells[lRowIndex, 2].Value.ToString());

                    lRowIndex++;
                    while (pWorksheet.Cells[lRowIndex, 1].Value == null && pWorksheet.Cells[lRowIndex, 2].Value != null)
                    {
                        lWorkDay.OpeningHours.Add(pWorksheet.Cells[lRowIndex, 2].Value.ToString());
                        this.ReadTeacherPlanning(pWorksheet, lRowIndex, lWorkDay.Name, pWorksheet.Cells[lRowIndex, 2].Value.ToString());
                        lRowIndex++;
                    }
                    
                }
                return 1;
            }
            return 0;
        }

        public void ReadTeacherPlanning(ExcelWorksheet pWorksheet, int pRowIndex, string pName, string pHour)
        {
            // Now, read for the teachers.
            int lColIndex = 3;
            while (pWorksheet.Cells[1, lColIndex].Value != null)
            {
                Teacher lTeacher = this.Teachers.FirstOrDefault(pTeacher => pTeacher.Name == pWorksheet.Cells[1, lColIndex].Value.ToString());
                if (lTeacher != null)
                {
                    if (pWorksheet.Cells[pRowIndex, lColIndex].Value != null)
                    {
                        lTeacher.IsPresent.Add(pName + "@" + pHour);
                    }
                    
                }
                lColIndex++;
            }
        }

        public int ReadStudentPlanning(ExcelWorksheet pWorksheet)
        {
            if (pWorksheet != null)
            {
                int lDayRowIndex = 19;
                int lRowIndex = 20;

                this.DayOfWeek = pWorksheet.Cells[19, 2].Value.ToString();
                this.Date = pWorksheet.Cells[1, 3].Value.ToString();

                string lWorkday = pWorksheet.Cells[lDayRowIndex, 2].Value.ToString();
                while (pWorksheet.Cells[lRowIndex, 1].Value != null)
                {
                    if (pWorksheet.Cells[lRowIndex, 2].Value != null)
                    {
                        Student lStudent = this.Students.FirstOrDefault(pStudent => pStudent.Name == pWorksheet.Cells[lRowIndex, 2].Value.ToString());
                        if (lStudent != null)
                        {
                            for (int lColIndex = 3; lColIndex < 10; lColIndex++)
                            {
                                if (pWorksheet.Cells[lRowIndex, lColIndex].Value != null)
                                {
                                    lStudent.IsPresent.Add(lWorkday + "@" + pWorksheet.Cells[lDayRowIndex, lColIndex].Value.ToString());
                                }
                                else
                                {
                                    lStudent.IsPresent.Add("NOP");
                                }
                            }
                            
                        }
                    }

                    lRowIndex++;
                }
                return 1;
            }
            return 0;
        }

        public List<Teacher> GetDayTeacher()
        {
            return this.Teachers.FindAll(pTeacher => pTeacher.IsPresent.FirstOrDefault(pField => pField.Contains(this.DayOfWeek)) != null);
        }

        public List<Student> GetDayStudent()
        {
            return this.Students.FindAll(pTeacher => pTeacher.IsPresent.FirstOrDefault(pField => pField.Contains(this.DayOfWeek)) != null);
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();

            lBuilder.AppendLine("************************* FIELD AREAS *************************");
            lBuilder.AppendLine(string.Join(",", this.FieldAreas));
            lBuilder.AppendLine("***************************************************************");


            lBuilder.AppendLine("*************************** TEACHERS **************************");
            lBuilder.AppendLine(string.Join(",", this.Teachers));
            lBuilder.AppendLine("***************************************************************");

            lBuilder.AppendLine("*************************** WORKDAYS **************************");
            lBuilder.AppendLine(string.Join(",", this.WorkDays));
            lBuilder.AppendLine("***************************************************************");

            lBuilder.AppendLine("*************************** STUDENTS **************************");
            lBuilder.AppendLine(string.Join(",", this.Students));
            lBuilder.AppendLine("***************************************************************");

            return lBuilder.ToString();
        }
    }
}

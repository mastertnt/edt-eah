using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAH.DataModel
{
    /**
     * This class represents a student.
     */
    public class Student
    {
        public Student()
        {
            this.FieldAreas = new List<FieldArea>();
            this.IsPresent = new List<string>();

        }

        /**
         * Gets the room code for the student.
         */
        public string RoomCode
        {
            get;
            set;
        }

        /**
         * Gets the name of the student.
         */
        public string Name
        {
            get;
            set;

        }

        /**
         * Gets all field areas for this student.
         */
        public List<FieldArea> FieldAreas
        {
            get;
            set;

        }

        /// <summary>
        /// Checks if the student is available for a slot.
        /// </summary>
        public List<string> IsPresent
        {
            get;
            set;

        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine("[" + this.Name + "]");
            lBuilder.AppendLine(string.Join("|", this.FieldAreas.Select(pItem => pItem.Code)));
            lBuilder.AppendLine(string.Join("|", this.IsPresent));
            return lBuilder.ToString();
        }
    }
}

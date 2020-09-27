using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAH.DataModel
{
    /**
     * This class describes a teacher.
     */
    public class Teacher
    {

        public Teacher()
        {
            this.FieldAreas = new List<FieldArea>();
            this.IsPresent = new List<string>();
        }

        /**
         * Gets or sets the name.
         */
        public string Name
        {
            get;
            set;
        }

        /**
         * Gets or sets the field areas.
         */
        public List<FieldArea> FieldAreas
        {
            get;
            set;
        }

        /// <summary>
        /// The planning.
        /// </summary>
        public List<string> IsPresent
        {
            get;
            set;
        }

        /// <summary>
        /// Returns all slots for a workday.
        /// </summary>
        /// <param name="pDayOfWeek"></param>
        /// <returns>All time slot for this day.</returns>
        public List<string> GetDaySlots(string pDayOfWeek)
        {
            return this.IsPresent.FindAll(pItem => pItem.Contains(pDayOfWeek));
        }

        /// <summary>
        /// Overrides ToString
        /// </summary>
        /// <returns>The string representation.</returns>
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

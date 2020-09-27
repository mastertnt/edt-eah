using System.Collections.Generic;
using System.Text;

namespace EAH.DataModel
{
    /**
     * This class describes a work day.
     */
    public class WorkDay
    {

        public WorkDay()
        {
            this.OpeningHours = new List<string>();
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
         * Gets or sets the opening hours.
         */
        public List<string> OpeningHours
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine("[" + this.Name + "]");
            lBuilder.AppendLine(string.Join(";", this.OpeningHours));
            return lBuilder.ToString();
        }
    }
}

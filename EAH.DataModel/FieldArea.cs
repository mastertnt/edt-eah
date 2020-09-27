using System.Text;

namespace EAH.DataModel
{
    public class FieldArea
    {
        /**
         * Gets or sets the code of field area.
         */
        public string Code
        {
            get;
            set;
        }

        /**
         * Gets or sets the description of field area.
         */
        public string Description
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine("[" + this.Code + " : " + this.Description + "]");
            return lBuilder.ToString();
        }
    }
}

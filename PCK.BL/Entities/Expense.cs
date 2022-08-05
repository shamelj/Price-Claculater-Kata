using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCK.BL.Entities
{
    public abstract class Expense
    {
        public string Description { get; set; }
        protected Expense(string description)
        {
            this.Description = description;
        }
    }

}

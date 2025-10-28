using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor
{
    public class Job
    {
        public string Title { get; set; }
        public DateTime Date { get; private set; }
        public float Cost { get; set; }
        public bool Completed { get; set; }
        // Easier for datatype to ref back to cont. object
        public Contractor AssignedContractor { get; set; }
        public Job() { }
        public Job(string title, DateTime date, float cost, bool completed, Contractor assigned)
        {
            // Default status should be incomplete & empty before assigning
            Completed = false;
            AssignedContractor = null;
            Date = DateTime.Now;
        }
}
}

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
        // set to private so that date when created cant be altered
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public bool Completed { get; set; }

        // Easier for datatype to ref back to the object
        public Contractors AssignedContractor { get; set; }
        public Job(string title, float cost)
        {
            // Default status should be incomplete & empty before assigning
            Completed = false;
            AssignedContractor = null;
            Date = DateTime.Now;
            Title = title;
            Cost = cost;
        }

        /// <summary>
        /// Overrides ToString() to convert object (job.job) to return value
        /// </summary>
        /// <param name="title"></param>
        /// <param name="cost"></param>
        public override string ToString() {
            return $"{Title} - {Cost}";
        }

    }
}

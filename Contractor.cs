using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor
{
    public class Contractors
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public float HourlyWage { get; set; }
        
        public Contractors(string firstName, string lastName, float hourlyWage)
        {
            FirstName = firstName;
            LastName = lastName;
            StartDate = DateTime.Now;
            HourlyWage = hourlyWage;
        }
        /// <summary>
        /// Method to set the default values for contractor
        /// </summary>
        /// <param name="FirstName">First name I want to assign to contractor</param>
        /// <param name="LastName">Ditto but last name</param>
        /// <param name="HourlyWage">Wage for the contractor in float</param>
    }


}

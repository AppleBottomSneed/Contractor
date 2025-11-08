using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor
{
    class RecruitmentSystem
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Contractors> contractors = new List<Contractors>();
        private readonly List<Job> jobs = new List<Job>();

        /// <summary>
        /// Persistent list of Contractors
        /// </summary>
        /// <returns>contractors so it doesnt refresh</returns>
        public List<Contractors> GetContractors()
        {
            return contractors;
        }
        /// <summary>
        /// Method to add contractors to object Contractors
        /// </summary>
        /// <param name="contractors">adding contractor fields to Contractors</param>
        public void AddContractors(Contractors contractors)
        {
            this.contractors.Add(contractors);
        }

        public void RemoveContractors(Contractors contractors)
        {
            this.contractors.Remove(contractors);
        }
        /// <summary>
        /// Persistent list of Job
        /// </summary>
        /// <returns>jobs so it doesnt refresh</returns>
        public List<Job> GetJobs()
        {
            return jobs;
        }

        public void AddJobs(Job jobs)
        {
            this.jobs.Add(jobs);
        }

        public void RemoveJobs(Job jobs)
        {
            this.jobs.Remove(jobs);
        }

        

        /// Things to do:
        /// #1 create GetJob to return jobs after completing contractors
        /// 
    }


}

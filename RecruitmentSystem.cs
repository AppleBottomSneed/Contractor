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

        /// <summary>
        /// contractor field AssignedJob to be job field Title 
        /// </summary>
        /// <param name="contractors">getting AssignedJob from contractors</param>
        /// <param name="job">getting Title from job</param>
        public void AssignJob(Contractors contractors, Job job)
        {
            contractors.AssignedJob = job.Title;
            job.AssignedContractor = contractors;
        }

        /// <summary>
        /// Complete_Click - sets job completed to true and unassigns from contractor assigned to same job (Contractor object + AssignedJob property)
        /// </summary>
        /// <param name="job"></param>
        public void CompleteJob(Job job)
        {
            job.Completed = true;
            job.AssignedContractor.AssignedJob = null;
            job.AssignedContractor = null;

        }

        /// <summary>
        /// Filter method to show only contractors with empty AssisgnedJob field
        /// </summary>
        /// <returns>unssigned</returns>
        public List<Contractors> GetAvailableContractors()
        {
            List<Contractors> unassigned = new List<Contractors> ();

            foreach (Contractors contractor in contractors)
            {
                if (string.IsNullOrEmpty(contractor.AssignedJob))
                {
                    unassigned.Add(contractor);
                }
            }
            return unassigned;
        }

        /// <summary>
        /// Filter method to show only jobs without AssignedContractor field
        /// </summary>
        /// <returns>unassigned</returns>
        /// 
        public List<Job> GetUnassignedJobs()
        {
            List<Job> unassigned = new List<Job> ();

            foreach (Job job in jobs)
            {
                if (job.AssignedContractor == null)
                {
                    unassigned.Add(job);
                }
            }
            return unassigned;
        }
        /// Things to do:
        /// # GetJobByCost to filter cost using slider
        /// # User validation for inputs
        /// # If theres time have job assignment available as comboBox during adding job
        /// 
        /// Bug board:
        /// # error when not selecting contractor + job for assign button
        /// # null exception error if ComboBoxItem has IsSelected="True" (where 'All' Filter is turned on by default)

    }


}

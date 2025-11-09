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

        /// <summary>
        /// Method to remove contractors from object Contractors
        /// </summary>
        /// <param name="contractors"></param>
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

        /// <summary>
        /// Method to add jobs to object Job
        /// </summary>
        /// <param name="jobs"></param>
        public void AddJobs(Job jobs)
        {
            this.jobs.Add(jobs);
        }

        /// <summary>
        /// Method to remove jobs from object Job
        /// </summary>
        /// <param name="jobs"></param>
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
        /// <returns>unssigned contractors</returns>
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
        /// <returns>unassigned jobs</returns>
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

        /// <summary>
        /// Method to filter/show only jobs less or equal maxCost (set in xaml) 
        /// </summary>
        /// <returns>list of all jobs less or equal to maxCost</returns>
        public List<Job> GetJobByCost(float maxCost)
        {
            List<Job> costFilter = new List<Job> ();
            foreach (Job job in jobs)
            {
                if (job.Cost <= maxCost)
                {
                    costFilter.Add(job);
                }
            }
            return costFilter;
        }
        
        /// Things to do:
        /// # If theres time have job assignment available as comboBox during adding job + edit button 
        /// # find better way to set max cost, right now internally set via slider
        /// # carried over unimplemented functions including: JobEditor costbox and assigneebox 
        /// Bug board:
        /// # error when not selecting contractor + job for assign button
        /// # null exception error if ComboBoxItem has IsSelected="True" (where 'All' Filter is turned on by default)
        /// # blows up (null excep.) when you select only one job/contractor and complete a completed job again
        /// # there's a lot of null exceptions, go see recordings again

    }


}

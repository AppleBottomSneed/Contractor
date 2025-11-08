using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Contractor;

namespace Contractor
{
    /// <summary>
    /// Contains logic for window interaction with front-end elements
    /// </summary>
    public partial class MainWindow : Window
    {
        // instancing recruitmentsystem
        RecruitmentSystem recruitmentSystem = new RecruitmentSystem();
        // combo box test
        List<Job> jobs = new List<Job>() { new Job("Do things", 100), new Job("Write codes", 5) };
        List<string> jobHeadings = new List<string>() { "Text one", "Text two", "Text three" };
        // avoid putting constructors in main window
        public MainWindow()
        {
            InitializeComponent();
            jobBox.ItemsSource = jobs;
            contractorlist.ItemsSource = recruitmentSystem.GetContractors();
            jobList.ItemsSource = recruitmentSystem.GetJobs();
        }
        
        /// <summary>
        /// Same as contractor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Job job = new Job(null,0);
            JobEditor editor = new JobEditor(job);
            // display jobeditor window
            editor.ShowDialog();
            jobList.ItemsSource = new Job[] { job };
            recruitmentSystem.AddJobs(job);
            jobList.ItemsSource = recruitmentSystem.GetJobs();
        }

        private void Remove_Job(object sender, RoutedEventArgs e)
        {
            Job selected = (Job)jobList.SelectedItem; 
            recruitmentSystem.RemoveJobs(selected);
            jobList.ItemsSource = recruitmentSystem.GetJobs();
            jobList.Items.Refresh();
        }

        /// <summary>
        /// Creates new contractor --> opens ContractorEditor window --> submit --> updates contractorlist
        /// #Item.Refresh just in case view doesn't load/refresh
        /// </summary>
        private void Display_Contractor(object sender, RoutedEventArgs e)
        {
            Contractors contractors = new Contractors(null, null, 0);
            ContractorEditor contractorEditor = new ContractorEditor(contractors);
            contractorEditor.ShowDialog();
            contractorlist.ItemsSource = new Contractors[] { contractors };
            recruitmentSystem.AddContractors(contractors);
            contractorlist.ItemsSource = recruitmentSystem.GetContractors();

        }

        /// <summary>
        /// Remove selected contractor
        /// </summary>
        /// <param name="sender">remove button that removes selected contractor</param>
        /// <param name="e"></param>
        private void Remove_Contractor(object sender, RoutedEventArgs e)
        {
            Contractors selected = (Contractors)contractorlist.SelectedItem;
            recruitmentSystem.RemoveContractors(selected);
            contractorlist.ItemsSource = recruitmentSystem.GetContractors();
            contractorlist.Items.Refresh();
        }

        /*
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Job job = new Job("Do things", 5);
            // job.AssignedContractor = new Contractors();
            JobEditor editor = new JobEditor(job);
            editor.Show();
        }
        */

        ///#modify later to view/filter available contractors
        private void selectedJob(object sender, SelectionChangedEventArgs e)
        {
            //Job selectedJob = jobBox.SelectedItem as Job;
            Job selectedJob = jobs [jobBox.SelectedIndex];
            if (selectedJob != null)
            {
                infoLabel.Content = selectedJob.ToString();
            }
        }

        
    }
}
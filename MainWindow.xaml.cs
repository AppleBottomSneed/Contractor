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
        // combo box test
        List<Job> jobs = new List<Job>() { new Job("Do things", 100), new Job("Write codes", 5) };
        List<string> jobHeadings = new List<string>() { "Text one", "Text two", "Text three" };
        // avoid putting constructors in main window
        public MainWindow()
        {
            InitializeComponent();
            jobBox.ItemsSource = jobs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Job job = new Job(null,0);
            JobEditor editor = new JobEditor(job);
            // display jobeditor window
            editor.ShowDialog();
            jobList.ItemsSource = new Job[] { job };
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Job job = new Job("Do things", 5);
            job.AssignedContractor = new Contractors();
            JobEditor editor = new JobEditor(job);
            editor.Show();
        }

        //modify later to view/filter available contractors
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Contractor
{
    /// <summary>
    /// Interaction logic for JobEditor.xaml
    /// </summary>
    public partial class JobEditor : Window
    {
        // setting paramater for constructor below
        public Job JobToEdit { get; set; }

        public event EventHandler JobEditComplete;

        // constructor includes job which changes job boxes
        public JobEditor(Job job)
        {
            InitializeComponent();
            JobToEdit = job;
            titleBox.Text = JobToEdit.Title;
            dateBox.SelectedDate = JobToEdit.Date;
            completeBox.IsChecked = JobToEdit.Completed;
            costBox.Text = JobToEdit.Cost.ToString();
            // give empty string if not null
            assigneeBox.Text = JobToEdit.AssignedContractor?.ToString();

        }

        // on click change JobToEdit to job boxes
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JobToEdit.Title = titleBox.Text;
            JobToEdit.Date = (DateTime)dateBox.SelectedDate;
            // typecast completeBox as (bool)
            JobToEdit.Completed = (bool)completeBox.IsChecked;
            float cost;
            if (float.TryParse(costBox.Text, out cost))
            {
                JobToEdit.Cost = cost;
            }
            
            if (JobEditComplete!= null)
            {
                JobEditComplete(this, new EventArgs());
            }
            // close window after done
            Close();
        }

        private void costBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            
        }

        private void assigneeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = e.Text;
                if (!float.TryParse(input, out _))
                {
                    e.Handled = true;
                }
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if (char.IsDigit(input[i]) || (input[i] == '.'))
                    {
                        return;
                    }
                }
                e.Handled = true;
            }
        }
    }
}

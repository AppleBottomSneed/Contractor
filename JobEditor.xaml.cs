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
        public JobEditor(Job jobs)
        {
            InitializeComponent();
            JobToEdit = jobs;
            titleBox.Text = JobToEdit.Title;
            dateBox.SelectedDate = JobToEdit.Date;
            completeBox.IsChecked = JobToEdit.Completed;
            costBox.Text = JobToEdit.Cost.ToString();
            // give empty string if not null
            assigneeBox.Text = JobToEdit.AssignedContractor?.ToString();

        }

        /// <summary>
        /// on click change JobToEdit to job boxes
        /// user validation for title (cant be empty) and cost (must have only numbers)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JobToEdit.Title = titleBox.Text;
            JobToEdit.Date = (DateTime)dateBox.SelectedDate;
            // typecast completeBox as (bool)
            JobToEdit.Completed = (bool)completeBox.IsChecked;
            float cost;

            if (string.IsNullOrWhiteSpace(titleBox.Text))
            {
                MessageBox.Show("Job title can't be empty");
                return;
            }
            // cost must have number
            if (!float.TryParse(costBox.Text, out cost))
            {
                MessageBox.Show("Cost of job must be a float number");
                return;
            }
            else
            {
                JobToEdit.Cost = cost;
            }

            if (JobEditComplete != null)
            {
                JobEditComplete(this, new EventArgs());
            }
            // close window after done
            Close();
        }

        //leftover from lecture
        private void costBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            
        }

        //leftover from lecture
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

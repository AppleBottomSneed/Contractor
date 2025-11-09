using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ContractorEditor.xaml, similar logic to JobEditor.xaml.cs
    /// </summary>
    public partial class ContractorEditor : Window
    {

        public Contractors ContractorsToEdit { get; set; }

        // instnacing event ContractorsEditComplete
        public event EventHandler ContractorsEditComplete;
        public ContractorEditor(Contractors contractors)
        {
            InitializeComponent();
            ContractorsToEdit = contractors;
            firstNameBox.Text = ContractorsToEdit.FirstName;
            lastNameBox.Text = ContractorsToEdit.LastName;
            startDateBox.SelectedDate = ContractorsToEdit.StartDate;
            hourlyWageBox.Text = ContractorsToEdit.HourlyWage.ToString();

        }

        /// <summary>
        /// after submit_button clicked set fields to user input + user validation 
        /// wage number validated, first name and last name must not be empty (string validation too complex)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Button(object sender, RoutedEventArgs e)
        {
            ContractorsToEdit.FirstName = firstNameBox.Text;
            ContractorsToEdit.LastName = lastNameBox.Text;
            ContractorsToEdit.StartDate = (DateTime)startDateBox.SelectedDate;
            float HourlyWage;

            //first name and last name must have input
            if (string.IsNullOrWhiteSpace(firstNameBox.Text))
            {
                MessageBox.Show("First name can't be empty");
                return;
            }

            if (string.IsNullOrWhiteSpace(lastNameBox.Text))
            {
                MessageBox.Show("Last name can't be empty");
                return;
            }

            // wage must have number
            if (!float.TryParse(hourlyWageBox.Text, out HourlyWage))
            {
                MessageBox.Show("Houry Wage must be a float number");
                return;
            }
            else
            {
                ContractorsToEdit.HourlyWage = HourlyWage;
            }
            
            if (ContractorsEditComplete != null)
            {
                ContractorsEditComplete(this, new EventArgs());
            }
            Close();
        }
        /// <summary>
        /// ContractorEditor enables contractor fields to fill the Contractor listbox
        /// Submit_Button takes the user input in contractor fields and overrides ContractorsToEdit object
        /// </summary>
        
    }

}

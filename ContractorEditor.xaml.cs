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

        private void Submit_Button(object sender, RoutedEventArgs e)
        {
            ContractorsToEdit.FirstName = firstNameBox.Text;
            ContractorsToEdit.LastName = lastNameBox.Text;
            ContractorsToEdit.StartDate = (DateTime)startDateBox.SelectedDate;
            float HourlyWage;
            if (float.TryParse(hourlyWageBox.Text, out HourlyWage))
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

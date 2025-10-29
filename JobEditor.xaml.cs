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
        public JobEditor()
        {
            InitializeComponent();
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

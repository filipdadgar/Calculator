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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // If I instead would want to use symbols.
        private string[] operationSymbols = new string[] { "+", "-", "*", "/", "^" };
        public MainWindow()
        {
            InitializeComponent();

            // Replace the enum with corresponding symbols from operationSymbols
            //cmb_Operations.ItemsSource = Enum.GetValues(typeof(Operation)).Cast<Operation>().Select(v => operationSymbols[(int)v]).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoMath();
        }

        // Method to get the values from textboxes and do the math
        private void DoMath()
        {
            // Make sure not more than decimals are entered in the txtValue1 and txtValue2 textboxes
            // Get the values from the textboxes

            double x, y;
            if (!double.TryParse(txt_Value1.Text, out x))
            {
                MessageBox.Show("Invalid value entered in 'Number 1' text box.");
                return;
            }
            if (!double.TryParse(txt_Value2.Text, out y))
            {
                MessageBox.Show("Invalid value entered in 'Number 2' text box.");
                return;
            }

            // Get the operation from the combobox
            Operation operation = (Operation)cmb_Operations.SelectedItem;

            // Update the combobox
            cmb_Operations.SelectedItem = operation;

            // Create a new instance of the CalcManager class
            CalcManager calcManager = new CalcManager();

            // Call the DoMath method in the CalcManager class
            double result = calcManager.DoMath(x, y, operation);

            // Display the result but with only 2 decimals
            txt_Results.Text = result.ToString("0.00");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            // Increase the value in txt_Results by 0.1 and then update txtValue1 and txtValue2 so the result is the same
            // Get the value from txt_Results
            double result = double.Parse(txt_Results.Text);

            // Increase the value by 0.1
            result -= 0.1;

            // Update txt_Results
            txt_Results.Text = result.ToString("0.00");

            // Update txtValue1 and txtValue2 based on the calculation
            // Get the operation from the combobox
            Operation operation = (Operation)cmb_Operations.SelectedItem;

            // Get the values from the textboxes
            double x = double.Parse(txt_Value1.Text);
            double y = double.Parse(txt_Value2.Text);

            // Create a new instance of the CalcManager class
            CalcManager calcManager = new CalcManager();

            // Call the DoMath method in the CalcManager class
            double result2 = calcManager.DoMath(x, y, operation);

            // Update txtValue1 and txtValue2
            txt_Value1.Text = (result - y).ToString("0.00");
            txt_Value2.Text = (result - x).ToString("0.00");
            
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            // Increase the value in txt_Results by 0.1 and then update txtValue1 and txtValue2 so the result is the same
            // Get the value from txt_Results
            double result = double.Parse(txt_Results.Text);

            // Increase the value by 0.1
            result += 0.1;

            // Update txt_Results
            txt_Results.Text = result.ToString("0.00");

            // Update txtValue1 and txtValue2 based on the calculation
            // Get the operation from the combobox
            Operation operation = (Operation)cmb_Operations.SelectedItem;

            // Get the values from the textboxes
            double x = double.Parse(txt_Value1.Text);
            double y = double.Parse(txt_Value2.Text);

            // Create a new instance of the CalcManager class
            CalcManager calcManager = new CalcManager();

            // Call the DoMath method in the CalcManager class
            double result2 = calcManager.DoMath(x, y, operation);

            // Update txtValue1 and txtValue2
            txt_Value1.Text = (result - y).ToString("0.00");
            txt_Value2.Text = (result - x).ToString("0.00");
        }
    }
}

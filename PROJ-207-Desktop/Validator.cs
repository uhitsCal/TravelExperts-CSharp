using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PROJ_207_Project_2
{
    /// <summary>
    /// a repository of static methods for validation 
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// tests if text box contains non-empty string
        /// </summary>
        /// <param name="textBox">text box to validate (with Tag property set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsPresent(TextBox textBox)
        {
            bool isValid = true;
            if(textBox.Text == "")
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " is required");
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if a textbox contains a non-negative integer value
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <returns> true if valid and false if not</returns>
        public static bool IsNonNegativeInt(TextBox textBox)
        {
            bool isValid = true;
            int result; 
            if(!Int32.TryParse(textBox.Text, out result)) // if cannot parse as int
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a whole number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if(result < 0) // an int but can be negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if a textbox contains a non-negative double value
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <returns> true if valid and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox textBox)
        {
            bool isValid = true;
            double result;
            if (!Double.TryParse(textBox.Text, out result)) // if cannot parse as int
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (result < 0) // an int but can be negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }
        /// <summary>
        /// tests if a textbox contains a non-negative Decimal value
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <returns> true if valid and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox textBox)
        {
            bool isValid = true;
            Decimal result;
            if (!Decimal.TryParse(textBox.Text, out result)) // if cannot parse as Decimal
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a Decimal number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (result < 0) // a Decimal but can be negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }
        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        /// <summary>
        /// Checks whether the user entered a decimal value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered a decimal value.</returns>
        public static bool IsDecimal(TextBox textBox)
        {

            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

    } // class
} // namespace

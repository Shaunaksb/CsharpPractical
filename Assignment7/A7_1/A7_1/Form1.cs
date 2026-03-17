using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A7_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Try to parse the text from TextBoxes into doubles
            if (double.TryParse(textBox1.Text, out double num1) &&
                double.TryParse(textBox2.Text, out double num2))
            {
                // 2. Perform the calculation
                double sum = num1 + num2;

                // 3. Display the result in the label
                label1.Text = "Result: " + sum.ToString();
            }
            else
            {
                // 4. Handle invalid input (e.g., if user types letters)
                MessageBox.Show("Please enter valid numeric values.", "Input Error");
            }
        }
    }
}

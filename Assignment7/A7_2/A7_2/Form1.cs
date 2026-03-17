using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A7_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Try to parse the input from the default-named textboxes
            if (double.TryParse(textBox1.Text, out double length) &&
                double.TryParse(textBox2.Text, out double width))
            {
                // 2. Perform the Area and Perimeter calculations
                double area = length * width;
                double perimeter = 2 * (length + width);

                // 3. Display the results in the default-named label
                label1.Text = $"Area: {area:F2}\nPerimeter: {perimeter:F2}";
            }
            else
            {
                // 4. Error handling for invalid input
                MessageBox.Show("Please enter valid numeric values for Length and Width.", "Input Error");
            }
        }
    }
}

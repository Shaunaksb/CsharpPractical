using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A7_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Get Quantity
            decimal quantity = numericUpDown1.Value;
            decimal unitPrice = 0;

            // 2. Determine Unit Price based on Selected RadioButton
            if (radioButton1.Checked) unitPrice = 125;      // Small
            else if (radioButton2.Checked) unitPrice = 175; // Medium
            else if (radioButton3.Checked) unitPrice = 250; // Large
            else
            {
                MessageBox.Show("Please select a T-Shirt size.");
                return;
            }

            // 3. Calculate Base Price
            decimal basePrice = unitPrice * quantity;

            // 4. Apply Promocode Discount (10%)
            if (textBox1.Text.Trim().ToUpper() == "TRUEBLUE")
            {
                basePrice -= basePrice * 0.10m;
            }

            // 5. Apply GST (9%)
            decimal gstAmount = basePrice * 0.09m;
            decimal finalPrice = basePrice + gstAmount;

            // 6. Display Result
            label1.Text = $"Final Price: Rs. {finalPrice:F2}";
        }
    }
}

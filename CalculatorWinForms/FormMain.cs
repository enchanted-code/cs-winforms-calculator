using System;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    public partial class FormMain : Form
    {
        private string operation = "";
        private decimal sum = 0;
        public FormMain()
        {
            InitializeComponent();
        }
        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            string number = (sender as Button).Text;
            if (outputLabel.Text == "0")
            {
                outputLabel.Text = "";
            }
            outputLabel.Text += number;
        }
        private void ButtonOperation_Click(object sender, EventArgs e)
        {
            operation = (sender as Button).Text;
            sum = decimal.Parse(outputLabel.Text);
            outputLabel.Text = "0";
        }
        private void ButtonSum_Click(object sender, EventArgs e)
        {
            try
            {
                decimal number = decimal.Parse(outputLabel.Text);
                if (outputLabel.Text != "")
                {
                    switch (operation)
                    {
                        case "+":
                            sum += number;
                            break;
                        case "-":
                            sum -= number;
                            break;
                        case "*":
                            sum *= number;
                            break;
                        case "/":
                            sum /= number;
                            break;
                        default:
                            return;
                    }
                    operation = "";
                    outputLabel.Text = sum.ToString();
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Cannot Divide By Zero!");
            }
        }
        private void ButtonPlusMinus_Click(object sender, EventArgs e)
        {
            if (outputLabel.Text.StartsWith("-"))
            {
                outputLabel.Text = outputLabel.Text[1..];
            }
            else
            {
                outputLabel.Text = "-" + outputLabel.Text;
            }
        }
        private void ButtomDecimal_Click(object sender, EventArgs e)
        {
            if (!outputLabel.Text.Contains("."))
            {
                outputLabel.Text += ".";
            }
        }
    }
}

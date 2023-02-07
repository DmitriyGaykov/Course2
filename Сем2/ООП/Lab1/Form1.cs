using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private IDictionary<string, IOperation> Operations = new Dictionary<string, IOperation>()
    {
        { "и", new AndOperation() },
        { "или", new OrOperation() },
        { "~", new NotOperation() }
    };
        public Form1()
        {
            InitializeComponent();
        }

        private void OperationClick(object sender, EventArgs e)
        {
            if (Monitor.Text == "")
            {
                Monitor.Text = "0";
            }
            else
            {
                Calculator.SetOperand1(int.Parse(Monitor.Text));
                Monitor.Text = "";

                var operation = sender as Button;
                
                var res = Calculator.SetOperation(Operations[operation.Text]);

                if (Operations[operation.Text] is IUnaryOperation)
                {
                    Monitor.Text = res.ToString();

                    Calculator.SetOperation(null);
                    Calculator.SetOperand1(null);
                    Calculator.SetOperand2(null);
                }
            }
        }

        private void OperationConvertClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (Monitor.Text != "")
            {
                Translator.Text = Convert.ToString(int.Parse(Monitor.Text), int.Parse(button.Text));
                Monitor.Text = "";
            }
        }

        private void EqualClick(object sender, EventArgs e)
        {
            if (Monitor.Text == "")
            {
                Monitor.Text = "0";
            }
            else
            {
                Calculator.SetOperand2(int.Parse(Monitor.Text));
                Monitor.Text = Calculator.Calculate().ToString();

                Calculator.SetOperation(null);
                Calculator.SetOperand1(null);
                Calculator.SetOperand2(null);
            }
        }  
    }
}

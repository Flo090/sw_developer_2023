using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taschenrechner.OperatorTypes;

namespace Taschenrechner
{
    public partial class MainForm : Form
    {
        private double _firstNumber;
        private OperatorHandler _latestSelectedOperator;
        private bool _outputShouldBeClearedOnce;
        private string _decimalSeperator;

        public MainForm()
        {
            InitializeComponent();

            // setup operator assosiation with buttons
            btn_plus.Tag = new OperatorHandler(OperatorMethods.Addition);
            btn_minus.Tag = new OperatorHandler(OperatorMethods.Subtraction);
            btn_mal.Tag = new OperatorHandler(OperatorMethods.Multiplication);
            btn_geteilt.Tag = new OperatorHandler(OperatorMethods.Division);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_ausgabe.Text = "0";

            _decimalSeperator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            btn_komma.Text = _decimalSeperator;
        }

        private void NumericButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null)
            {
                return;
            }

            if (lbl_ausgabe.Text == "0" || _outputShouldBeClearedOnce)
            {
                if (clickedButton.Text == _decimalSeperator)        // ?
                {
                    _outputShouldBeClearedOnce = false;
                }
                else
                {
                    lbl_ausgabe.Text = string.Empty;
                    _outputShouldBeClearedOnce = false;
                }
            }

            if(lbl_ausgabe.Text.Length <= 9)
            {
                if (clickedButton.Text == _decimalSeperator && lbl_ausgabe.Text.Contains(_decimalSeperator))
                {
                    return;
                }

                lbl_ausgabe.Text += clickedButton.Text;
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            var clickedOperatorButton = sender as Button;
            if (clickedOperatorButton == null)
            {
                return;
            }

            _firstNumber = double.Parse(lbl_ausgabe.Text);
            _latestSelectedOperator = clickedOperatorButton.Tag as OperatorHandler;
            _outputShouldBeClearedOnce = true;
        }

        private void btn_gleich_Click(object sender, EventArgs e)
        {
            if (_latestSelectedOperator == null)
            {
                return;
            }
            var secondNumber = double.Parse(lbl_ausgabe.Text);

            var erg = _latestSelectedOperator?.Invoke(_firstNumber, secondNumber);
            lbl_ausgabe.Text = erg.ToString();

            //_firstNumber = 0;
            _latestSelectedOperator = null;
            _outputShouldBeClearedOnce = true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            lbl_ausgabe.Text = "0";
            _latestSelectedOperator = null;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lbl_ausgabe.Text.Length > 0)
            {
                lbl_ausgabe.Text = lbl_ausgabe.Text.Substring(0, lbl_ausgabe.Text.Length - 1);
                
                if (lbl_ausgabe.Text == string.Empty)
                {
                    lbl_ausgabe.Text = "0";
                }
            }
        }
    }
}

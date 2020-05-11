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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Action_Click(object sender, RoutedEventArgs e)
        {
            switch(((Button)sender).Content.ToString())
            {
                //Clear all
                case "C":
                    tblFistNumber.Text = "";
                    tblSecondNumber.Text = "";
                    tblOperand.Text = "";
                    tblResult.Text = "";
                    break;
                //Clear second element + result
                case "CE":
                    tblResult.Text = "";
                    tblSecondNumber.Text = "";
                    break;
                //Remove last digit
                case "«":
                    if(tblOperand.Text == "")
                    {
                        tblResult.Text = "";
                        tblFistNumber.Text = removeLastDigit(tblFistNumber.Text);
                    }
                    else
                    {
                        tblResult.Text = "";
                        tblSecondNumber.Text = removeLastDigit(tblSecondNumber.Text);
                    }
                    break;
                //Solve the calculation
                case "=":
                    //solve the calculation with the right operand
                    switch(tblOperand.Text)
                    {
                        case "+":
                            tblResult.Text = (double.Parse(tblFistNumber.Text) + double.Parse(tblSecondNumber.Text)).ToString();
                            break;
                        case "-":
                            tblResult.Text = (double.Parse(tblFistNumber.Text) - double.Parse(tblSecondNumber.Text)).ToString();
                            break;
                        case "*":
                            tblResult.Text = (double.Parse(tblFistNumber.Text) * double.Parse(tblSecondNumber.Text)).ToString();
                            break;
                        case "/":
                            tblResult.Text = (double.Parse(tblFistNumber.Text) / double.Parse(tblSecondNumber.Text)).ToString();
                            break;
                        //useless code
                        default:
                            MessageBox.Show("That shouldnt happend :( I am very sorry!");
                            break;
                    }
                    break;
                //useless code
                default:
                    MessageBox.Show("Exception, that shouldn´t happend, i am sorry!");
                    break;
            }

        }

        //Add operand to calculation
        private void Operant_Click(object sender, RoutedEventArgs e)
        {
            if(tblResult.Text == "")
            {
                if (tblFistNumber.Text != "")
                {
                    tblOperand.Text = ((Button)sender).Content.ToString();
                }
                else
                {
                    MessageBox.Show("Bitte zuerst eine Zahl eingeben");
                }
            }
            //Use result as first number for new calculation
            else
            {
                tblFistNumber.Text = tblResult.Text;
                tblOperand.Text = ((Button)sender).Content.ToString();
                tblSecondNumber.Text = "";
                tblResult.Text = "";
            }


        }


        //Add number
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if(tblResult.Text=="")
            {
                if (tblOperand.Text == "")
                {
                    if (((Button)sender).Content.ToString() == ",")
                    {
                        if (isNoComma(tblFistNumber.Text.ToString()))
                        {
                            tblFistNumber.Text = tblFistNumber.Text + ((Button)sender).Content.ToString();
                        }
                    }
                    else
                    {
                        tblFistNumber.Text = tblFistNumber.Text + ((Button)sender).Content.ToString();
                    }

                }
                else
                {
                    if (((Button)sender).Content.ToString() == ",")
                    {
                        if (isNoComma(tblSecondNumber.Text.ToString()))
                        {
                            tblSecondNumber.Text = tblSecondNumber.Text + ((Button)sender).Content.ToString();
                        }
                    }
                    else
                    {
                        tblSecondNumber.Text = tblSecondNumber.Text + ((Button)sender).Content.ToString();
                    }

                }
            }
            //Clear calculation by typing new number 
            else
            {
                tblFistNumber.Text = ((Button)sender).Content.ToString();
                tblOperand.Text = "";
                tblSecondNumber.Text = "";
                tblResult.Text = "";
            }
              
        }

        //Methods and Functions

        /// <summary>
        /// This Method removes the last place from string in parameter
        /// <param name="oldString"></param>
        /// <returns></returns>
        /// </summary>
        public string removeLastDigit(string oldString)
        {
            if(oldString.Length - 1 < 0)
            {
                oldString = "";
            }
            else
            {
                oldString = oldString.Remove(oldString.Length - 1);
            }
            

            
            return oldString;
        }

        /// <summary>
        /// This Method telling you if there is an Comma in the string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool isNoComma(string value)
        {
            if(value.Contains(","))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

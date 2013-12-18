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
using System.Globalization;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double a;
        private double b;
        private Action currentAction;
        private bool screenCleared;
        private bool resultCalulated;
        public MainWindow()
        {
            InitializeComponent();
            screenCleared = false;
            resultCalulated = false;
        }

        private enum Action
        {
            NoAction, Add, Substract, Divide, Multiply, Percent, Sqrt, PlusMinus, Period, Equals, Clear 
        }

        private void buttonClickHandler(object sender, RoutedEventArgs e)
        {
            Button src = (Button)e.OriginalSource;


            switch ((string)src.Content)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                
                    if (resultCalulated)
                    {
                        resultCalulated = false;
                        lbScreen.Content = "";
                    }
                    actionSelectedCheck();
                    removeZero();
                    lbScreen.Content += (string)src.Content;
                    break;
                    case ".":
                     if (resultCalulated)
                    {
                        resultCalulated = false;
                        lbScreen.Content = "";
                    }
                    actionSelectedCheck();
                    removeZero();
                    lbScreen.Content += (string)NumberFormatInfo.CurrentInfo.NumberDecimalSeparator; 
                    
                    break;

                case "C":
                    lbScreen.Content = "0";
                            currentAction = Action.NoAction;
                            resultCalulated = false;
                            screenCleared = false;
                    break;
                case "+":
                    currentAction = Action.Add;
                    getA();
                    break;
                case "-":
                    currentAction = Action.Substract;
                    getA();
                    break;
                case "*":
                    currentAction = Action.Multiply;
                    getA();
                    break;
                case "/":
                    currentAction = Action.Divide;
                    getA();
                    break;
                case "+/-":
                    currentAction = Action.PlusMinus;
                    getA();
                    clearAfterAction(0 - Double.Parse((string)lbScreen.Content));
                    break;
                case "sqrt":
                    currentAction = Action.Sqrt;
                    getA();
                    clearAfterAction(Math.Sqrt(Double.Parse((string)lbScreen.Content)));
                    break;
                case "%":
                    currentAction = Action.Percent;
                    getA();
                   
                    break;   
                case "=":
                    b = Double.Parse((string)lbScreen.Content);
                    double result = 0;
                    switch (currentAction)
                    {
                        case Action.NoAction:
                            break;
                        case Action.Add:
                            result = a + b;
                            clearAfterAction(result);
                            break;
                        case Action.Substract:
                            result = a - b;
                            clearAfterAction(result);
                            break;
                        case Action.Multiply:
                            result = a * b;
                            clearAfterAction(result);
                            break;
                        case Action.Divide:
                            if (b != 0)
                            {
                                result = a / b;
                                clearAfterAction(result);
                            }
                            else
                            {
                                clearAfterAction(result);
                                lbScreen.Content = "Err";
                            }
                            break;
                        case Action.Percent:
                             result = a % b;
                           
                            clearAfterAction(result);
                            break;
                    }
                    break;
            }         
        }
        private void clearAfterAction(double result)
        {
            if (result.ToString() == "NaN")
                lbScreen.Content = "Err";
            else
                lbScreen.Content = result.ToString();
            currentAction = Action.NoAction;
            resultCalulated = true;
            screenCleared = false;
        }

        private void removeZero()
        {
            if ((string)lbScreen.Content == "0")
                lbScreen.Content = "";
        }

        private void actionSelectedCheck()
        {
            if (currentAction != Action.NoAction && screenCleared != true)
            {
                lbScreen.Content = "";
                screenCleared = true;
            }
        }

        private void getA()
        {
            try
            {
                a = Double.Parse((string)lbScreen.Content);
            }
            catch
            {


            }
        }
    }
}

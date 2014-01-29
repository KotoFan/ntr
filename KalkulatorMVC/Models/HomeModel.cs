using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace KalkulatorMVC.Models
{
    public class HomeModel
    {
        [Required(ErrorMessage = "a")]
        public string Test { get; set; }
        public string val;
        public string action;

        private double a;
        private double b;
        private Action currentAction;
        private bool screenCleared;
        private bool resultCalulated;
        private bool hasComa;
        public string Display;
        public HomeModel()
        {
            Display = "";
            screenCleared = false;
            resultCalulated = false;
            hasComa = false;
        }

        private enum Action
        {
            NoAction, Add, Substract, Divide, Multiply, Percent, Sqrt, PlusMinus, Period, Equals, Clear
        }


        public void process(string button)
        {



            switch (button)
            {
                case "n0":
                case "n1":
                case "n2":
                case "n3":
                case "n4":
                case "n5":
                case "n6":
                case "n7":
                case "n8":
                case "n9":

                    if (resultCalulated)
                    {
                        resultCalulated = false;
                        Display = "";
                    }
                    actionSelectedCheck();
                    removeZero();
                    Display += button.Remove(0, 1);
                    break;
                case ",":
                    if (!hasComa && Display != "" && Display != "0")
                    {
                        if (resultCalulated)
                        {
                            resultCalulated = false;
                            Display = "";
                        }
                        actionSelectedCheck();
                        removeZero();
                        Display += (string)NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                        hasComa = true;
                    }
                    break;

                case "C":
                    Display = "0";
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
                    clearAfterAction(0 - Double.Parse((string)Display));
                    break;
                case "sqrt":
                    currentAction = Action.Sqrt;
                    getA();
                    clearAfterAction(Math.Sqrt(Double.Parse((string)Display)));
                    break;
                case "%":
                    currentAction = Action.Percent;
                    getA();

                    break;
                case "=":
                    b = Double.Parse((string)Display);
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
                                Display = "Err";
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
                Display = "Err";
            else
                Display = result.ToString();
            currentAction = Action.NoAction;
            resultCalulated = true;
            screenCleared = false;
            hasComa = false;
        }

        private void removeZero()
        {
            if ((string)Display == "0")
                Display = "";
        }

        private void actionSelectedCheck()
        {
            if (currentAction != Action.NoAction && screenCleared != true)
            {
                Display = "";
                screenCleared = true;
            }
        }

        private void getA()
        {
            try
            {
                a = Double.Parse((string)Display);
            }
            catch
            {


            }
        }
    }

}
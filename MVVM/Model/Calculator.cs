using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using log4net;

namespace MVVM.Model
{
    class Calculator
    {
        private double a;
        private double b;
        private Action currentAction;
        private bool screenCleared;
        private bool resultCalulated;
        private bool hasComa;
        private readonly ILog log = LogManager.GetLogger(typeof(Calculator));
        public string Display { get; set; }

        public Calculator()
        {
            log4net.Config.XmlConfigurator.Configure();
            Display = "";
            screenCleared = false;
            resultCalulated = false;
            hasComa = false;
        }

        private enum Action
        {
            NoAction, Add, Substract, Divide, Multiply, Percent, Sqrt, PlusMinus, Period, Equals, Clear
        }


        public void Process(string value)
        {

            switch (value)
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
                        Display = "";
                    }
                    actionSelectedCheck();
                    removeZero();
                    Display += value;
                    break;
                case ".":
                    if (resultCalulated)
                    {
                        resultCalulated = false;
                        Display = "";
                    }
                    actionSelectedCheck();
                    removeZero();
                    if (!hasComa)
                    {
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
                    log.Debug(Display);
                    log.Debug("+/-");
                    Double val = 0 - Double.Parse((string)Display);
                    log.Debug(val);
                    clearAfterAction(val);

                    break;
                case "sqrt":
                    currentAction = Action.Sqrt;
                    getA();
                    log.Debug(Display);
                    log.Debug("sqrt");
                    Double val2 = Math.Sqrt(Double.Parse((string)Display));
                    log.Debug(val2);
                    clearAfterAction(val2);
                    break;
                case "%":
                    currentAction = Action.Percent;
                    getA();

                    break;
                case "=":
                    b = Double.Parse((string)Display);
                    double result = 0;
                    log.Debug(a);
                    switch (currentAction)
                    {
                        case Action.NoAction:
                            break;
                        case Action.Add:
                            result = a + b;
                            log.Debug("+");
                            clearAfterAction(result);
                            break;
                        case Action.Substract:
                            result = a - b;
                            log.Debug("-");
                            clearAfterAction(result);
                            break;
                        case Action.Multiply:
                            result = a * b;
                            log.Debug("*");
                            clearAfterAction(result);
                            break;
                        case Action.Divide:
                            if (b != 0)
                            {
                                result = a / b;
                                log.Debug("/");
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
                            log.Debug("%");
                            clearAfterAction(result);
                            break;
                    }

                    log.Debug(b);
                    log.Debug("=");
                    log.Debug(Display);
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

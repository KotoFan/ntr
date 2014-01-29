using KalkulatorMVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KalkulatorMVC.Controllers
{
    public class HomeController : Controller
    {

        private enum Action
        {
            NoAction, Add, Substract, Divide, Multiply, Percent, Sqrt, PlusMinus, Period, Equals, Clear
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            Session["test"] = "test";
            Session["currentAction"] = Action.NoAction;
            Session["screenCleared"] = false;

            var model = new HomeModel();

            model.Test = "Modelowy";
            model.val = "0";
            Session["model"] = model;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string Display, string button)
        {
            HomeModel model = (HomeModel)Session["model"];
            model.process(button);
            return View(model);
        }
        //    var model = new HomeModel();
        //    double res = double.Parse(val);
        //    switch (button)
        //    {

        //        case "n1":
        //        case "n2":
        //        case "n3":
        //        case "n4":
        //        case "n5":
        //        case "n6":
        //        case "n7":
        //        case "n8":
        //        case "n9":
        //        case "n0":
        //            if (actionSelectedCheck())
        //                val = "0";


        //            if (val == "0")
        //                val = button.Remove(0, 1);
        //            else
        //                val += button.Remove(0, 1);

        //            break;
        //        case "o,":
        //            var hasComa = Session["hasComa"];
        //            if ((bool)hasComa != true)
        //            {
        //                val += (string)NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        //                Session["hasComa"] = true;
        //            }
        //            break;
        //        case "oC":
        //            val = "0";
        //            Session["currentAction"] = Action.NoAction;
        //            Session["resultCalulated"] = false;
        //            break;
        //        case "oAdd":
        //            Session["currentAction"] = Action.Add;
        //            Session["A"] = val;
        //            break;
        //        case "oSqrt":
        //        case "oMultiply":
        //        case "oDivide":
        //            Session["currentAction"] = Action.Divide;
        //            Session["A"] = val;
        //            break;
        //        case "oEq":
        //            Action currentAction = (Action)Session["currentAction"];

        //            double a;


        //            try
        //            {
        //                var aVal = Session["A"];

        //                a = Double.Parse((string)aVal);
        //            }
        //            catch (Exception e)
        //            {
        //                a = 0;
        //            }

        //            double b = Double.Parse(val);
        //            double result = 0;

        //            switch (currentAction)
        //            {
        //                case Action.NoAction:
        //                    break;
        //                case Action.Add:
        //                    result = a + b;
        //                    clearAfterAction(result);
        //                    break;
        //                case Action.Substract:
        //                    result = a - b;
        //                    clearAfterAction(result);
        //                    break;
        //                case Action.Multiply:
        //                    result = a * b;
        //                    clearAfterAction(result);
        //                    break;
        //                case Action.Divide:
        //                    if (b != 0)
        //                    {
        //                        result = a / b;
        //                        clearAfterAction(result);
        //                    }
        //                    else
        //                    {
        //                        clearAfterAction(result);
        //                        val = "Err";
        //                    }
        //                    break;
        //                case Action.Percent:
        //                    result = a % b;

        //                    clearAfterAction(result);
        //                    break;
        //            }
        //            val = result.ToString();
        //            break;




        //    }

        //    model.val = val;
        //    model.action = "a";
        //    ModelState.Clear();
        //    return View(model);
        //}


        //private bool actionSelectedCheck()
        //{
        //    Action currentAction = (Action)Session["currentAction"];
        //    bool screenCleared = (bool)Session["screenCleared"];
        //    if (currentAction != Action.NoAction && screenCleared != true)
        //    {

        //        Session["screenCleared"] = true;
        //        return true;
        //    }
        //    return false;
        //}

        //private void clearAfterAction(double d)
        //{
        //    Session["currentAction"] = Action.NoAction;
        //    Session["resultCalulated"] = true;
        //    Session["screenCleared"] = false;
        //}
    }
}

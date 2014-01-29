using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KalkulatorMVC;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;
using System.Globalization;
namespace KalkulatorMVC.Tests
{
   

    [TestClass]
    public class UnitTest1
    {
        private Controllers.HomeController controller;
        private string Display;
        private MockHttpSession session;
        private Mock<ControllerContext> context; 

        [TestInitialize()]
        public void Initialize()
        {
            context = new Mock<ControllerContext>();
            session = new MockHttpSession();

            context.Setup(m => m.HttpContext.Session).Returns(session);
            Display = "";
            controller = new Controllers.HomeController();
            controller.ControllerContext = context.Object;
           
            controller.Index();
        }

        private void execute(string button)
        {
            controller.Index(Display, button);

        }

        [TestMethod]
        public void TestAdd()
        {
            execute("n1");
            execute("+");
            execute("n1");
            execute("=");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "2");
        }

        [TestMethod]
        public void TestMultiply()
        {
            execute("n5");
            execute("*");
            execute("n2");
            execute("=");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "10");
        }

        [TestMethod]
        public void TestPlusMinus()
        {
            execute("n5");
            execute("+/-");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "-5");
        }

        [TestMethod]
        public void TestPlusMinusMultiply()
        {
            execute("n5");
            execute("+/-");
            execute("+");
            execute("n1");
            execute("n0");
            execute("=");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "5");
        }

        [TestMethod]
        public void DivideByZero()
        {
            execute("n5");
            execute("/");
            execute("n0");

            execute("=");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "Err");
        }

        [TestMethod]
        public void TestMinus()
        {
            execute("n1");
            execute("n6");
            execute("n2");
            execute("-");
            execute("n1");
            execute("n6");
            execute("=");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "146");
        }

        [TestMethod]
        public void TestStartWithComa()
        {
            execute(",");
            execute("n6");
            execute("*");
            execute("n2");
            execute("=");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "12");
        }
        [TestMethod]
        public void TestStartWithComaFollowedByNum()
        {

            execute("n6");
            execute(",");
            execute(",");
            execute("n2");
            execute("*");
            execute("n2");
            execute("=");
            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "12" + (string)NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "4");
        }

        [TestMethod]
        public void TestMulitpleComas()
        {
            execute("n6");
            execute(",");
            execute(",");
            execute("*");
            execute("n2");
            execute("="); Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "12");
        }

        [TestMethod]
        public void TestModulo()
        {
            execute("n6");
            execute("%");
            execute("n4");
            execute("=");

            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "2");
        }

        [TestMethod]
        public void TestSqrt()
        {
            execute("n4");
            execute("sqrt");

            Models.HomeModel test = (Models.HomeModel)session["model"];
            Assert.AreEqual(test.Display, "2");
        }






        private class MockHttpSession : HttpSessionStateBase {
            Dictionary<string, object> _sessionDictionary = new Dictionary<string,object>();
            public override object this[string name]{
                get {
                    return _sessionDictionary[name];
                }
                set{
                    _sessionDictionary[name] = value;
                }
            }
        }
    }
}

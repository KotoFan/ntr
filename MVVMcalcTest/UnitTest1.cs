using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM.ViewModel;

namespace MVVMcalcTest
{
    [TestClass]
    public class CalcTest
    {
        private MainViewModel vm;

        [TestInitialize()]
        public void Initialize()
        {
            vm = new MainViewModel();
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void TestPlus()
        {
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("2");
            vm.ButtonCommand.Execute("+");
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("178", vm.Display, "162+16=178");
        }

        [TestMethod]
        public void TestMinus()
        {
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("2");
            vm.ButtonCommand.Execute("-");
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("146", vm.Display, "162-16=146");
        }

         [TestMethod]
        public void TestMultiply()
        {
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("*");
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("256", vm.Display, "16*16=256");
        }

         [TestMethod]
        public void TestDivide()
        {
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("/");
            vm.ButtonCommand.Execute("1");
            vm.ButtonCommand.Execute("6");
            vm.ButtonCommand.Execute("=");
            Assert.AreEqual("1", vm.Display, "16/16=1");
        }

         [TestMethod]
         public void TestStartWithComa()
         {
             vm.ButtonCommand.Execute(".");
             vm.ButtonCommand.Execute("6");
             vm.ButtonCommand.Execute("*");
             vm.ButtonCommand.Execute("2");
             vm.ButtonCommand.Execute("=");
             Assert.AreEqual("1.2", vm.Display, ".6*2=1.2");
         }

         [TestMethod]
         public void TestMulitpleComas()
         {
             vm.ButtonCommand.Execute("6");
             vm.ButtonCommand.Execute(".");
             vm.ButtonCommand.Execute(".");
             vm.ButtonCommand.Execute("*");
             vm.ButtonCommand.Execute("2");
             vm.ButtonCommand.Execute("=");
             Assert.AreEqual("12", vm.Display, "6..*12");
         }

         [TestMethod]
         public void TestDivideByZoro()
         {
             vm.ButtonCommand.Execute("6");
             vm.ButtonCommand.Execute("/");
             vm.ButtonCommand.Execute("0");
             vm.ButtonCommand.Execute("=");
             Assert.AreEqual("Err", vm.Display, "6/0=Err");
         }

         [TestMethod]
         public void TestPlusMinus()
         {
             vm.ButtonCommand.Execute("6");
             vm.ButtonCommand.Execute("+/-");

             Assert.AreEqual("-6", vm.Display, "6*(-1)=-6");
         }

         [TestMethod]
         public void TestNegativeSqrt()
         {
             vm.ButtonCommand.Execute("6");
             vm.ButtonCommand.Execute("+/-");
             vm.ButtonCommand.Execute("sqrt");
             Assert.AreEqual("Err", vm.Display, "-6sqrt");
         }

         [TestMethod]
         public void TestOrder()
         {
             vm.ButtonCommand.Execute("6");
             vm.ButtonCommand.Execute("*");
             vm.ButtonCommand.Execute("/");
             vm.ButtonCommand.Execute("2");
             vm.ButtonCommand.Execute("=");
             Assert.AreEqual("3", vm.Display, "6/2=3");
         }
    }
}

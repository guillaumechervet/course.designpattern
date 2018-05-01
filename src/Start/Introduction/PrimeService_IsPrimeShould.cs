using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Start.Introduction
{
    [TestCategory("Introduction")]
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            throw new NotImplementedException("Please create a test first");
        }
    }

    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        [TestMethod]
        public void ReturnTrueGivenValueOf1()
        {
            var result = new PrimeService().IsPrime(1);
            Assert.IsTrue(result, "1 should be prime");
        }

        /*[DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, true)]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(5, true)]
        [DataRow(6, false)]
        [TestMethod]
        public void ReturnResultGivenInjectedValue(int candidate, bool isPrime)
        {
            var result = new PrimeService().IsPrime(1);
            Assert.AreEqual(result, "1 should be prime");
        }*/
    }


    

}

using HouseholdEconomy.Economy;
using NUnit.Framework;
using System.Collections.Generic;

namespace HouseholdEconomyTest
{
    /// <summary>
    /// Class for testing logic of Savings class.
    /// </summary>
    [TestFixture]
    public class SavingsTest
    {
        /// <summary>
        /// Resets Percentage property between each test case.
        /// </summary>
        [TearDown]
        protected void CleanUp()
        {
            Savings.Percentage = 0;
        }

        //HE_SA_001, HE_PE_HUN_001
        [Test]
        public void Savings_ShouldBeZero_WhenGivenValueGreaterThanHundred([Values(100.01)] double percentage)
        {        
            double expected = 0;         
            Savings.Percentage = percentage;
            Assert.AreEqual(expected, Savings.Percentage);
        }

        //HE_SA_002, HE_PE_ZER_001
        [Test]
        public void Savings_ShouldBeZero_WhenGivenValueLessThanZero([Values(-1)] double percentage)
        {
            double expected = 0;
            Savings.Percentage = percentage;
            Assert.AreEqual(expected, Savings.Percentage);
        }

        //HE_SA_003, HE_PE_BET_001
        [TestCaseSource(nameof(ValidInput))]
        public void Savings_ShouldBeSet_WhenGivenValueBetweenZeroAndOneHundred(double expected, double actual)
        {
            Savings.Percentage = actual;
            Assert.AreEqual(expected, Savings.Percentage);
        }

        private static IEnumerable<TestCaseData> ValidInput()
        {
            yield return new TestCaseData(0, 0);
            yield return new TestCaseData(100, 100);
            yield return new TestCaseData(50, 50);
        }
    }
}
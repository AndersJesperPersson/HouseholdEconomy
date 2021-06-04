namespace HouseholdEconomyTest
{
    using HouseholdEconomy;
    using NUnit.Framework;
    using System;

    [TestFixture]
    internal class IncomeTest
    {
        //HE_IN_AM_SAM_002
        [Test]
        public void Cost_Value_Should_Remain_Same([Values(400, 450.50)] double cost)
        {
            var income = new Income("Test", cost);
            var expected = Math.Abs(cost);
            var actual = income.Amount;
            Assert.AreEqual(expected, actual);
        }

        //HE_IN_AM_NEG_001
        [Test]
        public void Cost_Negative_Turns_Out_Positive([Values(-900, 950.50)] double cost)
        {
            var income = new Income("Test", cost);
            var expected = Math.Abs(cost);
            var actual = income.Amount;
            Assert.AreEqual(expected, actual);
        }
    }
}
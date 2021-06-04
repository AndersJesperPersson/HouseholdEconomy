namespace HouseholdEconomyTest
{
    using HouseholdEconomy;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExpenseTest
    {
        //HE_EX_AM_SAM_002
        [Test]
        public void Amount_Value_Should_Remain_Same([Values(400, 450.50)] double cost)
        {
            var expense = new Expense("Test", cost);
            var expected = Math.Abs(cost);
            var actual = expense.Amount;
            Assert.AreEqual(expected, actual);
        }

        //HE_EX_AM_NEG_001
        [Test]
        public void Amount_Negative_Turns_Out_Positive([Values(-900, -950.50)] double cost)
        {
            var expense = new Expense("Test", cost);
            var expected = Math.Abs(cost);
            var actual = expense.Amount;
            Assert.AreEqual(expected, actual);
        }
    }
}
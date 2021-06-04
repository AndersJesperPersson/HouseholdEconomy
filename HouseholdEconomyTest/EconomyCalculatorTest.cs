namespace HouseholdEconomyTest
{
    using HouseholdEconomy;
    using HouseholdEconomy.Economy;
    using NUnit.Framework;
    using System.Collections.Generic;
     

    [TestFixture]
    internal class EconomyCalculatorTest
    {
        [SetUp]
        public void Start()
        {
            Account.Balance = 0;
            Account.Savings = 0;
        }

        [TearDown]
        public void CleanUp()
        {
            Account.Balance = 0;
            Account.Savings = 0;
        }
        // HE_EC_BAL_001
        [Test]
        public void IncomeCheck_Should_Show_BalanceAccount()
        {
            var ec = new EconomyCalculator();
            var incomes = new List<IBalance>() { new Income("salery", 10000), new Income("CSN", 1000) };
            var testList = incomes;
            var expected = 11000;
            ec.IncomeCheck(testList);
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_INC_NEG_001
        [Test]
        public void IncomeCheck_Should_CorrectNegativeValues()
        {
            var ec = new EconomyCalculator();
            var incomes = new List<IBalance>() { new Income("salery", -10000), new Income("CSN", -1000) };
            var testList = incomes;
            var expected = 11000;
            ec.IncomeCheck(testList);
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_INC_NULL_001
        [Test]
        public void IncomeCheck_Should_CorrectNull()
        {
            var ec = new EconomyCalculator();
            var incomes = new List<IBalance>() { null };
            var testList = incomes;
            var expected = 0;
            ec.IncomeCheck(testList);
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_EXP_BAL_001
        [Test]
        public void ExpanseCheck_Should_BalanceAccount()
        {
            Account.Balance = 14500;
            var ec = new EconomyCalculator();
            var expanse = new List<IBalance>() { new Expense("rent", 8900), new Expense("netflix", 89) };
            var expected = 5511;
            ec.ExpanseCheck(expanse);
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_EXP_NEG_001
        [Test]
        public void ExpanseCheck_Should_CorrectNegativeValues()
        {
            Account.Balance = 14500;
            var ec = new EconomyCalculator();
            var expanse = new List<IBalance>() { new Expense("rent", -8900), new Expense("netflix", -89) };
            var testList = expanse;
            var expected = 5511;
            ec.ExpanseCheck(testList);
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_EXP_NULL_001
        [Test]
        public void ExpanseCheck_Should_CorrectNull()
        {
            var ec = new EconomyCalculator();
            var expanse = new List<IBalance>() { null };
            var testList = expanse;
            var expected = 0;
            ec.ExpanseCheck(testList);
            var actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_CS_BAL_001
        [Test]
        public void CalculateSavings_Should_BalanceAccount()
        {
            var ec = new EconomyCalculator();
            var saving = new List<IBalance>() { new Income("CSN", 2000) };
            var expected = 200;
            Savings.Percentage = 10;
            ec.CalculateSavings(saving);
            var actual = Account.Savings;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_CS_NEG_001
        [Test]
        public void CalculateSavings_Should_CorrectNegativeValues()
        {
            var ec = new EconomyCalculator();
            var saving = new List<IBalance>() { new Income("CSN", -500), new Income("salery", -500) };
            var expected = 100;
            Savings.Percentage = 10;
            ec.CalculateSavings(saving);
            var actual = Account.Savings;
            Assert.AreEqual(expected, actual);
        }
        // HE_EC_CS_NULL_001
        [Test]
        public void CalculateSavings_Should_CorrectNull()
        {
            var ec = new EconomyCalculator();
            var saving = new List<IBalance>() { null };
            var expected = 0;
            Savings.Percentage = 10;
            ec.CalculateSavings(saving);
            var actual = Account.Savings;
            Assert.AreEqual(expected, actual);
        }
    }
}
using HouseholdEconomy;
using HouseholdEconomy.Economy;
using HouseholdEconomy.HouseholdLog;
using HouseholdEconomy.MockData;
using NUnit.Framework;
using System.Collections.Generic;

namespace HouseholdEconomyTest
{
    [TestFixture]
    internal class BudgetReportTest
    {
        [SetUp]
        public void SetUp()
        {
            Account.Savings = 0;
            Account.Balance = 0;
        }

        [TearDown]
        public void CleanUp()
        {
            Account.Savings = 0;
            Account.Balance = 0;
        }

        // HE_GB_CRE_01, HE_GB_CRE_02
        [TestCaseSource(nameof(AccountData))]
        public void GenerateBudgetReport(double balance, double savings, double expected)
        {
            Account.Savings = savings;
            Account.Balance = balance;
            EconomyCalculator ec = new EconomyCalculator();

            var mock = new EconomyMockData();
            var incomeList = mock.GetIncomes();
            var expenseList = mock.GetExpenses();

            Savings.Percentage = 10;
            ec.IncomeCheck(incomeList);
            ec.CalculateSavings(incomeList);
            ec.ExpanseCheck(expenseList);

            BudgetReport.GetLog(ec.incomeList, ec.expensesList, ec.SavingMonthly, ec.unpaidList);

            Assert.AreEqual(expected, Account.Balance);
        }

        private static IEnumerable<TestCaseData> AccountData()
        {
            yield return new TestCaseData(0, 0, 843);
            yield return new TestCaseData(2000, 2000, 1643);
        }
    }
}
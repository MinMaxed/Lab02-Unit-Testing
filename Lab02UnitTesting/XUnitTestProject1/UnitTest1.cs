using System;
using Lab02UnitTesting;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {


        [Fact]
        public void TestSeeBalance()
        {
            Assert.Equal($"You have ${Program.Balance} in your account.", Program.SeeBalance());
        }


        //testing withdraw for workable example, invalid example, and edge cases
        [Theory]
        [InlineData(500, "withdrawal complete")]
        [InlineData(500.45, "withdrawal complete")]
        [InlineData(-500, "You don't have that much in your account")]
        [InlineData(0, "You don't have that much in your account")]
        [InlineData(5000, "You don't have that much in your account")]

        public void TestWithdrawal(double value, string expectedResult)
        {
            Assert.Equal(expectedResult, Program.Withdraw(value));
        }


        //testing deposit for workable example, invalid example, and an edge case
        [Theory]
        [InlineData(500, "Funds successfully added to your account")]
        [InlineData(-500, "Does not compute")]
        [InlineData(0, "Does not compute")]
        [InlineData(500.86, "Funds successfully added to your account")]


        public void TestDeposit(double value, string expectedResult)
        {
            Assert.Equal(expectedResult, Program.Deposit(value));
        }
    }
}

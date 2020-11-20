using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {


        /// <summary>
        /// Debito deve dar 7.44
        /// </summary>
        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Lincon", beginningBalance);
            //Act
            account.Debit(debitAmount);
            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Débito não ocorreu corretamente.");
        }
        
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRanger() {
            
            //Arange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Lincon", beginningBalance);

            // Acts and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(()=>account.Debit(debitAmount));


        }
        /// <summary>
        /// Debito deve dar errado.
        /// </summary>
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange() {

            //Arange
            double beginningBalance = 11.99;
            double debitAmount = 15.00;
            BankAccount account = new BankAccount("Lincon", beginningBalance);

            // Acts and assert
            try {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");

        }

        /// <summary>
        /// Deposito de valor > 0
        /// </summary>
        [TestMethod]
        public void Credit_ComOValorDepositoValido_ComAtualizaçaoDeSaldo() {
            //Arrange
            double beginningBalance = 11.99;
            double deposit = 100;
            double expected = 111.99;
            BankAccount account = new BankAccount("Lincon", beginningBalance);
            //Act
            account.Credit(deposit);
            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Valor do Deposito válido");
        }
 

    }
}

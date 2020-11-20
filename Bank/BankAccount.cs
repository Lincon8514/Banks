using System;

namespace Bank
{
    /// <summary>
    /// Classe de Sistema de Banco
    /// </summary>
    public class BankAccount
    {
        //atributos da classe
        private readonly string m_customerName;
        private double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

      //  public const string CreditAmountExceedsBalanceMessage = "Valor do Débito inválido";
       // public const string CreditAmountLessThanZeroMessage = "Valor do débito somado";

        //metodos construtores
        public BankAccount() { }

        public BankAccount(string customerName, double balance) 
        {
            m_customerName = customerName;
            m_balance = balance;
        }


        // propriedades - Encapsulamento
        public string CustomerName 
        {
            get { return m_customerName; }
        }

        public double Balance 
        { 
        get { return m_balance; }
        }

        //metodos das classes

        public void Debit(double amount) {
            if (amount > m_balance) {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0) {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }

        public void Credit(double amount) {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException("amount");
            }
            if (amount > 0 ) {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;

        }


        public static void Main()
        {
            BankAccount ba = new BankAccount("Lincon", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balanceid ${0}", ba.Balance);

        }
    }
}

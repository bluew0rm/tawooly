
namespace Bank
{
    public class BankAccount
    {
        public int balance;

        public void lookMyBalance(bool know)
        {
            if (know)
            {
                Console.WriteLine("残高は" + balance + "です。");
            }else
            {
                Console.WriteLine("初期画面に戻ります。");
            }
            Console.WriteLine();
        }

        public void deposit(int plus)
        {
            balance += plus;
            Console.WriteLine("入金金額："+ plus + " / 残高：" + balance);
            Console.WriteLine();
        }

        public void withdraw(int minus)
        {
            balance -= minus;
            Console.WriteLine("出金金額：" + minus + " / 残高：" + balance);
            Console.WriteLine();
        }

    }
}

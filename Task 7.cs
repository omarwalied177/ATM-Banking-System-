namespace taskBank
{
    public class cardHolder
    {
        public string cardNumber;
        public int pinCode;
        public string firstName;
        public string lastName;
        public double balance;

        public cardHolder(string cardNumber, int pinCode, string firstName, string lastName, double balance)
        {
            this.cardNumber = cardNumber;
            this.pinCode = pinCode;
            this.firstName =firstName;
            this.lastName = lastName;
            this.balance = balance;
        }
    }
    internal class Program
    {
        static cardHolder? usercard;

        static void Main(string[] args)
        {
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("11111", 121212, "Ziad", "Hassan1",  20000.32));
            cardHolders.Add(new cardHolder("22222", 131313, "Ziad2", "Hassan2", 21000.32));
            cardHolders.Add(new cardHolder("33333", 141414, "Ziad1", "Hassan3", 40000.32));
            cardHolders.Add(new cardHolder("44444", 434232, "Ziad3", "Hassan4", 50000.32));
            cardHolders.Add(new cardHolder("55555", 231233, "Ziad4", "Hassan5", 10000.32));
            cardHolders.Add(new cardHolder("66666", 112222, "Ziad5", "Hassan6", 20000.32));

            Console.WriteLine(  "Welcome in ATM online bank :- ");
            Console.WriteLine(  "Please enter your card number :- ");
            while (true) 
            {
                string? userCardNumber  = Console.ReadLine();
                usercard = cardHolders.FirstOrDefault(x => x.cardNumber == userCardNumber);
                if (usercard is not null)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter correct number:- ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }
            Console.WriteLine("Please enter your Pin Code:- ");
            int pinCode = 0;
            while (true)
            {
                pinCode = int.Parse(Console.ReadLine());
                if (usercard.pinCode == pinCode)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("please enter correct pin code:- ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }
            
            while (true) 
            {
                SelectOption();
                Console.Write("Enter your choise : ");
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        {
                            Console.Write("Enter the amount that you want to deposit : ");
                            int amount = int.Parse(Console.ReadLine());
                            Deposit(amount);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter the amount that you want to Withdraw : ");
                            int amountWithdraw = int.Parse(Console.ReadLine());
                            Withdraw(amountWithdraw);
                            break;
                        }
                    case 3:
                        {
                            Balance();
                            break;
                        }
                }
                if (num > 3 || num < 1)
                {
                    break;
                }
            }
        }

        private static void Withdraw(int amountWithdraw)
        {
            while (amountWithdraw > usercard.balance)     ///////////////////////////7
            {
                if (amountWithdraw > usercard.balance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not available amount");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enter valid amount");
                    amountWithdraw = int.Parse (Console.ReadLine());
                }
                
            }
            Console.WriteLine($"Your amount was {usercard.balance}");
            Console.WriteLine($"Your withdraw {amountWithdraw}");
            usercard.balance -= amountWithdraw;
            Balance();
        }

        private static void Balance()
        {
            Console.WriteLine($"Your current balance is {usercard.balance}");
        }

        private static void Deposit(int amount)
        {
            usercard.balance += amount;
            Balance();
        }

        public static void SelectOption()
        {
            Console.WriteLine("Choose one from the following :-");
            Console.WriteLine("1- Deposit");
            Console.WriteLine("2- Withdraw");
            Console.WriteLine("3- Show Balance");
            Console.WriteLine("4- Exit");

        }
    }
}

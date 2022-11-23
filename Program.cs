using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_card_validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Credit card no: ");
            #pragma warning disable CS8604 // Possible null reference argument.
           
            //string CardnoString = Console.ReadLine();
            
            long Credit_card_no = long.Parse(Console.ReadLine());
            //Console.WriteLine(Credit_card_no.GetType());

            Console.WriteLine("Your Credit card no: " + Credit_card_no + " is " + (CreditCardValidation(Credit_card_no) ? "valid" : "invalid"));
           
        }

        public static bool CreditCardValidation(long Card_num)
        {
            if(GetSize(Card_num) is >= 13 and <= 16)
            {
                bool isvalid = ((sumOfOddindexdigit(Card_num) + sumOfDoubleEvenIndex(Card_num)) % 10 == 0);
                //Console.WriteLine(isvalid);
                return (isvalid);
            }

            return false;
        }

        public static int sumOfOddindexdigit(long card_num)
        {
            int sum = 0;
            String num = card_num + "";

            for (int i = GetSize(card_num) - 1; i >= 0; i -= 2)
            {
                sum += int.Parse(num[i] + "");
                //Console.WriteLine("sum: " + sum);
            }
            return sum;
        }

        public static int sumOfDoubleEvenIndex(long card_num)
        {
            int sum = 0;

            String num = card_num + "";

            for (int i = GetSize(card_num) - 2; i >= 0; i -= 2)
            {
                sum += GetNo(int.Parse(num[i] + "") * 2);
                //Console.WriteLine("sum: " + sum);

            }
            return sum;
        }

        public static int GetSize(long number)
        {
            string cardstring = number.ToString();
            //Console.WriteLine(cardstring.Length);
            return cardstring.Length;
        }

        public static int GetNo(int number)
        {
            if (number < 9)
            {
                return number;
            }
            return number/10 + number%10;
        }
    }
}
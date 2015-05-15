using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models.Sistem.Pomocna
{
    //Klasa za validaciju kartica
    //Koristi Luhn algoritam
    //Svaki broj kartice bilo koje banke se moze na osnovu proracuna cifara odrediti da li je validan
    //broj (moraju da implementiraju da brojevi postuju ovaj algoritam)
    //Ovo samo provjerava da li je to validan broj(tj da nije neki random broj) ali ne i da li je
    //kartica postojeca (izdata, ponistena, istekla)
    
    public static class Luhn
    {
        public static bool LuhnCheck(this string cardNumber)
        {
            return LuhnCheck(cardNumber.Select(c => c - '0').ToArray());
        }
        private static bool LuhnCheck(this int[] digits)
        {
            return GetCheckValue(digits) == 0;
        }
        private static int GetCheckValue(int[] digits)
        {
            return digits.Select((d, i) => i % 2 == digits.Length % 2 ? ((2 * d) % 10) + d / 5 : d).Sum()% 10;
        }
    }
}

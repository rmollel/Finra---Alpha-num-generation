using System;
using System.Collections.Generic;

namespace AlphaNum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The conversion of phone number to equivalent alpha num has started!");

            Dictionary<char, char[]> phoneDialKeyPad = new Dictionary<char, char[]>();
            phoneDialKeyPad.Add('1', new char[] { '1' });
            phoneDialKeyPad.Add('2', new char[] { '2','A', 'B', 'C' });
            phoneDialKeyPad.Add('3', new char[] { '3', 'D', 'E', 'F' });
            phoneDialKeyPad.Add('4', new char[] { '4', 'G', 'H', 'I' });
            phoneDialKeyPad.Add('5', new char[] { '5', 'J', 'K', 'L' });
            phoneDialKeyPad.Add('6', new char[] { '6', 'M', 'N', 'O' });
            phoneDialKeyPad.Add('7', new char[] { '7', 'P', 'Q', 'R', 'S' });
            phoneDialKeyPad.Add('8', new char[] { '8', 'T', 'U', 'V' });
            phoneDialKeyPad.Add('9', new char[] { '9', 'W', 'X', 'Y', 'Z' });
            phoneDialKeyPad.Add('0', new char[] { '0' });
           
            List<string> results = new List<string>();
            char[] originalPhoneNumber = new char[] { '2', '3', '4', '5' };
            char[] equivalentAlphaNumber = new char[originalPhoneNumber.Length];
            int startPositon = originalPhoneNumber.Length - 1;

            GetAphaNumber(originalPhoneNumber, startPositon, phoneDialKeyPad, results, equivalentAlphaNumber);

            if (results.Count == 0)
                Console.WriteLine("Could not convert to equivalent alpha num.");
            else
            {
                Console.WriteLine("Total number combination is: {0}", results.Count);
                Console.WriteLine("Conversion for phone number {0} is: ", new string(originalPhoneNumber));
                foreach (var num in results)
                    Console.WriteLine(num);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();



        }

        

        static void GetAphaNumber(char[] originalPhoneNumber, int currPosition, Dictionary<char, char[]> phoneKeyPad, List<string> results, char [] modifiedPhoneNumber)
        {


            for (int i = currPosition; i >= 0; i--)
            {
               

                var currDigit = originalPhoneNumber[i];
                var currDigitAlphNumChoices = phoneKeyPad[currDigit];

                for(int n = 0; n < currDigitAlphNumChoices.Length; n++)
                {
                    var alphaNumChoice = currDigitAlphNumChoices[n];
                    bool found = false;
                    if (alphaNumChoice == 'f')
                        found = true;

                    modifiedPhoneNumber[i] = alphaNumChoice;
                    if (i > 0)
                        GetAphaNumber(originalPhoneNumber, i - 1, phoneKeyPad, results, modifiedPhoneNumber);
                    else
                        results.Add(new string(modifiedPhoneNumber));

                    if (n + 1 == currDigitAlphNumChoices.Length)
                        return;

                }
            }

        }
    }
}

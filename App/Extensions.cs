using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
   static class Extensions

    {
        public static int SubnetMaskPrefix(this int[] values)
        {
            string num;
            int number = 0;
           foreach(var item in values)
            {
                number += item.ToString().Count(f => f == '1');
            }
            return number;
           
        }
        public static int IPAdressClassPrefix(this char value)
        {
            int prefix;
            if (value == 'A' || value == 'a')
            {
                prefix = 8;
            }
            else if (value == 'B' || value == 'b')
            {
                prefix = 12;
            }
            else if (value == 'C' || value == 'c')
            {
                prefix = 16;
            }
            else
            {
                throw new Exception("Wrong input!");
            }
            return prefix;
        }
        public static string IntToBinary(this int number)
        {
            string bin = "";
            do
            {
                bin += $"{number % 2}";
                number /= 2;

            } while (number != 0);

            return bin.Inverse();
        }
        public static int Pow(this int bas, int exp)
        {
            return Enumerable
                  .Repeat(bas, exp)
                  .Aggregate(1, (a, b) => a * b);
        }
        public static int BinaryToInt(this string value)
        {
            int result;
            if(!Int32.TryParse(value,out result))
            {
                throw new Exception("Wrong input");
            }
            int num = 0;
            int potention = 0;
            do
            {
                if (result % 10 != 0 && result % 10 != 1)
                {
                    throw new Exception("Number is not in binary!");
                }
                num += result % 10 * 2.Pow(potention);
                potention++;
                result /= 10;
            } while (result!=0);
            return num;
        }
        public static string Inverse(this string @base)=>new string (@base.Reverse().ToArray());
        
        public static int[] AdressOctets(this string value)
        {
            return value.Split('.').Select(c => Convert.ToInt32(c)).ToArray();
        }
        public static bool AdressCheck(this int[] octets)
        {
            foreach (var item in octets)
            {
                if(item<0 || item>255)
                {
                    return false;
                }
            }
            return true;
        }
        public static char IPAdressClass(this int[] value)
        {
            int FirstOctet = value[0];
            // Klasa A 
            if (FirstOctet >= 1 && FirstOctet <= 126)
                return 'A';
            // Klasa B 
            else if (FirstOctet >= 128 && FirstOctet <= 191)
                return 'B';
            // Klasa C 
            else if (FirstOctet >= 192 && FirstOctet <= 223)
                return 'C';
            // Klasa D 
            else if (FirstOctet >= 224 && FirstOctet <= 239)
                return 'D';
            // Klasa E 
            else
                return 'E';
        }
        
    }
}

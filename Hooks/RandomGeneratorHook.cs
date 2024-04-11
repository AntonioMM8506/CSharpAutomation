using TechTalk.SpecFlow;
using System.Linq;
using System;
using System.Text;
using System.Data;
using System.IO;



namespace CSharpAutomation.Hooks
{
    [Binding]
    public class RandomGeneratorHook
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";


        public int RandomIntNumber(int min, int max){
            return random.Next(min, max);
        }//End of RandomIntNumber


        public double RandomDoubleNumber(int min, int max){
            return random.NextDouble() * (max-min) + min;
        }//End of RandomDoubleNumber


        public string RandomString(int length){
            string randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }//end of RandomString


        public string RandomAlphanumericString(int length){
            string randomAlphaNumericString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomAlphaNumericString;
        }//End of RandomAlphanumericString

    }//End of class
    
}//End of RandomGeneratorHook

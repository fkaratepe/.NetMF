using System;
using Microsoft.SPOT;
using System.Text;
using System.Threading;

namespace UTF8Example
{
    public class Program
    {
        public static void Main()
        {
            string First_string = "Fatih";
            byte[] bytes_of_First_String = Encoding.UTF8.GetBytes(First_string);
            string Last_String = new string(Encoding.UTF8.GetChars(bytes_of_First_String));
            Debug.Print(Last_String);
            Thread.Sleep(-1);
        }
    }
}

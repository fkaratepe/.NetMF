using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace RTCExample
{
    public class Program
    {
        public static void Main()
        {
            DateTime mytime = new DateTime(2016, 06, 17, 10, 53, 00);
            Utility.SetLocalTime(mytime);

            while (true)
            {
                Debug.Print(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }
    }
}

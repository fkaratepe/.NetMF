using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace TimerExtendedAlarm
{
    public class Program
    {
        public static OutputPort OutLED = new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_15), false);
        public static void Main()
        {
            ExtendedTimer my_extTimer = new ExtendedTimer(new System.Threading.TimerCallback(ExtTimer_Func), null, new DateTime(2011, 06, 01, 00, 01, 00),new TimeSpan());
            while (true)
            {
                Debug.Print(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }
        public static void ExtTimer_Func(object state)
        {
            Debug.Print("Alarm");
            OutLED.Write(true);
        }
    }
}

using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace Timer_BlinkyLed
{
    public class Program
    {
        static  bool ledstate = false;
        static public OutputPort OutLED = new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_15), false);
        public static void Main()
        {
            Timer my_timer = new Timer(new TimerCallback(my_timer_func),null, 2000,1000);
            while (true)
            {
                if (ledstate==true)
                {
                    OutLED.Write(true);
                }
                else
                {
                    OutLED.Write(false);
                }
            }
        }
        private static void my_timer_func(object state)
        {
            ledstate = (!ledstate);

        }
    }
}

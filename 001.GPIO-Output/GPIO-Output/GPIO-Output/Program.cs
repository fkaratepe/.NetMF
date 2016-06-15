using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace GPIO_Output
{
    public class Program
    {
        public static void Main()
        {
         OutputPort OutLED=new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_15),false);
         while (true)
         {
             OutLED.Write(true);
             Thread.Sleep(500);
             OutLED.Write(false);
             Thread.Sleep(500);
         }

        }
    }
}

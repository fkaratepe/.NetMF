using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace InputButtonInterrupt
{
    public class Program
    {
         static OutputPort OutLed = new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_15), false);
         static InterruptPort UserButton = new InterruptPort((Cpu.Pin)(STM32.GPIO.GPIOA_0), true, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeHigh);
        
        public static void Main()
        {
            UserButton.OnInterrupt += UserButton_OnInterrupt;
            Thread.Sleep(-1);

        }

        static void UserButton_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            OutLed.Write(true);
            Thread.Sleep(500);
            OutLed.Write(false);
        }
        
    }
}

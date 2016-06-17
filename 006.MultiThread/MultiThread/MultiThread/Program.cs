using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace MultiThread
{
    public class Program
    {
      public static  OutputPort OutLEDBlue = new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_15), false);
      public static  OutputPort OutLEDRed = new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_14), false);
        public static void Main()
        {
            Thread Thread1 = new Thread(Thread1Func);
            Thread Thread2 = new Thread(Thread2Func);
            Thread1.Start();
            Thread2.Start();
            Thread.Sleep(-1);
        }
        public static void Thread1Func()
        {
            while (true)
            {
                OutLEDBlue.Write(true);
                Thread.Sleep(500);
                Debug.Print("Blue Led:ON");
                OutLEDBlue.Write(false);
                Thread.Sleep(500);
                Debug.Print("Blue Led:OFF");
            } 

        }
        public static void Thread2Func()
        {
            while (true)
            {
                OutLEDRed.Write(true);
                Thread.Sleep(1000);
                Debug.Print("Red Led:ON");
                OutLEDRed.Write(false);
                Thread.Sleep(1000);
                Debug.Print("Blue Led:OFF");
            }
        }
    }
}

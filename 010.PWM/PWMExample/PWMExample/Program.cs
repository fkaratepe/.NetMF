using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace PWMExample
{
    public class Program
    {
        static uint i = 0;
        static PWM myPWM = new PWM(Cpu.PWMChannel.PWM_0, 2500, 1250, PWM.ScaleFactor.Microseconds, false);
        static PWM myPWM2 = new PWM((Cpu.PWMChannel.PWM_1), 5000, 1200,PWM.ScaleFactor.Microseconds, false);
        public static void Main()
        {
            
            while (true)
            {
                myPWM.Start();
                myPWM2.Start();
                Thread.Sleep(-1);  
            }
        }
    }
}

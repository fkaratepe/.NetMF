using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;


namespace ADCExample
{
    public class Program
    {
        public static void Main()
        {
            AnalogInput ANIput = new AnalogInput(Cpu.AnalogChannel.ANALOG_0, 12);
            OutputPort Out = new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOA_5), false);
            OutputPort OutLED = new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_15), false);
            Out.Write(true);
            double value;
            while (true)
            {
                value = ANIput.Read()*3.3;
                Debug.Print("Read Value="+value.ToString());
                if (value>=3)
                {
                    OutLED.Write(true);
                }
                Thread.Sleep(1000);
                OutLED.Write(false);
            }
        }
    }
}

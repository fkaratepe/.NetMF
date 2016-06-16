using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace GPIO_Input
{
    public class Program
    {
        static public InputPort Button=new InputPort((Cpu.Pin)(STM32.GPIO.GPIOA_0),true,Port.ResistorMode.PullDown);
        static public OutputPort OutLed=new OutputPort((Cpu.Pin)(STM32.GPIO.GPIOD_15),false);
        public static void Main()
        {
          
            while (true)
	        {
	         if (Button.Read()==true)
	            {
		            OutLed.Write(true);
	            }
                OutLed.Write(false);
	        }
        }
    }
}

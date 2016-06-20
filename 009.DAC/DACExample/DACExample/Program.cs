using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace DACExample
{
    public class Program
    {
        public static void Main()
        {
            /*final voltage = Maximum Output  * ( (level*Scale) + Offset))*/
            AnalogOutput AnOutput = new AnalogOutput(Cpu.AnalogOutputChannel.ANALOG_OUTPUT_1);
            AnalogInput AnInput =new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            AnOutput.Scale = 1;
            AnOutput.Offset = 0.25;
            AnOutput.Write(0.5);
            double value;
            while (true)
            {
                value = AnInput.Read()*3.3;
                Debug.Print("Value=" + value.ToString());
                Thread.Sleep(1000);
            }
        }
    }
}

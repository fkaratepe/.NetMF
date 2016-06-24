using System;
using Microsoft.SPOT;
using System.Threading;
using Microsoft.SPOT.Hardware;

namespace TristateExample
{
    public class Program
    {
        public static void Main()
        {
            //Tristate Port init
            //Tristate Port set as input mode
            TristatePort tristate = new TristatePort((Cpu.Pin)(STM32.GPIO.GPIOD_15), false, false, Port.ResistorMode.PullUp);
            Debug.Print("Port is input port.");
            Thread.Sleep(1000);
            //Tristate Port set as output mode
            tristate.Active = true;
            Debug.Print("Port is output port");
            //Tristate set as high when output mode
            tristate.Write(true);
            Debug.Print("Output is high!");
            Thread.Sleep(5000);
            //Tristate set as low when output mode
            tristate.Write(false);
            Debug.Print("Output is low");
            Thread.Sleep(1000);
        }
    }
}
